using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Game_Elements
{
    public class Tile : INotifyPropertyChanged
    {
        public int X { get; set; }
        public int Y { get; set; }

        private TileState _tileState;
        public TileState TileState
        {
            get => _tileState;
            set
            {
                if (_tileState != value)
                {
                    _tileState = value;
                    OnPropertyChanged(nameof(TileState));
                }
            }
        }

        private TerrainType _terrain;
        public TerrainType Terrain
        {
            get => _terrain;
            set
            {
                if (_terrain != value)
                {
                    _terrain = value;
                    OnPropertyChanged(nameof(Terrain));
                }
            }
        }

        public TerrainType? PendingTerrainType { get; set; }

        private BuildingType? _building;
        public BuildingType? Building
        {
            get => _building;
            set
            {
                if (_building != value)
                {
                    _building = value;
                    OnPropertyChanged(nameof(Building));
                }
            }
        }

        public BuildingType? PendingBuildingType { get; set; }

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

        public string? CustomBuildingName { get; set; } = null;

        [JsonIgnore]
        public Color? CustomBuildingColor { get; set; } = null;

        // HTML string surrogate (for serialization/deserialization)
        public string? CustomBuildingColorHtml
        {
            get => CustomBuildingColor != null ? ColorTranslator.ToHtml((Color)CustomBuildingColor) : null;
            set => CustomBuildingColor = string.IsNullOrEmpty(value) ? null : ColorTranslator.FromHtml(value);
        }

        public void Tick(int playerIndex, TimeSpan timeSpan, ref int availablePower, ref Loot buildingProduction)
        {
            if (TileState == TileState.Idle) return;

            // Certain building types consume power in order to gain progress
            if (Building != null && (Building == BuildingType.WaterMaker || Building == BuildingType.FoodMaker
                || Building == BuildingType.ConcreteMaker || Building == BuildingType.MetalMaker
                || Building == BuildingType.ResearchMaker || Building == BuildingType.ItemMaker
                || Building == BuildingType.UnitMaker || Building == BuildingType.GoldMaker || Building == BuildingType.LootboxMaker
                || Building == BuildingType.RushBoostMaker || Building == BuildingType.ExperienceBoostMaker
                || Building == BuildingType.RarityBoostMaker || Building == BuildingType.MonsterEggMaker
                || Building == BuildingType.FertilizerMaker || Building == BuildingType.MysterySeedMaker))
            {
                if (availablePower > 0)
                {
                    availablePower -= 1;
                    Elapsed += timeSpan;
                }
            }
            else
            {
                Elapsed += timeSpan;
            }

            if (IsDone)
            {
                switch (TileState)
                {
                    case TileState.Terraforming:
                        if (PendingTerrainType == null) return;

                        // Update tile properties post-terraforming
                        Terrain = (TerrainType)PendingTerrainType;
                        PendingTerrainType = null;
                        Elapsed = TimeSpan.Zero;

                        TileState = TileState.Idle;

                        // Output if current player
                        if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                        {
                            OutputService.Write(true, [new($"Terraforming complete: {Terrain}", Properties.Settings.Default.PrimaryForeColor)]);
                        }

                        // Update quests and statistics
                        GameManager.TryQuestProgress(playerIndex, QuestType.TerraformTile, 1);
                        GameManager.Players[playerIndex].Statistics.TilesTerraformed += 1;

                        break;

                    case TileState.Constructing:
                        if (PendingBuildingType == null) return;

                        // Update tile properties post-construction
                        Building = (BuildingType)PendingBuildingType;
                        PendingBuildingType = null;
                        Elapsed = TimeSpan.Zero;

                        // Look up the appropriate values for this tile based on the building type
                        var (_, postConstructionState, productionDuration, _, _, _, modifier) = TileFactory.BuildingLookups()[(BuildingType)Building];

                        TileState = postConstructionState;

                        if (productionDuration != null)
                            Duration = TimeSpan.FromMilliseconds((long)productionDuration);

                        if (modifier != null)
                            GameManager.AddModifier(playerIndex, modifier);

                        // Output if current player
                        if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                        {
                            string buildingType = Building switch
                            {
                                BuildingType.CityCenter => "City Center",
                                BuildingType.Dwelling => "Dwelling",
                                BuildingType.Storage => "Storage",
                                BuildingType.ResearchMaker => "Research Maker",
                                BuildingType.PowerMaker => "Power Maker",
                                BuildingType.WaterMaker => "Water Maker",
                                BuildingType.FoodMaker => "Food Maker",
                                BuildingType.ConcreteMaker => "Concrete Maker",
                                BuildingType.MetalMaker => "Metal Maker",
                                BuildingType.ItemMaker => "Item Maker",
                                BuildingType.UnitMaker => "Unit Maker",
                                BuildingType.GoldMaker => "Gold Maker",
                                BuildingType.LootboxMaker => "Lootbox Maker",
                                BuildingType.RushBoostMaker => "Rush Boost Maker",
                                BuildingType.ExperienceBoostMaker => "Experience Boost Maker",
                                BuildingType.RarityBoostMaker => "Rarity Boost Maker",
                                BuildingType.MonsterEggMaker => "Monster Egg Maker",
                                BuildingType.FertilizerMaker => "Fertilizer Maker",
                                BuildingType.MysterySeedMaker => "Mystery Seed Maker",
                                _ => "Unknown Building"
                            };

                            OutputService.Write(true, [new($"Construction complete: {buildingType}", Properties.Settings.Default.PrimaryForeColor)]);
                        }

                        // Update quests and statistics
                        GameManager.TryQuestProgress(playerIndex, QuestType.ConstructBuilding, 1);
                        GameManager.Players[playerIndex].Statistics.BuildingsConstructed += 1;

                        break;

                    case TileState.Producing:
                        if (Building == null) return;

                        Elapsed = TimeSpan.Zero;

                        // Add/increment the relevant building production based on the building type
                        // Most production amounts can be modified by nodes in the research tree
                        switch (Building)
                        {
                            case BuildingType.PowerMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.PowerProductionAmount, StarterValues.PowerProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Power, quantity))
                                        buildingProduction.LootQuantities[LootType.Power] += quantity;
                                }
                                break;
                            case BuildingType.WaterMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.WaterProductionAmount, StarterValues.WaterProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Water, quantity))
                                        buildingProduction.LootQuantities[LootType.Water] += quantity;
                                }
                                break;
                            case BuildingType.FoodMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.FoodProductionAmount, StarterValues.FoodProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Food, quantity))
                                        buildingProduction.LootQuantities[LootType.Food] += quantity;
                                }
                                break;
                            case BuildingType.ConcreteMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ConcreteProductionAmount, StarterValues.ConcreteProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Concrete, quantity))
                                        buildingProduction.LootQuantities[LootType.Concrete] += quantity;
                                }
                                break;
                            case BuildingType.MetalMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MetalProductionAmount, StarterValues.MetalProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Metal, quantity))
                                        buildingProduction.LootQuantities[LootType.Metal] += quantity;
                                }
                                break;
                            case BuildingType.ResearchMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ResearchProductionAmount, StarterValues.ResearchProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Research, quantity))
                                        buildingProduction.LootQuantities[LootType.Research] += quantity;
                                }
                                break;
                            case BuildingType.ItemMaker:
                                buildingProduction.Items.Add(ItemFactory.GenerateRandomItem(playerIndex));
                                break;
                            case BuildingType.UnitMaker:
                                buildingProduction.Units.Add(UnitFactory.GenerateRandomUnit(playerIndex));
                                break;
                            case BuildingType.GoldMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.GoldProductionAmount, StarterValues.GoldProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Gold, quantity))
                                        buildingProduction.LootQuantities[LootType.Gold] += quantity;
                                }
                                break;
                            case BuildingType.LootboxMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.LootboxProductionAmount, StarterValues.LootboxProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Lootbox, quantity))
                                        buildingProduction.LootQuantities[LootType.Lootbox] += quantity;
                                }
                                break;
                            case BuildingType.RushBoostMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.RushBoostProductionAmount, StarterValues.RushBoostProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.RushBoost, quantity))
                                        buildingProduction.LootQuantities[LootType.RushBoost] += quantity;
                                }
                                break;
                            case BuildingType.ExperienceBoostMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ExperienceBoostProductionAmount, StarterValues.ExperienceBoostProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.ExperienceBoost, quantity))
                                        buildingProduction.LootQuantities[LootType.ExperienceBoost] += quantity;
                                }
                                break;
                            case BuildingType.RarityBoostMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.RarityBoostProductionAmount, StarterValues.RarityBoostProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.RarityBoost, quantity))
                                        buildingProduction.LootQuantities[LootType.RarityBoost] += quantity;
                                }
                                break;
                            case BuildingType.MonsterEggMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MonsterEggProductionAmount, StarterValues.MonsterEggProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.MonsterEgg, quantity))
                                        buildingProduction.LootQuantities[LootType.MonsterEgg] += quantity;
                                }
                                break;
                            case BuildingType.FertilizerMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.FertilizerProductionAmount, StarterValues.FertilizerProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.Fertilizer, quantity))
                                        buildingProduction.LootQuantities[LootType.Fertilizer] += quantity;
                                }
                                break;
                            case BuildingType.MysterySeedMaker:
                                {
                                    int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MysterySeedProductionAmount, StarterValues.MysterySeedProductionAmount);
                                    if (!buildingProduction.LootQuantities.TryAdd(LootType.MysterySeed, quantity))
                                        buildingProduction.LootQuantities[LootType.MysterySeed] += quantity;
                                }
                                break;
                        }

                        break;
                }
            }
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}