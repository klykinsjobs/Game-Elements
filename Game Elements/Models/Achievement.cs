using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Services;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Game_Elements.Models
{
    public class Achievement : INotifyPropertyChanged
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Loot? Loots { get; set; }
        public Modifier? Modifier { get; set; }

        [JsonIgnore]
        public Func<bool>? UnlockCondition { get; set; }

        private bool _unlocked;
        public bool Unlocked
        {
            get => _unlocked;
            set
            {
                if (_unlocked != value)
                {
                    _unlocked = value;
                    OnPropertyChanged(nameof(Unlocked));
                }
            }
        }
        public DateTime UnlockedTime { get; set; }

        private bool _seen;
        public bool Seen
        {
            get => _seen;
            set
            {
                if (_seen != value)
                {
                    _seen = value;
                    OnPropertyChanged(nameof(Seen));
                }
            }
        }

        public void Tick(int playerIndex)
        {
            if (Unlocked) return;

            if (UnlockCondition != null && UnlockCondition())
            {
                // Output if current player
                if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                {
                    OutputService.Write(true,
                        [
                        new("Achievement: ", Properties.Settings.Default.PrimaryForeColor, true, false, false),
                        new($"{Title}", Properties.Settings.Default.PrimaryForeColor, false, true, false)
                        ]);
                }

                // Add loot
                if (Loots != null)
                    Inventory.Add(playerIndex, Loots);

                // Add modifier
                if (Modifier != null)
                    GameManager.Players[playerIndex].Modifiers.Add(Modifier);

                // Update quests and statistics
                GameManager.TryQuestProgress(playerIndex, QuestType.UnlockAchievement, 1);
                GameManager.Players[playerIndex].Statistics.AchievementsUnlocked += 1;

                // Update relevant unlock properties
                UnlockedTime = DateTime.Now;
                Unlocked = true;
            }
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}