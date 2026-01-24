using System.ComponentModel;

namespace Game_Elements
{
    public class Statistics : INotifyPropertyChanged
    {
        private int _missionsStarted;
        public int MissionsStarted
        {
            get => _missionsStarted;
            set
            {
                if (_missionsStarted != value)
                {
                    _missionsStarted = value;
                    OnPropertyChanged(nameof(MissionsStarted));
                }
            }
        }

        private int _missionsSucceeded;
        public int MissionsSucceeded
        {
            get => _missionsSucceeded;
            set
            {
                if (_missionsSucceeded != value)
                {
                    _missionsSucceeded = value;
                    OnPropertyChanged(nameof(MissionsSucceeded));
                }
            }
        }

        private int _missionsFailed;
        public int MissionsFailed
        {
            get => _missionsFailed;
            set
            {
                if (_missionsFailed != value)
                {
                    _missionsFailed = value;
                    OnPropertyChanged(nameof(MissionsFailed));
                }
            }
        }

        private int _lootboxesOpened;
        public int LootboxesOpened
        {
            get => _lootboxesOpened;
            set
            {
                if (_lootboxesOpened != value)
                {
                    _lootboxesOpened = value;
                    OnPropertyChanged(nameof(LootboxesOpened));
                }
            }
        }

        private int _rushBoostsUsed;
        public int RushBoostsUsed
        {
            get => _rushBoostsUsed;
            set
            {
                if (_rushBoostsUsed != value)
                {
                    _rushBoostsUsed = value;
                    OnPropertyChanged(nameof(RushBoostsUsed));
                }
            }
        }

        private int _experienceBoostsUsed;
        public int ExperienceBoostsUsed
        {
            get => _experienceBoostsUsed;
            set
            {
                if (_experienceBoostsUsed != value)
                {
                    _experienceBoostsUsed = value;
                    OnPropertyChanged(nameof(ExperienceBoostsUsed));
                }
            }
        }

        private int _rarityBoostsUsed;
        public int RarityBoostsUsed
        {
            get => _rarityBoostsUsed;
            set
            {
                if (_rarityBoostsUsed != value)
                {
                    _rarityBoostsUsed = value;
                    OnPropertyChanged(nameof(RarityBoostsUsed));
                }
            }
        }

        private int _itemsSold;
        public int ItemsSold
        {
            get => _itemsSold;
            set
            {
                if (_itemsSold != value)
                {
                    _itemsSold = value;
                    OnPropertyChanged(nameof(ItemsSold));
                }
            }
        }

        private int _itemsBought;
        public int ItemsBought
        {
            get => _itemsBought;
            set
            {
                if (_itemsBought != value)
                {
                    _itemsBought = value;
                    OnPropertyChanged(nameof(ItemsBought));
                }
            }
        }

        private int _achievementsUnlocked;
        public int AchievementsUnlocked
        {
            get => _achievementsUnlocked;
            set
            {
                if (_achievementsUnlocked != value)
                {
                    _achievementsUnlocked = value;
                    OnPropertyChanged(nameof(AchievementsUnlocked));
                }
            }
        }

        private int _questsCompleted;
        public int QuestsCompleted
        {
            get => _questsCompleted;
            set
            {
                if (_questsCompleted != value)
                {
                    _questsCompleted = value;
                    OnPropertyChanged(nameof(QuestsCompleted));
                }
            }
        }

        private int _questsDismissed;
        public int QuestsDismissed
        {
            get => _questsDismissed;
            set
            {
                if (_questsDismissed != value)
                {
                    _questsDismissed = value;
                    OnPropertyChanged(nameof(QuestsDismissed));
                }
            }
        }

        private int _fishCaught;
        public int FishCaught
        {
            get => _fishCaught;
            set
            {
                if (_fishCaught != value)
                {
                    _fishCaught = value;
                    OnPropertyChanged(nameof(FishCaught));
                }
            }
        }

        private int _plantsHarvested;
        public int PlantsHarvested
        {
            get => _plantsHarvested;
            set
            {
                if (_plantsHarvested != value)
                {
                    _plantsHarvested = value;
                    OnPropertyChanged(nameof(PlantsHarvested));
                }
            }
        }

        private int _eggsHatched;
        public int EggsHatched
        {
            get => _eggsHatched;
            set
            {
                if (_eggsHatched != value)
                {
                    _eggsHatched = value;
                    OnPropertyChanged(nameof(EggsHatched));
                }
            }
        }

        private int _tilesTerraformed;
        public int TilesTerraformed
        {
            get => _tilesTerraformed;
            set
            {
                if (_tilesTerraformed != value)
                {
                    _tilesTerraformed = value;
                    OnPropertyChanged(nameof(TilesTerraformed));
                }
            }
        }

        private int _buildingsConstructed;
        public int BuildingsConstructed
        {
            get => _buildingsConstructed;
            set
            {
                if (_buildingsConstructed != value)
                {
                    _buildingsConstructed = value;
                    OnPropertyChanged(nameof(BuildingsConstructed));
                }
            }
        }

        private int _nodesResearched;
        public int NodesResearched
        {
            get => _nodesResearched;
            set
            {
                if (_nodesResearched != value)
                {
                    _nodesResearched = value;
                    OnPropertyChanged(nameof(NodesResearched));
                }
            }
        }

        private int _researchCollected;
        public int ResearchCollected
        {
            get => _researchCollected;
            set
            {
                if (_researchCollected != value)
                {
                    _researchCollected = value;
                    OnPropertyChanged(nameof(ResearchCollected));
                }
            }
        }

        private int _powerCollected;
        public int PowerCollected
        {
            get => _powerCollected;
            set
            {
                if (_powerCollected != value)
                {
                    _powerCollected = value;
                    OnPropertyChanged(nameof(PowerCollected));
                }
            }
        }

        private int _waterCollected;
        public int WaterCollected
        {
            get => _waterCollected;
            set
            {
                if (_waterCollected != value)
                {
                    _waterCollected = value;
                    OnPropertyChanged(nameof(WaterCollected));
                }
            }
        }

        private int _foodCollected;
        public int FoodCollected
        {
            get => _foodCollected;
            set
            {
                if (_foodCollected != value)
                {
                    _foodCollected = value;
                    OnPropertyChanged(nameof(FoodCollected));
                }
            }
        }

        private int _concreteCollected;
        public int ConcreteCollected
        {
            get => _concreteCollected;
            set
            {
                if (_concreteCollected != value)
                {
                    _concreteCollected = value;
                    OnPropertyChanged(nameof(ConcreteCollected));
                }
            }
        }

        private int _metalCollected;
        public int MetalCollected
        {
            get => _metalCollected;
            set
            {
                if (_metalCollected != value)
                {
                    _metalCollected = value;
                    OnPropertyChanged(nameof(MetalCollected));
                }
            }
        }

        private int _itemsCollected;
        public int ItemsCollected
        {
            get => _itemsCollected;
            set
            {
                if (_itemsCollected != value)
                {
                    _itemsCollected = value;
                    OnPropertyChanged(nameof(ItemsCollected));
                }
            }
        }

        private int _unitsCollected;
        public int UnitsCollected
        {
            get => _unitsCollected;
            set
            {
                if (_unitsCollected != value)
                {
                    _unitsCollected = value;
                    OnPropertyChanged(nameof(UnitsCollected));
                }
            }
        }

        private int _goldCollected;
        public int GoldCollected
        {
            get => _goldCollected;
            set
            {
                if (_goldCollected != value)
                {
                    _goldCollected = value;
                    OnPropertyChanged(nameof(GoldCollected));
                }
            }
        }

        private int _lootboxesCollected;
        public int LootboxesCollected
        {
            get => _lootboxesCollected;
            set
            {
                if (_lootboxesCollected != value)
                {
                    _lootboxesCollected = value;
                    OnPropertyChanged(nameof(LootboxesCollected));
                }
            }
        }

        private int _rushBoostsCollected;
        public int RushBoostsCollected
        {
            get => _rushBoostsCollected;
            set
            {
                if (_rushBoostsCollected != value)
                {
                    _rushBoostsCollected = value;
                    OnPropertyChanged(nameof(RushBoostsCollected));
                }
            }
        }

        private int _experienceBoostsCollected;
        public int ExperienceBoostsCollected
        {
            get => _experienceBoostsCollected;
            set
            {
                if (_experienceBoostsCollected != value)
                {
                    _experienceBoostsCollected = value;
                    OnPropertyChanged(nameof(ExperienceBoostsCollected));
                }
            }
        }

        private int _rarityBoostsCollected;
        public int RarityBoostsCollected
        {
            get => _rarityBoostsCollected;
            set
            {
                if (_rarityBoostsCollected != value)
                {
                    _rarityBoostsCollected = value;
                    OnPropertyChanged(nameof(RarityBoostsCollected));
                }
            }
        }

        private int _monsterEggsCollected;
        public int MonsterEggsCollected
        {
            get => _monsterEggsCollected;
            set
            {
                if (_monsterEggsCollected != value)
                {
                    _monsterEggsCollected = value;
                    OnPropertyChanged(nameof(MonsterEggsCollected));
                }
            }
        }

        private int _fertilizerCollected;
        public int FertilizerCollected
        {
            get => _fertilizerCollected;
            set
            {
                if (_fertilizerCollected != value)
                {
                    _fertilizerCollected = value;
                    OnPropertyChanged(nameof(FertilizerCollected));
                }
            }
        }

        private int _mysterySeedsCollected;
        public int MysterySeedsCollected
        {
            get => _mysterySeedsCollected;
            set
            {
                if (_mysterySeedsCollected != value)
                {
                    _mysterySeedsCollected = value;
                    OnPropertyChanged(nameof(MysterySeedsCollected));
                }
            }
        }

        public Dictionary<string, double> FishRecords { get; set; } = [];

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}