namespace Game_Elements
{
    partial class RenameDialog
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
            RenameDialogTLP = new TableLayoutPanel();
            RenameLabel = new Label();
            NewNameTextBox = new TextBox();
            OkButton = new Button();
            CancelRenameButton = new Button();
            RenameDialogTLP.SuspendLayout();
            SuspendLayout();
            // 
            // RenameDialogTLP
            // 
            RenameDialogTLP.ColumnCount = 1;
            RenameDialogTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            RenameDialogTLP.Controls.Add(RenameLabel, 0, 0);
            RenameDialogTLP.Controls.Add(NewNameTextBox, 0, 1);
            RenameDialogTLP.Controls.Add(OkButton, 0, 2);
            RenameDialogTLP.Controls.Add(CancelRenameButton, 0, 3);
            RenameDialogTLP.Dock = DockStyle.Fill;
            RenameDialogTLP.Location = new Point(0, 0);
            RenameDialogTLP.Name = "RenameDialogTLP";
            RenameDialogTLP.RowCount = 4;
            RenameDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            RenameDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            RenameDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            RenameDialogTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            RenameDialogTLP.Size = new Size(284, 161);
            RenameDialogTLP.TabIndex = 0;
            // 
            // RenameLabel
            // 
            RenameLabel.AutoSize = true;
            RenameLabel.Dock = DockStyle.Fill;
            RenameLabel.Location = new Point(3, 0);
            RenameLabel.Name = "RenameLabel";
            RenameLabel.Size = new Size(278, 40);
            RenameLabel.TabIndex = 0;
            RenameLabel.Text = "Enter New Name:";
            RenameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewNameTextBox
            // 
            NewNameTextBox.Dock = DockStyle.Fill;
            NewNameTextBox.Location = new Point(3, 43);
            NewNameTextBox.Name = "NewNameTextBox";
            NewNameTextBox.Size = new Size(278, 23);
            NewNameTextBox.TabIndex = 1;
            // 
            // OkButton
            // 
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Dock = DockStyle.Fill;
            OkButton.FlatStyle = FlatStyle.Flat;
            OkButton.Location = new Point(3, 83);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(278, 34);
            OkButton.TabIndex = 2;
            OkButton.Text = "Ok";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelRenameButton
            // 
            CancelRenameButton.DialogResult = DialogResult.Cancel;
            CancelRenameButton.Dock = DockStyle.Fill;
            CancelRenameButton.FlatStyle = FlatStyle.Flat;
            CancelRenameButton.Location = new Point(3, 123);
            CancelRenameButton.Name = "CancelRenameButton";
            CancelRenameButton.Size = new Size(278, 35);
            CancelRenameButton.TabIndex = 3;
            CancelRenameButton.Text = "Cancel";
            CancelRenameButton.UseVisualStyleBackColor = true;
            // 
            // RenameDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 161);
            Controls.Add(RenameDialogTLP);
            Name = "RenameDialog";
            Text = "Rename";
            RenameDialogTLP.ResumeLayout(false);
            RenameDialogTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel RenameDialogTLP;
        private Label RenameLabel;
        private TextBox NewNameTextBox;
        private Button OkButton;
        private Button CancelRenameButton;
    }
}