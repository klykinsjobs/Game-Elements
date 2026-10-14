namespace Game_Elements
{
    partial class CreditsForm
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
            CreditsTLP = new TableLayoutPanel();
            CreditBackPanel = new Panel();
            CreditTLP = new TableLayoutPanel();
            TitleLabel = new Label();
            CreatedByLabel = new Label();
            CreditsTLP.SuspendLayout();
            CreditBackPanel.SuspendLayout();
            CreditTLP.SuspendLayout();
            SuspendLayout();
            // 
            // CreditsTLP
            // 
            CreditsTLP.ColumnCount = 1;
            CreditsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            CreditsTLP.Controls.Add(CreditBackPanel, 0, 0);
            CreditsTLP.Dock = DockStyle.Fill;
            CreditsTLP.Location = new Point(0, 0);
            CreditsTLP.Name = "CreditsTLP";
            CreditsTLP.RowCount = 1;
            CreditsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            CreditsTLP.Size = new Size(800, 450);
            CreditsTLP.TabIndex = 0;
            // 
            // CreditBackPanel
            // 
            CreditBackPanel.Controls.Add(CreditTLP);
            CreditBackPanel.Dock = DockStyle.Fill;
            CreditBackPanel.Location = new Point(3, 3);
            CreditBackPanel.Name = "CreditBackPanel";
            CreditBackPanel.Size = new Size(794, 444);
            CreditBackPanel.TabIndex = 0;
            // 
            // CreditTLP
            // 
            CreditTLP.ColumnCount = 1;
            CreditTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            CreditTLP.Controls.Add(TitleLabel, 0, 0);
            CreditTLP.Controls.Add(CreatedByLabel, 0, 1);
            CreditTLP.Dock = DockStyle.Fill;
            CreditTLP.Location = new Point(0, 0);
            CreditTLP.Name = "CreditTLP";
            CreditTLP.RowCount = 2;
            CreditTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CreditTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            CreditTLP.Size = new Size(794, 444);
            CreditTLP.TabIndex = 0;
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = AnchorStyles.None;
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(352, 103);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(89, 15);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Game Elements";
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CreatedByLabel
            // 
            CreatedByLabel.Anchor = AnchorStyles.None;
            CreatedByLabel.AutoSize = true;
            CreatedByLabel.Location = new Point(331, 325);
            CreatedByLabel.Name = "CreatedByLabel";
            CreatedByLabel.Size = new Size(131, 15);
            CreatedByLabel.TabIndex = 1;
            CreatedByLabel.Text = "Created by Kevin Lykins";
            CreatedByLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CreditsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreditsTLP);
            Name = "CreditsForm";
            Text = "CreditsForm";
            FormClosing += CreditsForm_FormClosing;
            CreditsTLP.ResumeLayout(false);
            CreditBackPanel.ResumeLayout(false);
            CreditTLP.ResumeLayout(false);
            CreditTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel CreditsTLP;
        private Panel CreditBackPanel;
        private TableLayoutPanel CreditTLP;
        private Label TitleLabel;
        private Label CreatedByLabel;
    }
}