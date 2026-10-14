using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Factories;
using Game_Elements.Services;
using System.ComponentModel;

namespace Game_Elements.Models
{
    public class EggHatcher : INotifyPropertyChanged
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        private bool _full = false;
        public bool Full
        {
            get => _full;
            set
            {
                if (_full != value)
                {
                    _full = value;
                    OnPropertyChanged(nameof(Full));
                }
            }
        }

        public TimeSpan Duration { get; set; }

        private TimeSpan _elapsed = TimeSpan.Zero;
        public TimeSpan Elapsed
        {
            get => _elapsed;
            set
            {
                if (_elapsed != value)
                {
                    _elapsed = value;
                    OnPropertyChanged(nameof(Elapsed));
                }
            }
        }
        public bool IsDone => Elapsed >= Duration;

        public void Tick(int playerIndex, TimeSpan timeSpan)
        {
            if (!Full) return;

            Elapsed += timeSpan;

            if (IsDone)
            {
                // Update relevant properties so hatcher is ready for reuse
                Full = false;
                Elapsed = TimeSpan.Zero;

                // Output if current player
                if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                {
                    OutputService.Write(true, [new("Monster egg hatched!", Properties.Settings.Default.PrimaryForeColor, true, false, false)]);
                }

                // Add random monster unit
                Inventory.Add(playerIndex, new Loot() { Units = [UnitFactory.GenerateRandomMonsterUnit(playerIndex)] });

                // Update quests and statistics
                GameManager.TryQuestProgress(playerIndex, QuestType.HatchEgg, 1);
                GameManager.Players[playerIndex].Statistics.EggsHatched += 1;
            }
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}