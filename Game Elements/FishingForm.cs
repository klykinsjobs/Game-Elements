namespace Game_Elements
{
    public partial class FishingForm : Form
    {
        private FishingState _fishingState = FishingState.Idle;

        public FishingForm()
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;

            // Update UI elements for current player
            UpdateUI();
        }

        private void FishingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
        }

        private void GameManager_CurrentPlayerChanged(Player? previousPlayer)
        {
            // Ensure event runs on UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => GameManager_CurrentPlayerChanged(previousPlayer)));
                return;
            }

            // Update UI elements for current player
            UpdateUI();
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            FishingTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            StatusBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            StatusBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            StatusTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            StatusTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            StatusLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            StatusLabel.Font = new Font(StatusLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            CastButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            CastButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            CastButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            CastButton.Font = new Font(CastButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ReelButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            ReelButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ReelButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            ReelButton.Font = new Font(ReelButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            FishJournalListBox.BackColor = Properties.Settings.Default.PrimaryBackColor;
            FishJournalListBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FishJournalListBox.Font = new Font(FishJournalListBox.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
            FishJournalListBox.ItemHeight = TextRenderer.MeasureText("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_+", FishJournalListBox.Font).Height;

            ResultBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ResultBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ResultTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ResultTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ResultLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ResultLabel.Font = new Font(ResultLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (CastTimer.Enabled)
                CastTimer.Stop();

            if (ReelTimer.Enabled)
                ReelTimer.Stop();

            if (!CastButton.Enabled)
                CastButton.Enabled = true;

            if (ReelButton.Enabled)
                ReelButton.Enabled = false;

            _fishingState = FishingState.Idle;

            if (StatusLabel.Font.Bold)
                StatusLabel.Font = new Font(StatusLabel.Font, FontStyle.Regular);

            if (StatusLabel.Text != "Ready to cast...")
                StatusLabel.Text = "Ready to cast...";

            if (ResultLabel.Text != "")
                ResultLabel.Text = "";

            UpdateFishJournal();
        }

        private void UpdateFishJournal(int fishIndex = -1)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Populate listbox with fish records
            FishJournalListBox.Items.Clear();
            FishJournalListBox.BeginUpdate();
            FishJournalListBox.SuspendLayout();
            foreach (var kvp in GameManager.CurrentPlayer.Statistics.FishRecords)
                FishJournalListBox.Items.Add(kvp.Value != 0.0 ? $"{kvp.Key} - {kvp.Value:F2}" : "???");
            FishJournalListBox.ResumeLayout();
            FishJournalListBox.EndUpdate();

            // Select the fish that was just discovered or got a new record
            if (fishIndex != -1)
                FishJournalListBox.SelectedIndex = fishIndex;
        }

        private void CastButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Update buttons
            CastButton.Enabled = false;
            ReelButton.Enabled = true;

            // Update fishing state
            _fishingState = FishingState.Waiting;

            // Randomized delay before the next possible bite
            int newDelay = new Random().Next(1500, 12001);
            CastTimer.Interval = newDelay;
            CastTimer.Start();

            // Update label
            if (StatusLabel.Font.Bold)
                StatusLabel.Font = new Font(StatusLabel.Font, FontStyle.Regular);
            StatusLabel.Text = "Waiting for a bite...";
        }

        private void ReelButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Update buttons
            ReelButton.Enabled = false;
            CastButton.Enabled = true;

            // Stop timers because the user clicked reel
            ReelTimer.Stop();
            CastTimer.Stop();

            if (_fishingState == FishingState.BiteActive)
            {
                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

                double fishingSkill = GameManager.CurrentPlayer.FishingSkill;

                // Probability distribution influenced by fishing skill
                double nothingProbability = 0.5 * (1.0 - (fishingSkill / 100.0));
                double itemProbability = 0.05 * (fishingSkill / 100.0);
                double fishProbability = 1.0 - nothingProbability - itemProbability;

                double rng = Random.Shared.NextDouble();
                if (rng < nothingProbability)
                {
                    // Caught nothing

                    // Random flavor string
                    string[] nothingFlavors = ["The fish got away", "The line broke", "The fishing pole fell into the water"];
                    var nothingFlavor = nothingFlavors[Random.Shared.Next(nothingFlavors.Length)];

                    // Update label
                    ResultLabel.Text = nothingFlavor;

                    OutputService.Write(true, [new($"{nothingFlavor}", Properties.Settings.Default.PrimaryForeColor)]);

                    // Clear any previous selection in LB
                    FishJournalListBox.SelectedIndex = -1;
                }
                else if (rng < nothingProbability + fishProbability)
                {
                    // Caught fish

                    // Random fish
                    string[] fishType =
                    [
                            "Robotic Fish Type A", "Robotic Fish Type B", "Robotic Fish Type C", "Robotic Fish Type D", "Robotic Fish Type E",
                            "Robotic Fish Type F", "Robotic Fish Type G", "Robotic Fish Type H", "Robotic Fish Type I", "Robotic Fish Type J",
                            "Robotic Fish Type K", "Robotic Fish Type L", "Robotic Fish Type M", "Robotic Fish Type N", "Robotic Fish Type O",
                            "Robotic Fish Type P", "Robotic Fish Type Q", "Robotic Fish Type R", "Robotic Fish Type S", "Robotic Fish Type T",
                            "Robotic Fish Type U", "Robotic Fish Type V", "Robotic Fish Type W", "Robotic Fish Type X", "Robotic Fish Type Y",
                            "Robotic Fish Type Z"
                    ];
                    var fishIndex = Random.Shared.Next(fishType.Length);
                    var fish = fishType[fishIndex];

                    // Get a random fish weight within its minimum and maximum range
                    StarterValues.FishRanges.TryGetValue(fish, out (double Min, double Max) value);
                    var (minWeight, maxWeight) = value;
                    double interpolationFactor = Random.Shared.NextDouble();
                    double weight = Math.Round(minWeight + interpolationFactor * (maxWeight - minWeight), 2);

                    if (GameManager.CurrentPlayer.Statistics.FishRecords[fish] == 0)
                    {
                        // New fish discovered

                        // Update fish records
                        GameManager.CurrentPlayer.Statistics.FishRecords[fish] = weight;

                        OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Caught: {fish} - {weight:F2} kg! (New fish discovered!) Tossing it back in.", Properties.Settings.Default.PrimaryForeColor)]);

                        // Update LB and select this fish in LB to indicate new
                        UpdateFishJournal(fishIndex);
                    }
                    else if (GameManager.CurrentPlayer.Statistics.FishRecords[fish] < weight)
                    {
                        // New record for previously discovered fish

                        // Update fish records
                        GameManager.CurrentPlayer.Statistics.FishRecords[fish] = weight;

                        OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Caught: {fish} - {weight:F2} kg! (New record!) Tossing it back in.", Properties.Settings.Default.PrimaryForeColor)]);

                        // Update LB and select this fish in LB to indicate new
                        UpdateFishJournal(fishIndex);
                    }
                    else
                    {
                        // No record, previously discovered fish

                        OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"Caught: {fish} - {weight:F2} kg! Tossing it back in.", Properties.Settings.Default.PrimaryForeColor)]);

                        // Clear any previous selection in LB
                        FishJournalListBox.SelectedIndex = -1;
                    }

                    // Update label
                    ResultLabel.Text = $"{fish} - {weight:F2} kg";

                    // Update quests and statistics
                    GameManager.TryQuestProgress(playerIndex, QuestType.CaughtFish, 1);
                    GameManager.Players[playerIndex].Statistics.FishCaught += 1;
                }
                else
                {
                    // Caught item

                    // Fill loot
                    Loot lootToAdd = new();
                    var item = ItemFactory.GenerateRandomItem(playerIndex);
                    lootToAdd.Items.Add(item);

                    // Add item
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update label
                    ResultLabel.Text = $"{item.Name}";

                    OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new($"You fished up {item.Name}. It's a keeper.", Properties.Settings.Default.PrimaryForeColor)]);

                    // Clear any previous selection in LB
                    FishJournalListBox.SelectedIndex = -1;
                }

                // Check for skill gain
                AttemptSkillGain();
            }
            else if (_fishingState == FishingState.Waiting)
            {
                // Failed reel - clicked too early

                // Update label
                ResultLabel.Text = "";

                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("You tried to reel too early. Nothing on the line.", Properties.Settings.Default.PrimaryForeColor)]);

                // Clear any previous selection in LB
                FishJournalListBox.SelectedIndex = -1;
            }
            else
            {
                // Failed reel - no bite active

                // Update label
                ResultLabel.Text = "";

                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Nothing on the line.", Properties.Settings.Default.PrimaryForeColor)]);

                // Clear any previous selection in LB
                FishJournalListBox.SelectedIndex = -1;
            }

            // Update label
            if (StatusLabel.Font.Bold)
                StatusLabel.Font = new Font(StatusLabel.Font, FontStyle.Regular);
            StatusLabel.Text = "Ready to cast...";

            // Update fishing state
            _fishingState = FishingState.Idle;
        }

        private void CastTimer_Tick(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            // Stop timer because a bite just happened
            CastTimer.Stop();

            // Update fishing state
            _fishingState = FishingState.BiteActive;

            // Update label
            if (!StatusLabel.Font.Bold)
                StatusLabel.Font = new Font(StatusLabel.Font, FontStyle.Bold);
            StatusLabel.Text = "Reel it in!";

            OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Something is biting! Reel it in now!", Properties.Settings.Default.PrimaryForeColor)]);

            // Randomized delay for the reel window
            // Reel timer duration can be modified by nodes in the research tree to make this window more forgiving
            int newDelay = Random.Shared.Next(1500, 3001);
            int modifiedReelTimerDuration = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.ReelTimerDuration, newDelay);
            ReelTimer.Interval = modifiedReelTimerDuration;
            ReelTimer.Start();
        }

        private void ReelTimer_Tick(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Stop timer because the user didn't reel fast enough, so it got away
            ReelTimer.Stop();

            if (_fishingState == FishingState.BiteActive)
            {
                // Update label
                if (StatusLabel.Font.Bold)
                    StatusLabel.Font = new Font(StatusLabel.Font, FontStyle.Regular);
                StatusLabel.Text = "Ready to cast...";

                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("You didn't reel fast enough so it got away.", Properties.Settings.Default.PrimaryForeColor)]);

                // Update fishing state
                _fishingState = FishingState.Idle;

                // Update buttons
                ReelButton.Enabled = false;
                CastButton.Enabled = true;
            }
        }

        private static void AttemptSkillGain()
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

            // Roll a random value scaled by the maximum possible fishing skill
            double skillGainRng = Random.Shared.NextDouble() * StarterValues.MaxFishingSkill;

            // Increase skill if the roll exceeds current skill
            if (skillGainRng > GameManager.Players[playerIndex].FishingSkill)
            {
                GameManager.Players[playerIndex].FishingSkill += 0.1;

                OutputService.Write(true, [new($"Fishing skill increased: {GameManager.Players[playerIndex].FishingSkill:N1}!", Properties.Settings.Default.PrimaryForeColor)]);
            }
        }
    }
}