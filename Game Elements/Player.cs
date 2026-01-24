using System.ComponentModel;

namespace Game_Elements
{
    public class Player : INotifyPropertyChanged
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public BindingList<Modifier> Modifiers { get; set; } = [];
        public Statistics Statistics { get; set; } = new();
        public Inventory Inventory { get; set; } = new(400, 75, 75, 25, 25, 5000, 5, 5, 5, 5, 5, 5, 5);
        public BindingList<Mission> Missions { get; set; } = [];
        public BindingList<Tile> Tiles { get; set; } = [];
        public ResearchTree ResearchTree { get; set; } = new();
        public BindingList<Quest> Quests { get; set; } = [];
        public BindingList<EggHatcher> EggHatchers { get; set; } = [];
        public BindingList<GardeningPlot> GardeningPlots { get; set; } = [];
        public BindingList<Achievement> Achievements { get; set; } = [];

        public DateTime LastDailyReward { get; set; } = DateTime.MinValue;

        public List<string> MissionFactoryNames { get; set; } = [];
        public List<string> UnitFactoryNames { get; set; } = [];
        public List<string> ItemFactoryNames { get; set; } = [];
        public List<string> MonsterUnitFactoryNames { get; set; } = [];
        public List<string> JunkItemFactoryNames { get; set; } = [];
        public List<string> PlantItemFactoryNames { get; set; } = [];

        private double _fishingSkill;
        public double FishingSkill
        {
            get => _fishingSkill;
            set
            {
                if (_fishingSkill != value)
                {
                    _fishingSkill = value;
                    OnPropertyChanged(nameof(FishingSkill));
                }
            }
        }

        private double _gardeningSkill;
        public double GardeningSkill
        {
            get => _gardeningSkill;
            set
            {
                if (_gardeningSkill != value)
                {
                    _gardeningSkill = value;
                    OnPropertyChanged(nameof(GardeningSkill));
                }
            }
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}