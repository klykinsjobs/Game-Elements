using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;
using System.Data;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace Game_Elements
{
    public partial class QuestsForm : Form
    {
        private Quest? _selectedQuest = null;

        private readonly Timer _colorTransitionTimer;
        private readonly List<ColorTransition> _transitions = [];
        private readonly Dictionary<Rarity, Color> _rarityColors;
        private const int TransitionSteps = 20;
        private const int TimerIntervalMs = 30;

        private readonly Dictionary<int, Panel> _slotBorderPanels;
        private readonly Dictionary<int, TableLayoutPanel> _slotTLPs;
        private readonly Dictionary<int, Label> _slotLabels;

        public QuestsForm()
        {
            InitializeComponent();

            // Initialize dictionaries
            _rarityColors = new Dictionary<Rarity, Color>
            {
                { Rarity.Common, Properties.Settings.Default.CommonRarityColor },
                { Rarity.Rare, Properties.Settings.Default.RareRarityColor },
                { Rarity.Epic, Properties.Settings.Default.EpicRarityColor },
                { Rarity.Legendary, Properties.Settings.Default.LegendaryRarityColor },
            };

            _slotBorderPanels = new Dictionary<int, Panel>
            {
                { 0, FirstPageItemBorderPanel },
                { 1, SecondPageItemBorderPanel },
                { 2, ThirdPageItemBorderPanel },
                { 3, FourthPageItemBorderPanel },
                { 4, FifthPageItemBorderPanel },
                { 5, SixthPageItemBorderPanel }
            };

            _slotTLPs = new Dictionary<int, TableLayoutPanel>
            {
                { 0, FirstPageItemTLP },
                { 1, SecondPageItemTLP },
                { 2, ThirdPageItemTLP },
                { 3, FourthPageItemTLP },
                { 4, FifthPageItemTLP },
                { 5, SixthPageItemTLP }
            };

            _slotLabels = new Dictionary<int, Label>
            {
                { 0, FirstPageItemLabel },
                { 1, SecondPageItemLabel },
                { 2, ThirdPageItemLabel },
                { 3, FourthPageItemLabel },
                { 4, FifthPageItemLabel },
                { 5, SixthPageItemLabel }
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
                GameManager.CurrentPlayer.Quests.ListChanged += Quests_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for current player
            UpdatePage();
            UpdateUI();
        }

        private void QuestsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop and dispose timer
            _colorTransitionTimer.Stop();
            _colorTransitionTimer.Dispose();

            // Deselect selection (which will unsubscribe)
            if (_selectedQuest != null)
                DeselectPageItem();

            // Dispose tool tip
            QuestsToolTip.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Quests.ListChanged -= Quests_ListChanged;
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

            // Deselect selection (which will unsubscribe)
            if (_selectedQuest != null)
                DeselectPageItem();

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Quests.ListChanged -= Quests_ListChanged;
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Quests.ListChanged += Quests_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            UpdatePage();
            UpdateUI();
        }

        private void SelectedQuest_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Quest.Progress))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
            else if (e.PropertyName == nameof(Quest.Completed)
                || e.PropertyName == nameof(Quest.Dismissed))
            {
                // Deselect selection (which will unsubscribe)
                if (_selectedQuest != null)
                    DeselectPageItem();

                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void Quests_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded
                || e.ListChangedType == ListChangedType.ItemDeleted
                || e.ListChangedType == ListChangedType.Reset)
            {
                // Update UI to reflect changes
                UpdatePage();
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null)
            {
                if (e.PropertyDescriptor.Name == "Progress"
                    || e.PropertyDescriptor.Name == "Completed"
                    || e.PropertyDescriptor.Name == "Dismissed")
                {
                    // Update UI to reflect changes
                    UpdatePage();
                }
            }
        }

        private void Modifiers_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset ||
                (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null && e.PropertyDescriptor.Name == "ModifierQuantity"))
            {
                // Update UI to reflect modifier changes
                UpdatePage();
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            QuestsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            PageBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            PageBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            PageTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            PageTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            FirstPageItemBorderPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            FirstPageItemBorderPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            FirstPageItemTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            FirstPageItemTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            FirstPageItemLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FirstPageItemLabel.Font = new Font(FirstPageItemLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SecondPageItemBorderPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            SecondPageItemBorderPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            SecondPageItemTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            SecondPageItemTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            SecondPageItemLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SecondPageItemLabel.Font = new Font(SecondPageItemLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ThirdPageItemBorderPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ThirdPageItemBorderPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ThirdPageItemTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ThirdPageItemTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ThirdPageItemLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ThirdPageItemLabel.Font = new Font(ThirdPageItemLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FourthPageItemBorderPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            FourthPageItemBorderPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            FourthPageItemTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            FourthPageItemTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            FourthPageItemLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FourthPageItemLabel.Font = new Font(FourthPageItemLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FifthPageItemBorderPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            FifthPageItemBorderPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            FifthPageItemTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            FifthPageItemTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            FifthPageItemLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FifthPageItemLabel.Font = new Font(FifthPageItemLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SixthPageItemBorderPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            SixthPageItemBorderPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            SixthPageItemTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            SixthPageItemTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            SixthPageItemLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SixthPageItemLabel.Font = new Font(SixthPageItemLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            DismissButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            DismissButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            DismissButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            DismissButton.Font = new Font(DismissButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            SelectionBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            SelectionBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            SelectionTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            SelectionTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            DeselectButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            DeselectButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            DeselectButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            DeselectButton.Font = new Font(DeselectButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            SelectionLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SelectionLabel.Font = new Font(SelectionLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            // The page item controls share their own respective click handlers
            FirstPageItemBorderPanel.Click += FirstControl_Click;
            FirstPageItemTLP.Click += FirstControl_Click;
            FirstPageItemLabel.Click += FirstControl_Click;

            SecondPageItemBorderPanel.Click += SecondControl_Click;
            SecondPageItemTLP.Click += SecondControl_Click;
            SecondPageItemLabel.Click += SecondControl_Click;

            ThirdPageItemBorderPanel.Click += ThirdControl_Click;
            ThirdPageItemTLP.Click += ThirdControl_Click;
            ThirdPageItemLabel.Click += ThirdControl_Click;

            FourthPageItemBorderPanel.Click += FourthControl_Click;
            FourthPageItemTLP.Click += FourthControl_Click;
            FourthPageItemLabel.Click += FourthControl_Click;

            FifthPageItemBorderPanel.Click += FifthControl_Click;
            FifthPageItemTLP.Click += FifthControl_Click;
            FifthPageItemLabel.Click += FifthControl_Click;

            SixthPageItemBorderPanel.Click += SixthControl_Click;
            SixthPageItemTLP.Click += SixthControl_Click;
            SixthPageItemLabel.Click += SixthControl_Click;
        }

        private void UpdatePage()
        {
            // Update page for current player

            if (GameManager.CurrentPlayer == null)
                return;

            // Get the page items for this page
            var pageItems = GameManager.CurrentPlayer.Quests.Where(q => !q.Completed && !q.Dismissed).Take(6).ToList();

            // Update the page item controls
            for (int i = 0; i < 6; i++)
            {
                if (pageItems.Count > i)
                {
                    // Singular / plural
                    string questType = pageItems[i].QuestType switch
                    {
                        QuestType.StartMission => pageItems[i].Target > 1 ? "Start Missions" : "Start Mission",
                        QuestType.SucceedMission => pageItems[i].Target > 1 ? "Succeed Missions" : "Succeed Mission",
                        QuestType.FailMission => pageItems[i].Target > 1 ? "Fail Missions" : "Fail Mission",
                        QuestType.LevelUpUnit => pageItems[i].Target > 1 ? "Level Up Units" : "Level Up Unit",
                        QuestType.OpenLootbox => pageItems[i].Target > 1 ? "Open Lootboxes" : "Open Lootbox",
                        QuestType.UseRushBoost => pageItems[i].Target > 1 ? "Use Rush Boosts" : "Use Rush Boost",
                        QuestType.UseExperienceBoost => pageItems[i].Target > 1 ? "Use Experience Boosts" : "Use Experience Boost",
                        QuestType.UseRarityBoost => pageItems[i].Target > 1 ? "Use Rarity Boosts" : "Use Rarity Boost",
                        QuestType.SellItem => pageItems[i].Target > 1 ? "Sell Items" : "Sell Item",
                        QuestType.BuyItem => pageItems[i].Target > 1 ? "Buy Items" : "Buy Item",
                        QuestType.UnlockAchievement => pageItems[i].Target > 1 ? "Unlock Achievements" : "Unlock Achievement",
                        QuestType.CompleteQuest => pageItems[i].Target > 1 ? "Complete Quests" : "Complete Quest",
                        QuestType.DismissQuest => pageItems[i].Target > 1 ? "Dismiss Quests" : "Dismiss Quest",
                        QuestType.CaughtFish => "Caught Fish",
                        QuestType.HarvestPlant => pageItems[i].Target > 1 ? "Harvest Plants" : "Harvest Plant",
                        QuestType.HatchEgg => pageItems[i].Target > 1 ? "Hatch Eggs" : "Hatch Egg",
                        QuestType.TerraformTile => pageItems[i].Target > 1 ? "Terraform Tiles" : "Terraform Tile",
                        QuestType.ConstructBuilding => pageItems[i].Target > 1 ? "Construct Buildings" : "Construct Building",
                        QuestType.ResearchNode => pageItems[i].Target > 1 ? "Research Nodes" : "Research Node",
                        QuestType.CollectResearch => "Collect Research",
                        QuestType.CollectPower => "Collect Power",
                        QuestType.CollectWater => "Collect Water",
                        QuestType.CollectFood => "Collect Food",
                        QuestType.CollectConcrete => "Collect Concrete",
                        QuestType.CollectMetal => "Collect Metal",
                        QuestType.CollectItem => pageItems[i].Target > 1 ? "Collect Items" : "Collect Item",
                        QuestType.CollectUnit => pageItems[i].Target > 1 ? "Collect Units" : "Collect Unit",
                        QuestType.CollectGold => "Collect Gold",
                        QuestType.CollectLootbox => pageItems[i].Target > 1 ? "Collect Lootboxes" : "Collect Lootbox",
                        QuestType.CollectRushBoost => pageItems[i].Target > 1 ? "Collect Rush Boosts" : "Collect Rush Boost",
                        QuestType.CollectExperienceBoost => pageItems[i].Target > 1 ? "Collect Experience Boosts" : "Collect Experience Boost",
                        QuestType.CollectRarityBoost => pageItems[i].Target > 1 ? "Collect Rarity Boosts" : "Collect Rarity Boost",
                        QuestType.CollectMonsterEgg => pageItems[i].Target > 1 ? "Collect Monster Eggs" : "Collect Monster Egg",
                        QuestType.CollectFertilizer => "Collect Fertilizer",
                        QuestType.CollectMysterySeed => pageItems[i].Target > 1 ? "Collect Mystery Seeds" : "Collect Mystery Seed",
                        _ => "Unknown Quest"
                    };

                    // Update the label with relevant quest details
                    _slotLabels[i].Text = (!pageItems[i].Completed && !pageItems[i].Dismissed) ? $"{questType}\n{pageItems[i].Progress}/{pageItems[i].Target}" : "";

                    // Animate border panel to match quest rarity
                    if (_rarityColors.TryGetValue(pageItems[i].Rarity, out var newColor))
                    {
                        StartColorTransition(_slotBorderPanels[i], newColor);
                    }

                    // Build tooltip with relevant quest details
                    StringBuilder questDetailsSB = new();
                    questDetailsSB.Append($"Quest: {questType}\n\n");

                    // Loot
                    questDetailsSB.Append("Loot:\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Gold, out var gold) && gold > 0)
                        questDetailsSB.Append($"Gold: {gold}\n");

                    if (pageItems[i].Loots.Units.Count > 0)
                        foreach (var unit in pageItems[i].Loots.Units)
                            questDetailsSB.Append($"Unit: {unit.Name} ({unit.Rarity})\n");

                    if (pageItems[i].Loots.Items.Count > 0)
                        foreach (var item in pageItems[i].Loots.Items)
                            questDetailsSB.Append($"Item: {item.Name} ({item.Rarity})\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Lootbox, out var lootboxes) && lootboxes > 0)
                        questDetailsSB.Append($"Lootboxes: {lootboxes}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.MonsterEgg, out var monsterEggs) && monsterEggs > 0)
                        questDetailsSB.Append($"Monster Eggs: {monsterEggs}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.MysterySeed, out var mysterySeeds) && mysterySeeds > 0)
                        questDetailsSB.Append($"Mystery Seeds: {mysterySeeds}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.RarityBoost, out var rarityBoosts) && rarityBoosts > 0)
                        questDetailsSB.Append($"Rarity Boosts: {rarityBoosts}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.ExperienceBoost, out var experienceBoosts) && experienceBoosts > 0)
                        questDetailsSB.Append($"Experience Boosts: {experienceBoosts}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.RushBoost, out var rushBoosts) && rushBoosts > 0)
                        questDetailsSB.Append($"Rush Boosts: {rushBoosts}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Fertilizer, out var fertilizer) && fertilizer > 0)
                        questDetailsSB.Append($"Fertilizer: {fertilizer}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Water, out var water) && water > 0)
                        questDetailsSB.Append($"Water: {water}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Food, out var food) && food > 0)
                        questDetailsSB.Append($"Food: {food}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Concrete, out var concrete) && concrete > 0)
                        questDetailsSB.Append($"Concrete: {concrete}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Metal, out var metal) && metal > 0)
                        questDetailsSB.Append($"Metal: {metal}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Power, out var power) && power > 0)
                        questDetailsSB.Append($"Power: {power}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Research, out var research) && research > 0)
                        questDetailsSB.Append($"Research: {research}\n");

                    string toolTipCaption = questDetailsSB.ToString().TrimEnd();

                    // Set tooltips
                    string? currentToolTip = QuestsToolTip.GetToolTip(_slotBorderPanels[i]);
                    if (currentToolTip != toolTipCaption)
                    {
                        QuestsToolTip.SetToolTip(_slotBorderPanels[i], toolTipCaption);
                        QuestsToolTip.SetToolTip(_slotLabels[i], toolTipCaption);
                        QuestsToolTip.SetToolTip(_slotTLPs[i], toolTipCaption);
                    }
                }
                else
                {
                    // Reset label
                    _slotLabels[i].Text = "";

                    // Animate border panel back to default
                    StartColorTransition(_slotBorderPanels[i], Properties.Settings.Default.SecondaryBackColor);

                    // Reset tooltips
                    QuestsToolTip.SetToolTip(_slotBorderPanels[i], "");
                    QuestsToolTip.SetToolTip(_slotLabels[i], "");
                    QuestsToolTip.SetToolTip(_slotTLPs[i], "");
                }
            }

            // Start color transition timer to animate border panels
            _colorTransitionTimer.Start();
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (_selectedQuest != null)
            {
                DeselectButton.Enabled = true;

                var progress = (double)_selectedQuest.Progress / _selectedQuest.Target;
                ProgressPB.Value = Math.Clamp((int)(progress * 100), 0, 100);

                // Singular / plural
                string questType = _selectedQuest.QuestType switch
                {
                    QuestType.StartMission => _selectedQuest.Target > 1 ? "Start Missions" : "Start Mission",
                    QuestType.SucceedMission => _selectedQuest.Target > 1 ? "Succeed Missions" : "Succeed Mission",
                    QuestType.FailMission => _selectedQuest.Target > 1 ? "Fail Missions" : "Fail Mission",
                    QuestType.LevelUpUnit => _selectedQuest.Target > 1 ? "Level Up Units" : "Level Up Unit",
                    QuestType.OpenLootbox => _selectedQuest.Target > 1 ? "Open Lootboxes" : "Open Lootbox",
                    QuestType.UseRushBoost => _selectedQuest.Target > 1 ? "Use Rush Boosts" : "Use Rush Boost",
                    QuestType.UseExperienceBoost => _selectedQuest.Target > 1 ? "Use Experience Boosts" : "Use Experience Boost",
                    QuestType.UseRarityBoost => _selectedQuest.Target > 1 ? "Use Rarity Boosts" : "Use Rarity Boost",
                    QuestType.SellItem => _selectedQuest.Target > 1 ? "Sell Items" : "Sell Item",
                    QuestType.BuyItem => _selectedQuest.Target > 1 ? "Buy Items" : "Buy Item",
                    QuestType.UnlockAchievement => _selectedQuest.Target > 1 ? "Unlock Achievements" : "Unlock Achievement",
                    QuestType.CompleteQuest => _selectedQuest.Target > 1 ? "Complete Quests" : "Complete Quest",
                    QuestType.DismissQuest => _selectedQuest.Target > 1 ? "Dismiss Quests" : "Dismiss Quest",
                    QuestType.CaughtFish => "Caught Fish",
                    QuestType.HarvestPlant => _selectedQuest.Target > 1 ? "Harvest Plants" : "Harvest Plant",
                    QuestType.HatchEgg => _selectedQuest.Target > 1 ? "Hatch Eggs" : "Hatch Egg",
                    QuestType.TerraformTile => _selectedQuest.Target > 1 ? "Terraform Tiles" : "Terraform Tile",
                    QuestType.ConstructBuilding => _selectedQuest.Target > 1 ? "Construct Buildings" : "Construct Building",
                    QuestType.ResearchNode => _selectedQuest.Target > 1 ? "Research Nodes" : "Research Node",
                    QuestType.CollectResearch => "Collect Research",
                    QuestType.CollectPower => "Collect Power",
                    QuestType.CollectWater => "Collect Water",
                    QuestType.CollectFood => "Collect Food",
                    QuestType.CollectConcrete => "Collect Concrete",
                    QuestType.CollectMetal => "Collect Metal",
                    QuestType.CollectItem => _selectedQuest.Target > 1 ? "Collect Items" : "Collect Item",
                    QuestType.CollectUnit => _selectedQuest.Target > 1 ? "Collect Units" : "Collect Unit",
                    QuestType.CollectGold => "Collect Gold",
                    QuestType.CollectLootbox => _selectedQuest.Target > 1 ? "Collect Lootboxes" : "Collect Lootbox",
                    QuestType.CollectRushBoost => _selectedQuest.Target > 1 ? "Collect Rush Boosts" : "Collect Rush Boost",
                    QuestType.CollectExperienceBoost => _selectedQuest.Target > 1 ? "Collect Experience Boosts" : "Collect Experience Boost",
                    QuestType.CollectRarityBoost => _selectedQuest.Target > 1 ? "Collect Rarity Boosts" : "Collect Rarity Boost",
                    QuestType.CollectMonsterEgg => _selectedQuest.Target > 1 ? "Collect Monster Eggs" : "Collect Monster Egg",
                    QuestType.CollectFertilizer => "Collect Fertilizer",
                    QuestType.CollectMysterySeed => _selectedQuest.Target > 1 ? "Collect Mystery Seeds" : "Collect Mystery Seed",
                    _ => "Unknown Quest"
                };
                SelectionLabel.Text = $"Selected: {questType} ({_selectedQuest.Progress}/{_selectedQuest.Target})";

                DismissButton.Enabled = true;
            }
            else
            {
                DeselectButton.Enabled = false;
                ProgressPB.Value = 0;
                SelectionLabel.Text = "Selected: None";
                DismissButton.Enabled = false;
            }
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

        private void SelectPageItem(int index)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Deselect if anything already selected
            if (_selectedQuest != null)
                DeselectPageItem();

            // Limit selectable quests to those that haven't been completed or dismissed
            var activeQuests = GameManager.CurrentPlayer.Quests.Where(q => !q.Completed && !q.Dismissed).ToList();

            if (index < activeQuests.Count)
            {
                // Get new selection
                _selectedQuest = activeQuests[index];
                if (_selectedQuest != null)
                {
                    // Subscribe to its property changes
                    _selectedQuest.PropertyChanged += SelectedQuest_PropertyChanged;
                }
            }

            // Update UI to reflect changes
            UpdateUI();
        }

        private void FirstControl_Click(object? sender, EventArgs e) => SelectPageItem(0);
        private void SecondControl_Click(object? sender, EventArgs e) => SelectPageItem(1);
        private void ThirdControl_Click(object? sender, EventArgs e) => SelectPageItem(2);
        private void FourthControl_Click(object? sender, EventArgs e) => SelectPageItem(3);
        private void FifthControl_Click(object? sender, EventArgs e) => SelectPageItem(4);
        private void SixthControl_Click(object? sender, EventArgs e) => SelectPageItem(5);

        private void DeselectPageItem()
        {
            if (_selectedQuest != null)
            {
                // Unsubscribe
                _selectedQuest.PropertyChanged -= SelectedQuest_PropertyChanged;

                // Reset
                _selectedQuest = null;
            }
        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            if (_selectedQuest != null)
            {
                DeselectPageItem();
                UpdateUI();
            }
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedQuest == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex != -1)
            {
                // Dismiss this quest
                _selectedQuest.Dismissed = true;

                // Update quests and statistics
                GameManager.TryQuestProgress(playerIndex, QuestType.DismissQuest, 1);
                GameManager.Players[playerIndex].Statistics.QuestsDismissed += 1;

                OutputService.Write(true, [new($"Quest dismissed!", Properties.Settings.Default.PrimaryForeColor)]);
            }
        }
    }
}