using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Game_Elements
{
    public class Unit : INotifyPropertyChanged
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

        private UnitState _unitState;
        public UnitState UnitState
        {
            get => _unitState;
            set
            {
                if (_unitState != value)
                {
                    UnitStateLastChanged = DateTime.Now;

                    _unitState = value;
                    OnPropertyChanged(nameof(UnitState));
                }
            }
        }
        public DateTime UnitStateLastChanged { get; private set; } = DateTime.Now;

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged(nameof(Level));
                }
            }
        }

        private int _experience;
        public int Experience
        {
            get => _experience;
            set
            {
                if (_experience != value)
                {
                    _experience = value;
                    OnPropertyChanged(nameof(Experience));
                }
            }
        }

        private Rarity _rarity;
        public Rarity Rarity
        {
            get => _rarity;
            set
            {
                if (_rarity != value)
                {
                    _rarity = value;
                    OnPropertyChanged(nameof(Rarity));
                }
            }
        }

        private Element? _element;
        public Element? Element
        {
            get => _element;
            set
            {
                if (_element != value)
                {
                    _element = value;
                    OnPropertyChanged(nameof(Element));
                }
            }
        }

        private double _hydrationLevel;
        public double HydrationLevel
        {
            get => _hydrationLevel;
            set
            {
                if (_hydrationLevel != value)
                {
                    _hydrationLevel = value;
                    OnPropertyChanged(nameof(HydrationLevel));
                }
            }
        }

        private double _nourishmentLevel;
        public double NourishmentLevel
        {
            get => _nourishmentLevel;
            set
            {
                if (_nourishmentLevel != value)
                {
                    _nourishmentLevel = value;
                    OnPropertyChanged(nameof(NourishmentLevel));
                }
            }
        }

        private double _happinessLevel;
        public double HappinessLevel
        {
            get => _happinessLevel;
            set
            {
                if (_happinessLevel != value)
                {
                    HappinessLevelLastChanged = DateTime.Now;

                    _happinessLevel = value;
                    OnPropertyChanged(nameof(HappinessLevel));
                }
            }
        }
        public DateTime HappinessLevelLastChanged { get; private set; } = DateTime.Now;

        [JsonIgnore]
        public bool PendingDelete { get; set; } = false;

        public void Tick(int playerIndex)
        {
            // Max level can be modified by nodes in the research tree
            int modifiedMaxUnitLevel = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxUnitLevel, StarterValues.MaxUnitLevel);

            // Outer variables used later for output
            bool leveledUp = false;
            bool elementUnlocked = false;

            while (Experience >= GetExperienceNeeded() && Level <= modifiedMaxUnitLevel)
            {
                leveledUp = true;

                // Level up
                Level++;
                Experience -= GetExperienceNeeded();

                // If this unit doesn't have an element yet, try and unlock one
                if (Element != null)
                {
                    // New element odds based on unit rarity
                    double newElementOdds = Rarity switch
                    {
                        Rarity.Legendary => 8.0,
                        Rarity.Epic => 4.0,
                        Rarity.Rare => 2.0,
                        _ => 1.0
                    };

                    // Calculate if new element was unlocked
                    bool newElement = Random.Shared.NextDouble() < newElementOdds / 100;

                    if (newElement)
                    {
                        elementUnlocked = true;

                        // Assign randomized element
                        Element[] elementTypes = Enum.GetValues<Element>();
                        Element = elementTypes[Random.Shared.Next(elementTypes.Length)];
                    }
                }
            }

            // Output if this unit leveled up and if this player is the current player
            if (leveledUp && GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
            {
                if (elementUnlocked)
                    OutputService.Write(true, [new($"{Name} leveled up to {Level}! Unlocked {Element} element!", Properties.Settings.Default.PrimaryForeColor, true, false, false),]);
                else
                    OutputService.Write(true, [new($"{Name} leveled up to {Level}!", Properties.Settings.Default.PrimaryForeColor, true, false, false),]);
            }

            // Update unit state
            if (UnitState == UnitState.Cooldown && DateTime.Now - UnitStateLastChanged >= TimeSpan.FromSeconds(3))
                UnitState = UnitState.Idle;

            // Hydration and nourishment levels decrease over time
            double newHydration = HydrationLevel - 0.3;
            double newNourishment = NourishmentLevel - 0.1;

            // Drink and eat, if possible
            if (newHydration <= 75 && GameManager.Players[playerIndex].Inventory.Water > 0)
            {
                newHydration += 25;
                GameManager.Players[playerIndex].Inventory.Water -= 1;
            }
            if (newNourishment <= 75 && GameManager.Players[playerIndex].Inventory.Food > 0)
            {
                newNourishment += 25;
                GameManager.Players[playerIndex].Inventory.Food -= 1;
            }

            // Update hydration and nourishment levels once
            HydrationLevel = Math.Clamp(newHydration, 0, 100);
            NourishmentLevel = Math.Clamp(newNourishment, 0, 100);

            // Periodically update happiness levels based on hydration and nourishment levels
            if (DateTime.Now - HappinessLevelLastChanged >= TimeSpan.FromSeconds(60))
            {
                if (HydrationLevel < 25 && NourishmentLevel < 25)
                    HappinessLevel = Math.Clamp(HappinessLevel - 3, 0, 100);
                else if (HydrationLevel < 25 || NourishmentLevel < 25)
                    HappinessLevel = Math.Clamp(HappinessLevel - 1.5, 0, 100);
                else if (HydrationLevel < 50 || NourishmentLevel < 50)
                    HappinessLevel = Math.Clamp(HappinessLevel - 0.5, 0, 100);
                else
                    HappinessLevel = Math.Clamp(HappinessLevel + 0.1, 0, 100);
            }
        }

        // XP formula: base 600 scaled by 1.1^(Level - 1), plus a linear bonus of Level * 120
        public int GetExperienceNeeded() => (int)Math.Floor((600 * Math.Pow(1.1f, Level - 1) + (Level * 120)));

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}