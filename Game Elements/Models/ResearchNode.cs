using System.ComponentModel;

namespace Game_Elements.Models
{
    public class ResearchNode : INotifyPropertyChanged
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Prerequisites { get; set; } = [];

        public int Target { get; set; }
        public int Progress { get; set; }

        private bool _researched;
        public bool Researched
        {
            get => _researched;
            set
            {
                if (_researched != value)
                {
                    _researched = value;
                    OnPropertyChanged(nameof(Researched));
                }
            }
        }

        public Modifier Modifier { get; set; } = new();

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}