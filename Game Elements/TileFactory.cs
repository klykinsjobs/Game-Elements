namespace Game_Elements
{
    public static class TileFactory
    {
        public static Tile GenerateTile(int x, int y, TerrainType terrainType, BuildingType? buildingType)
        {
            return new Tile
            {
                X = x,
                Y = y,
                Terrain = terrainType,
                Building = buildingType != null ? buildingType : null,
                TileState = TileState.Idle
            };
        }

        // Helper to look up the appropriate values based on the building type
        public static Dictionary<BuildingType, (long constructionDuration, TileState postConstructionState, long? productionDuration,
            LootType? productionLootType, int? productionAmount, Dictionary<LootType, int> constructionMaterials, Modifier? modifier)>
            BuildingLookups()
        {
            return new Dictionary<BuildingType, (long constructionDuration, TileState postConstructionState, long? productionDuration, LootType? productionLootType, int? productionAmount, Dictionary<LootType, int> constructionMaterials, Modifier? modifier)>
            {
                {
                    BuildingType.CityCenter,
                    (300000, TileState.Idle, null, null, null,
                    new Dictionary<LootType, int> { {LootType.Concrete, 25}, { LootType.Metal, 25} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxInProgressMissions, ModifierType = ModifierType.Flat, ModifierAmount = 1, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.Dwelling,
                    (150000, TileState.Idle, null, null, null,
                    new Dictionary<LootType, int> { {LootType.Concrete, 15}, { LootType.Metal, 10} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxUnits, ModifierType = ModifierType.Flat, ModifierAmount = 5, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.Storage,
                    (90000, TileState.Idle, null, null, null,
                    new Dictionary<LootType, int> { {LootType.Concrete, 10}, { LootType.Metal, 5} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxItems, ModifierType = ModifierType.Flat, ModifierAmount = 25, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.ResearchMaker,
                    (60000, TileState.Producing, 15000, LootType.Research, 5,
                    new Dictionary<LootType, int> { {LootType.Concrete, 6}, { LootType.Metal, 4} },
                    null)
                },

                {
                    BuildingType.PowerMaker,
                    (30000, TileState.Producing, 60000, LootType.Power, 125, // increased this from 25 to 125
                    new Dictionary<LootType, int> { {LootType.Concrete, 3}, { LootType.Metal, 7} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxPower, ModifierType = ModifierType.Flat, ModifierAmount = 100, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.WaterMaker,
                    (30000, TileState.Producing, 90000, LootType.Water, 5,
                    new Dictionary<LootType, int> { {LootType.Concrete, 2}, { LootType.Metal, 3} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxWater, ModifierType = ModifierType.Flat, ModifierAmount = 50, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.FoodMaker,
                    (30000, TileState.Producing, 90000, LootType.Food, 4,
                    new Dictionary<LootType, int> { {LootType.Concrete, 3}, { LootType.Metal, 2} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxFood, ModifierType = ModifierType.Flat, ModifierAmount = 50, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.ConcreteMaker,
                    (60000, TileState.Producing, 150000, LootType.Concrete, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 6}, { LootType.Metal, 4} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxConcrete, ModifierType = ModifierType.Flat, ModifierAmount = 25, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.MetalMaker,
                    (60000, TileState.Producing, 150000, LootType.Metal, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 4}, { LootType.Metal, 6} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxMetal, ModifierType = ModifierType.Flat, ModifierAmount = 25, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.ItemMaker,
                    (150000, TileState.Producing, 600000, null, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 15}, { LootType.Metal, 10} },
                    null)
                },

                {
                    BuildingType.UnitMaker,
                    (150000, TileState.Producing, 600000, null, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 10}, { LootType.Metal, 15} },
                    null)
                },

                {
                    BuildingType.GoldMaker,
                    (90000, TileState.Producing, 45000, LootType.Gold, 100,
                    new Dictionary<LootType, int> { {LootType.Concrete, 5}, { LootType.Metal, 10} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxGold, ModifierType = ModifierType.Flat, ModifierAmount = 1000, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.LootboxMaker,
                    (150000, TileState.Producing, 600000, LootType.Lootbox, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 10}, { LootType.Metal, 15} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxLootboxes, ModifierType = ModifierType.Flat, ModifierAmount = 5, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.RushBoostMaker,
                    (90000, TileState.Producing, 300000, LootType.RushBoost, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 5}, { LootType.Metal, 10} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxRushBoosts, ModifierType = ModifierType.Flat, ModifierAmount = 10, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.ExperienceBoostMaker,
                    (90000, TileState.Producing, 300000, LootType.ExperienceBoost, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 10}, { LootType.Metal, 5} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxExperienceBoosts, ModifierType = ModifierType.Flat, ModifierAmount = 10, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.RarityBoostMaker,
                    (90000, TileState.Producing, 300000, LootType.RarityBoost, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 7}, { LootType.Metal, 8} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxRarityBoosts, ModifierType = ModifierType.Flat, ModifierAmount = 10, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.MonsterEggMaker,
                    (150000, TileState.Producing, 600000, LootType.MonsterEgg, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 20}, { LootType.Metal, 5} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxMonsterEggs, ModifierType = ModifierType.Flat, ModifierAmount = 5, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.FertilizerMaker,
                    (60000, TileState.Producing, 150000, LootType.Fertilizer, 5,
                    new Dictionary<LootType, int> { {LootType.Concrete, 5}, { LootType.Metal, 5} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxFertilizer, ModifierType = ModifierType.Flat, ModifierAmount = 25, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },

                {
                    BuildingType.MysterySeedMaker,
                    (150000, TileState.Producing, 600000, LootType.MysterySeed, 1,
                    new Dictionary<LootType, int> { {LootType.Concrete, 5}, { LootType.Metal, 20} },
                    new Modifier() { ModifierTarget = ModifierTarget.MaxMysterySeeds, ModifierType = ModifierType.Flat, ModifierAmount = 5, ModifierSource = ModifierSource.Building, ModifierQuantity = 1 })
                },
            };
        }
    }
}