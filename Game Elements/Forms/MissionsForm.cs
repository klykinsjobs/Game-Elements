using Game_Elements.Data;
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
    public partial class MissionsForm : Form
    {
        private int _currentPage = 1;

        private const int PageSize = 3;

        private Mission? _selectedMission = null;

        private readonly Timer _colorTransitionTimer;
        private readonly List<ColorTransition> _transitions = [];
        private readonly Dictionary<Rarity, Color> _rarityColors;
        private const int TransitionSteps = 20;
        private const int TimerIntervalMs = 30;

        private readonly Dictionary<int, Panel> _slotBorderPanels;
        private readonly Dictionary<int, Label> _slotLabels;
        private readonly Dictionary<int, TableLayoutPanel> _slotTLPs;

        public MissionsForm()
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
                { 2, ThirdPageItemBorderPanel }
            };

            _slotTLPs = new Dictionary<int, TableLayoutPanel>
            {
                { 0, FirstPageItemTLP },
                { 1, SecondPageItemTLP },
                { 2, ThirdPageItemTLP }
            };

            _slotLabels = new Dictionary<int, Label>
            {
                { 0, FirstPageItemLabel },
                { 1, SecondPageItemLabel },
                { 2, ThirdPageItemLabel }
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
                GameManager.CurrentPlayer.Missions.ListChanged += Missions_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for current player
            UpdatePage();
            UpdateUI();
        }

        private void MissionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop and dispose timer
            _colorTransitionTimer.Stop();
            _colorTransitionTimer.Dispose();

            // Deselect selection (which will unsubscribe)
            if (_selectedMission != null)
                DeselectPageItem();

            // Dispose tool tip
            MissionsToolTip.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Missions.ListChanged -= Missions_ListChanged;
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
            if (_selectedMission != null)
                DeselectPageItem();

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Missions.ListChanged -= Missions_ListChanged;
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Missions.ListChanged += Missions_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            _currentPage = 1;
            UpdatePage();
            UpdateUI();
        }

        private void SelectedMission_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Mission.MissionState)
                || e.PropertyName == nameof(Mission.Elapsed))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void Missions_ListChanged(object? sender, ListChangedEventArgs e)
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
                if (e.PropertyDescriptor.PropertyType == typeof(MissionState))
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

            MissionsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

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

            FirstSlotLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FirstSlotLabel.Font = new Font(FirstSlotLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SecondSlotLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SecondSlotLabel.Font = new Font(SecondSlotLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ThirdSlotLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ThirdSlotLabel.Font = new Font(ThirdSlotLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            UseRushBoostButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            UseRushBoostButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UseRushBoostButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            UseRushBoostButton.Font = new Font(UseRushBoostButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ClearAllCompleteButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            ClearAllCompleteButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ClearAllCompleteButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            ClearAllCompleteButton.Font = new Font(ClearAllCompleteButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            InProgressMissionsCountLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            InProgressMissionsCountLabel.Font = new Font(InProgressMissionsCountLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

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
        }

        private void UpdatePage()
        {
            // Update page for current player

            if (GameManager.CurrentPlayer == null)
                return;

            // Prevent being on an empty page after completed missions are cleared
            var pageCount = (double)GameManager.CurrentPlayer.Missions.Count / PageSize;
            var pageCountCeiling = (int)Math.Ceiling(pageCount);
            if (_currentPage > pageCountCeiling)
                _currentPage = pageCountCeiling;

            // Get the page items for this page
            int start = (_currentPage - 1) * PageSize;
            var pageItems = GameManager.CurrentPlayer.Missions.Skip(start).Take(PageSize).ToList();

            // Update the page item controls
            for (int i = 0; i < PageSize; i++)
            {
                if (pageItems.Count > i)
                {
                    // Update the label with relevant mission details
                    StringBuilder pageItemText = new();
                    pageItemText.Append($"{pageItems[i].Name}\nLevel: {pageItems[i].Level}\nRarity: {pageItems[i].Rarity}");
                    pageItemText.Append(pageItems[i].MissionState == MissionState.InProgress ? "\nState: In Progress" : $"\nState: {pageItems[i].MissionState}");
                    _slotLabels[i].Text = pageItemText.ToString();

                    // Animate border panel to match mission rarity
                    if (_rarityColors.TryGetValue(pageItems[i].Rarity, out var newColor))
                    {
                        StartColorTransition(_slotBorderPanels[i], newColor);
                    }

                    // Build tooltip with relevant mission details
                    StringBuilder missionDetailsSB = new();
                    missionDetailsSB.Append($"Mission: {pageItems[i].Name}\n");
                    missionDetailsSB.Append($"Level: {pageItems[i].Level}\n");
                    missionDetailsSB.Append($"Rarity: {pageItems[i].Rarity}\n");
                    missionDetailsSB.Append($"Duration: {pageItems[i].Duration.TotalSeconds} seconds\n");

                    // Elements
                    StringBuilder elementsSB = new();
                    if (pageItems[i].Elements != null && pageItems[i].Elements?.Count > 0)
                    {
                        for (int j = 0; j < pageItems[i].Elements?.Count; j++)
                        {
                            elementsSB.Append(j == pageItems[i].Elements?.Count - 1 ? $"{pageItems[i].Elements?[j]}" : $"{pageItems[i].Elements?[j]}, ");
                        }
                    }
                    missionDetailsSB.Append(elementsSB.Length > 0 ? $"Elements: {elementsSB}\n" : "Elements: None\n");

                    // Experience
                    if (pageItems[i].Experience > 0)
                        missionDetailsSB.Append($"Experience: {pageItems[i].Experience}\n");

                    // Loot
                    StringBuilder lootSB = new("\nLoot:\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Gold, out var gold) && gold > 0)
                        lootSB.Append($"Gold: {gold}\n");

                    if (pageItems[i].Loots.Units.Count > 0)
                        foreach (var unit in pageItems[i].Loots.Units)
                            lootSB.Append($"Unit: {unit.Name} ({unit.Rarity})\n");

                    if (pageItems[i].Loots.Items.Count > 0)
                        foreach (var item in pageItems[i].Loots.Items)
                            lootSB.Append($"Item: {item.Name} ({item.Rarity})\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Lootbox, out var lootboxes) && lootboxes > 0)
                        lootSB.Append($"Lootboxes: {lootboxes}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.MonsterEgg, out var monsterEggs) && monsterEggs > 0)
                        lootSB.Append($"Monster Eggs: {monsterEggs}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.MysterySeed, out var mysterySeeds) && mysterySeeds > 0)
                        lootSB.Append($"Mystery Seeds: {mysterySeeds}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.RarityBoost, out var rarityBoosts) && rarityBoosts > 0)
                        lootSB.Append($"Rarity Boosts: {rarityBoosts}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.ExperienceBoost, out var experienceBoosts) && experienceBoosts > 0)
                        lootSB.Append($"Experience Boosts: {experienceBoosts}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.RushBoost, out var rushBoosts) && rushBoosts > 0)
                        lootSB.Append($"Rush Boosts: {rushBoosts}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Fertilizer, out var fertilizer) && fertilizer > 0)
                        lootSB.Append($"Fertilizer: {fertilizer}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Water, out var water) && water > 0)
                        lootSB.Append($"Water: {water}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Food, out var food) && food > 0)
                        lootSB.Append($"Food: {food}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Concrete, out var concrete) && concrete > 0)
                        lootSB.Append($"Concrete: {concrete}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Metal, out var metal) && metal > 0)
                        lootSB.Append($"Metal: {metal}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Power, out var power) && power > 0)
                        lootSB.Append($"Power: {power}\n");

                    if (pageItems[i].Loots.LootQuantities.TryGetValue(LootType.Research, out var research) && research > 0)
                        lootSB.Append($"Research: {research}\n");

                    missionDetailsSB.Append(lootSB);

                    // Mission state
                    missionDetailsSB.Append(pageItems[i].MissionState == MissionState.InProgress ? "\nState: In Progress\n" : $"\nState: {pageItems[i].MissionState}\n");

                    string toolTipCaption = missionDetailsSB.ToString().TrimEnd();

                    // Set tooltips
                    string? currentToolTip = MissionsToolTip.GetToolTip(_slotBorderPanels[i]);
                    if (currentToolTip != toolTipCaption)
                    {
                        MissionsToolTip.SetToolTip(_slotBorderPanels[i], toolTipCaption);
                        MissionsToolTip.SetToolTip(_slotLabels[i], toolTipCaption);
                        MissionsToolTip.SetToolTip(_slotTLPs[i], toolTipCaption);
                    }
                }
                else
                {
                    // Reset label
                    _slotLabels[i].Text = "";

                    // Animate border panel back to default
                    StartColorTransition(_slotBorderPanels[i], Properties.Settings.Default.SecondaryBackColor);

                    // Reset tooltips
                    MissionsToolTip.SetToolTip(_slotBorderPanels[i], "");
                    MissionsToolTip.SetToolTip(_slotLabels[i], "");
                    MissionsToolTip.SetToolTip(_slotTLPs[i], "");
                }
            }

            // Start color transition timer to animate border panels
            _colorTransitionTimer.Start();

            // Update the label showing count and maximum for in progress missions
            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            InProgressMissionsCountLabel.Text = $"In Progress: {GameManager.CurrentPlayer.Missions.Where(m => m.MissionState == MissionState.InProgress).Count()}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxInProgressMissions, StarterValues.MaxInProgressMissions)}";

            // Navigation
            PreviousButton.Enabled = _currentPage > 1;
            NextButton.Enabled = start + PageSize < GameManager.CurrentPlayer.Missions.Count;

            // If this page no longer contains the selection, then deselect
            if (_selectedMission != null && pageItems.FirstOrDefault(u => u.Id == _selectedMission.Id) == null)
            {
                DeselectPageItem();
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (_selectedMission != null)
            {
                DeselectButton.Enabled = true;

                switch (_selectedMission.MissionState)
                {
                    case MissionState.Available:
                        MissionPB.Value = 0;

                        SelectionLabel.Text = $"Selected: {_selectedMission.Name}";

                        FirstSlotLabel.Text = " ";
                        SecondSlotLabel.Text = " ";
                        ThirdSlotLabel.Text = " ";

                        UseRushBoostButton.Enabled = false;

                        break;
                    case MissionState.InProgress:
                        if (_selectedMission.IsDone)
                        {
                            MissionPB.Value = 100;
                        }
                        else
                        {
                            var progress = _selectedMission.Elapsed.TotalSeconds / _selectedMission.Duration.TotalSeconds;
                            MissionPB.Value = Math.Clamp((int)(progress * 100), 0, 100);
                        }

                        SelectionLabel.Text = $"Selected: {_selectedMission.Name}";

                        // Assigned unit names
                        if (GameManager.CurrentPlayer != null && _selectedMission.AssignedUnitGuids != null && _selectedMission.AssignedUnitGuids.Count == 3)
                        {
                            var firstUnit = GameManager.CurrentPlayer.Inventory.Units.FirstOrDefault(u => u.Id == _selectedMission.AssignedUnitGuids[0]);
                            var secondUnit = GameManager.CurrentPlayer.Inventory.Units.FirstOrDefault(u => u.Id == _selectedMission.AssignedUnitGuids[1]);
                            var thirdUnit = GameManager.CurrentPlayer.Inventory.Units.FirstOrDefault(u => u.Id == _selectedMission.AssignedUnitGuids[2]);

                            FirstSlotLabel.Text = firstUnit != null ? firstUnit.Name : " ";
                            SecondSlotLabel.Text = secondUnit != null ? secondUnit.Name : " ";
                            ThirdSlotLabel.Text = thirdUnit != null ? thirdUnit.Name : " ";
                        }
                        else
                        {
                            FirstSlotLabel.Text = " ";
                            SecondSlotLabel.Text = " ";
                            ThirdSlotLabel.Text = " ";
                        }

                        UseRushBoostButton.Enabled = !_selectedMission.IsDone;

                        break;

                    case MissionState.Success:
                        MissionPB.Value = 100;

                        SelectionLabel.Text = $"Selected: {_selectedMission.Name} | Result: Success!";

                        FirstSlotLabel.Text = " ";
                        SecondSlotLabel.Text = " ";
                        ThirdSlotLabel.Text = " ";

                        UseRushBoostButton.Enabled = false;

                        break;
                    case MissionState.Fail:
                        MissionPB.Value = 100;

                        SelectionLabel.Text = $"Selected: {_selectedMission.Name} | Result: Fail!";

                        FirstSlotLabel.Text = " ";
                        SecondSlotLabel.Text = " ";
                        ThirdSlotLabel.Text = " ";

                        UseRushBoostButton.Enabled = false;

                        break;
                }
            }
            else
            {
                DeselectButton.Enabled = false;
                MissionPB.Value = 0;
                SelectionLabel.Text = "Selected: None";
                FirstSlotLabel.Text = " ";
                SecondSlotLabel.Text = " ";
                ThirdSlotLabel.Text = " ";
                UseRushBoostButton.Enabled = false;
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
                t.Panel?.BackColor = Color.FromArgb(r, g, b);

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
            if (_selectedMission != null)
                DeselectPageItem();

            if (index < GameManager.CurrentPlayer.Missions.Count)
            {
                // Get new selection
                _selectedMission = GameManager.CurrentPlayer.Missions[index];
                // Subscribe to its property changes
                _selectedMission?.PropertyChanged += SelectedMission_PropertyChanged;
            }

            // Update UI to reflect changes
            UpdateUI();
        }

        private void FirstControl_Click(object? sender, EventArgs e) => SelectPageItem((_currentPage - 1) * PageSize);
        private void SecondControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 1);
        private void ThirdControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 2);

        private void DeselectPageItem()
        {
            // Unsubscribe
            _selectedMission?.PropertyChanged -= SelectedMission_PropertyChanged;

            // Reset
            _selectedMission = null;
        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            if (_selectedMission != null)
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
                int lastPage = Math.Max(1, (GameManager.CurrentPlayer.Missions.Count + PageSize - 1) / PageSize);
                _currentPage = Math.Min(lastPage, _currentPage - 1);
                UpdatePage();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Change to next page
            if (GameManager.CurrentPlayer != null && _currentPage * PageSize < GameManager.CurrentPlayer.Missions.Count)
            {
                _currentPage++;
                UpdatePage();
            }
        }

        private void UseRushBoostButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedMission == null)
                return;

            if (_selectedMission.MissionState != MissionState.InProgress)
            {
                OutputService.Write(true, [new("Mission must be in progress.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (_selectedMission.IsDone)
            {
                OutputService.Write(true, [new("Mission is already done.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.RushBoosts < 1)
            {
                OutputService.Write(true, [new("No rush boosts available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.RushBoost, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove rush boost
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Boost elapsed
                        _selectedMission.Elapsed = _selectedMission.Duration;

                        OutputService.Write(true, [new($"{_selectedMission.Name} was rushed using a boost!", Properties.Settings.Default.PrimaryForeColor)]);

                        // Update quests and statistics
                        GameManager.CurrentPlayer.Statistics.RushBoostsUsed += 1;
                        GameManager.TryQuestProgress(playerIndex, QuestType.UseRushBoost, 1);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use rush boost.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void ClearAllCompleteButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            List<Mission> completeMissions = [.. GameManager.CurrentPlayer.Missions.Where(m => m.MissionState == MissionState.Success || m.MissionState == MissionState.Fail)];
            GameManager.CurrentPlayer.Missions.RaiseListChangedEvents = false;
            foreach (var mission in completeMissions)
                GameManager.CurrentPlayer.Missions.Remove(mission);
            GameManager.CurrentPlayer.Missions.RaiseListChangedEvents = true;
            GameManager.CurrentPlayer.Missions.ResetBindings();
        }
    }
}