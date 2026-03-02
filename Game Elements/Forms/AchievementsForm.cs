using Game_Elements.Engine;
using Game_Elements.Models;
using System.ComponentModel;

namespace Game_Elements
{
    public partial class AchievementsForm : Form
    {
        public AchievementsForm()
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            GameManager.CurrentPlayer?.Achievements.ListChanged += Achievements_ListChanged;

            // Update UI elements for current player
            UpdateUI();
        }

        private void AchievementsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose tool tip
            AchievementsToolTip.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            GameManager.CurrentPlayer?.Achievements.ListChanged -= Achievements_ListChanged;
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
            previousPlayer?.Achievements.ListChanged -= Achievements_ListChanged;

            // Subscribe to new player's events
            GameManager.CurrentPlayer?.Achievements.ListChanged += Achievements_ListChanged;

            // Update UI elements for new player
            UpdateUI();
        }

        private void Achievements_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                if (GameManager.CurrentPlayer == null)
                    return;

                // Retrieve the achievement that was modified
                var changedAchievement = GameManager.CurrentPlayer.Achievements[e.NewIndex];

                // Find the corresponding label control with a tag matching this achievement
                var matchingCtrl = AchievementsFLP.Controls
                    .OfType<Label>()
                    .FirstOrDefault(c => c.Tag == changedAchievement);

                // Only update the UI if the label exists and the achievement is unlocked
                if (matchingCtrl != null && changedAchievement.Unlocked)
                {
                    // Label text
                    matchingCtrl.Text = $"{changedAchievement.Title}\n{changedAchievement.UnlockedTime}";

                    if (!changedAchievement.Seen)
                    {
                        // Visually indicate that this achievement was unlocked and it hasnt been seen yet
                        matchingCtrl.Font = new Font(matchingCtrl.Font.FontFamily, Properties.Settings.Default.SmallFontSize, FontStyle.Bold);

                        // Enable mark all as seen, if it isn't already
                        if (!MarkAllAsSeenButton.Enabled)
                            MarkAllAsSeenButton.Enabled = true;
                    }

                    // Tooltip
                    AchievementsToolTip.SetToolTip(matchingCtrl, $"{changedAchievement.Description}");
                }
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            AchievementsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            AchievementsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            AchievementsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            AchievementsFLP.Padding = new Padding(Properties.Settings.Default.Padding);
            AchievementsFLP.BackColor = Properties.Settings.Default.PrimaryBackColor;
            AchievementsFLP.Font = new Font(AchievementsFLP.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            MarkAllAsSeenButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            MarkAllAsSeenButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MarkAllAsSeenButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            MarkAllAsSeenButton.Font = new Font(MarkAllAsSeenButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            AchievementsToolTip.SetToolTip(MarkAllAsSeenButton, "Mark all unlocked and unseen achievements as seen.");
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            AchievementsFLP.SuspendLayout();
            AchievementsFLP.Controls.Clear();
            foreach (var achievement in GameManager.CurrentPlayer.Achievements)
            {
                // Create a label for this achievement
                var label = new Label
                {
                    AutoSize = true,
                    Text = $"{achievement.Title}" + $"{(achievement.Unlocked ? $"\n{achievement.UnlockedTime}" : "")}",
                    Tag = achievement,
                    ForeColor = Properties.Settings.Default.PrimaryForeColor,
                    Margin = new Padding(5),
                    Font = (achievement.Unlocked && !achievement.Seen) ? new Font(AchievementsFLP.Font.FontFamily, Properties.Settings.Default.SmallFontSize, FontStyle.Bold) : new Font(AchievementsFLP.Font.FontFamily, Properties.Settings.Default.SmallFontSize, FontStyle.Regular)
                };

                // Attach event handler
                label.MouseEnter += AchievementLabel_MouseEnter;

                // Add to FLP
                AchievementsFLP.Controls.Add(label);

                // Tooltip
                AchievementsToolTip.SetToolTip(label, achievement.Unlocked ? $"{achievement.Description}" : "Achievement conditions revealed after unlocking.");
            }
            AchievementsFLP.ResumeLayout();

            // Only enable button if there are unlocked achievements that are unseen
            MarkAllAsSeenButton.Enabled = GameManager.CurrentPlayer.Achievements.Any(a => a.Unlocked && !a.Seen);
        }

        private void AchievementLabel_MouseEnter(object? sender, EventArgs e)
        {
            // Mark an unlocked and unseen achievement as seen

            if (GameManager.CurrentPlayer == null)
                return;

            var label = sender as Label;
            if (label?.Tag is Achievement achievement && achievement.Unlocked && !achievement.Seen)
            {
                // Mark the achievement as seen
                achievement.Seen = true;

                // Visually indicate that it has been viewed
                label.Font = new Font(label.Font.FontFamily, Properties.Settings.Default.SmallFontSize, FontStyle.Regular);

                if (MarkAllAsSeenButton.Enabled && !GameManager.CurrentPlayer.Achievements.Any(a => a.Unlocked && !a.Seen))
                    MarkAllAsSeenButton.Enabled = false;
            }
        }

        private void MarkAllAsSeenButton_Click(object sender, EventArgs e)
        {
            // Mark all unlocked and unseen achievements as seen

            AchievementsFLP.SuspendLayout();
            foreach (var label in AchievementsFLP.Controls.OfType<Label>())
            {
                // Check that the label represents an achievement that is unlocked and unseen
                if (label.Tag is Achievement achievement && achievement.Unlocked && !achievement.Seen)
                {
                    // Mark the achievement as seen
                    achievement.Seen = true;

                    // Visually indicate that it has been viewed
                    label.Font = new Font(label.Font.FontFamily, Properties.Settings.Default.SmallFontSize, FontStyle.Regular);
                }
            }
            AchievementsFLP.ResumeLayout();

            MarkAllAsSeenButton.Enabled = false;
        }
    }
}
