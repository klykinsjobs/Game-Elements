using Game_Elements.Enums;
using System.ComponentModel;

namespace Game_Elements.Models
{
    public class Modifier : INotifyPropertyChanged
    {
        public ModifierTarget ModifierTarget { get; set; }
        public ModifierType ModifierType { get; set; }
        public double ModifierAmount { get; set; }
        public ModifierSource ModifierSource { get; set; }

        private int _modifierQuantity;
        public int ModifierQuantity
        {
            get => _modifierQuantity;
            set
            {
                if (_modifierQuantity != value)
                {
                    _modifierQuantity = value;
                    OnPropertyChanged(nameof(ModifierQuantity));
                }
            }
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}