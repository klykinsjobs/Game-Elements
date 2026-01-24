namespace Game_Elements
{
    partial class ItemShopForm
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
            ItemShopTLP = new TableLayoutPanel();
            ItemsBackPanel = new Panel();
            ItemsTLP = new TableLayoutPanel();
            BuyLootboxButton = new Button();
            BuyRarityBoostButton = new Button();
            BuyExperienceBoostButton = new Button();
            BuyRushBoostButton = new Button();
            ResourcesTLP = new TableLayoutPanel();
            BuyConcreteButton = new Button();
            BuyMetalButton = new Button();
            BuyWaterButton = new Button();
            BuyFoodButton = new Button();
            ItemShopTLP.SuspendLayout();
            ItemsBackPanel.SuspendLayout();
            ItemsTLP.SuspendLayout();
            ResourcesTLP.SuspendLayout();
            SuspendLayout();
            // 
            // ItemShopTLP
            // 
            ItemShopTLP.ColumnCount = 1;
            ItemShopTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ItemShopTLP.Controls.Add(ItemsBackPanel, 0, 0);
            ItemShopTLP.Dock = DockStyle.Fill;
            ItemShopTLP.Location = new Point(0, 0);
            ItemShopTLP.Name = "ItemShopTLP";
            ItemShopTLP.RowCount = 1;
            ItemShopTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ItemShopTLP.Size = new Size(800, 450);
            ItemShopTLP.TabIndex = 0;
            // 
            // ItemsBackPanel
            // 
            ItemsBackPanel.Controls.Add(ItemsTLP);
            ItemsBackPanel.Dock = DockStyle.Fill;
            ItemsBackPanel.Location = new Point(3, 3);
            ItemsBackPanel.Name = "ItemsBackPanel";
            ItemsBackPanel.Size = new Size(794, 444);
            ItemsBackPanel.TabIndex = 0;
            // 
            // ItemsTLP
            // 
            ItemsTLP.ColumnCount = 3;
            ItemsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ItemsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ItemsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ItemsTLP.Controls.Add(BuyLootboxButton, 0, 0);
            ItemsTLP.Controls.Add(BuyRarityBoostButton, 1, 0);
            ItemsTLP.Controls.Add(BuyExperienceBoostButton, 0, 1);
            ItemsTLP.Controls.Add(BuyRushBoostButton, 1, 1);
            ItemsTLP.Controls.Add(ResourcesTLP, 2, 0);
            ItemsTLP.Dock = DockStyle.Fill;
            ItemsTLP.Location = new Point(0, 0);
            ItemsTLP.Name = "ItemsTLP";
            ItemsTLP.RowCount = 2;
            ItemsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ItemsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ItemsTLP.Size = new Size(794, 444);
            ItemsTLP.TabIndex = 0;
            // 
            // BuyLootboxButton
            // 
            BuyLootboxButton.Dock = DockStyle.Fill;
            BuyLootboxButton.FlatAppearance.BorderSize = 2;
            BuyLootboxButton.FlatStyle = FlatStyle.Flat;
            BuyLootboxButton.Location = new Point(10, 10);
            BuyLootboxButton.Margin = new Padding(10);
            BuyLootboxButton.Name = "BuyLootboxButton";
            BuyLootboxButton.Size = new Size(244, 202);
            BuyLootboxButton.TabIndex = 0;
            BuyLootboxButton.Text = "BuyLootboxButton";
            BuyLootboxButton.UseVisualStyleBackColor = true;
            BuyLootboxButton.Click += BuyLootboxButton_Click;
            // 
            // BuyRarityBoostButton
            // 
            BuyRarityBoostButton.Dock = DockStyle.Fill;
            BuyRarityBoostButton.FlatAppearance.BorderSize = 2;
            BuyRarityBoostButton.FlatStyle = FlatStyle.Flat;
            BuyRarityBoostButton.Location = new Point(274, 10);
            BuyRarityBoostButton.Margin = new Padding(10);
            BuyRarityBoostButton.Name = "BuyRarityBoostButton";
            BuyRarityBoostButton.Size = new Size(244, 202);
            BuyRarityBoostButton.TabIndex = 1;
            BuyRarityBoostButton.Text = "BuyRarityBoostButton";
            BuyRarityBoostButton.UseVisualStyleBackColor = true;
            BuyRarityBoostButton.Click += BuyRarityBoostButton_Click;
            // 
            // BuyExperienceBoostButton
            // 
            BuyExperienceBoostButton.Dock = DockStyle.Fill;
            BuyExperienceBoostButton.FlatAppearance.BorderSize = 2;
            BuyExperienceBoostButton.FlatStyle = FlatStyle.Flat;
            BuyExperienceBoostButton.Location = new Point(10, 232);
            BuyExperienceBoostButton.Margin = new Padding(10);
            BuyExperienceBoostButton.Name = "BuyExperienceBoostButton";
            BuyExperienceBoostButton.Size = new Size(244, 202);
            BuyExperienceBoostButton.TabIndex = 2;
            BuyExperienceBoostButton.Text = "BuyExperienceBoostButton";
            BuyExperienceBoostButton.UseVisualStyleBackColor = true;
            BuyExperienceBoostButton.Click += BuyExperienceBoostButton_Click;
            // 
            // BuyRushBoostButton
            // 
            BuyRushBoostButton.Dock = DockStyle.Fill;
            BuyRushBoostButton.FlatAppearance.BorderSize = 2;
            BuyRushBoostButton.FlatStyle = FlatStyle.Flat;
            BuyRushBoostButton.Location = new Point(274, 232);
            BuyRushBoostButton.Margin = new Padding(10);
            BuyRushBoostButton.Name = "BuyRushBoostButton";
            BuyRushBoostButton.Size = new Size(244, 202);
            BuyRushBoostButton.TabIndex = 3;
            BuyRushBoostButton.Text = "BuyRushBoostButton";
            BuyRushBoostButton.UseVisualStyleBackColor = true;
            BuyRushBoostButton.Click += BuyRushBoostButton_Click;
            // 
            // ResourcesTLP
            // 
            ResourcesTLP.ColumnCount = 2;
            ResourcesTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ResourcesTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ResourcesTLP.Controls.Add(BuyConcreteButton, 0, 0);
            ResourcesTLP.Controls.Add(BuyMetalButton, 1, 0);
            ResourcesTLP.Controls.Add(BuyWaterButton, 0, 1);
            ResourcesTLP.Controls.Add(BuyFoodButton, 1, 1);
            ResourcesTLP.Dock = DockStyle.Fill;
            ResourcesTLP.Location = new Point(538, 10);
            ResourcesTLP.Margin = new Padding(10);
            ResourcesTLP.Name = "ResourcesTLP";
            ResourcesTLP.RowCount = 2;
            ResourcesTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ResourcesTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            ResourcesTLP.Size = new Size(246, 202);
            ResourcesTLP.TabIndex = 4;
            // 
            // BuyConcreteButton
            // 
            BuyConcreteButton.Dock = DockStyle.Fill;
            BuyConcreteButton.FlatAppearance.BorderSize = 2;
            BuyConcreteButton.FlatStyle = FlatStyle.Flat;
            BuyConcreteButton.Location = new Point(10, 10);
            BuyConcreteButton.Margin = new Padding(10);
            BuyConcreteButton.Name = "BuyConcreteButton";
            BuyConcreteButton.Size = new Size(103, 81);
            BuyConcreteButton.TabIndex = 0;
            BuyConcreteButton.Text = "BuyConcreteButton";
            BuyConcreteButton.UseVisualStyleBackColor = true;
            BuyConcreteButton.Click += BuyConcreteButton_Click;
            // 
            // BuyMetalButton
            // 
            BuyMetalButton.Dock = DockStyle.Fill;
            BuyMetalButton.FlatAppearance.BorderSize = 2;
            BuyMetalButton.FlatStyle = FlatStyle.Flat;
            BuyMetalButton.Location = new Point(133, 10);
            BuyMetalButton.Margin = new Padding(10);
            BuyMetalButton.Name = "BuyMetalButton";
            BuyMetalButton.Size = new Size(103, 81);
            BuyMetalButton.TabIndex = 1;
            BuyMetalButton.Text = "BuyMetalButton";
            BuyMetalButton.UseVisualStyleBackColor = true;
            BuyMetalButton.Click += BuyMetalButton_Click;
            // 
            // BuyWaterButton
            // 
            BuyWaterButton.Dock = DockStyle.Fill;
            BuyWaterButton.FlatAppearance.BorderSize = 2;
            BuyWaterButton.FlatStyle = FlatStyle.Flat;
            BuyWaterButton.Location = new Point(10, 111);
            BuyWaterButton.Margin = new Padding(10);
            BuyWaterButton.Name = "BuyWaterButton";
            BuyWaterButton.Size = new Size(103, 81);
            BuyWaterButton.TabIndex = 2;
            BuyWaterButton.Text = "BuyWaterButton";
            BuyWaterButton.UseVisualStyleBackColor = true;
            BuyWaterButton.Click += BuyWaterButton_Click;
            // 
            // BuyFoodButton
            // 
            BuyFoodButton.Dock = DockStyle.Fill;
            BuyFoodButton.FlatAppearance.BorderSize = 2;
            BuyFoodButton.FlatStyle = FlatStyle.Flat;
            BuyFoodButton.Location = new Point(133, 111);
            BuyFoodButton.Margin = new Padding(10);
            BuyFoodButton.Name = "BuyFoodButton";
            BuyFoodButton.Size = new Size(103, 81);
            BuyFoodButton.TabIndex = 3;
            BuyFoodButton.Text = "BuyFoodButton";
            BuyFoodButton.UseVisualStyleBackColor = true;
            BuyFoodButton.Click += BuyFoodButton_Click;
            // 
            // ItemShopForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ItemShopTLP);
            Name = "ItemShopForm";
            Text = "ItemShopForm";
            FormClosing += ItemShopForm_FormClosing;
            ItemShopTLP.ResumeLayout(false);
            ItemsBackPanel.ResumeLayout(false);
            ItemsTLP.ResumeLayout(false);
            ResourcesTLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel ItemShopTLP;
        private Panel ItemsBackPanel;
        private TableLayoutPanel ItemsTLP;
        private Button BuyLootboxButton;
        private Button BuyRarityBoostButton;
        private Button BuyExperienceBoostButton;
        private Button BuyRushBoostButton;
        private TableLayoutPanel ResourcesTLP;
        private Button BuyConcreteButton;
        private Button BuyMetalButton;
        private Button BuyWaterButton;
        private Button BuyFoodButton;
    }
}