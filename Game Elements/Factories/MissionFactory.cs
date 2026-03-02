using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;

namespace Game_Elements.Factories
{
    public static class MissionFactory
    {
        public static Mission GenerateRandomMission(int playerIndex)
        {
            // Randomized name
            string name = GameManager.Players[playerIndex].MissionFactoryNames[Random.Shared.Next(GameManager.Players[playerIndex].MissionFactoryNames.Count)];

            // Random level from 1 to the highest unit level
            var unitLevels = GameManager.Players[playerIndex].Inventory.Units.Select(u => u.Level).ToList();
            int maxLevel = unitLevels.Count != 0 ? unitLevels.Max() : 1;
            int level = Random.Shared.Next(1, maxLevel + 1);

            // Randomized rarity
            Rarity rarity = Random.Shared.Next(0, 100) switch
            {
                > 98 => Rarity.Legendary,
                > 94 => Rarity.Epic,
                > 78 => Rarity.Rare,
                _ => Rarity.Common
            };

            // Number of elements are based on mission rarity
            int elementCount = rarity switch
            {
                Rarity.Legendary => 3,
                Rarity.Epic => 2,
                Rarity.Rare => 1,
                _ => 0
            };

            // If this mission has elements, get random ones
            List<Element> elements = [];
            if (elementCount > 0)
            {
                // Random element(s)
                Element[] elementTypes = Enum.GetValues<Element>();
                List<Element> shuffledElements = [.. elementTypes.OrderBy(_ => Random.Shared.Next())];
                elements.AddRange(shuffledElements.Take(elementCount));
            }

            // Reward multiplier is based on mission rarity
            int rewardMultiplier = rarity switch
            {
                Rarity.Legendary => 8,
                Rarity.Epic => 4,
                Rarity.Rare => 2,
                _ => 1
            };

            // Experience and gold both use reward multiplier
            // Both can also be modified by nodes in the research tree
            int modifiedExperienceAmount = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionExperienceAmount, rewardMultiplier * (25 + (level - 1) * 5));
            int modifiedGoldAmount = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionGoldAmount, Random.Shared.Next(rewardMultiplier * 1 * level, rewardMultiplier * 3 * level));

            // All remaining loot odds are based on mission rarity
            // They can also be modified by nodes in the research tree
            double lootboxOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedLootboxOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionLootboxOdds, lootboxOdds);
            bool awardLootbox = Random.Shared.NextDouble() < modifiedLootboxOdds / 100;

            double rushBoostOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedRushBoostOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionRushBoostOdds, rushBoostOdds);
            bool awardRushBoost = Random.Shared.NextDouble() < modifiedRushBoostOdds / 100;

            double experienceBoostOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedExperienceBoostOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionExperienceBoostOdds, experienceBoostOdds);
            bool awardExperienceBoost = Random.Shared.NextDouble() < modifiedExperienceBoostOdds / 100;

            double rarityBoostOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedRarityBoostOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionRarityBoostOdds, rarityBoostOdds);
            bool awardRarityBoost = Random.Shared.NextDouble() < modifiedRarityBoostOdds / 100;

            double powerOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedPowerOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionPowerOdds, powerOdds);
            bool awardPower = Random.Shared.NextDouble() < modifiedPowerOdds / 100;

            double waterOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedWaterOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionWaterOdds, waterOdds);
            bool awardWater = Random.Shared.NextDouble() < modifiedWaterOdds / 100;

            double foodOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedFoodOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionFoodOdds, foodOdds);
            bool awardFood = Random.Shared.NextDouble() < modifiedFoodOdds / 100;

            double concreteOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedConcreteOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionConcreteOdds, concreteOdds);
            bool awardConcrete = Random.Shared.NextDouble() < modifiedConcreteOdds / 100;

            double metalOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedMetalOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionMetalOdds, metalOdds);
            bool awardMetal = Random.Shared.NextDouble() < modifiedMetalOdds / 100;

            double fertilizerOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedFertilizerOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionFertilizerOdds, fertilizerOdds);
            bool awardFertilizer = Random.Shared.NextDouble() < modifiedFertilizerOdds / 100;

            double monsterEggOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedMonsterEggOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionMonsterEggOdds, monsterEggOdds);
            bool awardMonsterEgg = Random.Shared.NextDouble() < modifiedMonsterEggOdds / 100;

            double mysterySeedOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedMysterySeedOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionMysterySeedOdds, mysterySeedOdds);
            bool awardMysterySeed = Random.Shared.NextDouble() < modifiedMysterySeedOdds / 100;

            double itemOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedItemOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionItemOdds, itemOdds);
            bool awardItem = Random.Shared.NextDouble() < modifiedItemOdds / 100;
            List<Item> items = [];
            if (awardItem)
                items.Add(ItemFactory.GenerateRandomItem(playerIndex));

            double unitOdds = rarity switch
            {
                Rarity.Legendary => 8.0,
                Rarity.Epic => 4.0,
                Rarity.Rare => 2.0,
                _ => 1.0
            };
            double modifiedUnitOdds = GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionUnitOdds, unitOdds);
            bool awardUnit = Random.Shared.NextDouble() < modifiedUnitOdds / 100;
            List<Unit> units = [];
            if (awardUnit)
                units.Add(UnitFactory.GenerateRandomUnit(playerIndex));

            // Fill loot
            Loot loots = new();
            loots.LootQuantities.Add(LootType.Gold, modifiedGoldAmount);
            if (awardLootbox) loots.LootQuantities.Add(LootType.Lootbox, 1);
            if (awardRushBoost) loots.LootQuantities.Add(LootType.RushBoost, 1);
            if (awardExperienceBoost) loots.LootQuantities.Add(LootType.ExperienceBoost, 1);
            if (awardRarityBoost) loots.LootQuantities.Add(LootType.RarityBoost, 1);
            if (awardPower) loots.LootQuantities.Add(LootType.Power, 1);
            if (awardWater) loots.LootQuantities.Add(LootType.Water, 1);
            if (awardFood) loots.LootQuantities.Add(LootType.Food, 1);
            if (awardConcrete) loots.LootQuantities.Add(LootType.Concrete, 1);
            if (awardMetal) loots.LootQuantities.Add(LootType.Metal, 1);
            if (awardMonsterEgg) loots.LootQuantities.Add(LootType.MonsterEgg, 1);
            if (awardFertilizer) loots.LootQuantities.Add(LootType.Fertilizer, 1);
            if (awardMysterySeed) loots.LootQuantities.Add(LootType.MysterySeed, 1);
            loots.Items = items;
            loots.Units = units;

            // Duration is based on mission rarity
            // It can also be modified by nodes in the research tree
            TimeSpan duration = rarity switch
            {
                Rarity.Legendary => TimeSpan.FromMilliseconds(GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionDuration, StarterValues.LegendaryMissionDuration)),
                Rarity.Epic => TimeSpan.FromMilliseconds(GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionDuration, StarterValues.EpicMissionDuration)),
                Rarity.Rare => TimeSpan.FromMilliseconds(GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionDuration, StarterValues.RareMissionDuration)),
                _ => TimeSpan.FromMilliseconds(GameManager.ApplyModifiers(playerIndex, ModifierTarget.MissionDuration, StarterValues.CommonMissionDuration))
            };

            // 5 minute expiration
            DateTime expiration = DateTime.Now + TimeSpan.FromMinutes(5);

            return new Mission
            {
                Name = name,
                Level = level,
                Rarity = rarity,
                Elements = elements,
                Experience = modifiedExperienceAmount,
                Loots = loots,
                Duration = duration,
                Expiration = expiration,
                AssignedUnitGuids = [],
                MissionState = MissionState.Available
            };
        }
    }
}