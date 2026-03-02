using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;

namespace Game_Elements
{
    public partial class GardeningForm : Form
    {
        private int _currentPage = 1;

        private const int PageSize = 6;

        private GardeningPlot? _selectedGardeningPlot = null;

        private readonly Dictionary<int, Label> _slotLabels;

        public GardeningForm()
        {
            InitializeComponent();

            // Initialize dictionary
            _slotLabels = new Dictionary<int, Label>
            {
                { 0, FirstPageItemLabel },
                { 1, SecondPageItemLabel },
                { 2, ThirdPageItemLabel },
                { 3, FourthPageItemLabel },
                { 4, FifthPageItemLabel },
                { 5, SixthPageItemLabel }
            };

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.GardeningPlots.ListChanged += GardeningPlots_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for current player
            UpdatePage();
            UpdateUI();
        }

        private void GardeningForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Deselect selection (which will unsubscribe)
            if (_selectedGardeningPlot != null)
                DeselectPageItem();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                GameManager.CurrentPlayer.GardeningPlots.ListChanged -= GardeningPlots_ListChanged;
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
            if (_selectedGardeningPlot != null)
                DeselectPageItem();

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                previousPlayer.GardeningPlots.ListChanged -= GardeningPlots_ListChanged;
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.GardeningPlots.ListChanged += GardeningPlots_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            _currentPage = 1;
            UpdatePage();
            UpdateUI();
        }

        private void SelectedGardeningPlot_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(GardeningPlot.Elapsed)
                || e.PropertyName == nameof(GardeningPlot.Tilled)
                || e.PropertyName == nameof(GardeningPlot.Planted)
                || e.PropertyName == nameof(GardeningPlot.Fertilized)
                || e.PropertyName == nameof(GardeningPlot.Watered)
                || e.PropertyName == nameof(GardeningPlot.ReadyForHarvest))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void Inventory_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Inventory.MysterySeeds)
                || e.PropertyName == nameof(Inventory.Fertilizer)
                || e.PropertyName == nameof(Inventory.Water))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void GardeningPlots_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset)
            {
                // Update UI to reflect changes
                UpdatePage();
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null)
            {
                if (e.PropertyDescriptor.Name == "Planted" || e.PropertyDescriptor.Name == "ReadyForHarvest")
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
                UpdateUI();
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            GardeningTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

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

            MysterySeedsLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MysterySeedsLabel.Font = new Font(MysterySeedsLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FertilizerLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FertilizerLabel.Font = new Font(FertilizerLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            WaterLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            WaterLabel.Font = new Font(WaterLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            TillButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            TillButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            TillButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            TillButton.Font = new Font(TillButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            PlantButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            PlantButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PlantButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            PlantButton.Font = new Font(PlantButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            FertilizeButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            FertilizeButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FertilizeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            FertilizeButton.Font = new Font(FertilizeButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            WaterButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            WaterButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            WaterButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            WaterButton.Font = new Font(WaterButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            HarvestButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            HarvestButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            HarvestButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            HarvestButton.Font = new Font(HarvestButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            UnlockNewPlotButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            UnlockNewPlotButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UnlockNewPlotButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            UnlockNewPlotButton.Font = new Font(UnlockNewPlotButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

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
            int start = (_currentPage - 1) * PageSize;
            var pageItems = GameManager.CurrentPlayer.GardeningPlots.Skip(start).Take(PageSize).ToList();

            // Update the page item controls
            for (int i = 0; i < PageSize; i++)
            {
                if (pageItems.Count > i)
                {
                    // Update the label with relevant gardening plot details
                    if (pageItems[i].ReadyForHarvest)
                        _slotLabels[i].Text = "Ready for harvest...";
                    else if (pageItems[i].Planted)
                        _slotLabels[i].Text = "Growing...";
                    else
                        _slotLabels[i].Text = "[Empty]";
                }
                else
                {
                    // Reset label
                    _slotLabels[i].Text = "";
                }
            }

            // Navigation
            PreviousButton.Enabled = _currentPage > 1;
            NextButton.Enabled = start + PageSize < GameManager.CurrentPlayer.GardeningPlots.Count;

            // If this page no longer contains the selection, then deselect
            if (_selectedGardeningPlot != null && pageItems.FirstOrDefault(e => e.Id == _selectedGardeningPlot.Id) == null)
            {
                DeselectPageItem();
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            if (_selectedGardeningPlot != null)
            {
                DeselectButton.Enabled = true;

                var progress = _selectedGardeningPlot.Elapsed.TotalSeconds / _selectedGardeningPlot.Duration.TotalSeconds;
                ProgressPB.Value = Math.Clamp((int)(progress * 100), 0, 100);

                if (_selectedGardeningPlot.ReadyForHarvest)
                    SelectionLabel.Text = "Selected: Ready for harvest...";
                else if (_selectedGardeningPlot.Planted)
                    SelectionLabel.Text = "Selected: Growing...";
                else
                    SelectionLabel.Text = "Selected: [Empty]";

                TillButton.Enabled = !_selectedGardeningPlot.Tilled;
                PlantButton.Enabled = (_selectedGardeningPlot.Tilled && !_selectedGardeningPlot.Planted);
                FertilizeButton.Enabled = (_selectedGardeningPlot.Planted && !_selectedGardeningPlot.Fertilized);
                WaterButton.Enabled = (_selectedGardeningPlot.Planted && !_selectedGardeningPlot.Watered);
                HarvestButton.Enabled = _selectedGardeningPlot.ReadyForHarvest;

                MysterySeedsLabel.Text = $"Mystery Seeds: {GameManager.CurrentPlayer.Inventory.MysterySeeds}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds)}";
                FertilizerLabel.Text = $"Fertilizer: {GameManager.CurrentPlayer.Inventory.Fertilizer}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer)}";
                WaterLabel.Text = $"Water: {GameManager.CurrentPlayer.Inventory.Water}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxWater, StarterValues.MaxWater)}";
            }
            else
            {
                DeselectButton.Enabled = false;

                ProgressPB.Value = 0;

                SelectionLabel.Text = "Selected: None";

                TillButton.Enabled = false;
                PlantButton.Enabled = false;
                FertilizeButton.Enabled = false;
                WaterButton.Enabled = false;
                HarvestButton.Enabled = false;

                MysterySeedsLabel.Text = $"Mystery Seeds: {GameManager.CurrentPlayer.Inventory.MysterySeeds}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds)}";
                FertilizerLabel.Text = $"Fertilizer: {GameManager.CurrentPlayer.Inventory.Fertilizer}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer)}";
                WaterLabel.Text = $"Water: {GameManager.CurrentPlayer.Inventory.Water}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxWater, StarterValues.MaxWater)}";
            }
        }

        private void SelectPageItem(int index)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Deselect if anything already selected
            if (_selectedGardeningPlot != null)
                DeselectPageItem();

            if (index < GameManager.CurrentPlayer.GardeningPlots.Count)
            {
                // Get new selection
                _selectedGardeningPlot = GameManager.CurrentPlayer.GardeningPlots[index];
                if (_selectedGardeningPlot != null)
                {
                    // Subscribe to its property changes
                    _selectedGardeningPlot.PropertyChanged += SelectedGardeningPlot_PropertyChanged;
                }
            }

            // Update UI to reflect changes
            UpdateUI();
        }

        private void FirstControl_Click(object? sender, EventArgs e) => SelectPageItem((_currentPage - 1) * PageSize);
        private void SecondControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 1);
        private void ThirdControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 2);
        private void FourthControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 3);
        private void FifthControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 4);
        private void SixthControl_Click(object? sender, EventArgs e) => SelectPageItem(((_currentPage - 1) * PageSize) + 5);

        private void DeselectPageItem()
        {
            if (_selectedGardeningPlot != null)
            {
                // Unsubscribe
                _selectedGardeningPlot.PropertyChanged -= SelectedGardeningPlot_PropertyChanged;

                // Reset
                _selectedGardeningPlot = null;
            }
        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            if (_selectedGardeningPlot != null)
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
                int lastPage = Math.Max(1, (GameManager.CurrentPlayer.GardeningPlots.Count + PageSize - 1) / PageSize);
                _currentPage = Math.Min(lastPage, _currentPage - 1);
                UpdatePage();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Change to next page
            if (GameManager.CurrentPlayer != null && _currentPage * PageSize < GameManager.CurrentPlayer.GardeningPlots.Count)
            {
                _currentPage++;
                UpdatePage();
            }
        }

        private void TillButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedGardeningPlot == null)
                return;

            if (_selectedGardeningPlot.Tilled)
            {
                OutputService.Write(true, [new("This gardening plot is already tilled.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Plot has been tilled
                    _selectedGardeningPlot.Tilled = true;

                    OutputService.Write(true, [new($"Gardening plot has been tilled!", Properties.Settings.Default.PrimaryForeColor)]);

                    // Check for skill gain, up to the max for tilling
                    AttemptSkillGain(StarterValues.MaxSkillGainForTilling);
                }
            }
        }

        private void PlantButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedGardeningPlot == null)
                return;

            if (!_selectedGardeningPlot.Tilled)
            {
                OutputService.Write(true, [new("This gardening plot must be tilled first before planting something.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (_selectedGardeningPlot.Planted)
            {
                OutputService.Write(true, [new("This gardening plot already has something planted.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.MysterySeeds < 1)
            {
                OutputService.Write(true, [new("No mystery seeds available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.MysterySeed, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove mystery seed
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Gardening duration can be modified by nodes in the research tree
                        int modifiedGardeningDuration = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.GardeningDuration, StarterValues.GardeningDuration);
                        _selectedGardeningPlot.Duration = TimeSpan.FromMilliseconds(modifiedGardeningDuration);

                        // Plot has been planted
                        _selectedGardeningPlot.Planted = true;

                        OutputService.Write(true, [new($"Mystery seed planted in gardening plot!", Properties.Settings.Default.PrimaryForeColor)]);

                        // Check for skill gain, up to the max for planting
                        AttemptSkillGain(StarterValues.MaxSkillGainForPlanting);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use mystery seed.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void FertilizeButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedGardeningPlot == null)
                return;

            if (!_selectedGardeningPlot.Planted)
            {
                OutputService.Write(true, [new("This gardening plot doesn't have anything planted.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (_selectedGardeningPlot.Fertilized)
            {
                OutputService.Write(true, [new("This gardening plot has already been fertilized.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.Fertilizer < 1)
            {
                OutputService.Write(true, [new("No fertilizer available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Fertilizer, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove fertilizer
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Boost elapsed
                        _selectedGardeningPlot.Elapsed += TimeSpan.FromSeconds(_selectedGardeningPlot.Duration.TotalSeconds / 5);

                        // Plot has been fertilized
                        _selectedGardeningPlot.Fertilized = true;

                        OutputService.Write(true, [new($"Added fertilizer to the gardening plot!", Properties.Settings.Default.PrimaryForeColor)]);

                        // Check for skill gain, up to the max for water/fertilizer
                        AttemptSkillGain(StarterValues.MaxSkillGainForWaterOrFertilizer);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use fertilizer.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void WaterButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedGardeningPlot == null)
                return;

            if (!_selectedGardeningPlot.Planted)
            {
                OutputService.Write(true, [new("This gardening plot doesn't have anything planted.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (_selectedGardeningPlot.Watered)
            {
                OutputService.Write(true, [new("This gardening plot has already been watered.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.Water < 1)
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
                        // Boost elapsed
                        _selectedGardeningPlot.Elapsed += TimeSpan.FromSeconds(_selectedGardeningPlot.Duration.TotalSeconds / 5);

                        // Plot has been watered
                        _selectedGardeningPlot.Watered = true;

                        OutputService.Write(true, [new($"Added water to the gardening plot!", Properties.Settings.Default.PrimaryForeColor)]);

                        // Check for skill gain, up to the max for water/fertilizer
                        AttemptSkillGain(StarterValues.MaxSkillGainForWaterOrFertilizer);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use water.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void HarvestButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedGardeningPlot == null)
                return;

            if (!_selectedGardeningPlot.ReadyForHarvest)
            {
                OutputService.Write(true, [new("This gardening plot is not ready for harvest.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Harvest plot
                    _selectedGardeningPlot.Harvest(playerIndex);

                    OutputService.Write(true, [new($"Gardening plot has been harvested!", Properties.Settings.Default.PrimaryForeColor)]);

                    // Check for skill gain, up to the max for harvesting
                    AttemptSkillGain(StarterValues.MaxSkillGainForHarvesting);
                }
            }
        }

        private void UnlockNewPlotButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Gardening plot cost can be modified by nodes in the research tree
            int modifiedGardeningPlotCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.GardeningPlotCost, StarterValues.GardeningPlotCost);
            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedGardeningPlotCost)
            {
                OutputService.Write(true, [new($"Not enough gold to unlock new plot. Cost: {modifiedGardeningPlotCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedGardeningPlotCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    // Unlock new gardening plot
                    GameManager.Players[playerIndex].GardeningPlots.Add(new GardeningPlot());

                    OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Unlocked additional gardening plot!", Properties.Settings.Default.PrimaryForeColor)]);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to use gold.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private static void AttemptSkillGain(double maxSkillGain)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            // Determine the maximum possible gain for this attempt
            double min = Math.Min(StarterValues.MaxGardeningSkill, maxSkillGain);

            // Roll a random value within the allowed gain range
            double skillGainRng = Random.Shared.NextDouble() * min;

            // Increase skill if the roll exceeds current skill
            if (skillGainRng > GameManager.Players[playerIndex].GardeningSkill)
            {
                GameManager.Players[playerIndex].GardeningSkill += 0.1;

                OutputService.Write(true, [new($"Gardening skill increased: {GameManager.Players[playerIndex].GardeningSkill:N1}!", Properties.Settings.Default.PrimaryForeColor)]);
            }
        }
    }
}