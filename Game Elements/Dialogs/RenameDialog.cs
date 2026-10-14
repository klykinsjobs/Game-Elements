namespace Game_Elements
{
    public partial class RenameDialog : Form
    {
        public string NewNameText => NewNameTextBox.Text;

        public RenameDialog()
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            RenameDialogTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;
            RenameDialogTLP.Padding = new Padding(Properties.Settings.Default.Padding);

            RenameLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RenameLabel.Font = new Font(RenameLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            NewNameTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            NewNameTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            NewNameTextBox.Font = new Font(NewNameTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            OkButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            OkButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            OkButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            OkButton.Font = new Font(OkButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            CancelRenameButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            CancelRenameButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            CancelRenameButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            CancelRenameButton.Font = new Font(CancelRenameButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
        }
    }
}