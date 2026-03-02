using Game_Elements.Engine;
using Game_Elements.Models;
using System.ComponentModel;

namespace Game_Elements
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Statistics.PropertyChanged += Statistics_PropertyChanged;
            }

            // Update UI elements for current player
            UpdateUI();
        }

        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Statistics.PropertyChanged -= Statistics_PropertyChanged;
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
                previousPlayer.Statistics.PropertyChanged -= Statistics_PropertyChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Statistics.PropertyChanged += Statistics_PropertyChanged;
            }

            // Update UI elements for new player
            UpdateUI();
        }

        private void Statistics_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Only refresh the UI element that needs refreshing

            if (e.PropertyName == nameof(Statistics.MissionsStarted))
            {
                MissionsStartedLabel.Text = $"Missions Started: {GameManager.CurrentPlayer.Statistics.MissionsStarted}";
            }
            else if (e.PropertyName == nameof(Statistics.MissionsSucceeded))
            {
                MissionsSucceededLabel.Text = $"Missions Succeeded: {GameManager.CurrentPlayer.Statistics.MissionsSucceeded}";
            }
            else if (e.PropertyName == nameof(Statistics.MissionsFailed))
            {
                MissionsFailedLabel.Text = $"Missions Failed: {GameManager.CurrentPlayer.Statistics.MissionsFailed}";
            }
            else if (e.PropertyName == nameof(Statistics.RushBoostsUsed))
            {
                RushBoostsUsedLabel.Text = $"Rush Boosts Used: {GameManager.CurrentPlayer.Statistics.RushBoostsUsed}";
            }
            else if (e.PropertyName == nameof(Statistics.ExperienceBoostsUsed))
            {
                ExperienceBoostsUsedLabel.Text = $"Experience Boosts Used: {GameManager.CurrentPlayer.Statistics.ExperienceBoostsUsed}";
            }
            else if (e.PropertyName == nameof(Statistics.RarityBoostsUsed))
            {
                RarityBoostsUsedLabel.Text = $"Rarity Boosts Used: {GameManager.CurrentPlayer.Statistics.RarityBoostsUsed}";
            }
            else if (e.PropertyName == nameof(Statistics.LootboxesOpened))
            {
                LootboxesOpenedLabel.Text = $"Lootboxes Opened: {GameManager.CurrentPlayer.Statistics.LootboxesOpened}";
            }
            else if (e.PropertyName == nameof(Statistics.ItemsSold))
            {
                ItemsSoldLabel.Text = $"Items Sold: {GameManager.CurrentPlayer.Statistics.ItemsSold}";
            }
            else if (e.PropertyName == nameof(Statistics.ItemsBought))
            {
                ItemsBoughtLabel.Text = $"Items Bought: {GameManager.CurrentPlayer.Statistics.ItemsBought}";
            }
            else if (e.PropertyName == nameof(Statistics.AchievementsUnlocked))
            {
                AchievementsUnlockedLabel.Text = $"Achievements Unlocked: {GameManager.CurrentPlayer.Statistics.AchievementsUnlocked}";
            }
            else if (e.PropertyName == nameof(Statistics.QuestsCompleted))
            {
                QuestsCompletedLabel.Text = $"Quests Completed: {GameManager.CurrentPlayer.Statistics.QuestsCompleted}";
            }
            else if (e.PropertyName == nameof(Statistics.QuestsDismissed))
            {
                QuestsDismissedLabel.Text = $"Quests Dismissed: {GameManager.CurrentPlayer.Statistics.QuestsDismissed}";
            }
            else if (e.PropertyName == nameof(Statistics.FishCaught))
            {
                FishCaughtLabel.Text = $"Fish Caught: {GameManager.CurrentPlayer.Statistics.FishCaught}";
            }
            else if (e.PropertyName == nameof(Statistics.PlantsHarvested))
            {
                PlantsHarvestedLabel.Text = $"Plants Harvested: {GameManager.CurrentPlayer.Statistics.PlantsHarvested}";
            }
            else if (e.PropertyName == nameof(Statistics.EggsHatched))
            {
                EggsHatchedLabel.Text = $"Eggs Hatched: {GameManager.CurrentPlayer.Statistics.EggsHatched}";
            }
            else if (e.PropertyName == nameof(Statistics.TilesTerraformed))
            {
                TilesTerraformedLabel.Text = $"Tiles Terraformed: {GameManager.CurrentPlayer.Statistics.TilesTerraformed}";
            }
            else if (e.PropertyName == nameof(Statistics.BuildingsConstructed))
            {
                BuildingsConstructedLabel.Text = $"Buildings Constructed: {GameManager.CurrentPlayer.Statistics.BuildingsConstructed}";
            }
            else if (e.PropertyName == nameof(Statistics.NodesResearched))
            {
                NodesResearchedLabel.Text = $"Nodes Researched: {GameManager.CurrentPlayer.Statistics.NodesResearched}";
            }
            else if (e.PropertyName == nameof(Statistics.UnitsCollected))
            {
                UnitsCollectedLabel.Text = $"Units Collected: {GameManager.CurrentPlayer.Statistics.UnitsCollected}";
            }
            else if (e.PropertyName == nameof(Statistics.ItemsCollected))
            {
                ItemsCollectedLabel.Text = $"Items Collected: {GameManager.CurrentPlayer.Statistics.ItemsCollected}";
            }
            else if (e.PropertyName == nameof(Statistics.GoldCollected))
            {
                GoldCollectedLabel.Text = $"Gold Collected: {GameManager.CurrentPlayer.Statistics.GoldCollected}";
            }
            else if (e.PropertyName == nameof(Statistics.LootboxesCollected))
            {
                LootboxesCollectedLabel.Text = $"Lootboxes Collected: {GameManager.CurrentPlayer.Statistics.LootboxesCollected}";
            }
            else if (e.PropertyName == nameof(Statistics.ResearchCollected))
            {
                ResearchCollectedLabel.Text = $"Research Collected: {GameManager.CurrentPlayer.Statistics.ResearchCollected}";
            }
            else if (e.PropertyName == nameof(Statistics.PowerCollected))
            {
                PowerCollectedLabel.Text = $"Power Collected: {GameManager.CurrentPlayer.Statistics.PowerCollected}";
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            StatisticsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            StatsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            StatsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            StatsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            StatsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            MissionsStartedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MissionsStartedLabel.Font = new Font(MissionsStartedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MissionsSucceededLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MissionsSucceededLabel.Font = new Font(MissionsSucceededLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MissionsFailedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MissionsFailedLabel.Font = new Font(MissionsFailedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            RushBoostsUsedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RushBoostsUsedLabel.Font = new Font(RushBoostsUsedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ExperienceBoostsUsedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ExperienceBoostsUsedLabel.Font = new Font(ExperienceBoostsUsedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            RarityBoostsUsedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RarityBoostsUsedLabel.Font = new Font(RarityBoostsUsedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            LootboxesOpenedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            LootboxesOpenedLabel.Font = new Font(LootboxesOpenedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ItemsSoldLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ItemsSoldLabel.Font = new Font(ItemsSoldLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ItemsBoughtLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ItemsBoughtLabel.Font = new Font(ItemsBoughtLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            AchievementsUnlockedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            AchievementsUnlockedLabel.Font = new Font(AchievementsUnlockedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            QuestsCompletedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            QuestsCompletedLabel.Font = new Font(QuestsCompletedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            QuestsDismissedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            QuestsDismissedLabel.Font = new Font(QuestsDismissedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            FishCaughtLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FishCaughtLabel.Font = new Font(FishCaughtLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            PlantsHarvestedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PlantsHarvestedLabel.Font = new Font(PlantsHarvestedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            EggsHatchedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            EggsHatchedLabel.Font = new Font(EggsHatchedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            TilesTerraformedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            TilesTerraformedLabel.Font = new Font(TilesTerraformedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            BuildingsConstructedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            BuildingsConstructedLabel.Font = new Font(BuildingsConstructedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            NodesResearchedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            NodesResearchedLabel.Font = new Font(NodesResearchedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            UnitsCollectedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UnitsCollectedLabel.Font = new Font(UnitsCollectedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ItemsCollectedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ItemsCollectedLabel.Font = new Font(ItemsCollectedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            GoldCollectedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            GoldCollectedLabel.Font = new Font(GoldCollectedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            LootboxesCollectedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            LootboxesCollectedLabel.Font = new Font(LootboxesCollectedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ResearchCollectedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ResearchCollectedLabel.Font = new Font(ResearchCollectedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            PowerCollectedLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PowerCollectedLabel.Font = new Font(PowerCollectedLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            MissionsStartedLabel.Text = $"Missions Started: {GameManager.CurrentPlayer.Statistics.MissionsStarted}";
            MissionsSucceededLabel.Text = $"Missions Succeeded: {GameManager.CurrentPlayer.Statistics.MissionsSucceeded}";
            MissionsFailedLabel.Text = $"Missions Failed: {GameManager.CurrentPlayer.Statistics.MissionsFailed}";
            RushBoostsUsedLabel.Text = $"Rush Boosts Used: {GameManager.CurrentPlayer.Statistics.RushBoostsUsed}";
            ExperienceBoostsUsedLabel.Text = $"Experience Boosts Used: {GameManager.CurrentPlayer.Statistics.ExperienceBoostsUsed}";
            RarityBoostsUsedLabel.Text = $"Rarity Boosts Used: {GameManager.CurrentPlayer.Statistics.RarityBoostsUsed}";
            LootboxesOpenedLabel.Text = $"Lootboxes Opened: {GameManager.CurrentPlayer.Statistics.LootboxesOpened}";
            ItemsSoldLabel.Text = $"Items Sold: {GameManager.CurrentPlayer.Statistics.ItemsSold}";
            ItemsBoughtLabel.Text = $"Items Bought: {GameManager.CurrentPlayer.Statistics.ItemsBought}";

            AchievementsUnlockedLabel.Text = $"Achievements Unlocked: {GameManager.CurrentPlayer.Statistics.AchievementsUnlocked}";
            QuestsCompletedLabel.Text = $"Quests Completed: {GameManager.CurrentPlayer.Statistics.QuestsCompleted}";
            QuestsDismissedLabel.Text = $"Quests Dismissed: {GameManager.CurrentPlayer.Statistics.QuestsDismissed}";
            FishCaughtLabel.Text = $"Fish Caught: {GameManager.CurrentPlayer.Statistics.FishCaught}";
            PlantsHarvestedLabel.Text = $"Plants Harvested: {GameManager.CurrentPlayer.Statistics.PlantsHarvested}";
            EggsHatchedLabel.Text = $"Eggs Hatched: {GameManager.CurrentPlayer.Statistics.EggsHatched}";
            TilesTerraformedLabel.Text = $"Tiles Terraformed: {GameManager.CurrentPlayer.Statistics.TilesTerraformed}";
            BuildingsConstructedLabel.Text = $"Buildings Constructed: {GameManager.CurrentPlayer.Statistics.BuildingsConstructed}";
            NodesResearchedLabel.Text = $"Nodes Researched: {GameManager.CurrentPlayer.Statistics.NodesResearched}";

            UnitsCollectedLabel.Text = $"Units Collected: {GameManager.CurrentPlayer.Statistics.UnitsCollected}";
            ItemsCollectedLabel.Text = $"Items Collected: {GameManager.CurrentPlayer.Statistics.ItemsCollected}";
            GoldCollectedLabel.Text = $"Gold Collected: {GameManager.CurrentPlayer.Statistics.GoldCollected}";
            LootboxesCollectedLabel.Text = $"Lootboxes Collected: {GameManager.CurrentPlayer.Statistics.LootboxesCollected}";
            ResearchCollectedLabel.Text = $"Research Collected: {GameManager.CurrentPlayer.Statistics.ResearchCollected}";
            PowerCollectedLabel.Text = $"Power Collected: {GameManager.CurrentPlayer.Statistics.PowerCollected}";
        }
    }
}