namespace Game_Elements
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainSC = new SplitContainer();
            LeftPanel = new Panel();
            GuideButton = new Button();
            CreditsButton = new Button();
            SettingsButton = new Button();
            AchievementsButton = new Button();
            StatisticsButton = new Button();
            GardeningButton = new Button();
            FishingButton = new Button();
            HatcheryButton = new Button();
            QuestsButton = new Button();
            LootboxButton = new Button();
            ItemShopButton = new Button();
            InventoryButton = new Button();
            ResearchTreeButton = new Button();
            PlayerButton = new Button();
            TilesButton = new Button();
            UnitsButton = new Button();
            MissionsButton = new Button();
            RightTLP = new TableLayoutPanel();
            TopPanel = new Panel();
            OutputRTBE = new RichTextBoxExtended();
            MainPanel = new Panel();
            MainTimer = new System.Windows.Forms.Timer(components);
            MainStatusStrip = new StatusStrip();
            PreviousPlayerTSSL = new ToolStripStatusLabel();
            NextPlayerTSSL = new ToolStripStatusLabel();
            PlayerNameTSSL = new ToolStripStatusLabel();
            GoldTSSL = new ToolStripStatusLabel();
            PowerTSSL = new ToolStripStatusLabel();
            LootboxesTSSL = new ToolStripStatusLabel();
            RushBoostsTSSL = new ToolStripStatusLabel();
            ExperienceBoostsTSSL = new ToolStripStatusLabel();
            RarityBoostsTSSL = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)MainSC).BeginInit();
            MainSC.Panel1.SuspendLayout();
            MainSC.Panel2.SuspendLayout();
            MainSC.SuspendLayout();
            LeftPanel.SuspendLayout();
            RightTLP.SuspendLayout();
            TopPanel.SuspendLayout();
            MainStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainSC
            // 
            MainSC.Dock = DockStyle.Fill;
            MainSC.Location = new Point(0, 0);
            MainSC.Name = "MainSC";
            // 
            // MainSC.Panel1
            // 
            MainSC.Panel1.Controls.Add(LeftPanel);
            // 
            // MainSC.Panel2
            // 
            MainSC.Panel2.Controls.Add(RightTLP);
            MainSC.Size = new Size(1484, 839);
            MainSC.SplitterDistance = 250;
            MainSC.TabIndex = 0;
            // 
            // LeftPanel
            // 
            LeftPanel.Controls.Add(GuideButton);
            LeftPanel.Controls.Add(CreditsButton);
            LeftPanel.Controls.Add(SettingsButton);
            LeftPanel.Controls.Add(AchievementsButton);
            LeftPanel.Controls.Add(StatisticsButton);
            LeftPanel.Controls.Add(GardeningButton);
            LeftPanel.Controls.Add(FishingButton);
            LeftPanel.Controls.Add(HatcheryButton);
            LeftPanel.Controls.Add(QuestsButton);
            LeftPanel.Controls.Add(LootboxButton);
            LeftPanel.Controls.Add(ItemShopButton);
            LeftPanel.Controls.Add(InventoryButton);
            LeftPanel.Controls.Add(ResearchTreeButton);
            LeftPanel.Controls.Add(PlayerButton);
            LeftPanel.Controls.Add(TilesButton);
            LeftPanel.Controls.Add(UnitsButton);
            LeftPanel.Controls.Add(MissionsButton);
            LeftPanel.Dock = DockStyle.Fill;
            LeftPanel.Location = new Point(0, 0);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(250, 839);
            LeftPanel.TabIndex = 0;
            // 
            // GuideButton
            // 
            GuideButton.AutoSize = true;
            GuideButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GuideButton.Dock = DockStyle.Bottom;
            GuideButton.FlatAppearance.BorderSize = 0;
            GuideButton.FlatStyle = FlatStyle.Flat;
            GuideButton.Location = new Point(0, 764);
            GuideButton.Name = "GuideButton";
            GuideButton.Size = new Size(250, 25);
            GuideButton.TabIndex = 14;
            GuideButton.Text = "Guide";
            GuideButton.UseVisualStyleBackColor = true;
            // 
            // CreditsButton
            // 
            CreditsButton.AutoSize = true;
            CreditsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CreditsButton.Dock = DockStyle.Bottom;
            CreditsButton.FlatAppearance.BorderSize = 0;
            CreditsButton.FlatStyle = FlatStyle.Flat;
            CreditsButton.Location = new Point(0, 789);
            CreditsButton.Name = "CreditsButton";
            CreditsButton.Size = new Size(250, 25);
            CreditsButton.TabIndex = 15;
            CreditsButton.Text = "Credits";
            CreditsButton.UseVisualStyleBackColor = true;
            // 
            // SettingsButton
            // 
            SettingsButton.AutoSize = true;
            SettingsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SettingsButton.Dock = DockStyle.Bottom;
            SettingsButton.FlatAppearance.BorderSize = 0;
            SettingsButton.FlatStyle = FlatStyle.Flat;
            SettingsButton.Location = new Point(0, 814);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(250, 25);
            SettingsButton.TabIndex = 16;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            // 
            // AchievementsButton
            // 
            AchievementsButton.AutoSize = true;
            AchievementsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AchievementsButton.Dock = DockStyle.Top;
            AchievementsButton.FlatAppearance.BorderSize = 0;
            AchievementsButton.FlatStyle = FlatStyle.Flat;
            AchievementsButton.Location = new Point(0, 325);
            AchievementsButton.Name = "AchievementsButton";
            AchievementsButton.Size = new Size(250, 25);
            AchievementsButton.TabIndex = 13;
            AchievementsButton.Text = "Achievements";
            AchievementsButton.UseVisualStyleBackColor = true;
            // 
            // StatisticsButton
            // 
            StatisticsButton.AutoSize = true;
            StatisticsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StatisticsButton.Dock = DockStyle.Top;
            StatisticsButton.FlatAppearance.BorderSize = 0;
            StatisticsButton.FlatStyle = FlatStyle.Flat;
            StatisticsButton.Location = new Point(0, 300);
            StatisticsButton.Name = "StatisticsButton";
            StatisticsButton.Size = new Size(250, 25);
            StatisticsButton.TabIndex = 12;
            StatisticsButton.Text = "Statistics";
            StatisticsButton.UseVisualStyleBackColor = true;
            // 
            // GardeningButton
            // 
            GardeningButton.AutoSize = true;
            GardeningButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            GardeningButton.Dock = DockStyle.Top;
            GardeningButton.FlatAppearance.BorderSize = 0;
            GardeningButton.FlatStyle = FlatStyle.Flat;
            GardeningButton.Location = new Point(0, 275);
            GardeningButton.Name = "GardeningButton";
            GardeningButton.Size = new Size(250, 25);
            GardeningButton.TabIndex = 11;
            GardeningButton.Text = "Gardening";
            GardeningButton.UseVisualStyleBackColor = true;
            // 
            // FishingButton
            // 
            FishingButton.AutoSize = true;
            FishingButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FishingButton.Dock = DockStyle.Top;
            FishingButton.FlatAppearance.BorderSize = 0;
            FishingButton.FlatStyle = FlatStyle.Flat;
            FishingButton.Location = new Point(0, 250);
            FishingButton.Name = "FishingButton";
            FishingButton.Size = new Size(250, 25);
            FishingButton.TabIndex = 10;
            FishingButton.Text = "Fishing";
            FishingButton.UseVisualStyleBackColor = true;
            // 
            // HatcheryButton
            // 
            HatcheryButton.AutoSize = true;
            HatcheryButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            HatcheryButton.Dock = DockStyle.Top;
            HatcheryButton.FlatAppearance.BorderSize = 0;
            HatcheryButton.FlatStyle = FlatStyle.Flat;
            HatcheryButton.Location = new Point(0, 225);
            HatcheryButton.Name = "HatcheryButton";
            HatcheryButton.Size = new Size(250, 25);
            HatcheryButton.TabIndex = 9;
            HatcheryButton.Text = "Hatchery";
            HatcheryButton.UseVisualStyleBackColor = true;
            // 
            // QuestsButton
            // 
            QuestsButton.AutoSize = true;
            QuestsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            QuestsButton.Dock = DockStyle.Top;
            QuestsButton.FlatAppearance.BorderSize = 0;
            QuestsButton.FlatStyle = FlatStyle.Flat;
            QuestsButton.Location = new Point(0, 200);
            QuestsButton.Name = "QuestsButton";
            QuestsButton.Size = new Size(250, 25);
            QuestsButton.TabIndex = 8;
            QuestsButton.Text = "Quests";
            QuestsButton.UseVisualStyleBackColor = true;
            // 
            // LootboxButton
            // 
            LootboxButton.AutoSize = true;
            LootboxButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LootboxButton.Dock = DockStyle.Top;
            LootboxButton.FlatAppearance.BorderSize = 0;
            LootboxButton.FlatStyle = FlatStyle.Flat;
            LootboxButton.Location = new Point(0, 175);
            LootboxButton.Name = "LootboxButton";
            LootboxButton.Size = new Size(250, 25);
            LootboxButton.TabIndex = 7;
            LootboxButton.Text = "Lootbox";
            LootboxButton.UseVisualStyleBackColor = true;
            // 
            // ItemShopButton
            // 
            ItemShopButton.AutoSize = true;
            ItemShopButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ItemShopButton.Dock = DockStyle.Top;
            ItemShopButton.FlatAppearance.BorderSize = 0;
            ItemShopButton.FlatStyle = FlatStyle.Flat;
            ItemShopButton.Location = new Point(0, 150);
            ItemShopButton.Name = "ItemShopButton";
            ItemShopButton.Size = new Size(250, 25);
            ItemShopButton.TabIndex = 6;
            ItemShopButton.Text = "Item Shop";
            ItemShopButton.UseVisualStyleBackColor = true;
            // 
            // InventoryButton
            // 
            InventoryButton.AutoSize = true;
            InventoryButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InventoryButton.Dock = DockStyle.Top;
            InventoryButton.FlatAppearance.BorderSize = 0;
            InventoryButton.FlatStyle = FlatStyle.Flat;
            InventoryButton.Location = new Point(0, 125);
            InventoryButton.Name = "InventoryButton";
            InventoryButton.Size = new Size(250, 25);
            InventoryButton.TabIndex = 5;
            InventoryButton.Text = "Inventory";
            InventoryButton.UseVisualStyleBackColor = true;
            // 
            // ResearchTreeButton
            // 
            ResearchTreeButton.AutoSize = true;
            ResearchTreeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ResearchTreeButton.Dock = DockStyle.Top;
            ResearchTreeButton.FlatAppearance.BorderSize = 0;
            ResearchTreeButton.FlatStyle = FlatStyle.Flat;
            ResearchTreeButton.Location = new Point(0, 100);
            ResearchTreeButton.Name = "ResearchTreeButton";
            ResearchTreeButton.Size = new Size(250, 25);
            ResearchTreeButton.TabIndex = 4;
            ResearchTreeButton.Text = "Research Tree";
            ResearchTreeButton.UseVisualStyleBackColor = true;
            // 
            // PlayerButton
            // 
            PlayerButton.AutoSize = true;
            PlayerButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PlayerButton.Dock = DockStyle.Top;
            PlayerButton.FlatAppearance.BorderSize = 0;
            PlayerButton.FlatStyle = FlatStyle.Flat;
            PlayerButton.Location = new Point(0, 75);
            PlayerButton.Name = "PlayerButton";
            PlayerButton.Size = new Size(250, 25);
            PlayerButton.TabIndex = 3;
            PlayerButton.Text = "Player";
            PlayerButton.UseVisualStyleBackColor = true;
            // 
            // TilesButton
            // 
            TilesButton.AutoSize = true;
            TilesButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TilesButton.Dock = DockStyle.Top;
            TilesButton.FlatAppearance.BorderSize = 0;
            TilesButton.FlatStyle = FlatStyle.Flat;
            TilesButton.Location = new Point(0, 50);
            TilesButton.Name = "TilesButton";
            TilesButton.Size = new Size(250, 25);
            TilesButton.TabIndex = 2;
            TilesButton.Text = "Tiles";
            TilesButton.UseVisualStyleBackColor = true;
            // 
            // UnitsButton
            // 
            UnitsButton.AutoSize = true;
            UnitsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            UnitsButton.Dock = DockStyle.Top;
            UnitsButton.FlatAppearance.BorderSize = 0;
            UnitsButton.FlatStyle = FlatStyle.Flat;
            UnitsButton.Location = new Point(0, 25);
            UnitsButton.Name = "UnitsButton";
            UnitsButton.Size = new Size(250, 25);
            UnitsButton.TabIndex = 1;
            UnitsButton.Text = "Units";
            UnitsButton.UseVisualStyleBackColor = true;
            // 
            // MissionsButton
            // 
            MissionsButton.AutoSize = true;
            MissionsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MissionsButton.Dock = DockStyle.Top;
            MissionsButton.FlatAppearance.BorderSize = 0;
            MissionsButton.FlatStyle = FlatStyle.Flat;
            MissionsButton.Location = new Point(0, 0);
            MissionsButton.Name = "MissionsButton";
            MissionsButton.Size = new Size(250, 25);
            MissionsButton.TabIndex = 0;
            MissionsButton.Text = "Missions";
            MissionsButton.UseVisualStyleBackColor = true;
            // 
            // RightTLP
            // 
            RightTLP.ColumnCount = 1;
            RightTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            RightTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            RightTLP.Controls.Add(TopPanel, 0, 0);
            RightTLP.Controls.Add(MainPanel, 0, 1);
            RightTLP.Dock = DockStyle.Fill;
            RightTLP.Location = new Point(0, 0);
            RightTLP.Name = "RightTLP";
            RightTLP.RowCount = 2;
            RightTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            RightTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            RightTLP.Size = new Size(1230, 839);
            RightTLP.TabIndex = 0;
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(OutputRTBE);
            TopPanel.Dock = DockStyle.Fill;
            TopPanel.Location = new Point(3, 3);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1224, 203);
            TopPanel.TabIndex = 0;
            // 
            // OutputRTBE
            // 
            OutputRTBE.Dock = DockStyle.Fill;
            OutputRTBE.Location = new Point(0, 0);
            OutputRTBE.Name = "OutputRTBE";
            OutputRTBE.Size = new Size(1224, 203);
            OutputRTBE.TabIndex = 0;
            OutputRTBE.Text = "";
            OutputRTBE.Scrolled += OutputRTBE_Scrolled;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(3, 212);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1224, 624);
            MainPanel.TabIndex = 1;
            // 
            // MainTimer
            // 
            MainTimer.Interval = 1000;
            MainTimer.Tick += MainTimer_Tick;
            // 
            // MainStatusStrip
            // 
            MainStatusStrip.Items.AddRange(new ToolStripItem[] { PreviousPlayerTSSL, NextPlayerTSSL, PlayerNameTSSL, GoldTSSL, PowerTSSL, LootboxesTSSL, RushBoostsTSSL, ExperienceBoostsTSSL, RarityBoostsTSSL });
            MainStatusStrip.Location = new Point(0, 839);
            MainStatusStrip.Name = "MainStatusStrip";
            MainStatusStrip.Size = new Size(1484, 22);
            MainStatusStrip.TabIndex = 1;
            MainStatusStrip.Text = "statusStrip1";
            // 
            // PreviousPlayerTSSL
            // 
            PreviousPlayerTSSL.Name = "PreviousPlayerTSSL";
            PreviousPlayerTSSL.Size = new Size(15, 17);
            PreviousPlayerTSSL.Text = "<";
            PreviousPlayerTSSL.Click += PreviousPlayerTSSL_Click;
            // 
            // NextPlayerTSSL
            // 
            NextPlayerTSSL.Name = "NextPlayerTSSL";
            NextPlayerTSSL.Size = new Size(15, 17);
            NextPlayerTSSL.Text = ">";
            NextPlayerTSSL.Click += NextPlayerTSSL_Click;
            // 
            // PlayerNameTSSL
            // 
            PlayerNameTSSL.Name = "PlayerNameTSSL";
            PlayerNameTSSL.Size = new Size(74, 17);
            PlayerNameTSSL.Text = "Player Name";
            // 
            // GoldTSSL
            // 
            GoldTSSL.Name = "GoldTSSL";
            GoldTSSL.Size = new Size(32, 17);
            GoldTSSL.Text = "Gold";
            // 
            // PowerTSSL
            // 
            PowerTSSL.Name = "PowerTSSL";
            PowerTSSL.Size = new Size(40, 17);
            PowerTSSL.Text = "Power";
            // 
            // LootboxesTSSL
            // 
            LootboxesTSSL.Name = "LootboxesTSSL";
            LootboxesTSSL.Size = new Size(62, 17);
            LootboxesTSSL.Text = "Lootboxes";
            // 
            // RushBoostsTSSL
            // 
            RushBoostsTSSL.Name = "RushBoostsTSSL";
            RushBoostsTSSL.Size = new Size(71, 17);
            RushBoostsTSSL.Text = "Rush Boosts";
            // 
            // ExperienceBoostsTSSL
            // 
            ExperienceBoostsTSSL.Name = "ExperienceBoostsTSSL";
            ExperienceBoostsTSSL.Size = new Size(102, 17);
            ExperienceBoostsTSSL.Text = "Experience Boosts";
            // 
            // RarityBoostsTSSL
            // 
            RarityBoostsTSSL.Name = "RarityBoostsTSSL";
            RarityBoostsTSSL.Size = new Size(75, 17);
            RarityBoostsTSSL.Text = "Rarity Boosts";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1484, 861);
            Controls.Add(MainSC);
            Controls.Add(MainStatusStrip);
            Name = "MainForm";
            Text = "Game Elements";
            FormClosing += MainForm_FormClosing;
            MainSC.Panel1.ResumeLayout(false);
            MainSC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSC).EndInit();
            MainSC.ResumeLayout(false);
            LeftPanel.ResumeLayout(false);
            LeftPanel.PerformLayout();
            RightTLP.ResumeLayout(false);
            TopPanel.ResumeLayout(false);
            MainStatusStrip.ResumeLayout(false);
            MainStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer MainSC;
        private Panel LeftPanel;
        private TableLayoutPanel RightTLP;
        private Panel TopPanel;
        private RichTextBoxExtended OutputRTBE;
        private Panel MainPanel;
        private System.Windows.Forms.Timer MainTimer;
        private StatusStrip MainStatusStrip;
        private ToolStripStatusLabel PreviousPlayerTSSL;
        private ToolStripStatusLabel NextPlayerTSSL;
        private ToolStripStatusLabel PlayerNameTSSL;
        private Button SettingsButton;
        private Button CreditsButton;
        private Button GuideButton;
        private Button AchievementsButton;
        private Button StatisticsButton;
        private Button GardeningButton;
        private Button FishingButton;
        private Button HatcheryButton;
        private Button QuestsButton;
        private Button LootboxButton;
        private Button ItemShopButton;
        private Button InventoryButton;
        private Button ResearchTreeButton;
        private Button PlayerButton;
        private Button TilesButton;
        private Button UnitsButton;
        private Button MissionsButton;
        private ToolStripStatusLabel GoldTSSL;
        private ToolStripStatusLabel PowerTSSL;
        private ToolStripStatusLabel LootboxesTSSL;
        private ToolStripStatusLabel RushBoostsTSSL;
        private ToolStripStatusLabel ExperienceBoostsTSSL;
        private ToolStripStatusLabel RarityBoostsTSSL;
    }
}
