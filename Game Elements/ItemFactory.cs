namespace Game_Elements
{
    public static class ItemFactory
    {
        public static Item GenerateRandomItem(int playerIndex)
        {
            // Randomized name
            string name = GameManager.Players[playerIndex].ItemFactoryNames[Random.Shared.Next(GameManager.Players[playerIndex].ItemFactoryNames.Count)];

            // Randomized rarity
            Rarity rarity = Random.Shared.Next(0, 100) switch
            {
                > 98 => Rarity.Legendary,
                > 94 => Rarity.Epic,
                > 78 => Rarity.Rare,
                _ => Rarity.Common
            };

            // Price multiplier is based on item rarity
            int priceMultiplier = rarity switch
            {
                Rarity.Legendary => 16,
                Rarity.Epic => 8,
                Rarity.Rare => 4,
                _ => 1
            };

            // Sell price uses reward multiplier
            // It can also be modified by nodes in the research tree
            int modifiedSellPrice = priceMultiplier * (Random.Shared.Next(100) + (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemSellPrice, StarterValues.ItemSellPrice));

            return new Item
            {
                Name = name,
                Rarity = rarity,
                SellPrice = modifiedSellPrice
            };
        }

        public static Item GenerateRandomPlantItem(int playerIndex)
        {
            // Randomized name (plant variant)
            string name = GameManager.Players[playerIndex].PlantItemFactoryNames[Random.Shared.Next(GameManager.Players[playerIndex].PlantItemFactoryNames.Count)];

            // Randomized rarity
            Rarity rarity = Random.Shared.Next(0, 100) switch
            {
                > 98 => Rarity.Legendary,
                > 94 => Rarity.Epic,
                > 78 => Rarity.Rare,
                _ => Rarity.Common
            };

            // Price multiplier is based on item rarity
            int priceMultiplier = rarity switch
            {
                Rarity.Legendary => 16,
                Rarity.Epic => 8,
                Rarity.Rare => 4,
                _ => 1
            };

            // Sell price uses reward multiplier
            // It can also be modified by nodes in the research tree
            int modifiedSellPrice = priceMultiplier * (Random.Shared.Next(100) + (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemSellPrice, StarterValues.PlantItemSellPrice));

            return new Item
            {
                Name = name,
                Rarity = rarity,
                SellPrice = modifiedSellPrice
            };
        }

        public static Item GenerateRandomJunkItem(int playerIndex)
        {
            // Randomized name (junk variant)
            string name = GameManager.Players[playerIndex].JunkItemFactoryNames[Random.Shared.Next(GameManager.Players[playerIndex].JunkItemFactoryNames.Count)];

            return new Item
            {
                Name = name,
                Rarity = Rarity.Common,
                SellPrice = StarterValues.JunkItemSellPrice
            };
        }
    }
}