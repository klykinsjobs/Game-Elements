namespace Game_Elements
{
    partial class InventoryForm
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
            InventoryTLP = new TableLayoutPanel();
            ItemsBackPanel = new Panel();
            ItemsListBox = new ListBox();
            SelectionBackPanel = new Panel();
            SelectionTLP = new TableLayoutPanel();
            SelectionLabel = new Label();
            ControlsBackPanel = new Panel();
            ControlsTLP = new TableLayoutPanel();
            SellAllItemsButton = new Button();
            ItemCountLabel = new Label();
            WaterCountLabel = new Label();
            FoodCountLabel = new Label();
            ConcreteCountLabel = new Label();
            MetalCountLabel = new Label();
            MonsterEggsCountLabel = new Label();
            MysterySeedsCountLabel = new Label();
            FertilizerCountLabel = new Label();
            InventoryTLP.SuspendLayout();
            ItemsBackPanel.SuspendLayout();
            SelectionBackPanel.SuspendLayout();
            SelectionTLP.SuspendLayout();
            ControlsBackPanel.SuspendLayout();
            ControlsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // InventoryTLP
            // 
            InventoryTLP.ColumnCount = 3;
            InventoryTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            InventoryTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            InventoryTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            InventoryTLP.Controls.Add(ItemsBackPanel, 0, 0);
            InventoryTLP.Controls.Add(SelectionBackPanel, 0, 1);
            InventoryTLP.Controls.Add(ControlsBackPanel, 2, 0);
            InventoryTLP.Dock = DockStyle.Fill;
            InventoryTLP.Location = new Point(0, 0);
            InventoryTLP.Name = "InventoryTLP";
            InventoryTLP.RowCount = 2;
            InventoryTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            InventoryTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            InventoryTLP.Size = new Size(800, 450);
            InventoryTLP.TabIndex = 0;
            // 
            // ItemsBackPanel
            // 
            InventoryTLP.SetColumnSpan(ItemsBackPanel, 2);
            ItemsBackPanel.Controls.Add(ItemsListBox);
            ItemsBackPanel.Dock = DockStyle.Fill;
            ItemsBackPanel.Location = new Point(3, 3);
            ItemsBackPanel.Name = "ItemsBackPanel";
            ItemsBackPanel.Size = new Size(594, 219);
            ItemsBackPanel.TabIndex = 0;
            // 
            // ItemsListBox
            // 
            ItemsListBox.Dock = DockStyle.Fill;
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(0, 0);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(594, 219);
            ItemsListBox.TabIndex = 0;
            ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            ItemsListBox.DoubleClick += ItemsListBox_DoubleClick;
            // 
            // SelectionBackPanel
            // 
            InventoryTLP.SetColumnSpan(SelectionBackPanel, 2);
            SelectionBackPanel.Controls.Add(SelectionTLP);
            SelectionBackPanel.Dock = DockStyle.Fill;
            SelectionBackPanel.Location = new Point(3, 228);
            SelectionBackPanel.Name = "SelectionBackPanel";
            SelectionBackPanel.Size = new Size(594, 219);
            SelectionBackPanel.TabIndex = 1;
            // 
            // SelectionTLP
            // 
            SelectionTLP.ColumnCount = 1;
            SelectionTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            SelectionTLP.Controls.Add(SelectionLabel, 0, 0);
            SelectionTLP.Dock = DockStyle.Fill;
            SelectionTLP.Location = new Point(0, 0);
            SelectionTLP.Name = "SelectionTLP";
            SelectionTLP.RowCount = 1;
            SelectionTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            SelectionTLP.Size = new Size(594, 219);
            SelectionTLP.TabIndex = 0;
            // 
            // SelectionLabel
            // 
            SelectionLabel.Anchor = AnchorStyles.None;
            SelectionLabel.AutoSize = true;
            SelectionLabel.Location = new Point(255, 102);
            SelectionLabel.Name = "SelectionLabel";
            SelectionLabel.Size = new Size(83, 15);
            SelectionLabel.TabIndex = 0;
            SelectionLabel.Text = "SelectionLabel";
            SelectionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ControlsBackPanel
            // 
            ControlsBackPanel.Controls.Add(ControlsTLP);
            ControlsBackPanel.Dock = DockStyle.Fill;
            ControlsBackPanel.Location = new Point(603, 3);
            ControlsBackPanel.Name = "ControlsBackPanel";
            InventoryTLP.SetRowSpan(ControlsBackPanel, 2);
            ControlsBackPanel.Size = new Size(194, 444);
            ControlsBackPanel.TabIndex = 2;
            // 
            // ControlsTLP
            // 
            ControlsTLP.ColumnCount = 1;
            ControlsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsTLP.Controls.Add(SellAllItemsButton, 0, 1);
            ControlsTLP.Controls.Add(ItemCountLabel, 0, 2);
            ControlsTLP.Controls.Add(WaterCountLabel, 0, 3);
            ControlsTLP.Controls.Add(FoodCountLabel, 0, 4);
            ControlsTLP.Controls.Add(ConcreteCountLabel, 0, 5);
            ControlsTLP.Controls.Add(MetalCountLabel, 0, 6);
            ControlsTLP.Controls.Add(MonsterEggsCountLabel, 0, 7);
            ControlsTLP.Controls.Add(MysterySeedsCountLabel, 0, 8);
            ControlsTLP.Controls.Add(FertilizerCountLabel, 0, 9);
            ControlsTLP.Dock = DockStyle.Fill;
            ControlsTLP.Location = new Point(0, 0);
            ControlsTLP.Name = "ControlsTLP";
            ControlsTLP.RowCount = 10;
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ControlsTLP.Size = new Size(194, 444);
            ControlsTLP.TabIndex = 0;
            // 
            // SellAllItemsButton
            // 
            SellAllItemsButton.Dock = DockStyle.Fill;
            SellAllItemsButton.FlatStyle = FlatStyle.Flat;
            SellAllItemsButton.Location = new Point(3, 47);
            SellAllItemsButton.Name = "SellAllItemsButton";
            SellAllItemsButton.Size = new Size(188, 38);
            SellAllItemsButton.TabIndex = 0;
            SellAllItemsButton.Text = "Sell All Items";
            SellAllItemsButton.UseVisualStyleBackColor = true;
            SellAllItemsButton.Click += SellAllItemsButton_Click;
            // 
            // ItemCountLabel
            // 
            ItemCountLabel.Anchor = AnchorStyles.None;
            ItemCountLabel.AutoSize = true;
            ItemCountLabel.Location = new Point(51, 102);
            ItemCountLabel.Name = "ItemCountLabel";
            ItemCountLabel.Size = new Size(92, 15);
            ItemCountLabel.TabIndex = 1;
            ItemCountLabel.Text = "ItemCountLabel";
            ItemCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WaterCountLabel
            // 
            WaterCountLabel.Anchor = AnchorStyles.None;
            WaterCountLabel.AutoSize = true;
            WaterCountLabel.Location = new Point(47, 146);
            WaterCountLabel.Name = "WaterCountLabel";
            WaterCountLabel.Size = new Size(99, 15);
            WaterCountLabel.TabIndex = 2;
            WaterCountLabel.Text = "WaterCountLabel";
            WaterCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FoodCountLabel
            // 
            FoodCountLabel.Anchor = AnchorStyles.None;
            FoodCountLabel.AutoSize = true;
            FoodCountLabel.Location = new Point(49, 190);
            FoodCountLabel.Name = "FoodCountLabel";
            FoodCountLabel.Size = new Size(95, 15);
            FoodCountLabel.TabIndex = 3;
            FoodCountLabel.Text = "FoodCountLabel";
            FoodCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConcreteCountLabel
            // 
            ConcreteCountLabel.Anchor = AnchorStyles.None;
            ConcreteCountLabel.AutoSize = true;
            ConcreteCountLabel.Location = new Point(39, 234);
            ConcreteCountLabel.Name = "ConcreteCountLabel";
            ConcreteCountLabel.Size = new Size(116, 15);
            ConcreteCountLabel.TabIndex = 4;
            ConcreteCountLabel.Text = "ConcreteCountLabel";
            ConcreteCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MetalCountLabel
            // 
            MetalCountLabel.Anchor = AnchorStyles.None;
            MetalCountLabel.AutoSize = true;
            MetalCountLabel.Location = new Point(48, 278);
            MetalCountLabel.Name = "MetalCountLabel";
            MetalCountLabel.Size = new Size(98, 15);
            MetalCountLabel.TabIndex = 5;
            MetalCountLabel.Text = "MetalCountLabel";
            MetalCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MonsterEggsCountLabel
            // 
            MonsterEggsCountLabel.Anchor = AnchorStyles.None;
            MonsterEggsCountLabel.AutoSize = true;
            MonsterEggsCountLabel.Location = new Point(28, 322);
            MonsterEggsCountLabel.Name = "MonsterEggsCountLabel";
            MonsterEggsCountLabel.Size = new Size(137, 15);
            MonsterEggsCountLabel.TabIndex = 6;
            MonsterEggsCountLabel.Text = "MonsterEggsCountLabel";
            MonsterEggsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MysterySeedsCountLabel
            // 
            MysterySeedsCountLabel.Anchor = AnchorStyles.None;
            MysterySeedsCountLabel.AutoSize = true;
            MysterySeedsCountLabel.Location = new Point(27, 366);
            MysterySeedsCountLabel.Name = "MysterySeedsCountLabel";
            MysterySeedsCountLabel.Size = new Size(140, 15);
            MysterySeedsCountLabel.TabIndex = 7;
            MysterySeedsCountLabel.Text = "MysterySeedsCountLabel";
            MysterySeedsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FertilizerCountLabel
            // 
            FertilizerCountLabel.Anchor = AnchorStyles.None;
            FertilizerCountLabel.AutoSize = true;
            FertilizerCountLabel.Location = new Point(41, 412);
            FertilizerCountLabel.Name = "FertilizerCountLabel";
            FertilizerCountLabel.Size = new Size(112, 15);
            FertilizerCountLabel.TabIndex = 8;
            FertilizerCountLabel.Text = "FertilizerCountLabel";
            FertilizerCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(InventoryTLP);
            Name = "InventoryForm";
            Text = "InventoryForm";
            FormClosing += InventoryForm_FormClosing;
            InventoryTLP.ResumeLayout(false);
            ItemsBackPanel.ResumeLayout(false);
            SelectionBackPanel.ResumeLayout(false);
            SelectionTLP.ResumeLayout(false);
            SelectionTLP.PerformLayout();
            ControlsBackPanel.ResumeLayout(false);
            ControlsTLP.ResumeLayout(false);
            ControlsTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel InventoryTLP;
        private Panel ItemsBackPanel;
        private ListBox ItemsListBox;
        private Panel SelectionBackPanel;
        private TableLayoutPanel SelectionTLP;
        private Label SelectionLabel;
        private Panel ControlsBackPanel;
        private TableLayoutPanel ControlsTLP;
        private Button SellAllItemsButton;
        private Label ItemCountLabel;
        private Label WaterCountLabel;
        private Label FoodCountLabel;
        private Label ConcreteCountLabel;
        private Label MetalCountLabel;
        private Label MonsterEggsCountLabel;
        private Label MysterySeedsCountLabel;
        private Label FertilizerCountLabel;
    }
}