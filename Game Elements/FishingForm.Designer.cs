namespace Game_Elements
{
    partial class FishingForm
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
            components = new System.ComponentModel.Container();
            FishingTLP = new TableLayoutPanel();
            StatusBackPanel = new Panel();
            StatusTLP = new TableLayoutPanel();
            StatusLabel = new Label();
            ResultBackPanel = new Panel();
            ResultTLP = new TableLayoutPanel();
            ResultLabel = new Label();
            ControlsBackPanel = new Panel();
            ControlsTLP = new TableLayoutPanel();
            CastButton = new Button();
            ReelButton = new Button();
            FishJournalListBox = new ListBox();
            CastTimer = new System.Windows.Forms.Timer(components);
            ReelTimer = new System.Windows.Forms.Timer(components);
            FishingTLP.SuspendLayout();
            StatusBackPanel.SuspendLayout();
            StatusTLP.SuspendLayout();
            ResultBackPanel.SuspendLayout();
            ResultTLP.SuspendLayout();
            ControlsBackPanel.SuspendLayout();
            ControlsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // FishingTLP
            // 
            FishingTLP.ColumnCount = 2;
            FishingTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            FishingTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            FishingTLP.Controls.Add(StatusBackPanel, 0, 0);
            FishingTLP.Controls.Add(ResultBackPanel, 0, 1);
            FishingTLP.Controls.Add(ControlsBackPanel, 1, 0);
            FishingTLP.Dock = DockStyle.Fill;
            FishingTLP.Location = new Point(0, 0);
            FishingTLP.Name = "FishingTLP";
            FishingTLP.RowCount = 2;
            FishingTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            FishingTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            FishingTLP.Size = new Size(800, 450);
            FishingTLP.TabIndex = 0;
            // 
            // StatusBackPanel
            // 
            StatusBackPanel.Controls.Add(StatusTLP);
            StatusBackPanel.Dock = DockStyle.Fill;
            StatusBackPanel.Location = new Point(3, 3);
            StatusBackPanel.Name = "StatusBackPanel";
            StatusBackPanel.Size = new Size(594, 331);
            StatusBackPanel.TabIndex = 0;
            // 
            // StatusTLP
            // 
            StatusTLP.ColumnCount = 1;
            StatusTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            StatusTLP.Controls.Add(StatusLabel, 0, 0);
            StatusTLP.Dock = DockStyle.Fill;
            StatusTLP.Location = new Point(0, 0);
            StatusTLP.Name = "StatusTLP";
            StatusTLP.RowCount = 1;
            StatusTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            StatusTLP.Size = new Size(594, 331);
            StatusTLP.TabIndex = 0;
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.None;
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(263, 158);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(67, 15);
            StatusLabel.TabIndex = 0;
            StatusLabel.Text = "StatusLabel";
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ResultBackPanel
            // 
            ResultBackPanel.Controls.Add(ResultTLP);
            ResultBackPanel.Dock = DockStyle.Fill;
            ResultBackPanel.Location = new Point(3, 340);
            ResultBackPanel.Name = "ResultBackPanel";
            ResultBackPanel.Size = new Size(594, 107);
            ResultBackPanel.TabIndex = 1;
            // 
            // ResultTLP
            // 
            ResultTLP.ColumnCount = 1;
            ResultTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ResultTLP.Controls.Add(ResultLabel, 0, 0);
            ResultTLP.Dock = DockStyle.Fill;
            ResultTLP.Location = new Point(0, 0);
            ResultTLP.Name = "ResultTLP";
            ResultTLP.RowCount = 1;
            ResultTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ResultTLP.Size = new Size(594, 107);
            ResultTLP.TabIndex = 0;
            // 
            // ResultLabel
            // 
            ResultLabel.Anchor = AnchorStyles.None;
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(263, 46);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(67, 15);
            ResultLabel.TabIndex = 0;
            ResultLabel.Text = "ResultLabel";
            ResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ControlsBackPanel
            // 
            ControlsBackPanel.Controls.Add(ControlsTLP);
            ControlsBackPanel.Dock = DockStyle.Fill;
            ControlsBackPanel.Location = new Point(603, 3);
            ControlsBackPanel.Name = "ControlsBackPanel";
            FishingTLP.SetRowSpan(ControlsBackPanel, 2);
            ControlsBackPanel.Size = new Size(194, 444);
            ControlsBackPanel.TabIndex = 2;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 1;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            ControlsTLP.Controls.Add(CastButton, 0, 0);
            ControlsTLP.Controls.Add(ReelButton, 0, 2);
            ControlsTLP.Controls.Add(FishJournalListBox, 0, 4);
            ControlsTLP.Dock = DockStyle.Fill;
            ControlsTLP.Location = new Point(0, 0);
            ControlsTLP.Name = "ControlsTLP";
            ControlsTLP.RowCount = 8;
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            ControlsTLP.Size = new Size(194, 444);
            ControlsTLP.TabIndex = 0;
            // 
            // CastButton
            // 
            CastButton.Dock = DockStyle.Fill;
            CastButton.FlatStyle = FlatStyle.Flat;
            CastButton.Location = new Point(3, 3);
            CastButton.Name = "CastButton";
            ControlsTLP.SetRowSpan(CastButton, 2);
            CastButton.Size = new Size(188, 104);
            CastButton.TabIndex = 0;
            CastButton.Text = "Cast";
            CastButton.UseVisualStyleBackColor = true;
            CastButton.Click += CastButton_Click;
            // 
            // ReelButton
            // 
            ReelButton.Dock = DockStyle.Fill;
            ReelButton.FlatStyle = FlatStyle.Flat;
            ReelButton.Location = new Point(3, 113);
            ReelButton.Name = "ReelButton";
            ControlsTLP.SetRowSpan(ReelButton, 2);
            ReelButton.Size = new Size(188, 104);
            ReelButton.TabIndex = 1;
            ReelButton.Text = "Reel";
            ReelButton.UseVisualStyleBackColor = true;
            ReelButton.Click += ReelButton_Click;
            // 
            // FishJournalListBox
            // 
            FishJournalListBox.Dock = DockStyle.Fill;
            FishJournalListBox.FormattingEnabled = true;
            FishJournalListBox.Location = new Point(3, 223);
            FishJournalListBox.Name = "FishJournalListBox";
            ControlsTLP.SetRowSpan(FishJournalListBox, 4);
            FishJournalListBox.Size = new Size(188, 218);
            FishJournalListBox.TabIndex = 2;
            // 
            // CastTimer
            // 
            CastTimer.Tick += CastTimer_Tick;
            // 
            // ReelTimer
            // 
            ReelTimer.Tick += ReelTimer_Tick;
            // 
            // FishingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FishingTLP);
            Name = "FishingForm";
            Text = "FishingForm";
            FormClosing += FishingForm_FormClosing;
            FishingTLP.ResumeLayout(false);
            StatusBackPanel.ResumeLayout(false);
            StatusTLP.ResumeLayout(false);
            StatusTLP.PerformLayout();
            ResultBackPanel.ResumeLayout(false);
            ResultTLP.ResumeLayout(false);
            ResultTLP.PerformLayout();
            ControlsBackPanel.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel FishingTLP;
        private Panel StatusBackPanel;
        private TableLayoutPanel StatusTLP;
        private Panel ResultBackPanel;
        private Panel ControlsBackPanel;
        private Label StatusLabel;
        private TableLayoutPanel ResultTLP;
        private Label ResultLabel;
        private TableLayoutPanel ControlsTLP;
        private Button CastButton;
        private Button ReelButton;
        private ListBox FishJournalListBox;
        private System.Windows.Forms.Timer CastTimer;
        private System.Windows.Forms.Timer ReelTimer;
    }
}