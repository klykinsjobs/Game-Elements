using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Factories;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace Game_Elements
{
    public partial class LootboxForm : Form
    {
        private readonly Timer _colorTransitionTimer;
        private readonly List<ColorTransition> _transitions = [];
        private readonly Dictionary<Rarity, Color> _rarityColors;
        private const int TransitionSteps = 20;
        private const int TimerIntervalMs = 30;

        public LootboxForm()
        {
            InitializeComponent();

            // Initialize dictionary
            _rarityColors = new Dictionary<Rarity, Color>
            {
                { Rarity.Common, Properties.Settings.Default.CommonRarityColor },
                { Rarity.Rare, Properties.Settings.Default.RareRarityColor },
                { Rarity.Epic, Properties.Settings.Default.EpicRarityColor },
                { Rarity.Legendary, Properties.Settings.Default.LegendaryRarityColor },
            };

            // Configure the timer
            _colorTransitionTimer = new Timer { Interval = TimerIntervalMs };
            _colorTransitionTimer.Tick += ColorTransitionTimer_Tick;

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
            }

            // Update UI elements for current player
            UpdateUI();
        }

        private void LootboxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop and dispose timer
            _colorTransitionTimer.Stop();
            _colorTransitionTimer.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
            }
        }

        private void GameManager_CurrentPlayerChanged(Player? previousPlayer)
        {
            // Ensure event runs on UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => GameManager_CurrentPlayerChanged(previousPlayer)));
                return;
            }

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Inventory.PropertyChanged -= Inventory_PropertyChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Inventory.PropertyChanged += Inventory_PropertyChanged;
            }

            // Update UI elements for new player
            UpdateUI();
        }

        private void Inventory_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Only refresh the UI element that needs refreshing

            if (e.PropertyName == nameof(Inventory.Lootboxes))
            {
                OpenLootboxButton.Enabled = GameManager.CurrentPlayer.Inventory.Lootboxes > 0;
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            LootboxTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            FirstLootboxRewardPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            FirstLootboxRewardPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            SecondLootboxRewardPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            SecondLootboxRewardPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ThirdLootboxRewardPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ThirdLootboxRewardPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            FourthLootboxRewardPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            FourthLootboxRewardPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            FirstLootboxRewardButton.BackColor = Properties.Settings.Default.PrimaryBackColor;
            FirstLootboxRewardButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FirstLootboxRewardButton.Font = new Font(FirstLootboxRewardButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            SecondLootboxRewardButton.BackColor = Properties.Settings.Default.PrimaryBackColor;
            SecondLootboxRewardButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SecondLootboxRewardButton.Font = new Font(SecondLootboxRewardButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ThirdLootboxRewardButton.BackColor = Properties.Settings.Default.PrimaryBackColor;
            ThirdLootboxRewardButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ThirdLootboxRewardButton.Font = new Font(ThirdLootboxRewardButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            FourthLootboxRewardButton.BackColor = Properties.Settings.Default.PrimaryBackColor;
            FourthLootboxRewardButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FourthLootboxRewardButton.Font = new Font(FourthLootboxRewardButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            OpenLootboxButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            OpenLootboxButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            OpenLootboxButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            OpenLootboxButton.Font = new Font(OpenLootboxButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            OpenLootboxButton.Enabled = GameManager.CurrentPlayer.Inventory.Lootboxes > 0;

            // If a lootbox has been opened, reset the controls back to their starting appearance
            if (FirstLootboxRewardButton.Text != "")
            {
                // Buttons
                FirstLootboxRewardButton.Text = "";
                FirstLootboxRewardButton.FlatAppearance.MouseOverBackColor = Color.Empty;
                SecondLootboxRewardButton.Text = "";
                SecondLootboxRewardButton.FlatAppearance.MouseOverBackColor = Color.Empty;
                ThirdLootboxRewardButton.Text = "";
                ThirdLootboxRewardButton.FlatAppearance.MouseOverBackColor = Color.Empty;
                FourthLootboxRewardButton.Text = "";
                FourthLootboxRewardButton.FlatAppearance.MouseOverBackColor = Color.Empty;

                // Panels
                StartColorTransition(FirstLootboxRewardPanel, Properties.Settings.Default.SecondaryBackColor);
                StartColorTransition(SecondLootboxRewardPanel, Properties.Settings.Default.SecondaryBackColor);
                StartColorTransition(ThirdLootboxRewardPanel, Properties.Settings.Default.SecondaryBackColor);
                StartColorTransition(FourthLootboxRewardPanel, Properties.Settings.Default.SecondaryBackColor);

                // Start color transition timer to animate panels
                _colorTransitionTimer.Start();
            }
        }

        private void StartColorTransition(Panel panel, Color targetColor)
        {
            // If the panel is already the desired color, then no transition needed
            if (panel.BackColor == targetColor)
                return;

            // Remove any existing transitions for this panel
            _transitions.RemoveAll(t => t.Panel == panel);

            // Add a new transition entry starting from the current color
            _transitions.Add(new ColorTransition
            {
                Panel = panel,
                StartColor = panel.BackColor,
                TargetColor = targetColor,
                CurrentStep = 0,
                TotalSteps = TransitionSteps
            });
        }

        private void ColorTransitionTimer_Tick(object? sender, EventArgs e)
        {
            // Iterate backwards and remove finished transitions
            for (int i = _transitions.Count - 1; i >= 0; i--)
            {
                var t = _transitions[i];
                t.CurrentStep++;

                // Calculate interpolation ratio
                float ratio = t.CurrentStep / (float)t.TotalSteps;

                // Linearly interpolate each RGB component
                int r = (int)(t.StartColor.R + (t.TargetColor.R - t.StartColor.R) * ratio);
                int g = (int)(t.StartColor.G + (t.TargetColor.G - t.StartColor.G) * ratio);
                int b = (int)(t.StartColor.B + (t.TargetColor.B - t.StartColor.B) * ratio);

                // Apply the new color to the panel
                if (t.Panel != null)
                {
                    t.Panel.BackColor = Color.FromArgb(r, g, b);
                }

                // If transition is complete, remove it
                if (t.CurrentStep >= t.TotalSteps)
                {
                    _transitions.RemoveAt(i);
                }
            }

            // Stop the timer if no transitions remain
            if (_transitions.Count == 0)
                _colorTransitionTimer.Stop();
        }

        private void OpenLootboxButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            if (GameManager.CurrentPlayer.Inventory.Lootboxes < 1)
            {
                OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("You don't have any Lootboxes.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.Lootbox, 1);

                // Remove lootbox
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    // Set MouseOverBackColor when the first Lootbox is opened
                    if (FirstLootboxRewardButton.FlatAppearance.MouseDownBackColor.IsEmpty)
                    {
                        FirstLootboxRewardButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                        SecondLootboxRewardButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                        ThirdLootboxRewardButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                        FourthLootboxRewardButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                    }

                    // Each lootbox has four items
                    Button[] rewardButtons = [FirstLootboxRewardButton, SecondLootboxRewardButton, ThirdLootboxRewardButton, FourthLootboxRewardButton];
                    Panel[] rewardPanels = [FirstLootboxRewardPanel, SecondLootboxRewardPanel, ThirdLootboxRewardPanel, FourthLootboxRewardPanel];

                    // Fill loot
                    Loot lootToAdd = new();
                    for (int i = 0; i < rewardButtons.Length; i++)
                    {
                        int roll = Random.Shared.Next(0, 100);
                        Button button = rewardButtons[i];
                        Panel panel = rewardPanels[i];

                        if (roll < 5)
                        {
                            var unit = UnitFactory.GenerateRandomUnit(playerIndex);
                            lootToAdd.Units.Add(unit);

                            // Update button text
                            button.Text = $"{unit.Name} ({unit.Rarity})";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(unit.Rarity, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 10)
                        {
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.RarityBoost, 1))
                                lootToAdd.LootQuantities[LootType.RarityBoost] += 1;

                            // Update button text
                            button.Text = "Rarity Boost";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Epic, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 20)
                        {
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.ExperienceBoost, 1))
                                lootToAdd.LootQuantities[LootType.ExperienceBoost] += 1;

                            // Update button text
                            button.Text = "Experience Boost";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Rare, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 30)
                        {
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.RushBoost, 1))
                                lootToAdd.LootQuantities[LootType.RushBoost] += 1;

                            // Update button text
                            button.Text = "Rush Boost";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Common, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 50)
                        {
                            var item = ItemFactory.GenerateRandomItem(playerIndex);
                            lootToAdd.Items.Add(item);

                            // Update button text
                            button.Text = $"{item.Name}";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(item.Rarity, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 55)
                        {
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.Metal, 1))
                                lootToAdd.LootQuantities[LootType.Metal] += 1;

                            // Update button text
                            button.Text = "Metal";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Common, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 60)
                        {
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.Concrete, 1))
                                lootToAdd.LootQuantities[LootType.Concrete] += 1;

                            // Update button text
                            button.Text = "Concrete";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Common, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 70)
                        {
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.Food, 1))
                                lootToAdd.LootQuantities[LootType.Food] += 1;

                            // Update button text
                            button.Text = "Food";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Common, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else if (roll < 80)
                        {
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.Water, 1))
                                lootToAdd.LootQuantities[LootType.Water] += 1;

                            // Update button text
                            button.Text = "Water";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Common, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                        else
                        {
                            int quantity = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.LootboxGoldAmount, Random.Shared.Next(99, 1000));
                            if (!lootToAdd.LootQuantities.TryAdd(LootType.Gold, quantity))
                                lootToAdd.LootQuantities[LootType.Gold] += quantity;

                            // Update button text
                            button.Text = $"Gold: {quantity}";

                            // Animate border panel to match rarity
                            if (_rarityColors.TryGetValue(Rarity.Common, out var newColor))
                            {
                                StartColorTransition(panel, newColor);
                            }
                        }
                    }

                    // Add loot
                    Inventory.Add(playerIndex, lootToAdd);

                    // Update quests and statistics
                    GameManager.CurrentPlayer.Statistics.LootboxesOpened += 1;
                    GameManager.TryQuestProgress(playerIndex, QuestType.OpenLootbox, 1);

                    // Start color transition timer to animate panels
                    _colorTransitionTimer.Start();
                }
                else
                {
                    OutputService.Write(true, [new("Failed to open Lootbox.", Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }
    }
}