namespace Game_Elements
{
    partial class UnitsForm
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
            UnitsTLP = new TableLayoutPanel();
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
            FourthPageItemBorderPanel = new Panel();
            FourthPageItemTLP = new TableLayoutPanel();
            FourthPageItemLabel = new Label();
            PreviousButton = new Button();
            NextButton = new Button();
            SelectionBackPanel = new Panel();
            SelectionTLP = new TableLayoutPanel();
            DeselectButton = new Button();
            SelectionLabel = new Label();
            ControlsBackPanel = new Panel();
            ControlsTLP = new TableLayoutPanel();
            UseExperienceBoostButton = new Button();
            ExperiencePB = new ProgressBar();
            UseRarityBoostButton = new Button();
            WaterPB = new ProgressBar();
            DrinkButton = new Button();
            FoodPB = new ProgressBar();
            EatButton = new Button();
            RenameButton = new Button();
            ReleaseButton = new Button();
            UnitsCountLabel = new Label();
            UnitsToolTip = new ToolTip(components);
            UnitsTLP.SuspendLayout();
            PageBackPanel.SuspendLayout();
            PageTLP.SuspendLayout();
            FirstPageItemBorderPanel.SuspendLayout();
            FirstPageItemTLP.SuspendLayout();
            SecondPageItemBorderPanel.SuspendLayout();
            SecondPageItemTLP.SuspendLayout();
            ThirdPageItemBorderPanel.SuspendLayout();
            ThirdPageItemTLP.SuspendLayout();
            FourthPageItemBorderPanel.SuspendLayout();
            FourthPageItemTLP.SuspendLayout();
            SelectionBackPanel.SuspendLayout();
            SelectionTLP.SuspendLayout();
            ControlsBackPanel.SuspendLayout();
            ControlsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // UnitsTLP
            // 
            UnitsTLP.ColumnCount = 2;
            UnitsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            UnitsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            UnitsTLP.Controls.Add(PageBackPanel, 0, 0);
            UnitsTLP.Controls.Add(SelectionBackPanel, 0, 1);
            UnitsTLP.Controls.Add(ControlsBackPanel, 1, 0);
            UnitsTLP.Dock = DockStyle.Fill;
            UnitsTLP.Location = new Point(0, 0);
            UnitsTLP.Name = "UnitsTLP";
            UnitsTLP.RowCount = 2;
            UnitsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            UnitsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            UnitsTLP.Size = new Size(800, 450);
            UnitsTLP.TabIndex = 0;
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
            PageTLP.ColumnCount = 2;
            PageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            PageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            PageTLP.Controls.Add(FirstPageItemBorderPanel, 0, 0);
            PageTLP.Controls.Add(SecondPageItemBorderPanel, 1, 0);
            PageTLP.Controls.Add(ThirdPageItemBorderPanel, 0, 1);
            PageTLP.Controls.Add(FourthPageItemBorderPanel, 1, 1);
            PageTLP.Controls.Add(PreviousButton, 0, 2);
            PageTLP.Controls.Add(NextButton, 1, 2);
            PageTLP.Dock = DockStyle.Fill;
            PageTLP.Location = new Point(0, 0);
            PageTLP.Name = "PageTLP";
            PageTLP.RowCount = 3;
            PageTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            PageTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
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
            FirstPageItemBorderPanel.Size = new Size(291, 163);
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
            FirstPageItemTLP.Size = new Size(291, 163);
            FirstPageItemTLP.TabIndex = 0;
            // 
            // FirstPageItemLabel
            // 
            FirstPageItemLabel.Anchor = AnchorStyles.None;
            FirstPageItemLabel.AutoSize = true;
            FirstPageItemLabel.Location = new Point(92, 74);
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
            SecondPageItemBorderPanel.Location = new Point(300, 3);
            SecondPageItemBorderPanel.Name = "SecondPageItemBorderPanel";
            SecondPageItemBorderPanel.Size = new Size(291, 163);
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
            SecondPageItemTLP.Size = new Size(291, 163);
            SecondPageItemTLP.TabIndex = 0;
            // 
            // SecondPageItemLabel
            // 
            SecondPageItemLabel.Anchor = AnchorStyles.None;
            SecondPageItemLabel.AutoSize = true;
            SecondPageItemLabel.Location = new Point(83, 74);
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
            ThirdPageItemBorderPanel.Location = new Point(3, 172);
            ThirdPageItemBorderPanel.Name = "ThirdPageItemBorderPanel";
            ThirdPageItemBorderPanel.Size = new Size(291, 163);
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
            ThirdPageItemTLP.Size = new Size(291, 163);
            ThirdPageItemTLP.TabIndex = 0;
            // 
            // ThirdPageItemLabel
            // 
            ThirdPageItemLabel.Anchor = AnchorStyles.None;
            ThirdPageItemLabel.AutoSize = true;
            ThirdPageItemLabel.Location = new Point(89, 74);
            ThirdPageItemLabel.Name = "ThirdPageItemLabel";
            ThirdPageItemLabel.Size = new Size(112, 15);
            ThirdPageItemLabel.TabIndex = 0;
            ThirdPageItemLabel.Text = "ThirdPageItemLabel";
            ThirdPageItemLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FourthPageItemBorderPanel
            // 
            FourthPageItemBorderPanel.Controls.Add(FourthPageItemTLP);
            FourthPageItemBorderPanel.Dock = DockStyle.Fill;
            FourthPageItemBorderPanel.Location = new Point(300, 172);
            FourthPageItemBorderPanel.Name = "FourthPageItemBorderPanel";
            FourthPageItemBorderPanel.Size = new Size(291, 163);
            FourthPageItemBorderPanel.TabIndex = 3;
            // 
            // FourthPageItemTLP
            // 
            FourthPageItemTLP.ColumnCount = 1;
            FourthPageItemTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            FourthPageItemTLP.Controls.Add(FourthPageItemLabel, 0, 0);
            FourthPageItemTLP.Dock = DockStyle.Fill;
            FourthPageItemTLP.Location = new Point(0, 0);
            FourthPageItemTLP.Name = "FourthPageItemTLP";
            FourthPageItemTLP.RowCount = 1;
            FourthPageItemTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            FourthPageItemTLP.Size = new Size(291, 163);
            FourthPageItemTLP.TabIndex = 0;
            // 
            // FourthPageItemLabel
            // 
            FourthPageItemLabel.Anchor = AnchorStyles.None;
            FourthPageItemLabel.AutoSize = true;
            FourthPageItemLabel.Location = new Point(85, 74);
            FourthPageItemLabel.Name = "FourthPageItemLabel";
            FourthPageItemLabel.Size = new Size(120, 15);
            FourthPageItemLabel.TabIndex = 0;
            FourthPageItemLabel.Text = "FourthPageItemLabel";
            FourthPageItemLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PreviousButton
            // 
            PreviousButton.Dock = DockStyle.Fill;
            PreviousButton.FlatStyle = FlatStyle.Flat;
            PreviousButton.Location = new Point(3, 341);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new Size(291, 32);
            PreviousButton.TabIndex = 4;
            PreviousButton.Text = "<";
            PreviousButton.UseVisualStyleBackColor = true;
            PreviousButton.Click += PreviousButton_Click;
            // 
            // NextButton
            // 
            NextButton.Dock = DockStyle.Fill;
            NextButton.FlatStyle = FlatStyle.Flat;
            NextButton.Location = new Point(300, 341);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(291, 32);
            NextButton.TabIndex = 5;
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
            UnitsTLP.SetRowSpan(ControlsBackPanel, 2);
            ControlsBackPanel.Size = new Size(194, 444);
            ControlsBackPanel.TabIndex = 2;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 2;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ControlsTLP.Controls.Add(UseExperienceBoostButton, 0, 0);
            ControlsTLP.Controls.Add(ExperiencePB, 0, 1);
            ControlsTLP.Controls.Add(UseRarityBoostButton, 0, 2);
            ControlsTLP.Controls.Add(WaterPB, 0, 3);
            ControlsTLP.Controls.Add(DrinkButton, 1, 3);
            ControlsTLP.Controls.Add(FoodPB, 0, 4);
            ControlsTLP.Controls.Add(EatButton, 1, 4);
            ControlsTLP.Controls.Add(RenameButton, 0, 5);
            ControlsTLP.Controls.Add(ReleaseButton, 0, 6);
            ControlsTLP.Controls.Add(UnitsCountLabel, 0, 7);
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
            // UseExperienceBoostButton
            // 
            ControlsTLP.SetColumnSpan(UseExperienceBoostButton, 2);
            UseExperienceBoostButton.Dock = DockStyle.Fill;
            UseExperienceBoostButton.FlatStyle = FlatStyle.Flat;
            UseExperienceBoostButton.Location = new Point(3, 3);
            UseExperienceBoostButton.Name = "UseExperienceBoostButton";
            UseExperienceBoostButton.Size = new Size(188, 49);
            UseExperienceBoostButton.TabIndex = 0;
            UseExperienceBoostButton.Text = "Use Experience Boost";
            UseExperienceBoostButton.UseVisualStyleBackColor = true;
            UseExperienceBoostButton.Click += UseExperienceBoostButton_Click;
            // 
            // ExperiencePB
            // 
            ControlsTLP.SetColumnSpan(ExperiencePB, 2);
            ExperiencePB.Dock = DockStyle.Fill;
            ExperiencePB.Location = new Point(3, 58);
            ExperiencePB.Name = "ExperiencePB";
            ExperiencePB.Size = new Size(188, 49);
            ExperiencePB.TabIndex = 1;
            // 
            // UseRarityBoostButton
            // 
            ControlsTLP.SetColumnSpan(UseRarityBoostButton, 2);
            UseRarityBoostButton.Dock = DockStyle.Fill;
            UseRarityBoostButton.FlatStyle = FlatStyle.Flat;
            UseRarityBoostButton.Location = new Point(3, 113);
            UseRarityBoostButton.Name = "UseRarityBoostButton";
            UseRarityBoostButton.Size = new Size(188, 49);
            UseRarityBoostButton.TabIndex = 2;
            UseRarityBoostButton.Text = "Use Rarity Boost";
            UseRarityBoostButton.UseVisualStyleBackColor = true;
            UseRarityBoostButton.Click += UseRarityBoostButton_Click;
            // 
            // WaterPB
            // 
            WaterPB.Dock = DockStyle.Fill;
            WaterPB.Location = new Point(3, 168);
            WaterPB.Name = "WaterPB";
            WaterPB.Size = new Size(91, 49);
            WaterPB.TabIndex = 3;
            // 
            // DrinkButton
            // 
            DrinkButton.Dock = DockStyle.Fill;
            DrinkButton.FlatStyle = FlatStyle.Flat;
            DrinkButton.Location = new Point(100, 168);
            DrinkButton.Name = "DrinkButton";
            DrinkButton.Size = new Size(91, 49);
            DrinkButton.TabIndex = 4;
            DrinkButton.Text = "Drink";
            DrinkButton.UseVisualStyleBackColor = true;
            DrinkButton.Click += DrinkButton_Click;
            // 
            // FoodPB
            // 
            FoodPB.Dock = DockStyle.Fill;
            FoodPB.Location = new Point(3, 223);
            FoodPB.Name = "FoodPB";
            FoodPB.Size = new Size(91, 49);
            FoodPB.TabIndex = 5;
            // 
            // EatButton
            // 
            EatButton.Dock = DockStyle.Fill;
            EatButton.FlatStyle = FlatStyle.Flat;
            EatButton.Location = new Point(100, 223);
            EatButton.Name = "EatButton";
            EatButton.Size = new Size(91, 49);
            EatButton.TabIndex = 6;
            EatButton.Text = "Eat";
            EatButton.UseVisualStyleBackColor = true;
            EatButton.Click += EatButton_Click;
            // 
            // RenameButton
            // 
            ControlsTLP.SetColumnSpan(RenameButton, 2);
            RenameButton.Dock = DockStyle.Fill;
            RenameButton.FlatStyle = FlatStyle.Flat;
            RenameButton.Location = new Point(3, 278);
            RenameButton.Name = "RenameButton";
            RenameButton.Size = new Size(188, 49);
            RenameButton.TabIndex = 7;
            RenameButton.Text = "Rename";
            RenameButton.UseVisualStyleBackColor = true;
            RenameButton.Click += RenameButton_Click;
            // 
            // ReleaseButton
            // 
            ControlsTLP.SetColumnSpan(ReleaseButton, 2);
            ReleaseButton.Dock = DockStyle.Fill;
            ReleaseButton.FlatStyle = FlatStyle.Flat;
            ReleaseButton.Location = new Point(3, 333);
            ReleaseButton.Name = "ReleaseButton";
            ReleaseButton.Size = new Size(188, 49);
            ReleaseButton.TabIndex = 8;
            ReleaseButton.Text = "Release";
            ReleaseButton.UseVisualStyleBackColor = true;
            ReleaseButton.Click += ReleaseButton_Click;
            // 
            // UnitsCountLabel
            // 
            UnitsCountLabel.Anchor = AnchorStyles.None;
            UnitsCountLabel.AutoSize = true;
            ControlsTLP.SetColumnSpan(UnitsCountLabel, 2);
            UnitsCountLabel.Location = new Point(49, 407);
            UnitsCountLabel.Name = "UnitsCountLabel";
            UnitsCountLabel.Size = new Size(95, 15);
            UnitsCountLabel.TabIndex = 9;
            UnitsCountLabel.Text = "UnitsCountLabel";
            UnitsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UnitsToolTip
            // 
            UnitsToolTip.IsBalloon = true;
            // 
            // UnitsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UnitsTLP);
            Name = "UnitsForm";
            Text = "UnitsForm";
            FormClosing += UnitsForm_FormClosing;
            UnitsTLP.ResumeLayout(false);
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
            FourthPageItemBorderPanel.ResumeLayout(false);
            FourthPageItemTLP.ResumeLayout(false);
            FourthPageItemTLP.PerformLayout();
            SelectionBackPanel.ResumeLayout(false);
            SelectionTLP.ResumeLayout(false);
            SelectionTLP.PerformLayout();
            ControlsBackPanel.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ControlsTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel UnitsTLP;
        private Panel PageBackPanel;
        private Panel SelectionBackPanel;
        private Panel ControlsBackPanel;
        private TableLayoutPanel PageTLP;
        private Panel FirstPageItemBorderPanel;
        private TableLayoutPanel FirstPageItemTLP;
        private Label FirstPageItemLabel;
        private Panel SecondPageItemBorderPanel;
        private TableLayoutPanel SecondPageItemTLP;
        private Label SecondPageItemLabel;
        private Panel ThirdPageItemBorderPanel;
        private TableLayoutPanel ThirdPageItemTLP;
        private Label ThirdPageItemLabel;
        private Panel FourthPageItemBorderPanel;
        private TableLayoutPanel FourthPageItemTLP;
        private Label FourthPageItemLabel;
        private Button PreviousButton;
        private Button NextButton;
        private TableLayoutPanel SelectionTLP;
        private Button DeselectButton;
        private Label SelectionLabel;
        private TableLayoutPanel ControlsTLP;
        private Button UseExperienceBoostButton;
        private ProgressBar ExperiencePB;
        private Button UseRarityBoostButton;
        private ProgressBar WaterPB;
        private Button DrinkButton;
        private ProgressBar FoodPB;
        private Button EatButton;
        private Button RenameButton;
        private Button ReleaseButton;
        private Label UnitsCountLabel;
        private ToolTip UnitsToolTip;
    }
}