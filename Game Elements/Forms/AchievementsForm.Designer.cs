namespace Game_Elements
{
    partial class AchievementsForm
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
            AchievementsTLP = new TableLayoutPanel();
            AchievementsBackPanel = new Panel();
            AchievementsFLP = new FlowLayoutPanel();
            ControlsBackPanel = new Panel();
            ControlsTLP = new TableLayoutPanel();
            MarkAllAsSeenButton = new Button();
            AchievementsToolTip = new ToolTip(components);
            AchievementsTLP.SuspendLayout();
            AchievementsBackPanel.SuspendLayout();
            ControlsBackPanel.SuspendLayout();
            ControlsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // AchievementsTLP
            // 
            AchievementsTLP.ColumnCount = 3;
            AchievementsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            AchievementsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            AchievementsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            AchievementsTLP.Controls.Add(AchievementsBackPanel, 0, 0);
            AchievementsTLP.Controls.Add(ControlsBackPanel, 0, 1);
            AchievementsTLP.Dock = DockStyle.Fill;
            AchievementsTLP.Location = new Point(0, 0);
            AchievementsTLP.Name = "AchievementsTLP";
            AchievementsTLP.RowCount = 2;
            AchievementsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            AchievementsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            AchievementsTLP.Size = new Size(800, 450);
            AchievementsTLP.TabIndex = 0;
            // 
            // AchievementsBackPanel
            // 
            AchievementsTLP.SetColumnSpan(AchievementsBackPanel, 3);
            AchievementsBackPanel.Controls.Add(AchievementsFLP);
            AchievementsBackPanel.Dock = DockStyle.Fill;
            AchievementsBackPanel.Location = new Point(3, 3);
            AchievementsBackPanel.Name = "AchievementsBackPanel";
            AchievementsBackPanel.Size = new Size(794, 331);
            AchievementsBackPanel.TabIndex = 0;
            // 
            // AchievementsFLP
            // 
            AchievementsFLP.AutoScroll = true;
            AchievementsFLP.Dock = DockStyle.Fill;
            AchievementsFLP.Location = new Point(0, 0);
            AchievementsFLP.Name = "AchievementsFLP";
            AchievementsFLP.Size = new Size(794, 331);
            AchievementsFLP.TabIndex = 0;
            // 
            // ControlsBackPanel
            // 
            AchievementsTLP.SetColumnSpan(ControlsBackPanel, 3);
            ControlsBackPanel.Controls.Add(ControlsTLP);
            ControlsBackPanel.Dock = DockStyle.Fill;
            ControlsBackPanel.Location = new Point(3, 340);
            ControlsBackPanel.Name = "ControlsBackPanel";
            ControlsBackPanel.Size = new Size(794, 107);
            ControlsBackPanel.TabIndex = 1;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 1;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsTLP.Controls.Add(MarkAllAsSeenButton, 0, 0);
            ControlsTLP.Dock = DockStyle.Fill;
            ControlsTLP.Location = new Point(0, 0);
            ControlsTLP.Name = "ControlsTLP";
            ControlsTLP.RowCount = 1;
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ControlsTLP.Size = new Size(794, 107);
            ControlsTLP.TabIndex = 0;
            // 
            // MarkAllAsSeenButton
            // 
            MarkAllAsSeenButton.Dock = DockStyle.Fill;
            MarkAllAsSeenButton.FlatStyle = FlatStyle.Flat;
            MarkAllAsSeenButton.Location = new Point(3, 3);
            MarkAllAsSeenButton.Name = "MarkAllAsSeenButton";
            MarkAllAsSeenButton.Size = new Size(788, 101);
            MarkAllAsSeenButton.TabIndex = 0;
            MarkAllAsSeenButton.Text = "Mark All As Seen";
            MarkAllAsSeenButton.UseVisualStyleBackColor = true;
            MarkAllAsSeenButton.Click += MarkAllAsSeenButton_Click;
            // 
            // AchievementsToolTip
            // 
            AchievementsToolTip.IsBalloon = true;
            // 
            // AchievementsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AchievementsTLP);
            Name = "AchievementsForm";
            Text = "AchievementsForm";
            FormClosing += AchievementsForm_FormClosing;
            AchievementsTLP.ResumeLayout(false);
            AchievementsBackPanel.ResumeLayout(false);
            ControlsBackPanel.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel AchievementsTLP;
        private Panel AchievementsBackPanel;
        private Panel ControlsBackPanel;
        private TableLayoutPanel ControlsTLP;
        private FlowLayoutPanel AchievementsFLP;
        private Button MarkAllAsSeenButton;
        private ToolTip AchievementsToolTip;
    }
}