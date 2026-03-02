namespace Game_Elements
{
    partial class PlayerForm
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
            PlayerTLP = new TableLayoutPanel();
            SkillsBackPanel = new Panel();
            SkillsTLP = new TableLayoutPanel();
            FishingLabel = new Label();
            FishingPB = new ProgressBar();
            GardeningLabel = new Label();
            GardeningPB = new ProgressBar();
            CurrentPlayerBackPanel = new Panel();
            CurrentPlayerTLP = new TableLayoutPanel();
            PlayerLabel = new Label();
            ControlsBackPanel = new Panel();
            ControlsTLP = new TableLayoutPanel();
            RenameButton = new Button();
            CustomizeStringsButton = new Button();
            PlayerTLP.SuspendLayout();
            SkillsBackPanel.SuspendLayout();
            SkillsTLP.SuspendLayout();
            CurrentPlayerBackPanel.SuspendLayout();
            CurrentPlayerTLP.SuspendLayout();
            ControlsBackPanel.SuspendLayout();
            ControlsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // PlayerTLP
            // 
            PlayerTLP.ColumnCount = 2;
            PlayerTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            PlayerTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            PlayerTLP.Controls.Add(SkillsBackPanel, 0, 0);
            PlayerTLP.Controls.Add(CurrentPlayerBackPanel, 0, 1);
            PlayerTLP.Controls.Add(ControlsBackPanel, 1, 0);
            PlayerTLP.Dock = DockStyle.Fill;
            PlayerTLP.Location = new Point(0, 0);
            PlayerTLP.Name = "PlayerTLP";
            PlayerTLP.RowCount = 2;
            PlayerTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            PlayerTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            PlayerTLP.Size = new Size(800, 450);
            PlayerTLP.TabIndex = 0;
            // 
            // SkillsBackPanel
            // 
            SkillsBackPanel.Controls.Add(SkillsTLP);
            SkillsBackPanel.Dock = DockStyle.Fill;
            SkillsBackPanel.Location = new Point(3, 3);
            SkillsBackPanel.Name = "SkillsBackPanel";
            SkillsBackPanel.Size = new Size(594, 376);
            SkillsBackPanel.TabIndex = 0;
            // 
            // SkillsTLP
            // 
            SkillsTLP.ColumnCount = 2;
            SkillsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            SkillsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            SkillsTLP.Controls.Add(FishingLabel, 0, 0);
            SkillsTLP.Controls.Add(FishingPB, 1, 0);
            SkillsTLP.Controls.Add(GardeningLabel, 0, 1);
            SkillsTLP.Controls.Add(GardeningPB, 1, 1);
            SkillsTLP.Dock = DockStyle.Fill;
            SkillsTLP.Location = new Point(0, 0);
            SkillsTLP.Name = "SkillsTLP";
            SkillsTLP.RowCount = 5;
            SkillsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SkillsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SkillsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SkillsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SkillsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            SkillsTLP.Size = new Size(594, 376);
            SkillsTLP.TabIndex = 0;
            // 
            // FishingLabel
            // 
            FishingLabel.Anchor = AnchorStyles.None;
            FishingLabel.AutoSize = true;
            FishingLabel.Location = new Point(124, 30);
            FishingLabel.Name = "FishingLabel";
            FishingLabel.Size = new Size(48, 15);
            FishingLabel.TabIndex = 0;
            FishingLabel.Text = "Fishing:";
            FishingLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FishingPB
            // 
            FishingPB.Dock = DockStyle.Fill;
            FishingPB.Location = new Point(300, 3);
            FishingPB.Name = "FishingPB";
            FishingPB.Size = new Size(291, 69);
            FishingPB.TabIndex = 1;
            // 
            // GardeningLabel
            // 
            GardeningLabel.Anchor = AnchorStyles.None;
            GardeningLabel.AutoSize = true;
            GardeningLabel.Location = new Point(116, 105);
            GardeningLabel.Name = "GardeningLabel";
            GardeningLabel.Size = new Size(65, 15);
            GardeningLabel.TabIndex = 2;
            GardeningLabel.Text = "Gardening:";
            GardeningLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GardeningPB
            // 
            GardeningPB.Dock = DockStyle.Fill;
            GardeningPB.Location = new Point(300, 78);
            GardeningPB.Name = "GardeningPB";
            GardeningPB.Size = new Size(291, 69);
            GardeningPB.TabIndex = 3;
            // 
            // CurrentPlayerBackPanel
            // 
            CurrentPlayerBackPanel.Controls.Add(CurrentPlayerTLP);
            CurrentPlayerBackPanel.Dock = DockStyle.Fill;
            CurrentPlayerBackPanel.Location = new Point(3, 385);
            CurrentPlayerBackPanel.Name = "CurrentPlayerBackPanel";
            CurrentPlayerBackPanel.Size = new Size(594, 62);
            CurrentPlayerBackPanel.TabIndex = 1;
            // 
            // CurrentPlayerTLP
            // 
            CurrentPlayerTLP.ColumnCount = 1;
            CurrentPlayerTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            CurrentPlayerTLP.Controls.Add(PlayerLabel, 0, 0);
            CurrentPlayerTLP.Dock = DockStyle.Fill;
            CurrentPlayerTLP.Location = new Point(0, 0);
            CurrentPlayerTLP.Name = "CurrentPlayerTLP";
            CurrentPlayerTLP.RowCount = 1;
            CurrentPlayerTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            CurrentPlayerTLP.Size = new Size(594, 62);
            CurrentPlayerTLP.TabIndex = 0;
            // 
            // PlayerLabel
            // 
            PlayerLabel.Anchor = AnchorStyles.None;
            PlayerLabel.AutoSize = true;
            PlayerLabel.Location = new Point(263, 23);
            PlayerLabel.Name = "PlayerLabel";
            PlayerLabel.Size = new Size(67, 15);
            PlayerLabel.TabIndex = 0;
            PlayerLabel.Text = "PlayerLabel";
            PlayerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ControlsBackPanel
            // 
            ControlsBackPanel.Controls.Add(ControlsTLP);
            ControlsBackPanel.Dock = DockStyle.Fill;
            ControlsBackPanel.Location = new Point(603, 3);
            ControlsBackPanel.Name = "ControlsBackPanel";
            PlayerTLP.SetRowSpan(ControlsBackPanel, 2);
            ControlsBackPanel.Size = new Size(194, 444);
            ControlsBackPanel.TabIndex = 2;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 1;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsTLP.Controls.Add(RenameButton, 0, 6);
            ControlsTLP.Controls.Add(CustomizeStringsButton, 0, 7);
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
            // RenameButton
            // 
            RenameButton.Dock = DockStyle.Fill;
            RenameButton.FlatStyle = FlatStyle.Flat;
            RenameButton.Location = new Point(3, 333);
            RenameButton.Name = "RenameButton";
            RenameButton.Size = new Size(188, 49);
            RenameButton.TabIndex = 0;
            RenameButton.Text = "Rename";
            RenameButton.UseVisualStyleBackColor = true;
            RenameButton.Click += RenameButton_Click;
            // 
            // CustomizeStringsButton
            // 
            CustomizeStringsButton.Dock = DockStyle.Fill;
            CustomizeStringsButton.FlatStyle = FlatStyle.Flat;
            CustomizeStringsButton.Location = new Point(3, 388);
            CustomizeStringsButton.Name = "CustomizeStringsButton";
            CustomizeStringsButton.Size = new Size(188, 53);
            CustomizeStringsButton.TabIndex = 1;
            CustomizeStringsButton.Text = "Customize Strings";
            CustomizeStringsButton.UseVisualStyleBackColor = true;
            CustomizeStringsButton.Click += CustomizeStringsButton_Click;
            // 
            // PlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PlayerTLP);
            Name = "PlayerForm";
            Text = "PlayerForm";
            FormClosing += PlayerForm_FormClosing;
            PlayerTLP.ResumeLayout(false);
            SkillsBackPanel.ResumeLayout(false);
            SkillsTLP.ResumeLayout(false);
            SkillsTLP.PerformLayout();
            CurrentPlayerBackPanel.ResumeLayout(false);
            CurrentPlayerTLP.ResumeLayout(false);
            CurrentPlayerTLP.PerformLayout();
            ControlsBackPanel.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel PlayerTLP;
        private Panel SkillsBackPanel;
        private TableLayoutPanel SkillsTLP;
        private Panel CurrentPlayerBackPanel;
        private Panel ControlsBackPanel;
        private Label FishingLabel;
        private ProgressBar FishingPB;
        private Label GardeningLabel;
        private ProgressBar GardeningPB;
        private TableLayoutPanel CurrentPlayerTLP;
        private Label PlayerLabel;
        private TableLayoutPanel ControlsTLP;
        private Button RenameButton;
        private Button CustomizeStringsButton;
    }
}