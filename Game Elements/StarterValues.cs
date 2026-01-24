namespace Game_Elements
{
    public static class StarterValues
    {
        public const int CommonMissionDuration = 5000;
        public const int RareMissionDuration = 10000;
        public const int EpicMissionDuration = 20000;
        public const int LegendaryMissionDuration = 40000;

        public const int MaxInProgressMissions = 3;

        public const double UnitSuccessChance = 25.0;
        public const int UnitRenamingCost = 500;
        public const int MaxUnitLevel = 99;
        public const int UnitQuoteInterval = 60000;

        public const int LootboxCost = 6000;
        public const int RarityBoostCost = 4500;
        public const int ExperienceBoostCost = 3000;
        public const int RushBoostCost = 1500;
        public const int ConcreteCost = 125;
        public const int MetalCost = 250;
        public const int WaterCost = 25;
        public const int FoodCost = 50;

        public const int ItemSellPrice = 25;
        public const int PlantItemSellPrice = 250;
        public const int JunkItemSellPrice = 1;

        public const int MaxQuests = 3;

        public const int EggHatcherCost = 7500;
        public const int GardeningPlotCost = 750;

        public const int HatchingDuration = 60000;
        public const int GardeningDuration = 120000;

        public const int ExperienceBoostAmount = 500;

        public const double MaxGardeningSkill = 100.0;
        public const double MaxFishingSkill = 100.0;

        public const double MaxSkillGainForTilling = 25.0;
        public const double MaxSkillGainForPlanting = 50.0;
        public const double MaxSkillGainForWaterOrFertilizer = 75.0;
        public const double MaxSkillGainForHarvesting = 100.0;

        public const int MaxUnits = 10;
        public const int MaxItems = 10;
        public const int MaxPower = 750;
        public const int MaxWater = 100;
        public const int MaxFood = 100;
        public const int MaxConcrete = 50;
        public const int MaxMetal = 50;
        public const int MaxGold = 75000;
        public const int MaxLootboxes = 15;
        public const int MaxRushBoosts = 45;
        public const int MaxExperienceBoosts = 30;
        public const int MaxRarityBoosts = 15;
        public const int MaxMonsterEggs = 5;
        public const int MaxFertilizer = 50;
        public const int MaxMysterySeeds = 15;

        public const int ResearchProductionAmount = 5;
        public const int PowerProductionAmount = 125;
        public const int WaterProductionAmount = 5;
        public const int FoodProductionAmount = 4;
        public const int ConcreteProductionAmount = 1;
        public const int MetalProductionAmount = 1;
        public const int GoldProductionAmount = 100;
        public const int LootboxProductionAmount = 1;
        public const int RushBoostProductionAmount = 1;
        public const int ExperienceBoostProductionAmount = 1;
        public const int RarityBoostProductionAmount = 1;
        public const int MonsterEggProductionAmount = 1;
        public const int FertilizerProductionAmount = 5;
        public const int MysterySeedProductionAmount = 1;

        public const int TerraformingDuration = 150000;

        public const int PlayerRenamingCost = 500;
        public const int CustomizeStringsCost = 500;

        public static readonly Dictionary<string, (double Min, double Max)> FishRanges = new()
        {
            {"Robotic Fish Type A",(0.05, 0.6)}, {"Robotic Fish Type B",(0.1, 1.2)}, {"Robotic Fish Type C",(0.05, 0.8)},
            {"Robotic Fish Type D",(0.05, 0.9)}, {"Robotic Fish Type E",(0.5, 15.0)}, {"Robotic Fish Type F",(0.3, 30.0)},
            {"Robotic Fish Type G",(0.2, 6.0)}, {"Robotic Fish Type H",(1.0, 18.0)}, {"Robotic Fish Type I",(0.5, 20.0)},
            {"Robotic Fish Type J",(0.4, 6.0)}, {"Robotic Fish Type K",(0.2, 9.0)}, {"Robotic Fish Type L",(0.25, 6.5)},
            {"Robotic Fish Type M",(1.0, 30.0)}, {"Robotic Fish Type N",(0.5, 12.0)}, {"Robotic Fish Type O",(0.2, 3.0)},
            {"Robotic Fish Type P",(0.5, 15.0)}, {"Robotic Fish Type Q",(1.0, 50.0)}, {"Robotic Fish Type R",(2.0, 120.0)},
            {"Robotic Fish Type S",(5.0, 250.0)}, {"Robotic Fish Type T",(0.02, 0.12)}, {"Robotic Fish Type U",(0.05, 0.25)},
            {"Robotic Fish Type V",(0.3, 8.0)}, {"Robotic Fish Type W",(2.0, 40.0)}, {"Robotic Fish Type X",(20.0, 400.0)},
            {"Robotic Fish Type Y",(0.01, 0.05)}, {"Robotic Fish Type Z",(1.0, 30.0)}
        };
    }
}