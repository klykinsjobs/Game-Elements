namespace Game_Elements
{
    partial class GuideForm
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
            GuideTLP = new TableLayoutPanel();
            TopicsBackPanel = new Panel();
            TopicsTLP = new TableLayoutPanel();
            TopicsTreeView = new TreeView();
            DescriptionBackPanel = new Panel();
            DescriptionTLP = new TableLayoutPanel();
            DescriptionTextBox = new TextBox();
            GuideTLP.SuspendLayout();
            TopicsBackPanel.SuspendLayout();
            TopicsTLP.SuspendLayout();
            DescriptionBackPanel.SuspendLayout();
            DescriptionTLP.SuspendLayout();
            SuspendLayout();
            // 
            // GuideTLP
            // 
            GuideTLP.ColumnCount = 2;
            GuideTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            GuideTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            GuideTLP.Controls.Add(TopicsBackPanel, 0, 0);
            GuideTLP.Controls.Add(DescriptionBackPanel, 1, 0);
            GuideTLP.Dock = DockStyle.Fill;
            GuideTLP.Location = new Point(0, 0);
            GuideTLP.Name = "GuideTLP";
            GuideTLP.RowCount = 1;
            GuideTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            GuideTLP.Size = new Size(800, 450);
            GuideTLP.TabIndex = 0;
            // 
            // TopicsBackPanel
            // 
            TopicsBackPanel.Controls.Add(TopicsTLP);
            TopicsBackPanel.Dock = DockStyle.Fill;
            TopicsBackPanel.Location = new Point(3, 3);
            TopicsBackPanel.Name = "TopicsBackPanel";
            TopicsBackPanel.Size = new Size(234, 444);
            TopicsBackPanel.TabIndex = 0;
            // 
            // TopicsTLP
            // 
            TopicsTLP.ColumnCount = 1;
            TopicsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TopicsTLP.Controls.Add(TopicsTreeView, 0, 0);
            TopicsTLP.Dock = DockStyle.Fill;
            TopicsTLP.Location = new Point(0, 0);
            TopicsTLP.Name = "TopicsTLP";
            TopicsTLP.RowCount = 1;
            TopicsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TopicsTLP.Size = new Size(234, 444);
            TopicsTLP.TabIndex = 0;
            // 
            // TopicsTreeView
            // 
            TopicsTreeView.Dock = DockStyle.Fill;
            TopicsTreeView.Location = new Point(3, 3);
            TopicsTreeView.Name = "TopicsTreeView";
            TopicsTreeView.Size = new Size(228, 438);
            TopicsTreeView.TabIndex = 0;
            TopicsTreeView.AfterSelect += TopicsTreeView_AfterSelect;
            // 
            // DescriptionBackPanel
            // 
            DescriptionBackPanel.Controls.Add(DescriptionTLP);
            DescriptionBackPanel.Dock = DockStyle.Fill;
            DescriptionBackPanel.Location = new Point(243, 3);
            DescriptionBackPanel.Name = "DescriptionBackPanel";
            DescriptionBackPanel.Size = new Size(554, 444);
            DescriptionBackPanel.TabIndex = 1;
            // 
            // DescriptionTLP
            // 
            DescriptionTLP.ColumnCount = 1;
            DescriptionTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            DescriptionTLP.Controls.Add(DescriptionTextBox, 0, 0);
            DescriptionTLP.Dock = DockStyle.Fill;
            DescriptionTLP.Location = new Point(0, 0);
            DescriptionTLP.Name = "DescriptionTLP";
            DescriptionTLP.RowCount = 1;
            DescriptionTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            DescriptionTLP.Size = new Size(554, 444);
            DescriptionTLP.TabIndex = 0;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Dock = DockStyle.Fill;
            DescriptionTextBox.Location = new Point(3, 3);
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.ReadOnly = true;
            DescriptionTextBox.ScrollBars = ScrollBars.Vertical;
            DescriptionTextBox.Size = new Size(548, 438);
            DescriptionTextBox.TabIndex = 0;
            // 
            // GuideForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GuideTLP);
            Name = "GuideForm";
            Text = "GuideForm";
            GuideTLP.ResumeLayout(false);
            TopicsBackPanel.ResumeLayout(false);
            TopicsTLP.ResumeLayout(false);
            DescriptionBackPanel.ResumeLayout(false);
            DescriptionTLP.ResumeLayout(false);
            DescriptionTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel GuideTLP;
        private Panel TopicsBackPanel;
        private TableLayoutPanel TopicsTLP;
        private Panel DescriptionBackPanel;
        private TableLayoutPanel DescriptionTLP;
        private TreeView TopicsTreeView;
        private TextBox DescriptionTextBox;
    }
}