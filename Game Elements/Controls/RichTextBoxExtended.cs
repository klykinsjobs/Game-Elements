namespace Game_Elements
{
    public partial class RichTextBoxExtended : RichTextBox
    {
        // Windows messages that indicate scrolling actions
        private const int WM_VSCROLL = 0x115;
        private const int WM_HSCROLL = 0x114;
        private const int WM_MOUSEWHEEL = 0x20A;

        // Intercepts windows messages sent to the control
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // If the message corresponds to any scroll action, raise the Scrolled event
            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                OnScrolled(EventArgs.Empty);
            }
        }

        // Event raised whenever the control is scrolled
        public event EventHandler? Scrolled;

        // Helper method to trigger the Scrolled event
        protected virtual void OnScrolled(EventArgs e) => Scrolled?.Invoke(this, e);
    }
}