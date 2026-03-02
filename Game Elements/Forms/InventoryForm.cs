using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;
using System.Data;
using Timer = System.Windows.Forms.Timer;

namespace Game_Elements
{
    public partial class InventoryForm : Form
    {
        private readonly Timer _colorTransitionTimer;
        private readonly List<ColorTransition> _transitions = [];
        private readonly Dictionary<Rarity, Color> _rarityColors;
        private const int TransitionSteps = 20;
        private const int TimerIntervalMs = 30;

        public InventoryForm()
        {
            InitializeComponent();

            // Initialize dictionary
            _rarityColors = new Dictionary<Rarity, Color>
            {
                { Rarity.Common, Properties.Settings.Default.CommonRarityColor },
                { Rarity.Rare, Properties.Settings.Default.RareRarityColor },
                { Rarity.Epic, Properties.Settings.Default.EpicRarityColor },
                { Rarity.Legendary, Properties.Settings.Default.LegendaryRarityColor },
            };

            // Configure the timer
            _colorTransitionTimer = new Timer { Interval = TimerIntervalMs };
            _colorTransitionTimer.Tick += ColorTransitionTimer_Tick;

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.Inventory.Items.ListChanged += Items_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for current player
            UpdateUI();
        }

        private void InventoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop and dispose timer
            _colorTransitionTimer.Stop();
            _colorTransitionTimer.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                GameManager.CurrentPlayer.Inventory.Items.ListChanged -= Items_ListChanged;
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
                previousPlayer.Inventory.Items.ListChanged -= Items_ListChanged;
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.Inventory.Items.ListChanged += Items_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            UpdateUI();
        }

        private void Inventory_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Only refresh the UI element that needs refreshing

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            if (e.PropertyName == nameof(Inventory.Water))
            {
                WaterCountLabel.Text = $"Water: {GameManager.CurrentPlayer.Inventory.Water}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxWater, StarterValues.MaxWater)}";
            }
            else if (e.PropertyName == nameof(Inventory.Food))
            {
                FoodCountLabel.Text = $"Food: {GameManager.CurrentPlayer.Inventory.Food}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFood, StarterValues.MaxFood)}";
            }
            else if (e.PropertyName == nameof(Inventory.Concrete))
            {
                ConcreteCountLabel.Text = $"Concrete: {GameManager.CurrentPlayer.Inventory.Concrete}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxConcrete, StarterValues.MaxConcrete)}";
            }
            else if (e.PropertyName == nameof(Inventory.Metal))
            {
                MetalCountLabel.Text = $"Metal: {GameManager.CurrentPlayer.Inventory.Metal}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMetal, StarterValues.MaxMetal)}";
            }
            else if (e.PropertyName == nameof(Inventory.MonsterEggs))
            {
                MonsterEggsCountLabel.Text = $"Monster Eggs: {GameManager.CurrentPlayer.Inventory.MonsterEggs}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs)}";
            }
            else if (e.PropertyName == nameof(Inventory.MysterySeeds))
            {
                MysterySeedsCountLabel.Text = $"Mystery Seeds: {GameManager.CurrentPlayer.Inventory.MysterySeeds}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds)}";
            }
            else if (e.PropertyName == nameof(Inventory.Fertilizer))
            {
                FertilizerCountLabel.Text = $"Fertilizer: {GameManager.CurrentPlayer.Inventory.Fertilizer}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer)}";
            }
        }

        private void Items_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded
                || e.ListChangedType == ListChangedType.ItemDeleted
                || e.ListChangedType == ListChangedType.Reset)
            {
                // Update UI to reflect changes
                UpdateUI();
            }
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

            InventoryTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ItemsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ItemsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ItemsListBox.BackColor = Properties.Settings.Default.PrimaryBackColor;
            ItemsListBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ItemsListBox.Font = new Font(ItemsListBox.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
            ItemsListBox.ItemHeight = TextRenderer.MeasureText("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_+", ItemsListBox.Font).Height;

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            SellAllItemsButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            SellAllItemsButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SellAllItemsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            SellAllItemsButton.Font = new Font(SellAllItemsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ItemCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ItemCountLabel.Font = new Font(ItemCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            WaterCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            WaterCountLabel.Font = new Font(WaterCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FoodCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FoodCountLabel.Font = new Font(FoodCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ConcreteCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ConcreteCountLabel.Font = new Font(ConcreteCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MetalCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MetalCountLabel.Font = new Font(MetalCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MonsterEggsCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MonsterEggsCountLabel.Font = new Font(MonsterEggsCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MysterySeedsCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MysterySeedsCountLabel.Font = new Font(MysterySeedsCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FertilizerCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FertilizerCountLabel.Font = new Font(FertilizerCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SelectionBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            SelectionBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            SelectionTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            SelectionTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            SelectionLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SelectionLabel.Font = new Font(SelectionLabel.Font.FontFamily, Properties.Settings.Default.LargeFontSize);
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            ItemCountLabel.Text = $"Items: {GameManager.CurrentPlayer.Inventory.Items.Count}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxItems, StarterValues.MaxItems)}";
            WaterCountLabel.Text = $"Water: {GameManager.CurrentPlayer.Inventory.Water}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxWater, StarterValues.MaxWater)}";
            FoodCountLabel.Text = $"Food: {GameManager.CurrentPlayer.Inventory.Food}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFood, StarterValues.MaxFood)}";
            ConcreteCountLabel.Text = $"Concrete: {GameManager.CurrentPlayer.Inventory.Concrete}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxConcrete, StarterValues.MaxConcrete)}";
            MetalCountLabel.Text = $"Metal: {GameManager.CurrentPlayer.Inventory.Metal}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMetal, StarterValues.MaxMetal)}";
            MonsterEggsCountLabel.Text = $"Monster Eggs: {GameManager.CurrentPlayer.Inventory.MonsterEggs}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs)}";
            MysterySeedsCountLabel.Text = $"Mystery Seeds: {GameManager.CurrentPlayer.Inventory.MysterySeeds}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds)}";
            FertilizerCountLabel.Text = $"Fertilizer: {GameManager.CurrentPlayer.Inventory.Fertilizer}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer)}";

            ItemsListBox.DataSource = GameManager.CurrentPlayer.Inventory.Items;
            ItemsListBox_SelectedIndexChanged(ItemsListBox, EventArgs.Empty);
        }

        private void StartColorTransition(Panel panel, Color targetColor)
        {
            // If the panel is already the desired color, then no transition needed
            if (panel.BackColor == targetColor)
                return;

            // Remove any existing transitions for this panel
            _transitions.RemoveAll(t => t.Panel == panel);

            // Add a new transition entry starting from the current color
            _transitions.Add(new ColorTransition
            {
                Panel = panel,
                StartColor = panel.BackColor,
                TargetColor = targetColor,
                CurrentStep = 0,
                TotalSteps = TransitionSteps
            });
        }

        private void ColorTransitionTimer_Tick(object? sender, EventArgs e)
        {
            // Iterate backwards and remove finished transitions
            for (int i = _transitions.Count - 1; i >= 0; i--)
            {
                var t = _transitions[i];
                t.CurrentStep++;

                // Calculate interpolation ratio
                float ratio = t.CurrentStep / (float)t.TotalSteps;

                // Linearly interpolate each RGB component
                int r = (int)(t.StartColor.R + (t.TargetColor.R - t.StartColor.R) * ratio);
                int g = (int)(t.StartColor.G + (t.TargetColor.G - t.StartColor.G) * ratio);
                int b = (int)(t.StartColor.B + (t.TargetColor.B - t.StartColor.B) * ratio);

                // Apply the new color to the panel
                if (t.Panel != null)
                {
                    t.Panel.BackColor = Color.FromArgb(r, g, b);
                }

                // If transition is complete, remove it
                if (t.CurrentStep >= t.TotalSteps)
                {
                    _transitions.RemoveAt(i);
                }
            }

            // Stop the timer if no transitions remain
            if (_transitions.Count == 0)
                _colorTransitionTimer.Stop();
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is not Item selecteditem)
            {
                // Reset label
                SelectionLabel.Text = "No item selected.";

                // Animate border panel back to default
                StartColorTransition(SelectionBackPanel, Properties.Settings.Default.SecondaryBackColor);

                // Start color transition timer to animate panel
                _colorTransitionTimer.Start();
            }
            else
            {
                // Update the label with relevant item details
                SelectionLabel.Text = $"{selecteditem.Name}\n{selecteditem.Rarity}\n{selecteditem.SellPrice} gold";

                // Animate border panel to match item rarity
                if (_rarityColors.TryGetValue(selecteditem.Rarity, out var newColor))
                {
                    StartColorTransition(SelectionBackPanel, newColor);

                    // Start color transition timer to animate panel
                    _colorTransitionTimer.Start();
                }
            }
        }

        private void ItemsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem is not Item selectedItem)
            {
                return;
            }
            else
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"{selectedItem.Name} is not usable.", Properties.Settings.Default.ErrorTextColor)]);
            }
        }

        private void SellAllItemsButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            List<Item> itemsToSell = [.. GameManager.CurrentPlayer.Inventory.Items.Where(i => i.IsSellable != false)];
            if (itemsToSell.Count == 0)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("No items to sell.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                // Get the sum total
                int totalSellPrice = itemsToSell.Sum(i => i.SellPrice);

                Loot lootToRemove = new();
                foreach (var item in itemsToSell)
                    lootToRemove.Items.Add(item);

                // Remove all items
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    // Fill loot
                    Loot lootToAdd = new();
                    lootToAdd.LootQuantities.Add(LootType.Gold, totalSellPrice);

                    // Add gold
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.ItemsSold += itemsToSell.Count;
                    GameManager.TryQuestProgress(playerIndex, QuestType.SellItem, itemsToSell.Count);

                    OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Sold all items for {totalSellPrice} gold!", Properties.Settings.Default.PrimaryForeColor)]);
                }
                else
                {
                    OutputService.Write(true, [new($"Failed to sell all items.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }
    }
}