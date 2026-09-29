using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;

namespace Game_Elements
{
    public partial class MainForm : Form
    {
        private Form? _currentForm;

        private readonly Dictionary<Type, Func<Form>> _formTypes;

        private DateTime _lastScrolled = DateTime.MinValue;

        public MainForm()
        {
            InitializeComponent();

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            // Initialize form type dictionary for form-switching
            _formTypes = new Dictionary<Type, Func<Form>>
            {
                { typeof(MissionsForm), () => new MissionsForm() },
                { typeof(UnitsForm), () => new UnitsForm() },
                { typeof(TilesForm), () => new TilesForm() },
                { typeof(PlayerForm), () => new PlayerForm() },
                { typeof(ResearchTreeForm), () => new ResearchTreeForm() },
                { typeof(InventoryForm), () => new InventoryForm() },
                { typeof(ItemShopForm), () => new ItemShopForm() },
                { typeof(LootboxForm), () => new LootboxForm() },
                { typeof(QuestsForm), () => new QuestsForm() },
                { typeof(HatcheryForm), () => new HatcheryForm() },
                { typeof(FishingForm), () => new FishingForm() },
                { typeof(GardeningForm), () => new GardeningForm() },
                { typeof(StatisticsForm), () => new StatisticsForm() },
                { typeof(AchievementsForm), () => new AchievementsForm() },
                { typeof(GuideForm), () => new GuideForm() },
                { typeof(CreditsForm), () => new CreditsForm() },
                { typeof(SettingsForm), () => new SettingsForm() },
            };

            // Initialize UI (properties, data binding, etc)
            InitializeUI();

            // Event subscriptions
            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
            OutputService.OnOutput += AppendOutput;
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;

            // Initialize game state
            GameManager.InitializeGame();

            // Set first player as current player
            if (GameManager.Players.Count > 0)
                GameManager.CurrentPlayer = GameManager.Players[0];

            // Start main update timer
            MainTimer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe
            Properties.Settings.Default.PropertyChanged -= Default_PropertyChanged;
            OutputService.OnOutput -= AppendOutput;
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;

            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
                GameManager.CurrentPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                GameManager.CurrentPlayer.PropertyChanged -= CurrentPlayer_PropertyChanged;
            }

            // Stop and dispose timer
            MainTimer.Stop();
            MainTimer.Dispose();

            // Remove any previous form from panel
            MainPanel.Controls.Clear();

            // Close and dispose currently loaded form
            _currentForm?.Close();
            _currentForm?.Dispose();

            // Save game progress before exiting
            GameManager.SaveProgress();
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
                previousPlayer.Modifiers.ListChanged -= Modifiers_ListChanged;
                previousPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
                previousPlayer.PropertyChanged -= CurrentPlayer_PropertyChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.PropertyChanged += CurrentPlayer_PropertyChanged;
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
                GameManager.CurrentPlayer.Modifiers.ListChanged += Modifiers_ListChanged;
            }

            // Update UI elements for new player
            UpdateUI();
        }

        private void CurrentPlayer_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Only refresh the UI element that needs refreshing

            if (e.PropertyName == nameof(Player.Name))
            {
                PlayerNameTSSL.Text = GameManager.CurrentPlayer.Name;
            }
        }

        private void Inventory_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Only refresh the UI element that needs refreshing

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            if (e.PropertyName == nameof(Inventory.Gold))
            {
                GoldTSSL.Text = $"Gold: {GameManager.CurrentPlayer.Inventory.Gold}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxGold, StarterValues.MaxGold)}";
            }
            else if (e.PropertyName == nameof(Inventory.Power))
            {
                PowerTSSL.Text = $"Power: {GameManager.CurrentPlayer.Inventory.Power}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxPower, StarterValues.MaxPower)}";
            }
            else if (e.PropertyName == nameof(Inventory.Lootboxes))
            {
                LootboxesTSSL.Text = $"Lootboxes: {GameManager.CurrentPlayer.Inventory.Lootboxes}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxLootboxes, StarterValues.MaxLootboxes)}";
            }
            else if (e.PropertyName == nameof(Inventory.RushBoosts))
            {
                RushBoostsTSSL.Text = $"Rush Boosts: {GameManager.CurrentPlayer.Inventory.RushBoosts}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRushBoosts, StarterValues.MaxRushBoosts)}";
            }
            else if (e.PropertyName == nameof(Inventory.ExperienceBoosts))
            {
                ExperienceBoostsTSSL.Text = $"Experience Boosts: {GameManager.CurrentPlayer.Inventory.ExperienceBoosts}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxExperienceBoosts, StarterValues.MaxExperienceBoosts)}";
            }
            else if (e.PropertyName == nameof(Inventory.RarityBoosts))
            {
                RarityBoostsTSSL.Text = $"Rarity Boosts: {GameManager.CurrentPlayer.Inventory.RarityBoosts}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRarityBoosts, StarterValues.MaxRarityBoosts)}";
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

        private void Default_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Update UI when application settings change

            if (e.PropertyName == nameof(Properties.Settings.Default.MouseOverBackColor))
            {
                MissionsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                UnitsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                TilesButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                PlayerButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                ResearchTreeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                InventoryButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                ItemShopButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                LootboxButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                QuestsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                HatcheryButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                FishingButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                GardeningButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                StatisticsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                AchievementsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                GuideButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                CreditsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                SettingsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            }
            else if (e.PropertyName == nameof(Properties.Settings.Default.SmallFontSize))
            {
                OutputRTBE.Font = new Font(OutputRTBE.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                MainStatusStrip.Font = new Font(MainStatusStrip.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
            }
            else if (e.PropertyName == nameof(Properties.Settings.Default.MediumFontSize))
            {
                MissionsButton.Font = new Font(MissionsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                UnitsButton.Font = new Font(UnitsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                TilesButton.Font = new Font(TilesButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                PlayerButton.Font = new Font(PlayerButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                ResearchTreeButton.Font = new Font(ResearchTreeButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                InventoryButton.Font = new Font(InventoryButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                ItemShopButton.Font = new Font(ItemShopButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                LootboxButton.Font = new Font(LootboxButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                QuestsButton.Font = new Font(QuestsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                HatcheryButton.Font = new Font(HatcheryButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                FishingButton.Font = new Font(FishingButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                GardeningButton.Font = new Font(GardeningButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                StatisticsButton.Font = new Font(StatisticsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                AchievementsButton.Font = new Font(AchievementsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                GuideButton.Font = new Font(GuideButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                CreditsButton.Font = new Font(CreditsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
                SettingsButton.Font = new Font(SettingsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, data binding, etc)

            DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            MainSC.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            LeftPanel.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            MissionsButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MissionsButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MissionsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            MissionsButton.Font = new Font(MissionsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            UnitsButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            UnitsButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            UnitsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            UnitsButton.Font = new Font(UnitsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            TilesButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            TilesButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            TilesButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            TilesButton.Font = new Font(TilesButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            PlayerButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            PlayerButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            PlayerButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            PlayerButton.Font = new Font(PlayerButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ResearchTreeButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            ResearchTreeButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            ResearchTreeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            ResearchTreeButton.Font = new Font(ResearchTreeButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            InventoryButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            InventoryButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            InventoryButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            InventoryButton.Font = new Font(InventoryButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ItemShopButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            ItemShopButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            ItemShopButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            ItemShopButton.Font = new Font(ItemShopButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            LootboxButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            LootboxButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            LootboxButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            LootboxButton.Font = new Font(LootboxButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            QuestsButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            QuestsButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            QuestsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            QuestsButton.Font = new Font(QuestsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            HatcheryButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            HatcheryButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            HatcheryButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            HatcheryButton.Font = new Font(HatcheryButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            FishingButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            FishingButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            FishingButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            FishingButton.Font = new Font(FishingButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            GardeningButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            GardeningButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            GardeningButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            GardeningButton.Font = new Font(GardeningButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            StatisticsButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            StatisticsButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            StatisticsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            StatisticsButton.Font = new Font(StatisticsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            AchievementsButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            AchievementsButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            AchievementsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            AchievementsButton.Font = new Font(AchievementsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            GuideButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            GuideButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            GuideButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            GuideButton.Font = new Font(GuideButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            CreditsButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            CreditsButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            CreditsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            CreditsButton.Font = new Font(CreditsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            SettingsButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SettingsButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SettingsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            SettingsButton.Font = new Font(SettingsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            RightTLP.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            TopPanel.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            OutputRTBE.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            OutputRTBE.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            OutputRTBE.Font = new Font(OutputRTBE.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MainPanel.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            MainStatusStrip.DataBindings.Add("BackColor", Properties.Settings.Default, "AccentBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MainStatusStrip.DataBindings.Add("ForeColor", Properties.Settings.Default, "AccentForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MainStatusStrip.Font = new Font(MainStatusStrip.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            // Store form type in button Tag for generic click handling
            MissionsButton.Tag = typeof(MissionsForm);
            UnitsButton.Tag = typeof(UnitsForm);
            TilesButton.Tag = typeof(TilesForm);
            PlayerButton.Tag = typeof(PlayerForm);
            ResearchTreeButton.Tag = typeof(ResearchTreeForm);
            InventoryButton.Tag = typeof(InventoryForm);
            ItemShopButton.Tag = typeof(ItemShopForm);
            LootboxButton.Tag = typeof(LootboxForm);
            QuestsButton.Tag = typeof(QuestsForm);
            HatcheryButton.Tag = typeof(HatcheryForm);
            FishingButton.Tag = typeof(FishingForm);
            GardeningButton.Tag = typeof(GardeningForm);
            StatisticsButton.Tag = typeof(StatisticsForm);
            AchievementsButton.Tag = typeof(AchievementsForm);
            GuideButton.Tag = typeof(GuideForm);
            CreditsButton.Tag = typeof(CreditsForm);
            SettingsButton.Tag = typeof(SettingsForm);

            // All form-switching buttons share the same click handler
            MissionsButton.Click += Control_Click;
            UnitsButton.Click += Control_Click;
            TilesButton.Click += Control_Click;
            PlayerButton.Click += Control_Click;
            ResearchTreeButton.Click += Control_Click;
            InventoryButton.Click += Control_Click;
            ItemShopButton.Click += Control_Click;
            LootboxButton.Click += Control_Click;
            QuestsButton.Click += Control_Click;
            HatcheryButton.Click += Control_Click;
            FishingButton.Click += Control_Click;
            GardeningButton.Click += Control_Click;
            StatisticsButton.Click += Control_Click;
            AchievementsButton.Click += Control_Click;
            GuideButton.Click += Control_Click;
            CreditsButton.Click += Control_Click;
            SettingsButton.Click += Control_Click;
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer != null)
            {
                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

                PlayerNameTSSL.Text = GameManager.CurrentPlayer.Name;
                GoldTSSL.Text = $"Gold: {GameManager.CurrentPlayer.Inventory.Gold}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxGold, StarterValues.MaxGold)}";
                PowerTSSL.Text = $"Power: {GameManager.CurrentPlayer.Inventory.Power}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxPower, StarterValues.MaxPower)}";
                LootboxesTSSL.Text = $"Lootboxes: {GameManager.CurrentPlayer.Inventory.Lootboxes}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxLootboxes, StarterValues.MaxLootboxes)}";
                RushBoostsTSSL.Text = $"Rush Boosts: {GameManager.CurrentPlayer.Inventory.RushBoosts}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRushBoosts, StarterValues.MaxRushBoosts)}";
                ExperienceBoostsTSSL.Text = $"Experience Boosts: {GameManager.CurrentPlayer.Inventory.ExperienceBoosts}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxExperienceBoosts, StarterValues.MaxExperienceBoosts)}";
                RarityBoostsTSSL.Text = $"Rarity Boosts: {GameManager.CurrentPlayer.Inventory.RarityBoosts}/{GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRarityBoosts, StarterValues.MaxRarityBoosts)}";
            }
            else
            {
                PlayerNameTSSL.Text = "Player Name";
                GoldTSSL.Text = "Gold";
                PowerTSSL.Text = "Power";
                LootboxesTSSL.Text = "Lootboxes";
                RushBoostsTSSL.Text = "Rush Boosts";
                ExperienceBoostsTSSL.Text = "Experience Boosts";
                RarityBoostsTSSL.Text = "Rarity Boosts";
            }
        }

        public void AppendOutput(bool timestampPrefix, List<OutputSegment> segments)
        {
            // Optionally prepend timestamp
            if (timestampPrefix)
            {
                OutputRTBE.SelectionStart = OutputRTBE.TextLength;
                OutputRTBE.SelectionLength = 0;
                OutputRTBE.SelectionColor = Properties.Settings.Default.PrimaryForeColor;

                // Ensure timestamp uses regular font
                if (OutputRTBE.SelectionFont != null && OutputRTBE.SelectionFont.Style != FontStyle.Regular)
                    OutputRTBE.SelectionFont = new Font(OutputRTBE.Font, FontStyle.Regular);

                OutputRTBE.AppendText($"{DateTime.Now:t} | ");
            }

            // Append each styled text segment
            foreach (var segment in segments)
            {
                OutputRTBE.SelectionStart = OutputRTBE.TextLength;
                OutputRTBE.SelectionLength = 0;
                OutputRTBE.SelectionColor = segment.Color;

                // Build font style flags
                FontStyle style = FontStyle.Regular;
                if (segment.Bold) style |= FontStyle.Bold;
                if (segment.Italic) style |= FontStyle.Italic;
                if (segment.Underline) style |= FontStyle.Underline;

                // Apply style if needed
                if (OutputRTBE.SelectionFont != null && OutputRTBE.SelectionFont.Style != style)
                    OutputRTBE.SelectionFont = new Font(OutputRTBE.Font, style);

                OutputRTBE.AppendText(segment.Text);
            }

            OutputRTBE.AppendText(Environment.NewLine);

            // Auto-scroll only if user hasn't manually scrolled recently
            if ((DateTime.Now - _lastScrolled).TotalSeconds > 3)
                OutputRTBE.ScrollToCaret();
        }

        private void OutputRTBE_Scrolled(object sender, EventArgs e)
        {
            // Record time of manual scroll to temporarily cease auto-scroll
            _lastScrolled = DateTime.Now;
        }

        private void LoadChildForm(Type formType)
        {
            try
            {
                // Remove any previous form from panel
                MainPanel.Controls.Clear();

                // Close and dispose currently loaded form
                _currentForm?.Close();
                _currentForm?.Dispose();

                // Retrieve form type
                if (!_formTypes.TryGetValue(formType, out var form))
                    throw new ArgumentException($"Unsupported form type: {formType.Name}");

                // Create and configure new form
                _currentForm = form();
                _currentForm.TopLevel = false;
                _currentForm.FormBorderStyle = FormBorderStyle.None;
                _currentForm.Dock = DockStyle.Fill;

                // Display inside panel
                MainPanel.Controls.Add(_currentForm);
                _currentForm.BringToFront();
                _currentForm.Show();
            }
            catch (ArgumentException ex)
            {
                _currentForm = null;
                MessageBox.Show($"Error loading form: {ex.Message}");
            }
        }

        private void Control_Click(object? sender, EventArgs e)
        {
            // Ensure sender is a control with a valid tag
            if (sender is not Control control || control.Tag == null)
                return;

            // Load form only if it's different from the currently loaded one
            if (control.Tag is Type type && (_currentForm == null || _currentForm.GetType() != type))
                LoadChildForm(type);
        }

        private void PreviousPlayerTSSL_Click(object sender, EventArgs e)
        {
            // Cycle to previous player
            if (GameManager.CurrentPlayer != null && GameManager.Players.Count > 1)
            {
                int currentPlayerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (currentPlayerIndex != -1)
                {
                    GameManager.CurrentPlayer = currentPlayerIndex > 0 ? GameManager.Players[currentPlayerIndex - 1] : GameManager.Players[^1];
                }
            }
        }

        private void NextPlayerTSSL_Click(object sender, EventArgs e)
        {
            // Cycle to next player
            if (GameManager.CurrentPlayer != null && GameManager.Players.Count > 1)
            {
                int currentPlayerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (currentPlayerIndex != -1)
                {
                    GameManager.CurrentPlayer = currentPlayerIndex < GameManager.Players.Count - 1 ? GameManager.Players[currentPlayerIndex + 1] : GameManager.Players[0];
                }
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            // Advance game logic each tick
            GameManager.Tick();
        }
    }
}
