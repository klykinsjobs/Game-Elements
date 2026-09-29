using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;

namespace Game_Elements.Factories
{
    public static class AchievementFactory
    {
        public static List<Achievement> GetAchievements(int playerIndex)
        {
            var unlockConditions = UnlockConditions(playerIndex);

            return
            [
                new() { Title = "Missions Started", Description = "Start 10 missions", UnlockCondition = unlockConditions["Missions Started"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Missions Started +", Description = "Start 100 missions", UnlockCondition = unlockConditions["Missions Started +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Missions Started ++", Description = "Start 1000 missions", UnlockCondition = unlockConditions["Missions Started ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Missions Failed", Description = "Fail 5 missions", UnlockCondition = unlockConditions["Missions Failed"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Missions Failed +", Description = "Fail 10 missions", UnlockCondition = unlockConditions["Missions Failed +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Missions Failed ++", Description = "Fail 25 missions", UnlockCondition = unlockConditions["Missions Failed ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Missions Succeeded", Description = "Successfully complete 10 missions", UnlockCondition = unlockConditions["Missions Succeeded"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Missions Succeeded +", Description = "Successfully complete 100 missions", UnlockCondition = unlockConditions["Missions Succeeded +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Missions Succeeded ++", Description = "Successfully complete 1000 missions", UnlockCondition = unlockConditions["Missions Succeeded ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Mission Multitasking", Description = "Have 3 in progress missions simultaneously", UnlockCondition = unlockConditions["Mission Multitasking"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Mission Multitasking +", Description = "Have 6 in progress missions simultaneously", UnlockCondition = unlockConditions["Mission Multitasking +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Mission Multitasking ++", Description = "Have 12 in progress missions simultaneously", UnlockCondition = unlockConditions["Mission Multitasking ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Units", Description = "Have 10 units", UnlockCondition = unlockConditions["Units"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Units +", Description = "Have 100 units", UnlockCondition = unlockConditions["Units +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Units ++", Description = "Have 1000 units", UnlockCondition = unlockConditions["Units ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Unit Levels", Description = "Have 5 units at level 5", UnlockCondition = unlockConditions["Unit Levels"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Unit Levels +", Description = "Have 10 units at level 10", UnlockCondition = unlockConditions["Unit Levels +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Unit Levels ++", Description = "Have 25 units at level 25", UnlockCondition = unlockConditions["Unit Levels ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Legendary Units", Description = "Have 5 units at legendary rarity", UnlockCondition = unlockConditions["Legendary Units"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Legendary Units +", Description = "Have 10 units at legendary rarity", UnlockCondition = unlockConditions["Legendary Units +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Legendary Units ++", Description = "Have 25 units at legendary rarity", UnlockCondition = unlockConditions["Legendary Units ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Gold", Description = "Have 10000 gold", UnlockCondition = unlockConditions["Gold"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Gold +", Description = "Have 50000 gold", UnlockCondition = unlockConditions["Gold +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Gold ++", Description = "Have 250000 gold", UnlockCondition = unlockConditions["Gold ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Lootboxes Opened", Description = "Open 5 lootboxes", UnlockCondition = unlockConditions["Lootboxes Opened"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Lootboxes Opened +", Description = "Open 25 lootboxes", UnlockCondition = unlockConditions["Lootboxes Opened +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Lootboxes Opened ++", Description = "Open 100 lootboxes", UnlockCondition = unlockConditions["Lootboxes Opened ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Rush Boosts Used", Description = "Use 5 rush boosts", UnlockCondition = unlockConditions["Rush Boosts Used"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Rush Boosts Used +", Description = "Use 25 rush boosts", UnlockCondition = unlockConditions["Rush Boosts Used +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Rush Boosts Used ++", Description = "Use 100 rush boosts", UnlockCondition = unlockConditions["Rush Boosts Used ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Experience Boosts Used", Description = "Use 5 experience boosts", UnlockCondition = unlockConditions["Experience Boosts Used"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Experience Boosts Used +", Description = "Use 25 experience boosts", UnlockCondition = unlockConditions["Experience Boosts Used +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Experience Boosts Used ++", Description = "Use 100 experience boosts", UnlockCondition = unlockConditions["Experience Boosts Used ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Rarity Boosts Used", Description = "Use 5 rarity boosts", UnlockCondition = unlockConditions["Rarity Boosts Used"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Rarity Boosts Used +", Description = "Use 25 rarity boosts", UnlockCondition = unlockConditions["Rarity Boosts Used +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Rarity Boosts Used ++", Description = "Use 100 rarity boosts", UnlockCondition = unlockConditions["Rarity Boosts Used ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Items", Description = "Have 5 items", UnlockCondition = unlockConditions["Items"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Items +", Description = "Have 25 items", UnlockCondition = unlockConditions["Items +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Items ++", Description = "Have 100 items", UnlockCondition = unlockConditions["Items ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Rare Item", Description = "Have an item at rare rarity", UnlockCondition = unlockConditions["Rare Item"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Epic Item", Description = "Have an item at epic rarity", UnlockCondition = unlockConditions["Epic Item"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Legendary Item", Description = "Have an item at legendary rarity", UnlockCondition = unlockConditions["Legendary Item"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Items Sold", Description = "Sell 5 items", UnlockCondition = unlockConditions["Items Sold"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Items Sold +", Description = "Sell 25 items", UnlockCondition = unlockConditions["Items Sold +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Items Sold ++", Description = "Sell 100 items", UnlockCondition = unlockConditions["Items Sold ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Items Bought", Description = "Buy 5 items", UnlockCondition = unlockConditions["Items Bought"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Items Bought +", Description = "Buy 25 items", UnlockCondition = unlockConditions["Items Bought +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Items Bought ++", Description = "Buy 100 items", UnlockCondition = unlockConditions["Items Bought ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Achievements", Description = "Unlock 25 achievements", UnlockCondition = unlockConditions["Achievements"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Achievements +", Description = "Unlock 50 achievements", UnlockCondition = unlockConditions["Achievements +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Achievements ++", Description = "Unlock 75 achievements", UnlockCondition = unlockConditions["Achievements ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Quests Completed", Description = "Complete 25 quests", UnlockCondition = unlockConditions["Quests Completed"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Quests Completed +", Description = "Complete 250 quests", UnlockCondition = unlockConditions["Quests Completed +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Quests Completed ++", Description = "Complete 2500 quests", UnlockCondition = unlockConditions["Quests Completed ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Quests Dismissed", Description = "Dismiss 5 quests", UnlockCondition = unlockConditions["Quests Dismissed"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Quests Dismissed +", Description = "Dismiss 50 quests", UnlockCondition = unlockConditions["Quests Dismissed +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Quests Dismissed ++", Description = "Dismiss 500 quests", UnlockCondition = unlockConditions["Quests Dismissed ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Fishing", Description = "Reach 50 in fishing skill", UnlockCondition = unlockConditions["Fishing"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Fishing +", Description = "Reach 75 in fishing skill", UnlockCondition = unlockConditions["Fishing +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Fishing ++", Description = "Reach 100 in fishing skill", UnlockCondition = unlockConditions["Fishing ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Gardening", Description = "Reach 50 in gardening skill", UnlockCondition = unlockConditions["Gardening"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Gardening +", Description = "Reach 75 in gardening skill", UnlockCondition = unlockConditions["Gardening +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Gardening ++", Description = "Reach 100 in gardening skill", UnlockCondition = unlockConditions["Gardening ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Fish Alphabet", Description = "Caught one of every type of fish", UnlockCondition = unlockConditions["Fish Alphabet"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Caught Fish", Description = "Caught 5 fish", UnlockCondition = unlockConditions["Caught Fish"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Caught Fish +", Description = "Caught 50 fish", UnlockCondition = unlockConditions["Caught Fish +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Caught Fish ++", Description = "Caught 500 fish", UnlockCondition = unlockConditions["Caught Fish ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Harvested Plants", Description = "Harvested 5 plants", UnlockCondition = unlockConditions["Harvested Plants"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Harvested Plants +", Description = "Harvested 50 plants", UnlockCondition = unlockConditions["Harvested Plants +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Harvested Plants ++", Description = "Harvested 500 plants", UnlockCondition = unlockConditions["Harvested Plants ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Hatched Eggs", Description = "Hatched 5 monster eggs", UnlockCondition = unlockConditions["Hatched Eggs"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Hatched Eggs +", Description = "Hatched 25 monster eggs", UnlockCondition = unlockConditions["Hatched Eggs +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Hatched Eggs ++", Description = "Hatched 100 monster eggs", UnlockCondition = unlockConditions["Hatched Eggs ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Terraformed Tiles", Description = "Terraformed 5 tiles", UnlockCondition = unlockConditions["Terraformed Tiles"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Terraformed Tiles +", Description = "Terraformed 25 tiles", UnlockCondition = unlockConditions["Terraformed Tiles +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Terraformed Tiles ++", Description = "Terraformed 100 tiles", UnlockCondition = unlockConditions["Terraformed Tiles ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Constructed Buildings", Description = "Constructed 5 buildings", UnlockCondition = unlockConditions["Constructed Buildings"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Constructed Buildings +", Description = "Constructed 25 buildings", UnlockCondition = unlockConditions["Constructed Buildings +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Constructed Buildings ++", Description = "Constructed 100 buildings", UnlockCondition = unlockConditions["Constructed Buildings ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Researched Nodes", Description = "Researched 50 nodes", UnlockCondition = unlockConditions["Researched Nodes"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 100 } } } },

                new() { Title = "Researched Nodes +", Description = "Researched 100 nodes", UnlockCondition = unlockConditions["Researched Nodes +"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 1000 } } } },

                new() { Title = "Researched Nodes ++", Description = "Researched 150 nodes", UnlockCondition = unlockConditions["Researched Nodes ++"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Collected Research", Description = "Collected 25000 research", UnlockCondition = unlockConditions["Collected Research"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } } },

                new() { Title = "Collected Power", Description = "Collected 100000 power", UnlockCondition = unlockConditions["Collected Power"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxPower, ModifierType = ModifierType.Flat, ModifierAmount = 500, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Water", Description = "Collected 5000 water", UnlockCondition = unlockConditions["Collected Water"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxWater, ModifierType = ModifierType.Flat, ModifierAmount = 250, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Food", Description = "Collected 5000 food", UnlockCondition = unlockConditions["Collected Food"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxFood, ModifierType = ModifierType.Flat, ModifierAmount = 250, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Concrete", Description = "Collected 500 concrete", UnlockCondition = unlockConditions["Collected Concrete"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxConcrete, ModifierType = ModifierType.Flat, ModifierAmount = 250, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Metal", Description = "Collected 500 metal", UnlockCondition = unlockConditions["Collected Metal"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxMetal, ModifierType = ModifierType.Flat, ModifierAmount = 250, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Items", Description = "Collected 250 items", UnlockCondition = unlockConditions["Collected Items"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxItems, ModifierType = ModifierType.Flat, ModifierAmount = 50, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Units", Description = "Collected 250 units", UnlockCondition = unlockConditions["Collected Units"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxUnits, ModifierType = ModifierType.Flat, ModifierAmount = 50, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Gold", Description = "Collected 200000 gold", UnlockCondition = unlockConditions["Collected Gold"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxGold, ModifierType = ModifierType.Flat, ModifierAmount = 50000, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Lootboxes", Description = "Collected 250 lootboxes", UnlockCondition = unlockConditions["Collected Lootboxes"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxLootboxes, ModifierType = ModifierType.Flat, ModifierAmount = 100, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Rush Boosts", Description = "Collected 500 rush boosts", UnlockCondition = unlockConditions["Collected Rush Boosts"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxRushBoosts, ModifierType = ModifierType.Flat, ModifierAmount = 100, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Experience Boosts", Description = "Collected 500 experience boosts", UnlockCondition = unlockConditions["Collected Experience Boosts"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxExperienceBoosts, ModifierType = ModifierType.Flat, ModifierAmount = 100, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Rarity Boosts", Description = "Collected 500 rarity boosts", UnlockCondition = unlockConditions["Collected Rarity Boosts"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxRarityBoosts, ModifierType = ModifierType.Flat, ModifierAmount = 100, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Monster Eggs", Description = "Collected 250 monster eggs", UnlockCondition = unlockConditions["Collected Monster Eggs"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxMonsterEggs, ModifierType = ModifierType.Flat, ModifierAmount = 25, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Fertilizer", Description = "Collected 2500 fertilizer", UnlockCondition = unlockConditions["Collected Fertilizer"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxFertilizer, ModifierType = ModifierType.Flat, ModifierAmount = 75, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },

                new() { Title = "Collected Mystery Seeds", Description = "Collected 250 mystery seeds", UnlockCondition = unlockConditions["Collected Mystery Seeds"],
                    Loots = new() { LootQuantities = new Dictionary<LootType, int>() { { LootType.Gold, 10000 } } },
                    Modifier = new() { ModifierTarget = ModifierTarget.MaxMysterySeeds, ModifierType = ModifierType.Flat, ModifierAmount = 75, ModifierSource = ModifierSource.Achievement, ModifierQuantity = 1 } },
            ];
        }

        public static Dictionary<string, Func<bool>> UnlockConditions(int playerIndex)
        {
            int idx = playerIndex;

            return new Dictionary<string, Func<bool>>
            {
                { "Missions Started", () => GameManager.Players[idx].Statistics.MissionsStarted >= 10 },
                { "Missions Started +", () => GameManager.Players[idx].Statistics.MissionsStarted >= 100 },
                { "Missions Started ++", () => GameManager.Players[idx].Statistics.MissionsStarted >= 1000 },

                { "Missions Failed", () => GameManager.Players[idx].Statistics.MissionsFailed >= 5 },
                { "Missions Failed +", () => GameManager.Players[idx].Statistics.MissionsFailed >= 10 },
                { "Missions Failed ++", () => GameManager.Players[idx].Statistics.MissionsFailed >= 25 },

                { "Missions Succeeded", () => GameManager.Players[idx].Statistics.MissionsSucceeded >= 10 },
                { "Missions Succeeded +", () => GameManager.Players[idx].Statistics.MissionsSucceeded >= 100 },
                { "Missions Succeeded ++", () => GameManager.Players[idx].Statistics.MissionsSucceeded >= 1000 },

                { "Mission Multitasking", () => GameManager.Players[idx].Missions.Count(m => m.MissionState == MissionState.InProgress) >= 3 },
                { "Mission Multitasking +", () => GameManager.Players[idx].Missions.Count(m => m.MissionState == MissionState.InProgress) >= 6 },
                { "Mission Multitasking ++", () => GameManager.Players[idx].Missions.Count(m => m.MissionState == MissionState.InProgress) >= 12 },

                { "Units", () => GameManager.Players[idx].Inventory.Units.Count >= 10 },
                { "Units +", () => GameManager.Players[idx].Inventory.Units.Count >= 100 },
                { "Units ++", () => GameManager.Players[idx].Inventory.Units.Count >= 1000 },

                { "Unit Levels", () => GameManager.Players[idx].Inventory.Units.Count(u => u.Level >= 5) >= 5 },
                { "Unit Levels +", () => GameManager.Players[idx].Inventory.Units.Count(u => u.Level >= 10) >= 10 },
                { "Unit Levels ++", () => GameManager.Players[idx].Inventory.Units.Count(u => u.Level >= 25) >= 25 },

                { "Legendary Units", () => GameManager.Players[idx].Inventory.Units.Count(u => u.Rarity == Rarity.Legendary) >= 5 },
                { "Legendary Units +", () => GameManager.Players[idx].Inventory.Units.Count(u => u.Rarity == Rarity.Legendary) >= 10 },
                { "Legendary Units ++", () => GameManager.Players[idx].Inventory.Units.Count(u => u.Rarity == Rarity.Legendary) >= 25 },

                { "Gold", () => GameManager.Players[idx].Inventory.Gold >= 10000 },
                { "Gold +", () => GameManager.Players[idx].Inventory.Gold >= 50000 },
                { "Gold ++", () => GameManager.Players[idx].Inventory.Gold >= 250000 },

                { "Lootboxes Opened", () => GameManager.Players[idx].Statistics.LootboxesOpened >= 5 },
                { "Lootboxes Opened +", () => GameManager.Players[idx].Statistics.LootboxesOpened >= 25 },
                { "Lootboxes Opened ++", () => GameManager.Players[idx].Statistics.LootboxesOpened >= 100 },

                { "Rush Boosts Used", () => GameManager.Players[idx].Statistics.RushBoostsUsed >= 5 },
                { "Rush Boosts Used +", () => GameManager.Players[idx].Statistics.RushBoostsUsed >= 25 },
                { "Rush Boosts Used ++", () => GameManager.Players[idx].Statistics.RushBoostsUsed >= 100 },

                { "Experience Boosts Used", () => GameManager.Players[idx].Statistics.ExperienceBoostsUsed >= 5 },
                { "Experience Boosts Used +", () => GameManager.Players[idx].Statistics.ExperienceBoostsUsed >= 25 },
                { "Experience Boosts Used ++", () => GameManager.Players[idx].Statistics.ExperienceBoostsUsed >= 100 },

                { "Rarity Boosts Used", () => GameManager.Players[idx].Statistics.RarityBoostsUsed >= 5 },
                { "Rarity Boosts Used +", () => GameManager.Players[idx].Statistics.RarityBoostsUsed >= 25 },
                { "Rarity Boosts Used ++", () => GameManager.Players[idx].Statistics.RarityBoostsUsed >= 100 },

                { "Items", () => GameManager.Players[idx].Inventory.Items.Count >= 5 },
                { "Items +", () => GameManager.Players[idx].Inventory.Items.Count >= 25 },
                { "Items ++", () => GameManager.Players[idx].Inventory.Items.Count >= 100 },

                { "Rare Item", () => GameManager.Players[idx].Inventory.Items.Any(i => i.Rarity == Rarity.Rare) },
                { "Epic Item", () => GameManager.Players[idx].Inventory.Items.Any(i => i.Rarity == Rarity.Epic) },
                { "Legendary Item", () => GameManager.Players[idx].Inventory.Items.Any(i => i.Rarity == Rarity.Legendary) },

                { "Items Sold", () => GameManager.Players[idx].Statistics.ItemsSold >= 5 },
                { "Items Sold +", () => GameManager.Players[idx].Statistics.ItemsSold >= 25 },
                { "Items Sold ++", () => GameManager.Players[idx].Statistics.ItemsSold >= 100 },

                { "Items Bought", () => GameManager.Players[idx].Statistics.ItemsBought >= 5 },
                { "Items Bought +", () => GameManager.Players[idx].Statistics.ItemsBought >= 25 },
                { "Items Bought ++", () => GameManager.Players[idx].Statistics.ItemsBought >= 100 },

                { "Achievements", () => GameManager.Players[idx].Statistics.AchievementsUnlocked >= 25 },
                { "Achievements +", () => GameManager.Players[idx].Statistics.AchievementsUnlocked >= 50 },
                { "Achievements ++", () => GameManager.Players[idx].Statistics.AchievementsUnlocked >= 75 },

                { "Quests Completed", () => GameManager.Players[idx].Statistics.QuestsCompleted >= 25 },
                { "Quests Completed +", () => GameManager.Players[idx].Statistics.QuestsCompleted >= 250 },
                { "Quests Completed ++", () => GameManager.Players[idx].Statistics.QuestsCompleted >= 2500 },

                { "Quests Dismissed", () => GameManager.Players[idx].Statistics.QuestsDismissed >= 5 },
                { "Quests Dismissed +", () => GameManager.Players[idx].Statistics.QuestsDismissed >= 50 },
                { "Quests Dismissed ++", () => GameManager.Players[idx].Statistics.QuestsDismissed >= 500 },

                { "Fishing", () => GameManager.Players[idx].FishingSkill >= 50.0 },
                { "Fishing +", () => GameManager.Players[idx].FishingSkill >= 75.0 },
                { "Fishing ++", () => GameManager.Players[idx].FishingSkill >= 100.0 },

                { "Gardening", () => GameManager.Players[idx].GardeningSkill >= 50.0 },
                { "Gardening +", () => GameManager.Players[idx].GardeningSkill >= 75.0 },
                { "Gardening ++", () => GameManager.Players[idx].GardeningSkill >= 100.0 },

                { "Fish Alphabet", () => GameManager.Players[idx].Statistics.FishRecords.All(f => f.Value > 0.0) },

                { "Caught Fish", () => GameManager.Players[idx].Statistics.FishCaught >= 5 },
                { "Caught Fish +", () => GameManager.Players[idx].Statistics.FishCaught >= 50 },
                { "Caught Fish ++", () => GameManager.Players[idx].Statistics.FishCaught >= 500 },

                { "Harvested Plants", () => GameManager.Players[idx].Statistics.PlantsHarvested >= 5 },
                { "Harvested Plants +", () => GameManager.Players[idx].Statistics.PlantsHarvested >= 50 },
                { "Harvested Plants ++", () => GameManager.Players[idx].Statistics.PlantsHarvested >= 500 },

                { "Hatched Eggs", () => GameManager.Players[idx].Statistics.EggsHatched >= 5 },
                { "Hatched Eggs +", () => GameManager.Players[idx].Statistics.EggsHatched >= 25 },
                { "Hatched Eggs ++", () => GameManager.Players[idx].Statistics.EggsHatched >= 100 },

                { "Terraformed Tiles", () => GameManager.Players[idx].Statistics.TilesTerraformed >= 5 },
                { "Terraformed Tiles +", () => GameManager.Players[idx].Statistics.TilesTerraformed >= 25 },
                { "Terraformed Tiles ++", () => GameManager.Players[idx].Statistics.TilesTerraformed >= 100 },

                { "Constructed Buildings", () => GameManager.Players[idx].Statistics.BuildingsConstructed >= 5 },
                { "Constructed Buildings +", () => GameManager.Players[idx].Statistics.BuildingsConstructed >= 25 },
                { "Constructed Buildings ++", () => GameManager.Players[idx].Statistics.BuildingsConstructed >= 100 },

                { "Researched Nodes", () => GameManager.Players[idx].Statistics.NodesResearched >= 50 },
                { "Researched Nodes +", () => GameManager.Players[idx].Statistics.NodesResearched >= 100 },
                { "Researched Nodes ++", () => GameManager.Players[idx].Statistics.NodesResearched >= 150 },

                { "Collected Research", () => GameManager.Players[idx].Statistics.ResearchCollected >= 25000 },
                { "Collected Power", () => GameManager.Players[idx].Statistics.PowerCollected >= 100000 },
                { "Collected Water", () => GameManager.Players[idx].Statistics.WaterCollected >= 5000 },
                { "Collected Food", () => GameManager.Players[idx].Statistics.FoodCollected >= 5000 },
                { "Collected Concrete", () => GameManager.Players[idx].Statistics.ConcreteCollected >= 500 },
                { "Collected Metal", () => GameManager.Players[idx].Statistics.MetalCollected >= 500 },
                { "Collected Items", () => GameManager.Players[idx].Statistics.ItemsCollected >= 250 },
                { "Collected Units", () => GameManager.Players[idx].Statistics.UnitsCollected >= 250 },
                { "Collected Gold", () => GameManager.Players[idx].Statistics.GoldCollected >= 200000 },
                { "Collected Lootboxes", () => GameManager.Players[idx].Statistics.LootboxesCollected >= 250 },
                { "Collected Rush Boosts", () => GameManager.Players[idx].Statistics.RushBoostsCollected >= 500 },
                { "Collected Experience Boosts", () => GameManager.Players[idx].Statistics.ExperienceBoostsCollected >= 500 },
                { "Collected Rarity Boosts", () => GameManager.Players[idx].Statistics.RarityBoostsCollected >= 500 },
                { "Collected Monster Eggs", () => GameManager.Players[idx].Statistics.MonsterEggsCollected >= 250 },
                { "Collected Fertilizer", () => GameManager.Players[idx].Statistics.FertilizerCollected >= 2500 },
                { "Collected Mystery Seeds", () => GameManager.Players[idx].Statistics.MysterySeedsCollected >= 250 },
            };
        }
    }
}