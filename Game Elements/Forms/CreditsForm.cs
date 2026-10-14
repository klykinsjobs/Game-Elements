namespace Game_Elements
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();

            // Initialize UI (properties, generated background image, etc)
            InitializeUI();
        }

        private void CreditsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose generated image
            CreditTLP.BackgroundImage?.Dispose();
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, generated background image, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            CreditsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            CreditBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            CreditBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            CreditTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            CreditTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            TitleLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            TitleLabel.Font = new Font(TitleLabel.Font.FontFamily, Properties.Settings.Default.LargeFontSize);

            CreatedByLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            CreatedByLabel.Font = new Font(CreatedByLabel.Font.FontFamily, Properties.Settings.Default.LargeFontSize);

            // Create a bitmap matching the TLP size
            var bmp = new Bitmap(CreditTLP.Width, CreditTLP.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Fill the entire bitmap with the primary back color
                using SolidBrush b = new(Properties.Settings.Default.PrimaryBackColor);
                g.FillRectangle(b, new Rectangle(0, 0, bmp.Width, bmp.Height));
            }

            // Add tiny amount of noise to the bitmap
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (Random.Shared.NextDouble() < 0.0005)
                        bmp.SetPixel(x, y, Color.FromArgb(Random.Shared.Next(0, 255), Random.Shared.Next(0, 255), Random.Shared.Next(0, 255)));
                }
            }

            // Apply the generated bitmap as the TLP's background image
            CreditTLP.BackgroundImage = bmp;
        }
    }
}