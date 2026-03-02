namespace Game_Elements
{
    partial class CustomizeDialog
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
            CustomizeDialogTLP = new TableLayoutPanel();
            CustomizeLabel = new Label();
            MissionNamesLabel = new Label();
            UnitNamesLabel = new Label();
            MonsterUnitNamesLabel = new Label();
            ItemNamesLabel = new Label();
            JunkItemNamesLabel = new Label();
            PlantItemNamesLabel = new Label();
            MissionNamesTextBox = new TextBox();
            UnitNamesTextBox = new TextBox();
            MonsterUnitNamesTextBox = new TextBox();
            ItemNamesTextBox = new TextBox();
            JunkItemNamesTextBox = new TextBox();
            PlantItemNamesTextBox = new TextBox();
            OkButton = new Button();
            CancelCustomizeButton = new Button();
            CustomizeDialogTLP.SuspendLayout();
            SuspendLayout();
            // 
            // CustomizeDialogTLP
            // 
            CustomizeDialogTLP.ColumnCount = 2;
            CustomizeDialogTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            CustomizeDialogTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            CustomizeDialogTLP.Controls.Add(CustomizeLabel, 0, 0);
            CustomizeDialogTLP.Controls.Add(MissionNamesLabel, 0, 1);
            CustomizeDialogTLP.Controls.Add(UnitNamesLabel, 0, 2);
            CustomizeDialogTLP.Controls.Add(MonsterUnitNamesLabel, 0, 3);
            CustomizeDialogTLP.Controls.Add(ItemNamesLabel, 0, 4);
            CustomizeDialogTLP.Controls.Add(JunkItemNamesLabel, 0, 5);
            CustomizeDialogTLP.Controls.Add(PlantItemNamesLabel, 0, 6);
            CustomizeDialogTLP.Controls.Add(MissionNamesTextBox, 1, 1);
            CustomizeDialogTLP.Controls.Add(UnitNamesTextBox, 1, 2);
            CustomizeDialogTLP.Controls.Add(MonsterUnitNamesTextBox, 1, 3);
            CustomizeDialogTLP.Controls.Add(ItemNamesTextBox, 1, 4);
            CustomizeDialogTLP.Controls.Add(JunkItemNamesTextBox, 1, 5);
            CustomizeDialogTLP.Controls.Add(PlantItemNamesTextBox, 1, 6);
            CustomizeDialogTLP.Controls.Add(OkButton, 0, 7);
            CustomizeDialogTLP.Controls.Add(CancelCustomizeButton, 0, 8);
            CustomizeDialogTLP.Dock = DockStyle.Fill;
            CustomizeDialogTLP.Location = new Point(0, 0);
            CustomizeDialogTLP.Name = "CustomizeDialogTLP";
            CustomizeDialogTLP.RowCount = 9;
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111116F));
            CustomizeDialogTLP.Size = new Size(800, 450);
            CustomizeDialogTLP.TabIndex = 0;
            // 
            // CustomizeLabel
            // 
            CustomizeLabel.AutoSize = true;
            CustomizeDialogTLP.SetColumnSpan(CustomizeLabel, 2);
            CustomizeLabel.Dock = DockStyle.Fill;
            CustomizeLabel.Location = new Point(3, 0);
            CustomizeLabel.Name = "CustomizeLabel";
            CustomizeLabel.Size = new Size(794, 49);
            CustomizeLabel.TabIndex = 0;
            CustomizeLabel.Text = "Customize strings for this player slot";
            CustomizeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MissionNamesLabel
            // 
            MissionNamesLabel.AutoSize = true;
            MissionNamesLabel.Dock = DockStyle.Fill;
            MissionNamesLabel.Location = new Point(3, 49);
            MissionNamesLabel.Name = "MissionNamesLabel";
            MissionNamesLabel.Size = new Size(394, 49);
            MissionNamesLabel.TabIndex = 1;
            MissionNamesLabel.Text = "Mission Names:";
            MissionNamesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UnitNamesLabel
            // 
            UnitNamesLabel.AutoSize = true;
            UnitNamesLabel.Dock = DockStyle.Fill;
            UnitNamesLabel.Location = new Point(3, 98);
            UnitNamesLabel.Name = "UnitNamesLabel";
            UnitNamesLabel.Size = new Size(394, 49);
            UnitNamesLabel.TabIndex = 2;
            UnitNamesLabel.Text = "Unit Names:";
            UnitNamesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MonsterUnitNamesLabel
            // 
            MonsterUnitNamesLabel.AutoSize = true;
            MonsterUnitNamesLabel.Dock = DockStyle.Fill;
            MonsterUnitNamesLabel.Location = new Point(3, 147);
            MonsterUnitNamesLabel.Name = "MonsterUnitNamesLabel";
            MonsterUnitNamesLabel.Size = new Size(394, 49);
            MonsterUnitNamesLabel.TabIndex = 3;
            MonsterUnitNamesLabel.Text = "Monster Unit Names:";
            MonsterUnitNamesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ItemNamesLabel
            // 
            ItemNamesLabel.AutoSize = true;
            ItemNamesLabel.Dock = DockStyle.Fill;
            ItemNamesLabel.Location = new Point(3, 196);
            ItemNamesLabel.Name = "ItemNamesLabel";
            ItemNamesLabel.Size = new Size(394, 49);
            ItemNamesLabel.TabIndex = 4;
            ItemNamesLabel.Text = "Item Names:";
            ItemNamesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // JunkItemNamesLabel
            // 
            JunkItemNamesLabel.AutoSize = true;
            JunkItemNamesLabel.Dock = DockStyle.Fill;
            JunkItemNamesLabel.Location = new Point(3, 245);
            JunkItemNamesLabel.Name = "JunkItemNamesLabel";
            JunkItemNamesLabel.Size = new Size(394, 49);
            JunkItemNamesLabel.TabIndex = 5;
            JunkItemNamesLabel.Text = "Junk Item Names:";
            JunkItemNamesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlantItemNamesLabel
            // 
            PlantItemNamesLabel.AutoSize = true;
            PlantItemNamesLabel.Dock = DockStyle.Fill;
            PlantItemNamesLabel.Location = new Point(3, 294);
            PlantItemNamesLabel.Name = "PlantItemNamesLabel";
            PlantItemNamesLabel.Size = new Size(394, 49);
            PlantItemNamesLabel.TabIndex = 6;
            PlantItemNamesLabel.Text = "Plant Item Names:";
            PlantItemNamesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MissionNamesTextBox
            // 
            MissionNamesTextBox.Dock = DockStyle.Fill;
            MissionNamesTextBox.Location = new Point(403, 52);
            MissionNamesTextBox.Multiline = true;
            MissionNamesTextBox.Name = "MissionNamesTextBox";
            MissionNamesTextBox.ScrollBars = ScrollBars.Both;
            MissionNamesTextBox.Size = new Size(394, 43);
            MissionNamesTextBox.TabIndex = 8;
            // 
            // UnitNamesTextBox
            // 
            UnitNamesTextBox.Dock = DockStyle.Fill;
            UnitNamesTextBox.Location = new Point(403, 101);
            UnitNamesTextBox.Multiline = true;
            UnitNamesTextBox.Name = "UnitNamesTextBox";
            UnitNamesTextBox.ScrollBars = ScrollBars.Both;
            UnitNamesTextBox.Size = new Size(394, 43);
            UnitNamesTextBox.TabIndex = 9;
            // 
            // MonsterUnitNamesTextBox
            // 
            MonsterUnitNamesTextBox.Dock = DockStyle.Fill;
            MonsterUnitNamesTextBox.Location = new Point(403, 150);
            MonsterUnitNamesTextBox.Multiline = true;
            MonsterUnitNamesTextBox.Name = "MonsterUnitNamesTextBox";
            MonsterUnitNamesTextBox.ScrollBars = ScrollBars.Both;
            MonsterUnitNamesTextBox.Size = new Size(394, 43);
            MonsterUnitNamesTextBox.TabIndex = 10;
            // 
            // ItemNamesTextBox
            // 
            ItemNamesTextBox.Dock = DockStyle.Fill;
            ItemNamesTextBox.Location = new Point(403, 199);
            ItemNamesTextBox.Multiline = true;
            ItemNamesTextBox.Name = "ItemNamesTextBox";
            ItemNamesTextBox.ScrollBars = ScrollBars.Both;
            ItemNamesTextBox.Size = new Size(394, 43);
            ItemNamesTextBox.TabIndex = 11;
            // 
            // JunkItemNamesTextBox
            // 
            JunkItemNamesTextBox.Dock = DockStyle.Fill;
            JunkItemNamesTextBox.Location = new Point(403, 248);
            JunkItemNamesTextBox.Multiline = true;
            JunkItemNamesTextBox.Name = "JunkItemNamesTextBox";
            JunkItemNamesTextBox.ScrollBars = ScrollBars.Both;
            JunkItemNamesTextBox.Size = new Size(394, 43);
            JunkItemNamesTextBox.TabIndex = 12;
            // 
            // PlantItemNamesTextBox
            // 
            PlantItemNamesTextBox.Dock = DockStyle.Fill;
            PlantItemNamesTextBox.Location = new Point(403, 297);
            PlantItemNamesTextBox.Multiline = true;
            PlantItemNamesTextBox.Name = "PlantItemNamesTextBox";
            PlantItemNamesTextBox.ScrollBars = ScrollBars.Both;
            PlantItemNamesTextBox.Size = new Size(394, 43);
            PlantItemNamesTextBox.TabIndex = 13;
            // 
            // OkButton
            // 
            CustomizeDialogTLP.SetColumnSpan(OkButton, 2);
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Dock = DockStyle.Fill;
            OkButton.FlatStyle = FlatStyle.Flat;
            OkButton.Location = new Point(3, 346);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(794, 43);
            OkButton.TabIndex = 14;
            OkButton.Text = "Ok";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelCustomizeButton
            // 
            CustomizeDialogTLP.SetColumnSpan(CancelCustomizeButton, 2);
            CancelCustomizeButton.DialogResult = DialogResult.Cancel;
            CancelCustomizeButton.Dock = DockStyle.Fill;
            CancelCustomizeButton.FlatStyle = FlatStyle.Flat;
            CancelCustomizeButton.Location = new Point(3, 395);
            CancelCustomizeButton.Name = "CancelCustomizeButton";
            CancelCustomizeButton.Size = new Size(794, 52);
            CancelCustomizeButton.TabIndex = 7;
            CancelCustomizeButton.Text = "Cancel";
            CancelCustomizeButton.UseVisualStyleBackColor = true;
            // 
            // CustomizeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CustomizeDialogTLP);
            Name = "CustomizeDialog";
            Text = "Customize";
            CustomizeDialogTLP.ResumeLayout(false);
            CustomizeDialogTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel CustomizeDialogTLP;
        private Label CustomizeLabel;
        private Label MissionNamesLabel;
        private Label UnitNamesLabel;
        private Label MonsterUnitNamesLabel;
        private Label ItemNamesLabel;
        private Label JunkItemNamesLabel;
        private Label PlantItemNamesLabel;
        private TextBox MissionNamesTextBox;
        private TextBox UnitNamesTextBox;
        private TextBox MonsterUnitNamesTextBox;
        private TextBox ItemNamesTextBox;
        private TextBox JunkItemNamesTextBox;
        private TextBox PlantItemNamesTextBox;
        private Button OkButton;
        private Button CancelCustomizeButton;
    }
}