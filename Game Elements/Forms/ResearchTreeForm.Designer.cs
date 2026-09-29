namespace Game_Elements
{
    partial class ResearchTreeForm
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
            ResearchTreeTLP = new TableLayoutPanel();
            ResearchTreeBackPanel = new Panel();
            ResearchTreeFLP = new FlowLayoutPanel();
            ControlsBackPanel = new Panel();
            ControlsTLP = new TableLayoutPanel();
            ClearQueueButton = new Button();
            ResearchNodeToolTip = new ToolTip(components);
            ResearchTreeTLP.SuspendLayout();
            ResearchTreeBackPanel.SuspendLayout();
            ControlsBackPanel.SuspendLayout();
            ControlsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // ResearchTreeTLP
            // 
            ResearchTreeTLP.ColumnCount = 2;
            ResearchTreeTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            ResearchTreeTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ResearchTreeTLP.Controls.Add(ResearchTreeBackPanel, 0, 0);
            ResearchTreeTLP.Controls.Add(ControlsBackPanel, 1, 0);
            ResearchTreeTLP.Dock = DockStyle.Fill;
            ResearchTreeTLP.Location = new Point(0, 0);
            ResearchTreeTLP.Name = "ResearchTreeTLP";
            ResearchTreeTLP.RowCount = 1;
            ResearchTreeTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ResearchTreeTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ResearchTreeTLP.Size = new Size(800, 450);
            ResearchTreeTLP.TabIndex = 0;
            // 
            // ResearchTreeBackPanel
            // 
            ResearchTreeBackPanel.Controls.Add(ResearchTreeFLP);
            ResearchTreeBackPanel.Dock = DockStyle.Fill;
            ResearchTreeBackPanel.Location = new Point(3, 3);
            ResearchTreeBackPanel.Name = "ResearchTreeBackPanel";
            ResearchTreeBackPanel.Size = new Size(594, 444);
            ResearchTreeBackPanel.TabIndex = 0;
            // 
            // ResearchTreeFLP
            // 
            ResearchTreeFLP.AutoScroll = true;
            ResearchTreeFLP.Dock = DockStyle.Fill;
            ResearchTreeFLP.Location = new Point(0, 0);
            ResearchTreeFLP.Name = "ResearchTreeFLP";
            ResearchTreeFLP.Size = new Size(594, 444);
            ResearchTreeFLP.TabIndex = 0;
            // 
            // ControlsBackPanel
            // 
            ControlsBackPanel.Controls.Add(ControlsTLP);
            ControlsBackPanel.Dock = DockStyle.Fill;
            ControlsBackPanel.Location = new Point(603, 3);
            ControlsBackPanel.Name = "ControlsBackPanel";
            ControlsBackPanel.Size = new Size(194, 444);
            ControlsBackPanel.TabIndex = 1;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 1;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsTLP.Controls.Add(ClearQueueButton, 0, 7);
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
            // ClearQueueButton
            // 
            ClearQueueButton.Dock = DockStyle.Fill;
            ClearQueueButton.FlatStyle = FlatStyle.Flat;
            ClearQueueButton.Location = new Point(3, 388);
            ClearQueueButton.Name = "ClearQueueButton";
            ClearQueueButton.Size = new Size(188, 53);
            ClearQueueButton.TabIndex = 0;
            ClearQueueButton.Text = "Clear Queue";
            ClearQueueButton.UseVisualStyleBackColor = true;
            ClearQueueButton.Click += ClearQueueButton_Click;
            // 
            // ResearchNodeToolTip
            // 
            ResearchNodeToolTip.IsBalloon = true;
            // 
            // ResearchTreeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ResearchTreeTLP);
            Name = "ResearchTreeForm";
            Text = "ResearchTreeForm";
            FormClosing += ResearchTreeForm_FormClosing;
            ResearchTreeTLP.ResumeLayout(false);
            ResearchTreeBackPanel.ResumeLayout(false);
            ControlsBackPanel.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel ResearchTreeTLP;
        private Panel ResearchTreeBackPanel;
        private FlowLayoutPanel ResearchTreeFLP;
        private Panel ControlsBackPanel;
        private TableLayoutPanel ControlsTLP;
        private Button ClearQueueButton;
        private ToolTip ResearchNodeToolTip;
    }
}