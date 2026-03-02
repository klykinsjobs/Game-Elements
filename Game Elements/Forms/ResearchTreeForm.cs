using Game_Elements.Engine;
using Game_Elements.Models;
using System.ComponentModel;

namespace Game_Elements
{
    public partial class ResearchTreeForm : Form
    {
        public ResearchTreeForm()
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            GameManager.CurrentPlayer?.ResearchTree.ResearchNodes.ListChanged += ResearchNodes_ListChanged;

            // Update UI elements for current player
            UpdateUI();
        }

        private void ResearchTreeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose tool tip
            ResearchNodeToolTip.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            GameManager.CurrentPlayer?.ResearchTree.ResearchNodes.ListChanged -= ResearchNodes_ListChanged;
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
            previousPlayer?.ResearchTree.ResearchNodes.ListChanged -= ResearchNodes_ListChanged;

            // Subscribe to new player's events
            GameManager.CurrentPlayer?.ResearchTree.ResearchNodes.ListChanged += ResearchNodes_ListChanged;

            // Update UI elements for new player
            UpdateUI();
        }

        private void ResearchNodes_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null)
            {
                if (e.PropertyDescriptor.Name == "Researched")
                {
                    // Update UI to reflect changes
                    UpdateUI();
                }
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            ResearchTreeTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ResearchTreeBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ResearchTreeBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ResearchTreeFLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ResearchTreeFLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ClearQueueButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            ClearQueueButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ClearQueueButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            ClearQueueButton.Font = new Font(ClearQueueButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ResearchTreeFLP.Controls.Clear();
            if (GameManager.CurrentPlayer != null)
            {
                foreach (var researchNode in GameManager.CurrentPlayer.ResearchTree.ResearchNodes)
                {
                    // Create a button for this research node
                    var button = new Button
                    {
                        Text = researchNode.Name,
                        Tag = researchNode.Name,
                        Size = new Size(140, 60),
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Properties.Settings.Default.SecondaryBackColor,
                        ForeColor = Properties.Settings.Default.PrimaryForeColor
                    };

                    // Attach event handler
                    button.Click += ResearchNodeButton_Click;

                    // Add to FLP
                    ResearchTreeFLP.Controls.Add(button);

                    // Tooltip
                    ResearchNodeToolTip.SetToolTip(button, researchNode.Description);
                }
            }
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            foreach (var researchNode in GameManager.CurrentPlayer.ResearchTree.ResearchNodes)
            {
                // Check if this research node is queued
                bool inQueue = GameManager.CurrentPlayer.ResearchTree.Queue.Contains(researchNode.Name);

                // Get the matching button for this research node
                var matchingButton = ResearchTreeFLP.Controls.OfType<Button>().FirstOrDefault(c => c.Tag != null && (string)c.Tag == researchNode.Name);
                if (matchingButton != null)
                {
                    if (researchNode.Researched)
                    {
                        // Update the button to show this node was already researched

                        if (matchingButton.Text != researchNode.Name)
                            matchingButton.Text = researchNode.Name;
                        if (matchingButton.FlatAppearance.BorderColor != Properties.Settings.Default.SuccessTextColor)
                            matchingButton.FlatAppearance.BorderColor = Properties.Settings.Default.SuccessTextColor;
                    }
                    else
                    {
                        // Update the button to show this node hasn't been researched yet.

                        if (inQueue)
                        {
                            // Add an asterisk to indicate a node that is currently in queue
                            if (matchingButton.Text != $"{researchNode.Name} *")
                                matchingButton.Text = $"{researchNode.Name} *";
                        }
                        else if (matchingButton.Text != researchNode.Name)
                        {
                            matchingButton.Text = researchNode.Name;
                        }

                        if (matchingButton.FlatAppearance.BorderColor != Properties.Settings.Default.PrimaryForeColor)
                            matchingButton.FlatAppearance.BorderColor = Properties.Settings.Default.PrimaryForeColor;
                    }
                }
            }
        }

        private void ResearchNodeButton_Click(object? sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (sender is Button btn && btn.Tag is string researchNodeName)
            {
                // Get the matching research node for this button
                var researchNode = GameManager.CurrentPlayer.ResearchTree.ResearchNodes.FirstOrDefault(rn => rn.Name == researchNodeName);
                if (researchNode != null && !researchNode.Researched)
                {
                    // Queue this research node
                    GameManager.CurrentPlayer.ResearchTree.EnqueueResearch(researchNodeName);

                    // Update UI to reflect changes
                    UpdateUI();
                }
            }
        }

        private void ClearQueueButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (GameManager.CurrentPlayer.ResearchTree.Queue.Count > 0)
            {
                // Clear the queue
                GameManager.CurrentPlayer.ResearchTree.Queue.Clear();

                // Update UI to reflect changes
                UpdateUI();
            }
        }
    }
}