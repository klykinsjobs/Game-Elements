namespace Game_Elements
{
    partial class MissionsForm
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
            MissionsTLP = new TableLayoutPanel();
            PageBackPanel = new Panel();
            PageTLP = new TableLayoutPanel();
            FirstPageItemBorderPanel = new Panel();
            FirstPageItemTLP = new TableLayoutPanel();
            FirstPageItemLabel = new Label();
            SecondPageItemBorderPanel = new Panel();
            SecondPageItemTLP = new TableLayoutPanel();
            SecondPageItemLabel = new Label();
            ThirdPageItemBorderPanel = new Panel();
            ThirdPageItemTLP = new TableLayoutPanel();
            ThirdPageItemLabel = new Label();
            PreviousButton = new Button();
            NextButton = new Button();
            SelectionBackPanel = new Panel();
            SelectionTLP = new TableLayoutPanel();
            DeselectButton = new Button();
            SelectionLabel = new Label();
            ControlsBackPanel = new Panel();
            ControlsTLP = new TableLayoutPanel();
            FirstSlotLabel = new Label();
            SecondSlotLabel = new Label();
            ThirdSlotLabel = new Label();
            InProgressMissionsCountLabel = new Label();
            ClearAllCompleteButton = new Button();
            UseRushBoostButton = new Button();
            MissionPB = new ProgressBar();
            MissionsToolTip = new ToolTip(components);
            MissionsTLP.SuspendLayout();
            PageBackPanel.SuspendLayout();
            PageTLP.SuspendLayout();
            FirstPageItemBorderPanel.SuspendLayout();
            FirstPageItemTLP.SuspendLayout();
            SecondPageItemBorderPanel.SuspendLayout();
            SecondPageItemTLP.SuspendLayout();
            ThirdPageItemBorderPanel.SuspendLayout();
            ThirdPageItemTLP.SuspendLayout();
            SelectionBackPanel.SuspendLayout();
            SelectionTLP.SuspendLayout();
            ControlsBackPanel.SuspendLayout();
            ControlsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // MissionsTLP
            // 
            MissionsTLP.ColumnCount = 2;
            MissionsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            MissionsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            MissionsTLP.Controls.Add(PageBackPanel, 0, 0);
            MissionsTLP.Controls.Add(SelectionBackPanel, 0, 1);
            MissionsTLP.Controls.Add(ControlsBackPanel, 1, 0);
            MissionsTLP.Dock = DockStyle.Fill;
            MissionsTLP.Location = new Point(0, 0);
            MissionsTLP.Name = "MissionsTLP";
            MissionsTLP.RowCount = 2;
            MissionsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            MissionsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            MissionsTLP.Size = new Size(800, 450);
            MissionsTLP.TabIndex = 0;
            // 
            // PageBackPanel
            // 
            PageBackPanel.Controls.Add(PageTLP);
            PageBackPanel.Dock = DockStyle.Fill;
            PageBackPanel.Location = new Point(3, 3);
            PageBackPanel.Name = "PageBackPanel";
            PageBackPanel.Size = new Size(594, 376);
            PageBackPanel.TabIndex = 0;
            // 
            // PageTLP
            // 
            PageTLP.ColumnCount = 3;
            PageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            PageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            PageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            PageTLP.Controls.Add(FirstPageItemBorderPanel, 0, 0);
            PageTLP.Controls.Add(SecondPageItemBorderPanel, 1, 0);
            PageTLP.Controls.Add(ThirdPageItemBorderPanel, 2, 0);
            PageTLP.Controls.Add(PreviousButton, 0, 1);
            PageTLP.Controls.Add(NextButton, 2, 1);
            PageTLP.Dock = DockStyle.Fill;
            PageTLP.Location = new Point(0, 0);
            PageTLP.Name = "PageTLP";
            PageTLP.RowCount = 2;
            PageTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            PageTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            PageTLP.Size = new Size(594, 376);
            PageTLP.TabIndex = 0;
            // 
            // FirstPageItemBorderPanel
            // 
            FirstPageItemBorderPanel.Controls.Add(FirstPageItemTLP);
            FirstPageItemBorderPanel.Dock = DockStyle.Fill;
            FirstPageItemBorderPanel.Location = new Point(3, 3);
            FirstPageItemBorderPanel.Name = "FirstPageItemBorderPanel";
            FirstPageItemBorderPanel.Size = new Size(192, 332);
            FirstPageItemBorderPanel.TabIndex = 0;
            // 
            // FirstPageItemTLP
            // 
            FirstPageItemTLP.ColumnCount = 1;
            FirstPageItemTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            FirstPageItemTLP.Controls.Add(FirstPageItemLabel, 0, 0);
            FirstPageItemTLP.Dock = DockStyle.Fill;
            FirstPageItemTLP.Location = new Point(0, 0);
            FirstPageItemTLP.Name = "FirstPageItemTLP";
            FirstPageItemTLP.RowCount = 1;
            FirstPageItemTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            FirstPageItemTLP.Size = new Size(192, 332);
            FirstPageItemTLP.TabIndex = 0;
            // 
            // FirstPageItemLabel
            // 
            FirstPageItemLabel.Anchor = AnchorStyles.None;
            FirstPageItemLabel.AutoSize = true;
            FirstPageItemLabel.Location = new Point(42, 158);
            FirstPageItemLabel.Name = "FirstPageItemLabel";
            FirstPageItemLabel.Size = new Size(107, 15);
            FirstPageItemLabel.TabIndex = 0;
            FirstPageItemLabel.Text = "FirstPageItemLabel";
            FirstPageItemLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecondPageItemBorderPanel
            // 
            SecondPageItemBorderPanel.Controls.Add(SecondPageItemTLP);
            SecondPageItemBorderPanel.Dock = DockStyle.Fill;
            SecondPageItemBorderPanel.Location = new Point(201, 3);
            SecondPageItemBorderPanel.Name = "SecondPageItemBorderPanel";
            SecondPageItemBorderPanel.Size = new Size(192, 332);
            SecondPageItemBorderPanel.TabIndex = 1;
            // 
            // SecondPageItemTLP
            // 
            SecondPageItemTLP.ColumnCount = 1;
            SecondPageItemTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            SecondPageItemTLP.Controls.Add(SecondPageItemLabel, 0, 0);
            SecondPageItemTLP.Dock = DockStyle.Fill;
            SecondPageItemTLP.Location = new Point(0, 0);
            SecondPageItemTLP.Name = "SecondPageItemTLP";
            SecondPageItemTLP.RowCount = 1;
            SecondPageItemTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            SecondPageItemTLP.Size = new Size(192, 332);
            SecondPageItemTLP.TabIndex = 0;
            // 
            // SecondPageItemLabel
            // 
            SecondPageItemLabel.Anchor = AnchorStyles.None;
            SecondPageItemLabel.AutoSize = true;
            SecondPageItemLabel.Location = new Point(34, 158);
            SecondPageItemLabel.Name = "SecondPageItemLabel";
            SecondPageItemLabel.Size = new Size(124, 15);
            SecondPageItemLabel.TabIndex = 0;
            SecondPageItemLabel.Text = "SecondPageItemLabel";
            SecondPageItemLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ThirdPageItemBorderPanel
            // 
            ThirdPageItemBorderPanel.Controls.Add(ThirdPageItemTLP);
            ThirdPageItemBorderPanel.Dock = DockStyle.Fill;
            ThirdPageItemBorderPanel.Location = new Point(399, 3);
            ThirdPageItemBorderPanel.Name = "ThirdPageItemBorderPanel";
            ThirdPageItemBorderPanel.Size = new Size(192, 332);
            ThirdPageItemBorderPanel.TabIndex = 2;
            // 
            // ThirdPageItemTLP
            // 
            ThirdPageItemTLP.ColumnCount = 1;
            ThirdPageItemTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ThirdPageItemTLP.Controls.Add(ThirdPageItemLabel, 0, 0);
            ThirdPageItemTLP.Dock = DockStyle.Fill;
            ThirdPageItemTLP.Location = new Point(0, 0);
            ThirdPageItemTLP.Name = "ThirdPageItemTLP";
            ThirdPageItemTLP.RowCount = 1;
            ThirdPageItemTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ThirdPageItemTLP.Size = new Size(192, 332);
            ThirdPageItemTLP.TabIndex = 0;
            // 
            // ThirdPageItemLabel
            // 
            ThirdPageItemLabel.Anchor = AnchorStyles.None;
            ThirdPageItemLabel.AutoSize = true;
            ThirdPageItemLabel.Location = new Point(40, 158);
            ThirdPageItemLabel.Name = "ThirdPageItemLabel";
            ThirdPageItemLabel.Size = new Size(112, 15);
            ThirdPageItemLabel.TabIndex = 0;
            ThirdPageItemLabel.Text = "ThirdPageItemLabel";
            ThirdPageItemLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PreviousButton
            // 
            PreviousButton.Dock = DockStyle.Fill;
            PreviousButton.FlatStyle = FlatStyle.Flat;
            PreviousButton.Location = new Point(3, 341);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(192, 32);
            PreviousButton.TabIndex = 3;
            PreviousButton.Text = "<";
            PreviousButton.UseVisualStyleBackColor = true;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // NextButton
            // 
            NextButton.Dock = DockStyle.Fill;
            NextButton.FlatStyle = FlatStyle.Flat;
            NextButton.Location = new Point(399, 341);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(192, 32);
            NextButton.TabIndex = 4;
            NextButton.Text = ">";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // SelectionBackPanel
            // 
            SelectionBackPanel.Controls.Add(SelectionTLP);
            SelectionBackPanel.Dock = DockStyle.Fill;
            SelectionBackPanel.Location = new Point(3, 385);
            SelectionBackPanel.Name = "SelectionBackPanel";
            SelectionBackPanel.Size = new Size(594, 62);
            SelectionBackPanel.TabIndex = 1;
            // 
            // SelectionTLP
            // 
            SelectionTLP.ColumnCount = 2;
            SelectionTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            SelectionTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            SelectionTLP.Controls.Add(DeselectButton, 0, 0);
            SelectionTLP.Controls.Add(SelectionLabel, 1, 0);
            SelectionTLP.Dock = DockStyle.Fill;
            SelectionTLP.Location = new Point(0, 0);
            SelectionTLP.Name = "SelectionTLP";
            SelectionTLP.RowCount = 1;
            SelectionTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            SelectionTLP.Size = new Size(594, 62);
            SelectionTLP.TabIndex = 0;
            // 
            // DeselectButton
            // 
            DeselectButton.Dock = DockStyle.Fill;
            DeselectButton.FlatStyle = FlatStyle.Flat;
            DeselectButton.Location = new Point(3, 3);
            DeselectButton.Name = "DeselectButton";
            DeselectButton.Size = new Size(172, 56);
            DeselectButton.TabIndex = 0;
            DeselectButton.Text = "Deselect";
            DeselectButton.UseVisualStyleBackColor = true;
            DeselectButton.Click += DeselectButton_Click;
            // 
            // SelectionLabel
            // 
            SelectionLabel.Anchor = AnchorStyles.None;
            SelectionLabel.AutoSize = true;
            SelectionLabel.Location = new Point(344, 23);
            SelectionLabel.Name = "SelectionLabel";
            SelectionLabel.Size = new Size(83, 15);
            SelectionLabel.TabIndex = 1;
            SelectionLabel.Text = "SelectionLabel";
            SelectionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ControlsBackPanel
            // 
            ControlsBackPanel.Controls.Add(ControlsTLP);
            ControlsBackPanel.Dock = DockStyle.Fill;
            ControlsBackPanel.Location = new Point(603, 3);
            ControlsBackPanel.Name = "ControlsBackPanel";
            MissionsTLP.SetRowSpan(ControlsBackPanel, 2);
            ControlsBackPanel.Size = new Size(194, 444);
            ControlsBackPanel.TabIndex = 2;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 1;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsTLP.Controls.Add(FirstSlotLabel, 0, 0);
            ControlsTLP.Controls.Add(SecondSlotLabel, 0, 1);
            ControlsTLP.Controls.Add(ThirdSlotLabel, 0, 2);
            ControlsTLP.Controls.Add(InProgressMissionsCountLabel, 0, 6);
            ControlsTLP.Controls.Add(ClearAllCompleteButton, 0, 7);
            ControlsTLP.Controls.Add(UseRushBoostButton, 0, 5);
            ControlsTLP.Controls.Add(MissionPB, 0, 4);
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
            // FirstSlotLabel
            // 
            FirstSlotLabel.Anchor = AnchorStyles.None;
            FirstSlotLabel.AutoSize = true;
            FirstSlotLabel.Location = new Point(58, 20);
            FirstSlotLabel.Name = "FirstSlotLabel";
            FirstSlotLabel.Size = new Size(77, 15);
            FirstSlotLabel.TabIndex = 0;
            FirstSlotLabel.Text = "FirstSlotLabel";
            FirstSlotLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecondSlotLabel
            // 
            SecondSlotLabel.Anchor = AnchorStyles.None;
            SecondSlotLabel.AutoSize = true;
            SecondSlotLabel.Location = new Point(50, 75);
            SecondSlotLabel.Name = "SecondSlotLabel";
            SecondSlotLabel.Size = new Size(94, 15);
            SecondSlotLabel.TabIndex = 1;
            SecondSlotLabel.Text = "SecondSlotLabel";
            SecondSlotLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ThirdSlotLabel
            // 
            ThirdSlotLabel.Anchor = AnchorStyles.None;
            ThirdSlotLabel.AutoSize = true;
            ThirdSlotLabel.Location = new Point(56, 130);
            ThirdSlotLabel.Name = "ThirdSlotLabel";
            ThirdSlotLabel.Size = new Size(82, 15);
            ThirdSlotLabel.TabIndex = 2;
            ThirdSlotLabel.Text = "ThirdSlotLabel";
            ThirdSlotLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InProgressMissionsCountLabel
            // 
            InProgressMissionsCountLabel.Anchor = AnchorStyles.None;
            InProgressMissionsCountLabel.AutoSize = true;
            InProgressMissionsCountLabel.Location = new Point(12, 350);
            InProgressMissionsCountLabel.Name = "InProgressMissionsCountLabel";
            InProgressMissionsCountLabel.Size = new Size(169, 15);
            InProgressMissionsCountLabel.TabIndex = 5;
            InProgressMissionsCountLabel.Text = "InProgressMissionsCountLabel";
            InProgressMissionsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClearAllCompleteButton
            // 
            ClearAllCompleteButton.Dock = DockStyle.Fill;
            ClearAllCompleteButton.FlatStyle = FlatStyle.Flat;
            ClearAllCompleteButton.Location = new Point(3, 388);
            ClearAllCompleteButton.Name = "ClearAllCompleteButton";
            ClearAllCompleteButton.Size = new Size(188, 53);
            ClearAllCompleteButton.TabIndex = 6;
            ClearAllCompleteButton.Text = "Clear All Complete";
            ClearAllCompleteButton.UseVisualStyleBackColor = true;
            ClearAllCompleteButton.Click += ClearAllCompleteButton_Click;
            // 
            // UseRushBoostButton
            // 
            UseRushBoostButton.Dock = DockStyle.Fill;
            UseRushBoostButton.FlatStyle = FlatStyle.Flat;
            UseRushBoostButton.Location = new Point(3, 278);
            UseRushBoostButton.Name = "UseRushBoostButton";
            UseRushBoostButton.Size = new Size(188, 49);
            UseRushBoostButton.TabIndex = 4;
            UseRushBoostButton.Text = "Use Rush Boost";
            UseRushBoostButton.UseVisualStyleBackColor = true;
            UseRushBoostButton.Click += UseRushBoostButton_Click;
            // 
            // MissionPB
            // 
            MissionPB.Dock = DockStyle.Fill;
            MissionPB.Location = new Point(3, 223);
            MissionPB.Name = "MissionPB";
            MissionPB.Size = new Size(188, 49);
            MissionPB.TabIndex = 3;
            // 
            // MissionsToolTip
            // 
            MissionsToolTip.IsBalloon = true;
            // 
            // MissionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MissionsTLP);
            Name = "MissionsForm";
            Text = "MissionsForm";
            FormClosing += MissionsForm_FormClosing;
            MissionsTLP.ResumeLayout(false);
            PageBackPanel.ResumeLayout(false);
            PageTLP.ResumeLayout(false);
            FirstPageItemBorderPanel.ResumeLayout(false);
            FirstPageItemTLP.ResumeLayout(false);
            FirstPageItemTLP.PerformLayout();
            SecondPageItemBorderPanel.ResumeLayout(false);
            SecondPageItemTLP.ResumeLayout(false);
            SecondPageItemTLP.PerformLayout();
            ThirdPageItemBorderPanel.ResumeLayout(false);
            ThirdPageItemTLP.ResumeLayout(false);
            ThirdPageItemTLP.PerformLayout();
            SelectionBackPanel.ResumeLayout(false);
            SelectionTLP.ResumeLayout(false);
            SelectionTLP.PerformLayout();
            ControlsBackPanel.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ControlsTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MissionsTLP;
        private Panel PageBackPanel;
        private Panel SelectionBackPanel;
        private Panel ControlsBackPanel;
        private TableLayoutPanel PageTLP;
        private Panel FirstPageItemBorderPanel;
        private Panel SecondPageItemBorderPanel;
        private Panel ThirdPageItemBorderPanel;
        private Button PreviousButton;
        private Button NextButton;
        private TableLayoutPanel SelectionTLP;
        private Button DeselectButton;
        private Label SelectionLabel;
        private TableLayoutPanel ControlsTLP;
        private TableLayoutPanel FirstPageItemTLP;
        private Label FirstPageItemLabel;
        private TableLayoutPanel SecondPageItemTLP;
        private Label SecondPageItemLabel;
        private TableLayoutPanel ThirdPageItemTLP;
        private Label ThirdPageItemLabel;
        private Label FirstSlotLabel;
        private Label SecondSlotLabel;
        private Label ThirdSlotLabel;
        private Label InProgressMissionsCountLabel;
        private Button ClearAllCompleteButton;
        private Button UseRushBoostButton;
        private ProgressBar MissionPB;
        private ToolTip MissionsToolTip;
    }
}