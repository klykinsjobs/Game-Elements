using System.ComponentModel;
using System.Text;

namespace Game_Elements
{
    public class Mission : INotifyPropertyChanged
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Name { get; set; }

        private MissionState _missionState;
        public MissionState MissionState
        {
            get => _missionState;
            set
            {
                if (_missionState != value)
                {
                    MissionStateLastChanged = DateTime.Now;

                    _missionState = value;
                    OnPropertyChanged(nameof(MissionState));
                }
            }
        }
        public DateTime MissionStateLastChanged { get; private set; } = DateTime.Now;

        public int Level { get; set; }
        public Rarity Rarity { get; set; }
        public List<Element>? Elements { get; set; }

        public int Experience { get; set; }
        public required Loot Loots { get; set; }

        public TimeSpan Duration { get; set; }

        private TimeSpan _elapsed = TimeSpan.Zero;
        public TimeSpan Elapsed
        {
            get => _elapsed;
            set
            {
                if (_elapsed != value)
                {
                    _elapsed = value;
                    OnPropertyChanged(nameof(Elapsed));
                }
            }
        }
        public bool IsDone => Elapsed >= Duration;

        public DateTime Expiration { get; set; }

        public List<Guid>? AssignedUnitGuids { get; set; }

        public void Tick(int playerIndex, TimeSpan timeSpan)
        {
            if (MissionState != MissionState.InProgress)
                return;

            Elapsed += timeSpan;

            if (IsDone)
            {
                // Calculate if mission was successful
                bool success = Random.Shared.Next(101) <= GetSuccessChance(playerIndex, AssignedUnitGuids);

                if (AssignedUnitGuids != null)
                {
                    // Update state and add XP for each assigned unit
                    foreach (var guid in AssignedUnitGuids)
                    {
                        var unit = GameManager.Players[playerIndex].Inventory.Units.FirstOrDefault(u => u.Id == guid);
                        if (unit != null)
                        {
                            unit.UnitState = UnitState.Cooldown;
                            unit.Experience += success ? Experience : Experience / 8;   // partial XP for fail
                        }
                    }
                }

                StringBuilder stringBuilder = new(success ? $"+{Experience} XP" : $"+{Experience / 8} XP");

                if (success)
                {
                    // Update mission state
                    MissionState = MissionState.Success;

                    // Output if current player
                    if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                    {
                        OutputService.Write(true,
                            [
                            new("Mission Succeeded: ", Properties.Settings.Default.SuccessTextColor),
                            new($"{Name} ({Level} | {Rarity} | {stringBuilder})", Properties.Settings.Default.PrimaryForeColor)
                            ]);
                    }

                    // Add loot
                    if (Loots != null)
                        Inventory.Add(playerIndex, Loots);

                    // Update quests and statistics
                    GameManager.TryQuestProgress(playerIndex, QuestType.SucceedMission, 1);
                    GameManager.Players[playerIndex].Statistics.MissionsSucceeded++;
                }
                else
                {
                    // Update mission state
                    MissionState = MissionState.Fail;

                    // Output if current player
                    if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                    {
                        OutputService.Write(true,
                            [
                            new("Mission Failed: ", Properties.Settings.Default.FailureTextColor),
                            new($"{Name} ({Level} | {Rarity} | {stringBuilder})", Properties.Settings.Default.PrimaryForeColor)
                            ]);
                    }

                    // Update quests and statistics
                    GameManager.TryQuestProgress(playerIndex, QuestType.FailMission, 1);
                    GameManager.Players[playerIndex].Statistics.MissionsFailed++;
                }
            }
        }

        public double GetSuccessChance(int playerIndex, List<Guid>? guids)
        {
            // Start with zero chance
            double successChance = 0.0;

            // Return early if no units were provided
            if (guids == null)
                return successChance;

            // Track which elements are covered by the provided units (used later for penalties)
            var coveredElements = new HashSet<Element?>();

            foreach (var guid in guids)
            {
                // Try and find the unit in the player's inventory with matching GUID
                var unit = GameManager.Players[playerIndex].Inventory.Units.FirstOrDefault(u => u.Id == guid);
                if (unit == null)
                    continue;

                // If the unit has an element, add the element to covered
                if (unit.Element != null)
                    coveredElements.Add(unit.Element);

                // Base percent can be modified by nodes in the research tree
                double basePercent = GameManager.ApplyModifiers(playerIndex, ModifierTarget.UnitSuccessChance, StarterValues.UnitSuccessChance);

                // Level difference between this unit's level and the mission's level
                int levelDiff = unit.Level - Level;

                // Each level difference adds/subtracts 2.5 percentage points
                basePercent += (levelDiff * 2.5);

                // Add a flat bonus based on unit rarity
                double rarityBonus = unit.Rarity switch
                {
                    Rarity.Legendary => 10.0,
                    Rarity.Epic => 5.0,
                    Rarity.Rare => 2.5,
                    _ => 0.0
                };

                // Accumulate this unit's contribution to the overall success chance
                successChance += basePercent + rarityBonus;
            }

            // Count how many required elements aren't covered
            int missingElements = 0;
            if (Elements != null)
                foreach (var element in Elements)
                    if (!coveredElements.Contains(element))
                        missingElements++;

            // Apply a penalty per missing element to the overall success chance
            double elementsPenalty = missingElements * 5.0;
            successChance -= elementsPenalty;

            // Ensure the returned chance is within a sensible range
            return Math.Clamp(successChance, 0.0, 100.0);
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}