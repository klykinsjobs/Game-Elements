namespace Game_Elements.Enums
{
    public enum Rarity
    {
        Common, Rare, Epic, Legendary
    }

    public enum Element
    {
        Fire, Water, Ice, Wind, Earth, Lightning, Arcane, Metal
    }

    public enum MissionState
    {
        Available, InProgress, Success, Fail
    }

    public enum UnitState
    {
        Idle, OnMission, Cooldown
    }

    public enum TileState
    {
        Idle, Terraforming, Constructing, Producing
    }

    public enum FishingState
    {
        Idle, Waiting, BiteActive
    }

    public enum TerrainType
    {
        Water, Grassland, Desert, Mountain
    }

    public enum BuildingType
    {
        CityCenter, Dwelling, Storage, ResearchMaker, PowerMaker,
        WaterMaker, FoodMaker, ConcreteMaker, MetalMaker,
        ItemMaker, UnitMaker, GoldMaker, LootboxMaker,
        RushBoostMaker, ExperienceBoostMaker, RarityBoostMaker,
        MonsterEggMaker, FertilizerMaker, MysterySeedMaker
    }

    public enum QuestType
    {
        StartMission, SucceedMission, FailMission, LevelUpUnit, OpenLootbox,
        UseRushBoost, UseExperienceBoost, UseRarityBoost, SellItem, BuyItem,
        UnlockAchievement, CompleteQuest, DismissQuest, CaughtFish,
        HarvestPlant, HatchEgg, TerraformTile, ConstructBuilding, ResearchNode,
        CollectResearch, CollectPower, CollectWater, CollectFood, CollectConcrete,
        CollectMetal, CollectItem, CollectUnit, CollectGold,
        CollectLootbox, CollectRushBoost, CollectExperienceBoost, CollectRarityBoost,
        CollectMonsterEgg, CollectFertilizer, CollectMysterySeed
    }

    public enum LootType
    {
        Gold, Power, Water, Food, Concrete, Metal,
        Lootbox, RushBoost, ExperienceBoost, RarityBoost,
        MonsterEgg, Fertilizer, MysterySeed, Research
    }

    public enum ModifierType
    {
        Flat, Percent
    }

    public enum ModifierSource
    {
        ResearchNode, Building, Achievement, Item
    }

    public enum ModifierTarget
    {
        MissionDuration, MaxInProgressMissions, UnitSuccessChance,
        UnitRenamingCost, UnitQuoteInterval, MaxUnitLevel,
        ItemShopCost, ItemSellPrice, LootboxGoldAmount,
        QuestGoldAmount, MaxQuests, EggHatcherCost, HatchingDuration,
        GardeningPlotCost, GardeningDuration, ReelTimerDuration, ExperienceBoostAmount,
        MaxGold, MaxPower, MaxWater, MaxFood, MaxConcrete, MaxMetal,
        MaxLootboxes, MaxRushBoosts, MaxExperienceBoosts, MaxRarityBoosts,
        MaxUnits, MaxItems, MaxMonsterEggs, MaxFertilizer, MaxMysterySeeds,
        ResearchProductionAmount, PowerProductionAmount, WaterProductionAmount,
        FoodProductionAmount, ConcreteProductionAmount, MetalProductionAmount,
        GoldProductionAmount, LootboxProductionAmount, RushBoostProductionAmount,
        ExperienceBoostProductionAmount, RarityBoostProductionAmount,
        MonsterEggProductionAmount, FertilizerProductionAmount, MysterySeedProductionAmount,
        MissionExperienceAmount, MissionGoldAmount, MissionPowerOdds, MissionWaterOdds,
        MissionFoodOdds, MissionConcreteOdds, MissionMetalOdds, MissionItemOdds, MissionUnitOdds,
        MissionLootboxOdds, MissionRushBoostOdds, MissionExperienceBoostOdds, MissionRarityBoostOdds,
        MissionMonsterEggOdds, MissionFertilizerOdds, MissionMysterySeedOdds
    }
}