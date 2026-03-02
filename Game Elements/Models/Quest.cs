using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Services;
using System.ComponentModel;

namespace Game_Elements.Models
{
    public class Quest : INotifyPropertyChanged
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public QuestType QuestType { get; set; }
        public Rarity Rarity { get; set; }

        public required Loot Loots { get; set; }

        public int Target { get; set; }

        private int _progress = 0;
        public int Progress
        {
            get => _progress;
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    OnPropertyChanged(nameof(Progress));
                }
            }
        }
        public bool IsDone => Progress >= Target;

        private bool _completed = false;
        public bool Completed
        {
            get => _completed;
            set
            {
                if (_completed != value)
                {
                    CompletedOrDismissedAt = DateTime.Now;

                    _completed = value;
                    OnPropertyChanged(nameof(Completed));
                }
            }
        }

        private bool _dismissed = false;
        public bool Dismissed
        {
            get => _dismissed;
            set
            {
                if (_dismissed != value)
                {
                    CompletedOrDismissedAt = DateTime.Now;

                    _dismissed = value;
                    OnPropertyChanged(nameof(Dismissed));
                }
            }
        }

        public DateTime CompletedOrDismissedAt { get; private set; }

        public void Tick(int playerIndex)
        {
            if (Completed || Dismissed) return;

            if (IsDone)
            {
                Completed = true;

                // Output if current player
                if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                {
                    // singular/plural
                    string questType = QuestType switch
                    {
                        QuestType.StartMission => Target > 1 ? "Start Missions" : "Start Mission",
                        QuestType.SucceedMission => Target > 1 ? "Succeed Missions" : "Succeed Mission",
                        QuestType.FailMission => Target > 1 ? "Fail Missions" : "Fail Mission",
                        QuestType.LevelUpUnit => Target > 1 ? "Level Up Units" : "Level Up Unit",
                        QuestType.OpenLootbox => Target > 1 ? "Open Lootboxes" : "Open Lootbox",
                        QuestType.UseRushBoost => Target > 1 ? "Use Rush Boosts" : "Use Rush Boost",
                        QuestType.UseExperienceBoost => Target > 1 ? "Use Experience Boosts" : "Use Experience Boost",
                        QuestType.UseRarityBoost => Target > 1 ? "Use Rarity Boosts" : "Use Rarity Boost",
                        QuestType.SellItem => Target > 1 ? "Sell Items" : "Sell Item",
                        QuestType.BuyItem => Target > 1 ? "Buy Items" : "Buy Item",
                        QuestType.UnlockAchievement => Target > 1 ? "Unlock Achievements" : "Unlock Achievement",
                        QuestType.CompleteQuest => Target > 1 ? "Complete Quests" : "Complete Quest",
                        QuestType.DismissQuest => Target > 1 ? "Dismiss Quests" : "Dismiss Quest",
                        QuestType.CaughtFish => "Caught Fish",
                        QuestType.HarvestPlant => Target > 1 ? "Harvest Plants" : "Harvest Plant",
                        QuestType.HatchEgg => Target > 1 ? "Hatch Eggs" : "Hatch Egg",
                        QuestType.TerraformTile => Target > 1 ? "Terraform Tiles" : "Terraform Tile",
                        QuestType.ConstructBuilding => Target > 1 ? "Construct Buildings" : "Construct Building",
                        QuestType.ResearchNode => Target > 1 ? "Research Nodes" : "Research Node",
                        QuestType.CollectResearch => "Collect Research",
                        QuestType.CollectPower => "Collect Power",
                        QuestType.CollectWater => "Collect Water",
                        QuestType.CollectFood => "Collect Food",
                        QuestType.CollectConcrete => "Collect Concrete",
                        QuestType.CollectMetal => "Collect Metal",
                        QuestType.CollectItem => Target > 1 ? "Collect Items" : "Collect Item",
                        QuestType.CollectUnit => Target > 1 ? "Collect Units" : "Collect Unit",
                        QuestType.CollectGold => "Collect Gold",
                        QuestType.CollectLootbox => Target > 1 ? "Collect Lootboxes" : "Collect Lootbox",
                        QuestType.CollectRushBoost => Target > 1 ? "Collect Rush Boosts" : "Collect Rush Boost",
                        QuestType.CollectExperienceBoost => Target > 1 ? "Collect Experience Boosts" : "Collect Experience Boost",
                        QuestType.CollectRarityBoost => Target > 1 ? "Collect Rarity Boosts" : "Collect Rarity Boost",
                        QuestType.CollectMonsterEgg => Target > 1 ? "Collect Monster Eggs" : "Collect Monster Egg",
                        QuestType.CollectFertilizer => "Collect Fertilizer",
                        QuestType.CollectMysterySeed => Target > 1 ? "Collect Mystery Seeds" : "Collect Mystery Seed",
                        _ => "Unknown Quest"
                    };

                    OutputService.Write(true,
                        [
                            new("Quest completed: ", Properties.Settings.Default.SuccessTextColor),
                            new($"{questType} ({Progress}/{Target})", Properties.Settings.Default.PrimaryForeColor)
                        ]);
                }

                // Add loot
                if (Loots != null)
                    Inventory.Add(playerIndex, Loots);

                // Update quests and statistics
                GameManager.TryQuestProgress(playerIndex, QuestType.CompleteQuest, 1);
                GameManager.Players[playerIndex].Statistics.QuestsCompleted += 1;
            }
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}