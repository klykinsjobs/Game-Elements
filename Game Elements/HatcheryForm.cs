using System.ComponentModel;

namespace Game_Elements
{
    public partial class HatcheryForm : Form
    {
        private int _currentPage = 1;

        private const int PageSize = 4;

        private EggHatcher? _selectedEggHatcher = null;

        private readonly Dictionary<int, Label> _slotLabels;

        public HatcheryForm()
        {
            InitializeComponent();

            // Initialize dictionary
            _slotLabels = new Dictionary<int, Label>
            {
                { 0, FirstPageItemLabel },
                { 1, SecondPageItemLabel },
                { 2, ThirdPageItemLabel },
                { 3, FourthPageItemLabel }
            };

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.EggHatchers.ListChanged += EggHatchers_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for current player
            UpdatePage();
            UpdateUI();
        }

        private void HatcheryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Deselect selection (which will unsubscribe)
            if (_selectedEggHatcher != null)
                DeselectPageItem();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                GameManager.CurrentPlayer.EggHatchers.ListChanged -= EggHatchers_ListChanged;
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
            if (_selectedEggHatcher != null)
                DeselectPageItem();

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                previousPlayer.EggHatchers.ListChanged -= EggHatchers_ListChanged;
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.EggHatchers.ListChanged += EggHatchers_ListChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            _currentPage = 1;
            UpdatePage();
            UpdateUI();
        }

        private void SelectedEggHatcher_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(EggHatcher.Elapsed) || e.PropertyName == nameof(EggHatcher.Full))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void Inventory_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Inventory.MonsterEggs))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void EggHatchers_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset)
            {
                // Update UI to reflect changes
                UpdatePage();
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null)
            {
                if (e.PropertyDescriptor.Name == "Full")
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

            HatcheryTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

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

            MonsterEggsLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MonsterEggsLabel.Font = new Font(MonsterEggsLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            HatchEggButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            HatchEggButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            HatchEggButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            HatchEggButton.Font = new Font(HatchEggButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            UnlockNewHatcherButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            UnlockNewHatcherButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UnlockNewHatcherButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            UnlockNewHatcherButton.Font = new Font(UnlockNewHatcherButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

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

            // Get the page items for this page
            int start = (_currentPage - 1) * PageSize;
            var pageItems = GameManager.CurrentPlayer.EggHatchers.Skip(start).Take(PageSize).ToList();

            // Update the page item controls
            for (int i = 0; i < PageSize; i++)
            {
                if (pageItems.Count > i)
                {
                    // Update the label with relevant egg hatcher details
                    _slotLabels[i].Text = pageItems[i].Full ? "Hatching..." : "[Empty]";
                }
                else
                {
                    // Reset label
                    _slotLabels[i].Text = "";
                }
            }

            // Navigation
            PreviousButton.Enabled = _currentPage > 1;
            NextButton.Enabled = start + PageSize < GameManager.CurrentPlayer.EggHatchers.Count;

            // If this page no longer contains the selection, then deselect
            if (_selectedEggHatcher != null && pageItems.FirstOrDefault(e => e.Id == _selectedEggHatcher.Id) == null)
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

            if (_selectedEggHatcher != null)
            {
                DeselectButton.Enabled = true;

                var progress = _selectedEggHatcher.Elapsed.TotalSeconds / _selectedEggHatcher.Duration.TotalSeconds;
                ProgressPB.Value = Math.Clamp((int)(progress * 100), 0, 100);

                SelectionLabel.Text = _selectedEggHatcher.Full ? "Selected: Hatching..." : "Selected: [Empty]";

                HatchEggButton.Enabled = !_selectedEggHatcher.Full;

                MonsterEggsLabel.Text = $"Monster Eggs: {GameManager.CurrentPlayer.Inventory.MonsterEggs}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs)}";
            }
            else
            {
                DeselectButton.Enabled = false;

                ProgressPB.Value = 0;

                SelectionLabel.Text = "Selected: None";

                HatchEggButton.Enabled = false;

                MonsterEggsLabel.Text = $"Monster Eggs: {GameManager.CurrentPlayer.Inventory.MonsterEggs}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs)}";
            }
        }

        private void SelectPageItem(int index)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Deselect if anything already selected
            if (_selectedEggHatcher != null)
                DeselectPageItem();

            if (index < GameManager.CurrentPlayer.EggHatchers.Count)
            {
                // Get new selection
                _selectedEggHatcher = GameManager.CurrentPlayer.EggHatchers[index];
                if (_selectedEggHatcher != null)
                {
                    // Subscribe to its property changes
                    _selectedEggHatcher.PropertyChanged += SelectedEggHatcher_PropertyChanged;
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
            if (_selectedEggHatcher != null)
            {
                // Unsubscribe
                _selectedEggHatcher.PropertyChanged -= SelectedEggHatcher_PropertyChanged;

                // Reset
                _selectedEggHatcher = null;
            }
        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            if (_selectedEggHatcher != null)
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
                int lastPage = Math.Max(1, (GameManager.CurrentPlayer.EggHatchers.Count + PageSize - 1) / PageSize);
                _currentPage = Math.Min(lastPage, _currentPage - 1);
                UpdatePage();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Change to next page
            if (GameManager.CurrentPlayer != null && _currentPage * PageSize < GameManager.CurrentPlayer.EggHatchers.Count)
            {
                _currentPage++;
                UpdatePage();
            }
        }

        private void HatchEggButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedEggHatcher == null)
                return;

            if (_selectedEggHatcher.Full)
            {
                OutputService.Write(true, [new("This egg hatcher is already hatching a monster egg.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else if (GameManager.CurrentPlayer.Inventory.MonsterEggs < 1)
            {
                OutputService.Write(true, [new("No monster eggs available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.MonsterEgg, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove monster egg
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Hatching duration can be modified by nodes in the research tree
                        int modifiedHatchingDuration = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.HatchingDuration, StarterValues.HatchingDuration);
                        _selectedEggHatcher.Duration = TimeSpan.FromMilliseconds(modifiedHatchingDuration);

                        // Hatcher is full
                        _selectedEggHatcher.Full = true;

                        OutputService.Write(true, [new($"Monster egg placed in egg hatcher!", Properties.Settings.Default.PrimaryForeColor)]);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use monster egg.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void UnlockNewHatcherButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            // Egg hatcher cost can be modified by nodes in the research tree
            int modifiedEggHatcherCost = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.EggHatcherCost, StarterValues.EggHatcherCost);
            if (GameManager.CurrentPlayer.Inventory.Gold < modifiedEggHatcherCost)
            {
                OutputService.Write(true, [new($"Not enough gold to unlock new hatcher. Cost: {modifiedEggHatcherCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Gold, modifiedEggHatcherCost);

                // Remove gold
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    // Unlock new egg hatcher
                    GameManager.Players[playerIndex].EggHatchers.Add(new EggHatcher());

                    OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Unlocked additional egg hatcher!", Properties.Settings.Default.PrimaryForeColor)]);
                }
                else
                {
                    OutputService.Write(true, [new("Failed to use gold.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }
    }
}