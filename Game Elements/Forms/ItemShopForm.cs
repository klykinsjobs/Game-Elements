using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;

namespace Game_Elements
{
    public partial class ItemShopForm : Form
    {
        public ItemShopForm()
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for current player
            UpdateUI();

            OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Welcome to the Item Shop! No free samples.", Properties.Settings.Default.PrimaryForeColor, true, false, false)]);
        }

        private void ItemShopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }
        }

        private void GameManager_CurrentPlayerChanged(Player? previousPlayer)
        {
            // Ensure event runs on UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => GameManager_CurrentPlayerChanged(previousPlayer)));
                return;
            }

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            UpdateUI();
        }

        private void Inventory_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Update UI to reflect changes
            UpdateUI();
        }

        private void Modifiers_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset ||
                (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null && e.PropertyDescriptor.Name == "ModifierQuantity"))
            {
                // Update UI to reflect modifier changes
                UpdateUI();
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            ItemShopTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ItemsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ItemsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ItemsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ItemsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            BuyLootboxButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyLootboxButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyLootboxButton.FlatAppearance.BorderColor = Properties.Settings.Default.LegendaryRarityColor;
            BuyLootboxButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyLootboxButton.Font = new Font(BuyLootboxButton.Font.FontFamily, Properties.Settings.Default.LargeFontSize);

            BuyExperienceBoostButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyExperienceBoostButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyExperienceBoostButton.FlatAppearance.BorderColor = Properties.Settings.Default.EpicRarityColor;
            BuyExperienceBoostButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyExperienceBoostButton.Font = new Font(BuyExperienceBoostButton.Font.FontFamily, Properties.Settings.Default.LargeFontSize);

            BuyRarityBoostButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyRarityBoostButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyRarityBoostButton.FlatAppearance.BorderColor = Properties.Settings.Default.LegendaryRarityColor;
            BuyRarityBoostButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyRarityBoostButton.Font = new Font(BuyRarityBoostButton.Font.FontFamily, Properties.Settings.Default.LargeFontSize);

            BuyRushBoostButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyRushBoostButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyRushBoostButton.FlatAppearance.BorderColor = Properties.Settings.Default.RareRarityColor;
            BuyRushBoostButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyRushBoostButton.Font = new Font(BuyRushBoostButton.Font.FontFamily, Properties.Settings.Default.LargeFontSize);

            BuyWaterButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyWaterButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyWaterButton.FlatAppearance.BorderColor = Properties.Settings.Default.CommonRarityColor;
            BuyWaterButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyWaterButton.Font = new Font(BuyWaterButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            BuyFoodButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyFoodButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyFoodButton.FlatAppearance.BorderColor = Properties.Settings.Default.CommonRarityColor;
            BuyFoodButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyFoodButton.Font = new Font(BuyFoodButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            BuyConcreteButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyConcreteButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyConcreteButton.FlatAppearance.BorderColor = Properties.Settings.Default.CommonRarityColor;
            BuyConcreteButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyConcreteButton.Font = new Font(BuyConcreteButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            BuyMetalButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            BuyMetalButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuyMetalButton.FlatAppearance.BorderColor = Properties.Settings.Default.CommonRarityColor;
            BuyMetalButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            BuyMetalButton.Font = new Font(BuyMetalButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            // Item shop cost can be modified by nodes in the research tree
            int modifiedLootboxCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.LootboxCost);
            int modifiedRarityBoostCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.RarityBoostCost);
            int modifiedExperienceBoostCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.ExperienceBoostCost);
            int modifiedRushBoostCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.RushBoostCost);
            int modifiedConcreteCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.ConcreteCost);
            int modifiedMetalCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.MetalCost);
            int modifiedWaterCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.WaterCost);
            int modifiedFoodCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.FoodCost);

            // Update the buttons so they have the modified cost
            BuyLootboxButton.Text = $"Buy Lootbox\n({modifiedLootboxCost} gold)";
            BuyRarityBoostButton.Text = $"Buy Rarity Boost\n({modifiedRarityBoostCost} gold)";
            BuyExperienceBoostButton.Text = $"Buy Experience Boost\n({modifiedExperienceBoostCost} gold)";
            BuyRushBoostButton.Text = $"Buy Rush Boost\n({modifiedRushBoostCost} gold)";
            BuyConcreteButton.Text = $"Buy Concrete\n({modifiedConcreteCost} gold)";
            BuyMetalButton.Text = $"Buy Metal\n({modifiedMetalCost} gold)";
            BuyWaterButton.Text = $"Buy Water\n({modifiedWaterCost} gold)";
            BuyFoodButton.Text = $"Buy Food\n({modifiedFoodCost} gold)";
        }

        private void BuyLootboxButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedLootboxCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.LootboxCost);
            int maxLootboxes = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxLootboxes, StarterValues.MaxLootboxes);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedLootboxCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Lootbox. Cost: {modifiedLootboxCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.Lootboxes + 1 > maxLootboxes)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Lootboxes.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedLootboxCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.Lootbox, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Lootbox.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void BuyRarityBoostButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedRarityBoostCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.RarityBoostCost);
            int maxRarityBoosts = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRarityBoosts, StarterValues.MaxRarityBoosts);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedRarityBoostCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Rarity Boost. Cost: {modifiedRarityBoostCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.RarityBoosts + 1 > maxRarityBoosts)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Rarity Boosts.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedRarityBoostCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.RarityBoost, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Rarity Boost.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void BuyExperienceBoostButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedExperienceBoostCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.ExperienceBoostCost);
            int maxExperienceBoosts = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxExperienceBoosts, StarterValues.MaxExperienceBoosts);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedExperienceBoostCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Experience Boost. Cost: {modifiedExperienceBoostCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.ExperienceBoosts + 1 > maxExperienceBoosts)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Experience Boosts.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedExperienceBoostCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.ExperienceBoost, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Experience Boost.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void BuyRushBoostButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedRushBoostCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.RushBoostCost);
            int maxRushBoosts = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRushBoosts, StarterValues.MaxRushBoosts);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedRushBoostCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Rush Boost. Cost: {modifiedRushBoostCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.RushBoosts + 1 > maxRushBoosts)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Rush Boosts.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedRushBoostCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.RushBoost, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Rush Boost.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void BuyConcreteButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedConcreteCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.ConcreteCost);
            int maxConcrete = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxConcrete, StarterValues.MaxConcrete);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedConcreteCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Concrete. Cost: {modifiedConcreteCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.Concrete + 1 > maxConcrete)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Concrete.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedConcreteCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.Concrete, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Concrete.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void BuyMetalButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedMetalCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.MetalCost);
            int maxMetal = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMetal, StarterValues.MaxMetal);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedMetalCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Metal. Cost: {modifiedMetalCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.Metal + 1 > maxMetal)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Metal.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedMetalCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.Metal, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Metal.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void BuyWaterButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedWaterCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.WaterCost);
            int maxWater = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxWater, StarterValues.MaxWater);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedWaterCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Water. Cost: {modifiedWaterCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.Water + 1 > maxWater)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Water.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedWaterCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.Water, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Water.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void BuyFoodButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Item shop cost can be modified by nodes in the research tree
            // Max for this item can be boosted by building specific buildings
            int modifiedFoodCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ItemShopCost, StarterValues.FoodCost);
            int maxFood = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFood, StarterValues.MaxFood);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedFoodCost)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Not enough gold to buy Food. Cost: {modifiedFoodCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.Food + 1 > maxFood)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Can't hold any more Food.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedFoodCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.Food, 1);

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsBought += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.BuyItem, 1);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to buy Food.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }
    }
}