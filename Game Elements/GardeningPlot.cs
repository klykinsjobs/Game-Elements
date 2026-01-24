using System.ComponentModel;

namespace Game_Elements
{
    public class GardeningPlot : INotifyPropertyChanged
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        private bool _tilled = false;
        public bool Tilled
        {
            get => _tilled;
            set
            {
                if (_tilled != value)
                {
                    _tilled = value;
                    OnPropertyChanged(nameof(Tilled));
                }
            }
        }

        private bool _planted = false;
        public bool Planted
        {
            get => _planted;
            set
            {
                if (_planted != value)
                {
                    _planted = value;
                    OnPropertyChanged(nameof(Planted));
                }
            }
        }

        private bool _fertilized = false;
        public bool Fertilized
        {
            get => _fertilized;
            set
            {
                if (_fertilized != value)
                {
                    _fertilized = value;
                    OnPropertyChanged(nameof(Fertilized));
                }
            }
        }

        private bool _watered = false;
        public bool Watered
        {
            get => _watered;
            set
            {
                if (_watered != value)
                {
                    _watered = value;
                    OnPropertyChanged(nameof(Watered));
                }
            }
        }

        private bool _readyForHarvest = false;
        public bool ReadyForHarvest
        {
            get => _readyForHarvest;
            set
            {
                if (_readyForHarvest != value)
                {
                    _readyForHarvest = value;
                    OnPropertyChanged(nameof(ReadyForHarvest));
                }
            }
        }

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

        public void Harvest(int playerIndex)
        {
            if (ReadyForHarvest)
            {
                double gardeningSkill = Math.Max(0.0, Math.Min(100.0, GameManager.Players[playerIndex].GardeningSkill));

                // Calculate change of gardening plot needing to be tilled again. Odds decrease as skill level increases.
                double tillProbability = 0.25 * (1.0 - (gardeningSkill / 100.0));
                if (Random.Shared.NextDouble() < tillProbability)
                    Tilled = false;

                // Update relevant properties so plot is ready for reuse
                Planted = false;
                Fertilized = false;
                Watered = false;
                ReadyForHarvest = false;
                Elapsed = TimeSpan.Zero;

                // Fill loot
                Loot lootToAdd = new()
                {
                    Items = [ItemFactory.GenerateRandomPlantItem(playerIndex)]
                };

                // Calculate change of a bonus mystery seed being awarded too. Odds increase as skill level increases.
                double seedProbability = 0.25 * (gardeningSkill / 100.0);
                if (Random.Shared.NextDouble() < seedProbability)
                    lootToAdd.LootQuantities.Add(LootType.MysterySeed, 1);

                // Add loot
                Inventory.Add(playerIndex, lootToAdd);

                // Update quests and statistics
                GameManager.TryQuestProgress(playerIndex, QuestType.HarvestPlant, 1);
                GameManager.Players[playerIndex].Statistics.PlantsHarvested += 1;
            }
        }

        public void Tick(int playerIndex, TimeSpan timeSpan)
        {
            if (!Tilled || !Planted || ReadyForHarvest) return;

            Elapsed += timeSpan;

            if (IsDone)
            {
                // Update relevant property so player can harvest this gardening plot
                ReadyForHarvest = true;

                // Output if current player
                if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                {
                    OutputService.Write(true, [new("A gardening plot is ready for harvest...", Properties.Settings.Default.PrimaryForeColor)]);
                }
            }
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}