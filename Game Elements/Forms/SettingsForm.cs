namespace Game_Elements
{
    public partial class SettingsForm : Form
    {
        private bool _isLoaded = false;

        public SettingsForm()
        {
            InitializeComponent();

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            // Initialize UI (properties, data binding, etc)
            InitializeUI();

            // Event subscriptions
            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe
            Properties.Settings.Default.PropertyChanged -= Default_PropertyChanged;
        }

        private void Default_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Update UI when application settings change

            if (e.PropertyName == nameof(Properties.Settings.Default.MouseOverBackColor))
            {
                PrimaryBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                SecondaryBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                MouseOverBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                SelectedBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                AccentBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;

                PrimaryForeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                SelectedForeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                AccentForeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;

                SuccessButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                FailureButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                ErrorButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                FlavorButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;

                CommonButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                RareButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                EpicButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                LegendaryButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;

                WaterButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                GrasslandButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                DesertButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                MountainButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;

                Player1Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                Player2Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                Player3Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                Player4Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            }
            else if (e.PropertyName == nameof(Properties.Settings.Default.SmallFontSize))
            {
                SmallFontSizeLabel.Font = new Font(SmallFontSizeLabel.Font.FontFamily, SmallFontSizeTrackBar.Value);

                PrimaryBackButton.Font = new Font(PrimaryBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                SecondaryBackButton.Font = new Font(SecondaryBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                MouseOverBackButton.Font = new Font(MouseOverBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                SelectedBackButton.Font = new Font(SelectedBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                AccentBackButton.Font = new Font(AccentBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

                PrimaryForeButton.Font = new Font(PrimaryForeButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                SelectedForeButton.Font = new Font(SelectedForeButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                AccentForeButton.Font = new Font(AccentForeButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

                SuccessButton.Font = new Font(SuccessButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                FailureButton.Font = new Font(FailureButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                ErrorButton.Font = new Font(ErrorButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                FlavorButton.Font = new Font(FlavorButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

                CommonButton.Font = new Font(CommonButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                RareButton.Font = new Font(RareButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                EpicButton.Font = new Font(EpicButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                LegendaryButton.Font = new Font(LegendaryButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

                WaterButton.Font = new Font(WaterButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                GrasslandButton.Font = new Font(GrasslandButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                DesertButton.Font = new Font(DesertButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                MountainButton.Font = new Font(MountainButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

                Player1Button.Font = new Font(Player1Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                Player2Button.Font = new Font(Player2Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                Player3Button.Font = new Font(Player3Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                Player4Button.Font = new Font(Player4Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
            }
            else if (e.PropertyName == nameof(Properties.Settings.Default.MediumFontSize))
            {
                MediumFontSizeLabel.Font = new Font(MediumFontSizeLabel.Font.FontFamily, MediumFontSizeTrackBar.Value);
            }
            else if (e.PropertyName == nameof(Properties.Settings.Default.LargeFontSize))
            {
                LargeFontSizeLabel.Font = new Font(LargeFontSizeLabel.Font.FontFamily, LargeFontSizeTrackBar.Value);
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, data binding, etc)

            DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            SettingsFormTLP.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            SettingsBackPanel.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SettingsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);

            SettingsTLP.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SettingsTLP.Padding = new Padding(Properties.Settings.Default.Padding);

            LayoutColorsGroupBox.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            TextColorsGroupBox.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            RarityColorsGroupBox.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            TileColorsGroupBox.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            OtherGroupBox.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            PlayerColorsGroupBox.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            PrimaryBackButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            PrimaryBackButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            PrimaryBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            PrimaryBackButton.Font = new Font(PrimaryBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SecondaryBackButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SecondaryBackButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SecondaryBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            SecondaryBackButton.Font = new Font(SecondaryBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MouseOverBackButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MouseOverBackButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MouseOverBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            MouseOverBackButton.Font = new Font(MouseOverBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SelectedBackButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SelectedBackButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SelectedBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            SelectedBackButton.Font = new Font(SelectedBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            AccentBackButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            AccentBackButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            AccentBackButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            AccentBackButton.Font = new Font(AccentBackButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            PrimaryForeButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            PrimaryForeButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            PrimaryForeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            PrimaryForeButton.Font = new Font(PrimaryForeButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SelectedForeButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SelectedForeButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SelectedForeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            SelectedForeButton.Font = new Font(SelectedForeButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            AccentForeButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            AccentForeButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            AccentForeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            AccentForeButton.Font = new Font(AccentForeButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            SuccessButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SuccessButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SuccessButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            SuccessButton.Font = new Font(SuccessButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FailureButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            FailureButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            FailureButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            FailureButton.Font = new Font(FailureButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ErrorButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            ErrorButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            ErrorButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            ErrorButton.Font = new Font(ErrorButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FlavorButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            FlavorButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            FlavorButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            FlavorButton.Font = new Font(FlavorButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            CommonButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            CommonButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            CommonButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            CommonButton.Font = new Font(CommonButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            RareButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            RareButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            RareButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            RareButton.Font = new Font(RareButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            EpicButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            EpicButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            EpicButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            EpicButton.Font = new Font(EpicButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            LegendaryButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            LegendaryButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            LegendaryButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            LegendaryButton.Font = new Font(LegendaryButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            WaterButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            WaterButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            WaterButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            WaterButton.Font = new Font(WaterButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            GrasslandButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            GrasslandButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            GrasslandButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            GrasslandButton.Font = new Font(GrasslandButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            DesertButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            DesertButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            DesertButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            DesertButton.Font = new Font(DesertButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MountainButton.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MountainButton.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MountainButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            MountainButton.Font = new Font(MountainButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            Player1Button.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player1Button.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player1Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            Player1Button.Font = new Font(Player1Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            Player2Button.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player2Button.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player2Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            Player2Button.Font = new Font(Player2Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            Player3Button.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player3Button.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player3Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            Player3Button.Font = new Font(Player3Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            Player4Button.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player4Button.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            Player4Button.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            Player4Button.Font = new Font(Player4Button.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            PrimaryBackPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            SecondaryBackPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "SecondaryBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            MouseOverBackPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "MouseOverBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            SelectedBackPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "SelectedBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            AccentBackPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "AccentBackColor", true, DataSourceUpdateMode.OnPropertyChanged);

            PrimaryForePictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            SelectedForePictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "SelectedForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            AccentForePictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "AccentForeColor", true, DataSourceUpdateMode.OnPropertyChanged);

            SuccessPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "SuccessTextColor", true, DataSourceUpdateMode.OnPropertyChanged);

            FailurePictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "FailureTextColor", true, DataSourceUpdateMode.OnPropertyChanged);

            ErrorPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "ErrorTextColor", true, DataSourceUpdateMode.OnPropertyChanged);

            FlavorPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "FlavorTextColor", true, DataSourceUpdateMode.OnPropertyChanged);

            CommonPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "CommonRarityColor", true, DataSourceUpdateMode.OnPropertyChanged);

            RarePictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "RareRarityColor", true, DataSourceUpdateMode.OnPropertyChanged);

            EpicPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "EpicRarityColor", true, DataSourceUpdateMode.OnPropertyChanged);

            LegendaryPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "LegendaryRarityColor", true, DataSourceUpdateMode.OnPropertyChanged);

            WaterTerrainPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "WaterTerrainColor", true, DataSourceUpdateMode.OnPropertyChanged);

            GrasslandTerrainPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "GrasslandTerrainColor", true, DataSourceUpdateMode.OnPropertyChanged);

            DesertTerrainPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "DesertTerrainColor", true, DataSourceUpdateMode.OnPropertyChanged);

            MountainTerrainPictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "MountainTerrainColor", true, DataSourceUpdateMode.OnPropertyChanged);

            Player1PictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "P1BuildingColor", true, DataSourceUpdateMode.OnPropertyChanged);

            Player2PictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "P2BuildingColor", true, DataSourceUpdateMode.OnPropertyChanged);

            Player3PictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "P3BuildingColor", true, DataSourceUpdateMode.OnPropertyChanged);

            Player4PictureBox.DataBindings.Add("BackColor", Properties.Settings.Default, "P4BuildingColor", true, DataSourceUpdateMode.OnPropertyChanged);

            SmallFontSizeLabel.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            SmallFontSizeLabel.Font = new Font(SmallFontSizeLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MediumFontSizeLabel.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            MediumFontSizeLabel.Font = new Font(MediumFontSizeLabel.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            LargeFontSizeLabel.DataBindings.Add("ForeColor", Properties.Settings.Default, "PrimaryForeColor", true, DataSourceUpdateMode.OnPropertyChanged);
            LargeFontSizeLabel.Font = new Font(LargeFontSizeLabel.Font.FontFamily, Properties.Settings.Default.LargeFontSize);

            SmallFontSizeTrackBar.Value = Properties.Settings.Default.SmallFontSize;

            MediumFontSizeTrackBar.Value = Properties.Settings.Default.MediumFontSize;

            LargeFontSizeTrackBar.Value = Properties.Settings.Default.LargeFontSize;

            _isLoaded = true;
        }

        private void SetColor(string propertyName)
        {
            // Set the color dialog's initial color to the current color for this property
            switch (propertyName)
            {
                case "PrimaryBack": SettingsColorDialog.Color = PrimaryBackPictureBox.BackColor; break;
                case "SecondaryBack": SettingsColorDialog.Color = SecondaryBackPictureBox.BackColor; break;
                case "MouseOverBack": SettingsColorDialog.Color = MouseOverBackPictureBox.BackColor; break;
                case "SelectedBack": SettingsColorDialog.Color = SelectedBackPictureBox.BackColor; break;
                case "AccentBack": SettingsColorDialog.Color = AccentBackPictureBox.BackColor; break;

                case "PrimaryFore": SettingsColorDialog.Color = PrimaryForePictureBox.BackColor; break;
                case "SelectedFore": SettingsColorDialog.Color = SelectedForePictureBox.BackColor; break;
                case "AccentFore": SettingsColorDialog.Color = AccentForePictureBox.BackColor; break;

                case "SuccessText": SettingsColorDialog.Color = SuccessPictureBox.BackColor; break;
                case "FailureText": SettingsColorDialog.Color = FailurePictureBox.BackColor; break;
                case "ErrorText": SettingsColorDialog.Color = ErrorPictureBox.BackColor; break;
                case "FlavorText": SettingsColorDialog.Color = FlavorPictureBox.BackColor; break;

                case "CommonRarity": SettingsColorDialog.Color = CommonPictureBox.BackColor; break;
                case "RareRarity": SettingsColorDialog.Color = RarePictureBox.BackColor; break;
                case "EpicRarity": SettingsColorDialog.Color = EpicPictureBox.BackColor; break;
                case "LegendaryRarity": SettingsColorDialog.Color = LegendaryPictureBox.BackColor; break;

                case "WaterTerrain": SettingsColorDialog.Color = WaterTerrainPictureBox.BackColor; break;
                case "GrasslandTerrain": SettingsColorDialog.Color = GrasslandTerrainPictureBox.BackColor; break;
                case "DesertTerrain": SettingsColorDialog.Color = DesertTerrainPictureBox.BackColor; break;
                case "MountainTerrain": SettingsColorDialog.Color = MountainTerrainPictureBox.BackColor; break;

                case "P1Building": SettingsColorDialog.Color = Player1PictureBox.BackColor; break;
                case "P2Building": SettingsColorDialog.Color = Player2PictureBox.BackColor; break;
                case "P3Building": SettingsColorDialog.Color = Player3PictureBox.BackColor; break;
                case "P4Building": SettingsColorDialog.Color = Player4PictureBox.BackColor; break;
            }

            // Update the color for this property
            if (SettingsColorDialog.ShowDialog() == DialogResult.OK)
            {
                switch (propertyName)
                {
                    case "PrimaryBack": Properties.Settings.Default.PrimaryBackColor = SettingsColorDialog.Color; break;
                    case "SecondaryBack": Properties.Settings.Default.SecondaryBackColor = SettingsColorDialog.Color; break;
                    case "MouseOverBack": Properties.Settings.Default.MouseOverBackColor = SettingsColorDialog.Color; break;
                    case "SelectedBack": Properties.Settings.Default.SelectedBackColor = SettingsColorDialog.Color; break;
                    case "AccentBack": Properties.Settings.Default.AccentBackColor = SettingsColorDialog.Color; break;

                    case "PrimaryFore": Properties.Settings.Default.PrimaryForeColor = SettingsColorDialog.Color; break;
                    case "SelectedFore": Properties.Settings.Default.SelectedForeColor = SettingsColorDialog.Color; break;
                    case "AccentFore": Properties.Settings.Default.AccentForeColor = SettingsColorDialog.Color; break;

                    case "SuccessText": Properties.Settings.Default.SuccessTextColor = SettingsColorDialog.Color; break;
                    case "FailureText": Properties.Settings.Default.FailureTextColor = SettingsColorDialog.Color; break;
                    case "ErrorText": Properties.Settings.Default.ErrorTextColor = SettingsColorDialog.Color; break;
                    case "FlavorText": Properties.Settings.Default.FlavorTextColor = SettingsColorDialog.Color; break;

                    case "CommonRarity": Properties.Settings.Default.CommonRarityColor = SettingsColorDialog.Color; break;
                    case "RareRarity": Properties.Settings.Default.RareRarityColor = SettingsColorDialog.Color; break;
                    case "EpicRarity": Properties.Settings.Default.EpicRarityColor = SettingsColorDialog.Color; break;
                    case "LegendaryRarity": Properties.Settings.Default.LegendaryRarityColor = SettingsColorDialog.Color; break;

                    case "WaterTerrain": Properties.Settings.Default.WaterTerrainColor = SettingsColorDialog.Color; break;
                    case "GrasslandTerrain": Properties.Settings.Default.GrasslandTerrainColor = SettingsColorDialog.Color; break;
                    case "DesertTerrain": Properties.Settings.Default.DesertTerrainColor = SettingsColorDialog.Color; break;
                    case "MountainTerrain": Properties.Settings.Default.MountainTerrainColor = SettingsColorDialog.Color; break;

                    case "P1Building": Properties.Settings.Default.P1BuildingColor = SettingsColorDialog.Color; break;
                    case "P2Building": Properties.Settings.Default.P2BuildingColor = SettingsColorDialog.Color; break;
                    case "P3Building": Properties.Settings.Default.P3BuildingColor = SettingsColorDialog.Color; break;
                    case "P4Building": Properties.Settings.Default.P4BuildingColor = SettingsColorDialog.Color; break;
                }

                // Save settings
                Properties.Settings.Default.Save();
            }
        }

        private void PrimaryBackButton_Click(object sender, EventArgs e) => SetColor("PrimaryBack");
        private void SecondaryBackButton_Click(object sender, EventArgs e) => SetColor("SecondaryBack");
        private void MouseOverBackButton_Click(object sender, EventArgs e) => SetColor("MouseOverBack");
        private void SelectedBackButton_Click(object sender, EventArgs e) => SetColor("SelectedBack");
        private void AccentBackButton_Click(object sender, EventArgs e) => SetColor("AccentBack");

        private void PrimaryForeButton_Click(object sender, EventArgs e) => SetColor("PrimaryFore");
        private void SelectedForeButton_Click(object sender, EventArgs e) => SetColor("SelectedFore");
        private void AccentForeButton_Click(object sender, EventArgs e) => SetColor("AccentFore");

        private void SuccessTextButton_Click(object sender, EventArgs e) => SetColor("SuccessText");
        private void FailureTextButton_Click(object sender, EventArgs e) => SetColor("FailureText");
        private void ErrorTextButton_Click(object sender, EventArgs e) => SetColor("ErrorText");
        private void FlavorTextButton_Click(object sender, EventArgs e) => SetColor("FlavorText");

        private void CommonRarityButton_Click(object sender, EventArgs e) => SetColor("CommonRarity");
        private void RareRarityButton_Click(object sender, EventArgs e) => SetColor("RareRarity");
        private void EpicRarityButton_Click(object sender, EventArgs e) => SetColor("EpicRarity");
        private void LegendaryRarityButton_Click(object sender, EventArgs e) => SetColor("LegendaryRarity");

        private void WaterTerrainButton_Click(object sender, EventArgs e) => SetColor("WaterTerrain");
        private void GrasslandTerrainButton_Click(object sender, EventArgs e) => SetColor("GrasslandTerrain");
        private void DesertTerrainButton_Click(object sender, EventArgs e) => SetColor("DesertTerrain");
        private void MountainTerrainButton_Click(object sender, EventArgs e) => SetColor("MountainTerrain");

        private void P1BuildingButton_Click(object sender, EventArgs e) => SetColor("P1Building");
        private void P2BuildingButton_Click(object sender, EventArgs e) => SetColor("P2Building");
        private void P3BuildingButton_Click(object sender, EventArgs e) => SetColor("P3Building");
        private void P4BuildingButton_Click(object sender, EventArgs e) => SetColor("P4Building");

        private void SmallFontSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // Bypass during form load
            if (_isLoaded)
            {
                // Update this setting
                Properties.Settings.Default.SmallFontSize = SmallFontSizeTrackBar.Value;

                // Save settings
                Properties.Settings.Default.Save();
            }
        }

        private void MediumFontSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // Bypass during form load
            if (_isLoaded)
            {
                // Update this setting
                Properties.Settings.Default.MediumFontSize = MediumFontSizeTrackBar.Value;

                // Save settings
                Properties.Settings.Default.Save();
            }
        }

        private void LargeFontSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // Bypass during form load
            if (_isLoaded)
            {
                // Update this setting
                Properties.Settings.Default.LargeFontSize = LargeFontSizeTrackBar.Value;

                // Save settings
                Properties.Settings.Default.Save();
            }
        }
    }
}