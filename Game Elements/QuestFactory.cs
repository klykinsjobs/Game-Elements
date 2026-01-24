namespace Game_Elements
{
    public static class QuestFactory
    {
        public static Quest GenerateRandomQuest(int playerIndex)
        {
            // Randomized rarity
            Rarity rarity = Random.Shared.Next(0, 100) switch
            {
                > 98 => Rarity.Legendary,
                > 94 => Rarity.Epic,
                > 78 => Rarity.Rare,
                _ => Rarity.Common
            };

            // Reward multiplier is based on quest rarity
            int rewardMultiplier = rarity switch
            {
                Rarity.Legendary => 8,
                Rarity.Epic => 4,
                Rarity.Rare => 2,
                _ => 1
            };

            // Randomized quest type
            QuestType[] questTypes = Enum.GetValues<QuestType>();
            QuestType questType = questTypes[Random.Shared.Next(questTypes.Length)];

            // Look up a sensible target for this quest type and rarity combination
            int target;
            if (SensibleTargets().TryGetValue((questType, rarity), out var sensibleTarget))
                target = sensibleTarget;
            else
                target = 1; // fallback

            // Gold uses reward multiplier
            // It can also be modified by nodes in the research tree
            int modifiedGoldAmount = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.QuestGoldAmount, rewardMultiplier * 25 * Random.Shared.Next(1, 6));

            // Fill loot
            Loot loots = new();
            loots.LootQuantities.Add(LootType.Gold, modifiedGoldAmount);

            return new Quest
            {
                QuestType = questType,
                Rarity = rarity,
                Target = target,
                Loots = loots
            };
        }

        // Helper to look up sensible target values based on quest type and rarity
        public static Dictionary<(QuestType, Rarity), int> SensibleTargets()
        {
            return new Dictionary<(QuestType, Rarity), int>
            {
                { (QuestType.StartMission, Rarity.Common), 3 },
                { (QuestType.StartMission, Rarity.Rare), 6 },
                { (QuestType.StartMission, Rarity.Epic), 9 },
                { (QuestType.StartMission, Rarity.Legendary), 12 },

                { (QuestType.SucceedMission, Rarity.Common), 2 },
                { (QuestType.SucceedMission, Rarity.Rare), 4 },
                { (QuestType.SucceedMission, Rarity.Epic), 6 },
                { (QuestType.SucceedMission, Rarity.Legendary), 8 },

                { (QuestType.FailMission, Rarity.Common), 1 },
                { (QuestType.FailMission, Rarity.Rare), 2 },
                { (QuestType.FailMission, Rarity.Epic), 3 },
                { (QuestType.FailMission, Rarity.Legendary), 4 },

                { (QuestType.LevelUpUnit, Rarity.Common), 1 },
                { (QuestType.LevelUpUnit, Rarity.Rare), 2 },
                { (QuestType.LevelUpUnit, Rarity.Epic), 3 },
                { (QuestType.LevelUpUnit, Rarity.Legendary), 4 },

                { (QuestType.OpenLootbox, Rarity.Common), 1 },
                { (QuestType.OpenLootbox, Rarity.Rare), 2 },
                { (QuestType.OpenLootbox, Rarity.Epic), 3 },
                { (QuestType.OpenLootbox, Rarity.Legendary), 4 },

                { (QuestType.UseRushBoost, Rarity.Common), 1 },
                { (QuestType.UseRushBoost, Rarity.Rare), 2 },
                { (QuestType.UseRushBoost, Rarity.Epic), 3 },
                { (QuestType.UseRushBoost, Rarity.Legendary), 4 },

                { (QuestType.UseExperienceBoost, Rarity.Common), 1 },
                { (QuestType.UseExperienceBoost, Rarity.Rare), 2 },
                { (QuestType.UseExperienceBoost, Rarity.Epic), 3 },
                { (QuestType.UseExperienceBoost, Rarity.Legendary), 4 },

                { (QuestType.UseRarityBoost, Rarity.Common), 1 },
                { (QuestType.UseRarityBoost, Rarity.Rare), 2 },
                { (QuestType.UseRarityBoost, Rarity.Epic), 3 },
                { (QuestType.UseRarityBoost, Rarity.Legendary), 4 },

                { (QuestType.SellItem, Rarity.Common), 1 },
                { (QuestType.SellItem, Rarity.Rare), 2 },
                { (QuestType.SellItem, Rarity.Epic), 3 },
                { (QuestType.SellItem, Rarity.Legendary), 4 },

                { (QuestType.BuyItem, Rarity.Common), 1 },
                { (QuestType.BuyItem, Rarity.Rare), 2 },
                { (QuestType.BuyItem, Rarity.Epic), 3 },
                { (QuestType.BuyItem, Rarity.Legendary), 4 },

                { (QuestType.UnlockAchievement, Rarity.Common), 1 },
                { (QuestType.UnlockAchievement, Rarity.Rare), 2 },
                { (QuestType.UnlockAchievement, Rarity.Epic), 3 },
                { (QuestType.UnlockAchievement, Rarity.Legendary), 4 },

                { (QuestType.CompleteQuest, Rarity.Common), 1 },
                { (QuestType.CompleteQuest, Rarity.Rare), 2 },
                { (QuestType.CompleteQuest, Rarity.Epic), 3 },
                { (QuestType.CompleteQuest, Rarity.Legendary), 4 },

                { (QuestType.DismissQuest, Rarity.Common), 1 },
                { (QuestType.DismissQuest, Rarity.Rare), 2 },
                { (QuestType.DismissQuest, Rarity.Epic), 3 },
                { (QuestType.DismissQuest, Rarity.Legendary), 4 },

                { (QuestType.CaughtFish, Rarity.Common), 1 },
                { (QuestType.CaughtFish, Rarity.Rare), 2 },
                { (QuestType.CaughtFish, Rarity.Epic), 3 },
                { (QuestType.CaughtFish, Rarity.Legendary), 4 },

                { (QuestType.HarvestPlant, Rarity.Common), 1 },
                { (QuestType.HarvestPlant, Rarity.Rare), 2 },
                { (QuestType.HarvestPlant, Rarity.Epic), 3 },
                { (QuestType.HarvestPlant, Rarity.Legendary), 4 },

                { (QuestType.HatchEgg, Rarity.Common), 1 },
                { (QuestType.HatchEgg, Rarity.Rare), 2 },
                { (QuestType.HatchEgg, Rarity.Epic), 3 },
                { (QuestType.HatchEgg, Rarity.Legendary), 4 },

                { (QuestType.TerraformTile, Rarity.Common), 1 },
                { (QuestType.TerraformTile, Rarity.Rare), 2 },
                { (QuestType.TerraformTile, Rarity.Epic), 3 },
                { (QuestType.TerraformTile, Rarity.Legendary), 4 },

                { (QuestType.ConstructBuilding, Rarity.Common), 1 },
                { (QuestType.ConstructBuilding, Rarity.Rare), 2 },
                { (QuestType.ConstructBuilding, Rarity.Epic), 3 },
                { (QuestType.ConstructBuilding, Rarity.Legendary), 4 },

                { (QuestType.ResearchNode, Rarity.Common), 1 },
                { (QuestType.ResearchNode, Rarity.Rare), 2 },
                { (QuestType.ResearchNode, Rarity.Epic), 3 },
                { (QuestType.ResearchNode, Rarity.Legendary), 4 },

                { (QuestType.CollectResearch, Rarity.Common), 50 },
                { (QuestType.CollectResearch, Rarity.Rare), 100 },
                { (QuestType.CollectResearch, Rarity.Epic), 150 },
                { (QuestType.CollectResearch, Rarity.Legendary), 200 },

                { (QuestType.CollectPower, Rarity.Common), 25 },
                { (QuestType.CollectPower, Rarity.Rare), 50 },
                { (QuestType.CollectPower, Rarity.Epic), 75 },
                { (QuestType.CollectPower, Rarity.Legendary), 100 },

                { (QuestType.CollectWater, Rarity.Common), 25 },
                { (QuestType.CollectWater, Rarity.Rare), 50 },
                { (QuestType.CollectWater, Rarity.Epic), 75 },
                { (QuestType.CollectWater, Rarity.Legendary), 100 },

                { (QuestType.CollectFood, Rarity.Common), 25 },
                { (QuestType.CollectFood, Rarity.Rare), 50 },
                { (QuestType.CollectFood, Rarity.Epic), 75 },
                { (QuestType.CollectFood, Rarity.Legendary), 100 },

                { (QuestType.CollectConcrete, Rarity.Common), 5 },
                { (QuestType.CollectConcrete, Rarity.Rare), 10 },
                { (QuestType.CollectConcrete, Rarity.Epic), 15 },
                { (QuestType.CollectConcrete, Rarity.Legendary), 20 },

                { (QuestType.CollectMetal, Rarity.Common), 5 },
                { (QuestType.CollectMetal, Rarity.Rare), 10 },
                { (QuestType.CollectMetal, Rarity.Epic), 15 },
                { (QuestType.CollectMetal, Rarity.Legendary), 20 },

                { (QuestType.CollectItem, Rarity.Common), 1 },
                { (QuestType.CollectItem, Rarity.Rare), 2 },
                { (QuestType.CollectItem, Rarity.Epic), 3 },
                { (QuestType.CollectItem, Rarity.Legendary), 4 },

                { (QuestType.CollectUnit, Rarity.Common), 1 },
                { (QuestType.CollectUnit, Rarity.Rare), 2 },
                { (QuestType.CollectUnit, Rarity.Epic), 3 },
                { (QuestType.CollectUnit, Rarity.Legendary), 4 },

                { (QuestType.CollectGold, Rarity.Common), 1000 },
                { (QuestType.CollectGold, Rarity.Rare), 2000 },
                { (QuestType.CollectGold, Rarity.Epic), 3000 },
                { (QuestType.CollectGold, Rarity.Legendary), 4000 },

                { (QuestType.CollectLootbox, Rarity.Common), 1 },
                { (QuestType.CollectLootbox, Rarity.Rare), 2 },
                { (QuestType.CollectLootbox, Rarity.Epic), 3 },
                { (QuestType.CollectLootbox, Rarity.Legendary), 4 },

                { (QuestType.CollectRushBoost, Rarity.Common), 1 },
                { (QuestType.CollectRushBoost, Rarity.Rare), 2 },
                { (QuestType.CollectRushBoost, Rarity.Epic), 3 },
                { (QuestType.CollectRushBoost, Rarity.Legendary), 4 },

                { (QuestType.CollectExperienceBoost, Rarity.Common), 1 },
                { (QuestType.CollectExperienceBoost, Rarity.Rare), 2 },
                { (QuestType.CollectExperienceBoost, Rarity.Epic), 3 },
                { (QuestType.CollectExperienceBoost, Rarity.Legendary), 4 },

                { (QuestType.CollectRarityBoost, Rarity.Common), 1 },
                { (QuestType.CollectRarityBoost, Rarity.Rare), 2 },
                { (QuestType.CollectRarityBoost, Rarity.Epic), 3 },
                { (QuestType.CollectRarityBoost, Rarity.Legendary), 4 },

                { (QuestType.CollectMonsterEgg, Rarity.Common), 1 },
                { (QuestType.CollectMonsterEgg, Rarity.Rare), 2 },
                { (QuestType.CollectMonsterEgg, Rarity.Epic), 3 },
                { (QuestType.CollectMonsterEgg, Rarity.Legendary), 4 },

                { (QuestType.CollectFertilizer, Rarity.Common), 1 },
                { (QuestType.CollectFertilizer, Rarity.Rare), 2 },
                { (QuestType.CollectFertilizer, Rarity.Epic), 3 },
                { (QuestType.CollectFertilizer, Rarity.Legendary), 4 },

                { (QuestType.CollectMysterySeed, Rarity.Common), 1 },
                { (QuestType.CollectMysterySeed, Rarity.Rare), 2 },
                { (QuestType.CollectMysterySeed, Rarity.Epic), 3 },
                { (QuestType.CollectMysterySeed, Rarity.Legendary), 4 },
            };
        }
    }
}