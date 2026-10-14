using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;

namespace Game_Elements.Factories
{
    public static class UnitFactory
    {
        public static Unit GenerateRandomUnit(int playerIndex)
        {
            // Randomized name
            string name = GameManager.Players[playerIndex].UnitFactoryNames[Random.Shared.Next(GameManager.Players[playerIndex].UnitFactoryNames.Count)];

            // Randomized rarity
            Rarity rarity = Random.Shared.Next(0, 100) switch
            {
                > 98 => Rarity.Legendary,
                > 94 => Rarity.Epic,
                > 78 => Rarity.Rare,
                _ => Rarity.Common
            };

            return new Unit
            {
                Name = name,
                Level = 1,
                Experience = 0,
                Rarity = rarity,
                Element = null,
                HydrationLevel = Random.Shared.Next(80, 100),
                NourishmentLevel = Random.Shared.Next(80, 100),
                HappinessLevel = Random.Shared.Next(80, 100),
                UnitState = UnitState.Idle
            };
        }

        public static Unit GenerateRandomMonsterUnit(int playerIndex)
        {
            // Randomized name (monster variant)
            string name = GameManager.Players[playerIndex].MonsterUnitFactoryNames[Random.Shared.Next(GameManager.Players[playerIndex].MonsterUnitFactoryNames.Count)];

            // Randomized rarity
            Rarity rarity = Random.Shared.Next(0, 100) switch
            {
                > 98 => Rarity.Legendary,
                > 94 => Rarity.Epic,
                > 78 => Rarity.Rare,
                _ => Rarity.Common
            };

            return new Unit
            {
                Name = name,
                Level = 1,
                Experience = 0,
                Rarity = rarity,
                Element = null,
                HydrationLevel = Random.Shared.Next(80, 100),
                NourishmentLevel = Random.Shared.Next(80, 100),
                HappinessLevel = Random.Shared.Next(80, 100),
                UnitState = UnitState.Idle
            };
        }
    }
}