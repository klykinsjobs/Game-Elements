namespace Game_Elements
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StatisticsTLP = new TableLayoutPanel();
            StatsBackPanel = new Panel();
            StatsTLP = new TableLayoutPanel();
            MissionsStartedLabel = new Label();
            MissionsSucceededLabel = new Label();
            MissionsFailedLabel = new Label();
            RushBoostsUsedLabel = new Label();
            ExperienceBoostsUsedLabel = new Label();
            RarityBoostsUsedLabel = new Label();
            LootboxesOpenedLabel = new Label();
            ItemsSoldLabel = new Label();
            ItemsBoughtLabel = new Label();
            AchievementsUnlockedLabel = new Label();
            QuestsCompletedLabel = new Label();
            QuestsDismissedLabel = new Label();
            FishCaughtLabel = new Label();
            PlantsHarvestedLabel = new Label();
            EggsHatchedLabel = new Label();
            TilesTerraformedLabel = new Label();
            BuildingsConstructedLabel = new Label();
            NodesResearchedLabel = new Label();
            UnitsCollectedLabel = new Label();
            ItemsCollectedLabel = new Label();
            GoldCollectedLabel = new Label();
            LootboxesCollectedLabel = new Label();
            ResearchCollectedLabel = new Label();
            PowerCollectedLabel = new Label();
            StatisticsTLP.SuspendLayout();
            StatsBackPanel.SuspendLayout();
            StatsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // StatisticsTLP
            // 
            StatisticsTLP.ColumnCount = 1;
            StatisticsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            StatisticsTLP.Controls.Add(StatsBackPanel, 0, 0);
            StatisticsTLP.Dock = DockStyle.Fill;
            StatisticsTLP.Location = new Point(0, 0);
            StatisticsTLP.Name = "StatisticsTLP";
            StatisticsTLP.RowCount = 1;
            StatisticsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            StatisticsTLP.Size = new Size(800, 450);
            StatisticsTLP.TabIndex = 0;
            // 
            // StatsBackPanel
            // 
            StatsBackPanel.Controls.Add(StatsTLP);
            StatsBackPanel.Dock = DockStyle.Fill;
            StatsBackPanel.Location = new Point(3, 3);
            StatsBackPanel.Name = "StatsBackPanel";
            StatsBackPanel.Size = new Size(794, 444);
            StatsBackPanel.TabIndex = 0;
            // 
            // StatsTLP
            // 
            StatsTLP.ColumnCount = 3;
            StatsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            StatsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            StatsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            StatsTLP.Controls.Add(MissionsStartedLabel, 0, 0);
            StatsTLP.Controls.Add(MissionsSucceededLabel, 0, 1);
            StatsTLP.Controls.Add(MissionsFailedLabel, 0, 2);
            StatsTLP.Controls.Add(RushBoostsUsedLabel, 0, 3);
            StatsTLP.Controls.Add(ExperienceBoostsUsedLabel, 0, 4);
            StatsTLP.Controls.Add(RarityBoostsUsedLabel, 0, 5);
            StatsTLP.Controls.Add(LootboxesOpenedLabel, 0, 6);
            StatsTLP.Controls.Add(ItemsSoldLabel, 0, 7);
            StatsTLP.Controls.Add(ItemsBoughtLabel, 1, 0);
            StatsTLP.Controls.Add(AchievementsUnlockedLabel, 1, 1);
            StatsTLP.Controls.Add(QuestsCompletedLabel, 1, 2);
            StatsTLP.Controls.Add(QuestsDismissedLabel, 1, 3);
            StatsTLP.Controls.Add(FishCaughtLabel, 1, 4);
            StatsTLP.Controls.Add(PlantsHarvestedLabel, 1, 5);
            StatsTLP.Controls.Add(EggsHatchedLabel, 1, 6);
            StatsTLP.Controls.Add(TilesTerraformedLabel, 1, 7);
            StatsTLP.Controls.Add(BuildingsConstructedLabel, 2, 0);
            StatsTLP.Controls.Add(NodesResearchedLabel, 2, 1);
            StatsTLP.Controls.Add(UnitsCollectedLabel, 2, 2);
            StatsTLP.Controls.Add(ItemsCollectedLabel, 2, 3);
            StatsTLP.Controls.Add(GoldCollectedLabel, 2, 4);
            StatsTLP.Controls.Add(LootboxesCollectedLabel, 2, 5);
            StatsTLP.Controls.Add(ResearchCollectedLabel, 2, 6);
            StatsTLP.Controls.Add(PowerCollectedLabel, 2, 7);
            StatsTLP.Dock = DockStyle.Fill;
            StatsTLP.Location = new Point(0, 0);
            StatsTLP.Name = "StatsTLP";
            StatsTLP.RowCount = 8;
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            StatsTLP.Size = new Size(794, 444);
            StatsTLP.TabIndex = 0;
            // 
            // MissionsStartedLabel
            // 
            MissionsStartedLabel.Anchor = AnchorStyles.None;
            MissionsStartedLabel.AutoSize = true;
            MissionsStartedLabel.Location = new Point(73, 20);
            MissionsStartedLabel.Name = "MissionsStartedLabel";
            MissionsStartedLabel.Size = new Size(118, 15);
            MissionsStartedLabel.TabIndex = 0;
            MissionsStartedLabel.Text = "MissionsStartedLabel";
            MissionsStartedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MissionsSucceededLabel
            // 
            MissionsSucceededLabel.Anchor = AnchorStyles.None;
            MissionsSucceededLabel.AutoSize = true;
            MissionsSucceededLabel.Location = new Point(63, 75);
            MissionsSucceededLabel.Name = "MissionsSucceededLabel";
            MissionsSucceededLabel.Size = new Size(138, 15);
            MissionsSucceededLabel.TabIndex = 1;
            MissionsSucceededLabel.Text = "MissionsSucceededLabel";
            MissionsSucceededLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MissionsFailedLabel
            // 
            MissionsFailedLabel.Anchor = AnchorStyles.None;
            MissionsFailedLabel.AutoSize = true;
            MissionsFailedLabel.Location = new Point(76, 130);
            MissionsFailedLabel.Name = "MissionsFailedLabel";
            MissionsFailedLabel.Size = new Size(112, 15);
            MissionsFailedLabel.TabIndex = 2;
            MissionsFailedLabel.Text = "MissionsFailedLabel";
            MissionsFailedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RushBoostsUsedLabel
            // 
            RushBoostsUsedLabel.Anchor = AnchorStyles.None;
            RushBoostsUsedLabel.AutoSize = true;
            RushBoostsUsedLabel.Location = new Point(71, 185);
            RushBoostsUsedLabel.Name = "RushBoostsUsedLabel";
            RushBoostsUsedLabel.Size = new Size(122, 15);
            RushBoostsUsedLabel.TabIndex = 3;
            RushBoostsUsedLabel.Text = "RushBoostsUsedLabel";
            RushBoostsUsedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExperienceBoostsUsedLabel
            // 
            ExperienceBoostsUsedLabel.Anchor = AnchorStyles.None;
            ExperienceBoostsUsedLabel.AutoSize = true;
            ExperienceBoostsUsedLabel.Location = new Point(55, 240);
            ExperienceBoostsUsedLabel.Name = "ExperienceBoostsUsedLabel";
            ExperienceBoostsUsedLabel.Size = new Size(153, 15);
            ExperienceBoostsUsedLabel.TabIndex = 4;
            ExperienceBoostsUsedLabel.Text = "ExperienceBoostsUsedLabel";
            ExperienceBoostsUsedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RarityBoostsUsedLabel
            // 
            RarityBoostsUsedLabel.Anchor = AnchorStyles.None;
            RarityBoostsUsedLabel.AutoSize = true;
            RarityBoostsUsedLabel.Location = new Point(69, 295);
            RarityBoostsUsedLabel.Name = "RarityBoostsUsedLabel";
            RarityBoostsUsedLabel.Size = new Size(126, 15);
            RarityBoostsUsedLabel.TabIndex = 5;
            RarityBoostsUsedLabel.Text = "RarityBoostsUsedLabel";
            RarityBoostsUsedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LootboxesOpenedLabel
            // 
            LootboxesOpenedLabel.Anchor = AnchorStyles.None;
            LootboxesOpenedLabel.AutoSize = true;
            LootboxesOpenedLabel.Location = new Point(66, 350);
            LootboxesOpenedLabel.Name = "LootboxesOpenedLabel";
            LootboxesOpenedLabel.Size = new Size(132, 15);
            LootboxesOpenedLabel.TabIndex = 6;
            LootboxesOpenedLabel.Text = "LootboxesOpenedLabel";
            LootboxesOpenedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ItemsSoldLabel
            // 
            ItemsSoldLabel.Anchor = AnchorStyles.None;
            ItemsSoldLabel.AutoSize = true;
            ItemsSoldLabel.Location = new Point(88, 407);
            ItemsSoldLabel.Name = "ItemsSoldLabel";
            ItemsSoldLabel.Size = new Size(87, 15);
            ItemsSoldLabel.TabIndex = 7;
            ItemsSoldLabel.Text = "ItemsSoldLabel";
            ItemsSoldLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ItemsBoughtLabel
            // 
            ItemsBoughtLabel.Anchor = AnchorStyles.None;
            ItemsBoughtLabel.AutoSize = true;
            ItemsBoughtLabel.Location = new Point(344, 20);
            ItemsBoughtLabel.Name = "ItemsBoughtLabel";
            ItemsBoughtLabel.Size = new Size(103, 15);
            ItemsBoughtLabel.TabIndex = 8;
            ItemsBoughtLabel.Text = "ItemsBoughtLabel";
            ItemsBoughtLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AchievementsUnlockedLabel
            // 
            AchievementsUnlockedLabel.Anchor = AnchorStyles.None;
            AchievementsUnlockedLabel.AutoSize = true;
            AchievementsUnlockedLabel.Location = new Point(316, 75);
            AchievementsUnlockedLabel.Name = "AchievementsUnlockedLabel";
            AchievementsUnlockedLabel.Size = new Size(160, 15);
            AchievementsUnlockedLabel.TabIndex = 9;
            AchievementsUnlockedLabel.Text = "AchievementsUnlockedLabel";
            AchievementsUnlockedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QuestsCompletedLabel
            // 
            QuestsCompletedLabel.Anchor = AnchorStyles.None;
            QuestsCompletedLabel.AutoSize = true;
            QuestsCompletedLabel.Location = new Point(331, 130);
            QuestsCompletedLabel.Name = "QuestsCompletedLabel";
            QuestsCompletedLabel.Size = new Size(130, 15);
            QuestsCompletedLabel.TabIndex = 10;
            QuestsCompletedLabel.Text = "QuestsCompletedLabel";
            QuestsCompletedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QuestsDismissedLabel
            // 
            QuestsDismissedLabel.Anchor = AnchorStyles.None;
            QuestsDismissedLabel.AutoSize = true;
            QuestsDismissedLabel.Location = new Point(334, 185);
            QuestsDismissedLabel.Name = "QuestsDismissedLabel";
            QuestsDismissedLabel.Size = new Size(124, 15);
            QuestsDismissedLabel.TabIndex = 11;
            QuestsDismissedLabel.Text = "QuestsDismissedLabel";
            QuestsDismissedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FishCaughtLabel
            // 
            FishCaughtLabel.Anchor = AnchorStyles.None;
            FishCaughtLabel.AutoSize = true;
            FishCaughtLabel.Location = new Point(348, 240);
            FishCaughtLabel.Name = "FishCaughtLabel";
            FishCaughtLabel.Size = new Size(95, 15);
            FishCaughtLabel.TabIndex = 12;
            FishCaughtLabel.Text = "FishCaughtLabel";
            FishCaughtLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlantsHarvestedLabel
            // 
            PlantsHarvestedLabel.Anchor = AnchorStyles.None;
            PlantsHarvestedLabel.AutoSize = true;
            PlantsHarvestedLabel.Location = new Point(336, 295);
            PlantsHarvestedLabel.Name = "PlantsHarvestedLabel";
            PlantsHarvestedLabel.Size = new Size(120, 15);
            PlantsHarvestedLabel.TabIndex = 13;
            PlantsHarvestedLabel.Text = "PlantsHarvestedLabel";
            PlantsHarvestedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EggsHatchedLabel
            // 
            EggsHatchedLabel.Anchor = AnchorStyles.None;
            EggsHatchedLabel.AutoSize = true;
            EggsHatchedLabel.Location = new Point(343, 350);
            EggsHatchedLabel.Name = "EggsHatchedLabel";
            EggsHatchedLabel.Size = new Size(105, 15);
            EggsHatchedLabel.TabIndex = 14;
            EggsHatchedLabel.Text = "EggsHatchedLabel";
            EggsHatchedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TilesTerraformedLabel
            // 
            TilesTerraformedLabel.Anchor = AnchorStyles.None;
            TilesTerraformedLabel.AutoSize = true;
            TilesTerraformedLabel.Location = new Point(374, 407);
            TilesTerraformedLabel.Name = "TilesTerraformedLabel";
            TilesTerraformedLabel.Size = new Size(44, 15);
            TilesTerraformedLabel.TabIndex = 15;
            TilesTerraformedLabel.Text = "label16";
            TilesTerraformedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BuildingsConstructedLabel
            // 
            BuildingsConstructedLabel.Anchor = AnchorStyles.None;
            BuildingsConstructedLabel.AutoSize = true;
            BuildingsConstructedLabel.Location = new Point(586, 20);
            BuildingsConstructedLabel.Name = "BuildingsConstructedLabel";
            BuildingsConstructedLabel.Size = new Size(149, 15);
            BuildingsConstructedLabel.TabIndex = 16;
            BuildingsConstructedLabel.Text = "BuildingsConstructedLabel";
            BuildingsConstructedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NodesResearchedLabel
            // 
            NodesResearchedLabel.Anchor = AnchorStyles.None;
            NodesResearchedLabel.AutoSize = true;
            NodesResearchedLabel.Location = new Point(596, 75);
            NodesResearchedLabel.Name = "NodesResearchedLabel";
            NodesResearchedLabel.Size = new Size(129, 15);
            NodesResearchedLabel.TabIndex = 17;
            NodesResearchedLabel.Text = "NodesResearchedLabel";
            NodesResearchedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UnitsCollectedLabel
            // 
            UnitsCollectedLabel.Anchor = AnchorStyles.None;
            UnitsCollectedLabel.AutoSize = true;
            UnitsCollectedLabel.Location = new Point(605, 130);
            UnitsCollectedLabel.Name = "UnitsCollectedLabel";
            UnitsCollectedLabel.Size = new Size(112, 15);
            UnitsCollectedLabel.TabIndex = 18;
            UnitsCollectedLabel.Text = "UnitsCollectedLabel";
            UnitsCollectedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ItemsCollectedLabel
            // 
            ItemsCollectedLabel.Anchor = AnchorStyles.None;
            ItemsCollectedLabel.AutoSize = true;
            ItemsCollectedLabel.Location = new Point(604, 185);
            ItemsCollectedLabel.Name = "ItemsCollectedLabel";
            ItemsCollectedLabel.Size = new Size(114, 15);
            ItemsCollectedLabel.TabIndex = 19;
            ItemsCollectedLabel.Text = "ItemsCollectedLabel";
            ItemsCollectedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GoldCollectedLabel
            // 
            GoldCollectedLabel.Anchor = AnchorStyles.None;
            GoldCollectedLabel.AutoSize = true;
            GoldCollectedLabel.Location = new Point(606, 240);
            GoldCollectedLabel.Name = "GoldCollectedLabel";
            GoldCollectedLabel.Size = new Size(110, 15);
            GoldCollectedLabel.TabIndex = 20;
            GoldCollectedLabel.Text = "GoldCollectedLabel";
            GoldCollectedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LootboxesCollectedLabel
            // 
            LootboxesCollectedLabel.Anchor = AnchorStyles.None;
            LootboxesCollectedLabel.AutoSize = true;
            LootboxesCollectedLabel.Location = new Point(591, 295);
            LootboxesCollectedLabel.Name = "LootboxesCollectedLabel";
            LootboxesCollectedLabel.Size = new Size(140, 15);
            LootboxesCollectedLabel.TabIndex = 21;
            LootboxesCollectedLabel.Text = "LootboxesCollectedLabel";
            LootboxesCollectedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ResearchCollectedLabel
            // 
            ResearchCollectedLabel.Anchor = AnchorStyles.None;
            ResearchCollectedLabel.AutoSize = true;
            ResearchCollectedLabel.Location = new Point(595, 350);
            ResearchCollectedLabel.Name = "ResearchCollectedLabel";
            ResearchCollectedLabel.Size = new Size(132, 15);
            ResearchCollectedLabel.TabIndex = 22;
            ResearchCollectedLabel.Text = "ResearchCollectedLabel";
            ResearchCollectedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PowerCollectedLabel
            // 
            PowerCollectedLabel.Anchor = AnchorStyles.None;
            PowerCollectedLabel.AutoSize = true;
            PowerCollectedLabel.Location = new Point(602, 407);
            PowerCollectedLabel.Name = "PowerCollectedLabel";
            PowerCollectedLabel.Size = new Size(118, 15);
            PowerCollectedLabel.TabIndex = 23;
            PowerCollectedLabel.Text = "PowerCollectedLabel";
            PowerCollectedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StatisticsTLP);
            Name = "StatisticsForm";
            Text = "StatisticsForm";
            FormClosing += StatisticsForm_FormClosing;
            StatisticsTLP.ResumeLayout(false);
            StatsBackPanel.ResumeLayout(false);
            StatsTLP.ResumeLayout(false);
            StatsTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel StatisticsTLP;
        private Panel StatsBackPanel;
        private TableLayoutPanel StatsTLP;
        private Label MissionsStartedLabel;
        private Label MissionsSucceededLabel;
        private Label MissionsFailedLabel;
        private Label RushBoostsUsedLabel;
        private Label ExperienceBoostsUsedLabel;
        private Label RarityBoostsUsedLabel;
        private Label LootboxesOpenedLabel;
        private Label ItemsSoldLabel;
        private Label ItemsBoughtLabel;
        private Label AchievementsUnlockedLabel;
        private Label QuestsCompletedLabel;
        private Label QuestsDismissedLabel;
        private Label FishCaughtLabel;
        private Label PlantsHarvestedLabel;
        private Label EggsHatchedLabel;
        private Label TilesTerraformedLabel;
        private Label BuildingsConstructedLabel;
        private Label NodesResearchedLabel;
        private Label UnitsCollectedLabel;
        private Label ItemsCollectedLabel;
        private Label GoldCollectedLabel;
        private Label LootboxesCollectedLabel;
        private Label ResearchCollectedLabel;
        private Label PowerCollectedLabel;
    }
}