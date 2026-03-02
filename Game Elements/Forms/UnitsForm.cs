using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace Game_Elements
{
    public partial class UnitsForm : Form
    {
        private int _currentPage = 1;

        private const int PageSize = 4;

        private Unit? _selectedUnit = null;

        private readonly Timer _colorTransitionTimer;
        private readonly List<ColorTransition> _transitions = [];
        private readonly Dictionary<Rarity, Color> _rarityColors;
        private const int TransitionSteps = 20;
        private const int TimerIntervalMs = 30;

        private readonly Dictionary<int, Panel> _slotBorderPanels;
        private readonly Dictionary<int, Label> _slotLabels;
        private readonly Dictionary<int, TableLayoutPanel> _slotTLPs;

        public UnitsForm()
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
            };

            _slotTLPs = new Dictionary<int, TableLayoutPanel>
            {
                { 0, FirstPageItemTLP },
                { 1, SecondPageItemTLP },
                { 2, ThirdPageItemTLP },
                { 3, FourthPageItemTLP }
            };

            _slotLabels = new Dictionary<int, Label>
            {
                { 0, FirstPageItemLabel },
                { 1, SecondPageItemLabel },
                { 2, ThirdPageItemLabel },
                { 3, FourthPageItemLabel },
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
                GameManager.CurrentPlayer.Inventory.Units.ListChanged += Units_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for current player
            UpdatePage();
            UpdateUI();
        }

        private void UnitsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop and dispose timer
            _colorTransitionTimer.Stop();
            _colorTransitionTimer.Dispose();

            // Deselect selection (which will unsubscribe)
            if (_selectedUnit != null)
                DeselectPageItem();

            // Dispose tool tip
            UnitsToolTip.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.Units.ListChanged -= Units_ListChanged;
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
            if (_selectedUnit != null)
                DeselectPageItem();

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Inventory.Units.ListChanged -= Units_ListChanged;
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.Units.ListChanged += Units_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            _currentPage = 1;
            UpdatePage();
            UpdateUI();
        }

        private void SelectedUnit_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Unit.UnitState)
                || e.PropertyName == nameof(Unit.Experience)
                || e.PropertyName == nameof(Unit.HydrationLevel)
                || e.PropertyName == nameof(Unit.NourishmentLevel)
                || e.PropertyName == nameof(Unit.HappinessLevel))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void Units_ListChanged(object? sender, ListChangedEventArgs e)
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
                if (e.PropertyDescriptor.PropertyType == typeof(UnitState))
                {
                    // Update UI to reflect changes
                    UpdatePage();
                }
                else if (e.PropertyDescriptor.Name == "Name" || e.PropertyDescriptor.Name == "Level"
                    || e.PropertyDescriptor.Name == "Rarity" || e.PropertyDescriptor.Name == "Element")
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

            UnitsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

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

            PreviousButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            PreviousButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PreviousButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            PreviousButton.Font = new Font(PreviousButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            NextButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            NextButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            NextButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            NextButton.Font = new Font(NextButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            UseExperienceBoostButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            UseExperienceBoostButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UseExperienceBoostButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            UseExperienceBoostButton.Font = new Font(UseExperienceBoostButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            UseRarityBoostButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            UseRarityBoostButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UseRarityBoostButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            UseRarityBoostButton.Font = new Font(UseRarityBoostButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            DrinkButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            DrinkButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            DrinkButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            DrinkButton.Font = new Font(DrinkButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            EatButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            EatButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            EatButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            EatButton.Font = new Font(EatButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            RenameButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            RenameButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RenameButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            RenameButton.Font = new Font(RenameButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ReleaseButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            ReleaseButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ReleaseButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            ReleaseButton.Font = new Font(ReleaseButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            UnitsCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UnitsCountLabel.Font = new Font(UnitsCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

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
        }

        private void UpdatePage()
        {
            // Update page for current player

            if (GameManager.CurrentPlayer == null)
                return;

            // Prevent being on an empty page after a unit is removed
            var pageCount = (double)GameManager.CurrentPlayer.Inventory.Units.Count / PageSize;
            var pageCountCeiling = (int)Math.Ceiling(pageCount);
            if (_currentPage > pageCountCeiling)
                _currentPage = pageCountCeiling;

            // Get the page items for this page
            int start = (_currentPage - 1) * PageSize;
            var pageItems = GameManager.CurrentPlayer.Inventory.Units.Skip(start).Take(PageSize).ToList();

            // Update the page item controls
            for (int i = 0; i < PageSize; i++)
            {
                if (pageItems.Count > i)
                {
                    // Update the label with relevant unit details
                    StringBuilder pageItemText = new();
                    pageItemText.Append($"{pageItems[i].Name}\nLevel: {pageItems[i].Level}\nRarity: {pageItems[i].Rarity}");
                    pageItemText.Append(pageItems[i].UnitState == UnitState.OnMission ? "\nState: On Mission" : $"\nState: {pageItems[i].UnitState}");
                    _slotLabels[i].Text = pageItemText.ToString();

                    // Animate border panel to match unit rarity
                    if (_rarityColors.TryGetValue(pageItems[i].Rarity, out var newColor))
                    {
                        StartColorTransition(_slotBorderPanels[i], newColor);
                    }

                    // Build tooltip with relevant unit details
                    StringBuilder pageItemTooltip = new();
                    pageItemTooltip.Append($"{pageItems[i].Name}\nLevel: {pageItems[i].Level}\nRarity: {pageItems[i].Rarity}\n");
                    pageItemTooltip.Append(pageItems[i].Element != null ? $"Element: {pageItems[i].Element}\n\n" : $"Element: ???\n\n");
                    pageItemTooltip.Append(pageItems[i].UnitState == UnitState.OnMission ? "State: On Mission\n" : $"State: {pageItems[i].UnitState}\n");

                    // Mission name
                    if (pageItems[i].UnitState == UnitState.OnMission)
                    {
                        var mission = GameManager.CurrentPlayer.Missions.FirstOrDefault(m => m.AssignedUnitGuids != null && m.AssignedUnitGuids.Contains(pageItems[i].Id));
                        if (mission != null)
                            pageItemTooltip.Append($"Mission: {mission.Name}\n");
                    }

                    string toolTipCaption = pageItemTooltip.ToString().TrimEnd();

                    // Set tooltips
                    string? currentToolTip = UnitsToolTip.GetToolTip(_slotBorderPanels[i]);
                    if (currentToolTip != toolTipCaption)
                    {
                        UnitsToolTip.SetToolTip(_slotBorderPanels[i], toolTipCaption);
                        UnitsToolTip.SetToolTip(_slotLabels[i], toolTipCaption);
                        UnitsToolTip.SetToolTip(_slotTLPs[i], toolTipCaption);
                    }
                }
                else
                {
                    // Reset label
                    _slotLabels[i].Text = "";

                    // Animate border panel back to default
                    StartColorTransition(_slotBorderPanels[i], Properties.Settings.Default.SecondaryBackColor);

                    // Reset tooltips
                    UnitsToolTip.SetToolTip(_slotBorderPanels[i], "");
                    UnitsToolTip.SetToolTip(_slotLabels[i], "");
                    UnitsToolTip.SetToolTip(_slotTLPs[i], "");
                }
            }

            // Start color transition timer to animate border panels
            _colorTransitionTimer.Start();

            // Update the label showing count and maximum for units
            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            UnitsCountLabel.Text = $"Units: {GameManager.CurrentPlayer.Inventory.Units.Count}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxUnits, StarterValues.MaxUnits)}";

            // Navigation
            PreviousButton.Enabled = _currentPage > 1;
            NextButton.Enabled = start + PageSize < GameManager.CurrentPlayer.Inventory.Units.Count;

            // If this page no longer contains the selection, then deselect
            if (_selectedUnit != null && pageItems.FirstOrDefault(u => u.Id == _selectedUnit.Id) == null)
            {
                DeselectPageItem();
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (_selectedUnit != null)
            {
                DeselectButton.Enabled = true;

                var progress = (double)_selectedUnit.Experience / (double)_selectedUnit.GetExperienceNeeded();
                ExperiencePB.Value = Math.Clamp((int)(progress * 100), 0, 100);

                SelectionLabel.Text = $"Selected: {_selectedUnit.Name} | Happiness: {_selectedUnit.HappinessLevel:N1}%";

                UseExperienceBoostButton.Enabled = true;

                UseRarityBoostButton.Enabled = true;

                WaterPB.Value = (int)_selectedUnit.HydrationLevel;
                DrinkButton.Enabled = true;

                FoodPB.Value = (int)_selectedUnit.NourishmentLevel;
                EatButton.Enabled = true;

                RenameButton.Enabled = true;

                ReleaseButton.Enabled = _selectedUnit.UnitState != UnitState.OnMission;
            }
            else
            {
                DeselectButton.Enabled = false;
                ExperiencePB.Value = 0;
                SelectionLabel.Text = "Selected: None";
                UseExperienceBoostButton.Enabled = false;
                UseRarityBoostButton.Enabled = false;
                WaterPB.Value = 0;
                DrinkButton.Enabled = false;
                FoodPB.Value = 0;
                EatButton.Enabled = false;
                RenameButton.Enabled = false;
                ReleaseButton.Enabled = false;
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
            if (_selectedUnit != null)
                DeselectPageItem();

            if (index < GameManager.CurrentPlayer.Inventory.Units.Count)
            {
                // Get new selection
                _selectedUnit = GameManager.CurrentPlayer.Inventory.Units[index];
                if (_selectedUnit != null)
                {
                    // Subscribe to its property changes
                    _selectedUnit.PropertyChanged += SelectedUnit_PropertyChanged;
                }
            }

            // Update UI to reflect changes
            UpdateUI();
        }

        private void FirstControl_Click(object? sender, EventArgs e) => SelectPageItem((_currentPage - 1) * PageSize);
        private void SecondControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 1);
        private void ThirdControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 2);
        private void FourthControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 3);

        private void DeselectPageItem()
        {
            if (_selectedUnit != null)
            {
                // Unsubscribe
                _selectedUnit.PropertyChanged -= SelectedUnit_PropertyChanged;

                // Reset
                _selectedUnit = null;
            }
        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            if (_selectedUnit != null)
            {
                DeselectPageItem();
                UpdateUI();
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            // Change to previous page
            if (GameManager.CurrentPlayer != null && _currentPage > 1)
            {
                int lastPage = Math.Max(1, (GameManager.CurrentPlayer.Inventory.Units.Count + PageSize - 1) / PageSize);
                _currentPage = Math.Min(lastPage, _currentPage - 1);
                UpdatePage();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Change to next page
            if (GameManager.CurrentPlayer != null && _currentPage * PageSize < GameManager.CurrentPlayer.Inventory.Units.Count)
            {
                _currentPage++;
                UpdatePage();
            }
        }

        private void UseExperienceBoostButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedUnit == null)
                return;

            if (GameManager.CurrentPlayer.Inventory.ExperienceBoosts < 1)
            {
                OutputService.Write(true, [new("No experience boosts available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.ExperienceBoost, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove experience boost
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Experience boost amount can be modified by nodes in the research tree
                        int modifiedExperienceBoostAmount = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ExperienceBoostAmount, StarterValues.ExperienceBoostAmount);

                        // Add boost amount
                        _selectedUnit.Experience += modifiedExperienceBoostAmount;

                        OutputService.Write(true, [new($"{_selectedUnit.Name} gained {modifiedExperienceBoostAmount} XP using a boost!", Properties.Settings.Default.PrimaryForeColor)]);

                        // Update quests and statistics
                        GameManager.CurrentPlayer.Statistics.ExperienceBoostsUsed += 1;
                        GameManager.TryQuestProgress(playerIndex, QuestType.UseExperienceBoost, 1);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use experience boost.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void UseRarityBoostButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedUnit == null)
                return;

            if (_selectedUnit.Rarity == Rarity.Legendary)
            {
                OutputService.Write(true, [new($"{_selectedUnit.Name} can't have rarity boosted beyond Legendary.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.RarityBoosts < 1)
            {
                OutputService.Write(true, [new("No rarity boosts available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.RarityBoost, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove rarity boost
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Increase rarity
                        _selectedUnit.Rarity++;

                        OutputService.Write(true, [new($"{_selectedUnit.Name} increased rarity using a boost!", Properties.Settings.Default.PrimaryForeColor)]);

                        // Update quests and statistics
                        GameManager.CurrentPlayer.Statistics.RarityBoostsUsed += 1;
                        GameManager.TryQuestProgress(playerIndex, QuestType.UseRarityBoost, 1);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use rarity boost.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void DrinkButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedUnit == null)
                return;

            if (GameManager.CurrentPlayer.Inventory.Water < 1)
            {
                OutputService.Write(true, [new("No water available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Water, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove water
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Increase hydration level
                        _selectedUnit.HydrationLevel = Math.Clamp(_selectedUnit.HydrationLevel + 25, 0, 100);

                        OutputService.Write(true, [new($"{_selectedUnit.Name} drank water.", Properties.Settings.Default.PrimaryForeColor)]);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use water.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void EatButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedUnit == null)
                return;

            if (GameManager.CurrentPlayer.Inventory.Food < 1)
            {
                OutputService.Write(true, [new("No food available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Food, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove food
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Increase nourishment level
                        _selectedUnit.NourishmentLevel = Math.Clamp(_selectedUnit.NourishmentLevel + 25, 0, 100);

                        OutputService.Write(true, [new($"{_selectedUnit.Name} ate food.", Properties.Settings.Default.PrimaryForeColor)]);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use food.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedUnit == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Unit renaming cost can be modified by nodes in the research tree
            int modifiedRenameCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.UnitRenamingCost, StarterValues.UnitRenamingCost);

            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedRenameCost)
            {
                OutputService.Write(true, [new($"Not enough gold to rename unit. Cost: {modifiedRenameCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                var dialog = new RenameDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string userInput = dialog.NewNameText.Trim();

                    // Verify input wasn't blank or the current name
                    if (userInput != "" && userInput != _selectedUnit.Name)
                    {
                        Loot lootToRemove = new();
                        lootToRemove.LootQuantities.Add(LootType.Gold, modifiedRenameCost);

                        if (playerIndex != -1)
                        {
                            // Remove gold
                            if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                            {
                                // Update name
                                _selectedUnit.Name = userInput;

                                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Unit successfully renamed!", Properties.Settings.Default.PrimaryForeColor)]);
                            }
                            else
                            {
                                OutputService.Write(true, [new("Failed to use gold.", Properties.Settings.Default.ErrorTextColor)]);
                            }
                        }
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to rename unit.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void ReleaseButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedUnit == null || _selectedUnit.UnitState == UnitState.OnMission)
                return;

            // Set as pending delete to keep unit from being auto assigned to a mission while waiting on user input
            _selectedUnit.PendingDelete = true;

            var result = MessageBox.Show("Release this unit? This can not be undone.", "Release this unit?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // Get the unit to delete
                var unit = _selectedUnit;

                // Deselect selection (which will unsubscribe)
                DeselectPageItem();

                // Update UI to reflect changes
                UpdateUI();

                Loot lootToRemove = new();
                lootToRemove.Units.Add(unit);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove unit
                    if (!GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                        OutputService.Write(true, [new("Failed to release unit.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
            else
            {
                // Reset pending delete so unit can be auto assigned again
                _selectedUnit.PendingDelete = false;
            }
        }
    }
}