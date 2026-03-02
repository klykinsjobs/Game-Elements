using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;

namespace Game_Elements
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.PropertyChanged += CurrentPlayer_PropertyChanged;
            }

            // Update UI elements for current player
            UpdateUI();
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.PropertyChanged -= CurrentPlayer_PropertyChanged;
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
                previousPlayer.PropertyChanged -= CurrentPlayer_PropertyChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.PropertyChanged += CurrentPlayer_PropertyChanged;
            }

            // Update UI elements for new player
            UpdateUI();
        }

        private void CurrentPlayer_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Player.Name)
                || e.PropertyName == nameof(Player.FishingSkill)
                || e.PropertyName == nameof(Player.GardeningSkill))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            PlayerTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            SkillsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            SkillsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            SkillsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            SkillsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            FishingLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            FishingLabel.Font = new Font(FishingLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            GardeningLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            GardeningLabel.Font = new Font(GardeningLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            RenameButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            RenameButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RenameButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            RenameButton.Font = new Font(RenameButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            CustomizeStringsButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            CustomizeStringsButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            CustomizeStringsButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            CustomizeStringsButton.Font = new Font(CustomizeStringsButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            CurrentPlayerBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            CurrentPlayerBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            CurrentPlayerTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            CurrentPlayerTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            PlayerLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PlayerLabel.Font = new Font(GardeningLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex != -1)
            {
                PlayerLabel.Text = $"{GameManager.CurrentPlayer.Name}";

                RenameButton.Enabled = true;

                CustomizeStringsButton.Enabled = true;

                var fishing = GameManager.CurrentPlayer.FishingSkill / StarterValues.MaxFishingSkill;
                FishingLabel.Text = $"Fishing: {GameManager.CurrentPlayer.FishingSkill:N1}/{StarterValues.MaxFishingSkill:N1}";
                FishingPB.Value = Math.Clamp((int)(fishing * 100), 0, 100);

                var gardening = GameManager.CurrentPlayer.GardeningSkill / StarterValues.MaxGardeningSkill;
                GardeningLabel.Text = $"Gardening: {GameManager.CurrentPlayer.GardeningSkill:N1}/{StarterValues.MaxGardeningSkill:N1}";
                GardeningPB.Value = Math.Clamp((int)(gardening * 100), 0, 100);
            }
            else
            {
                PlayerLabel.Text = "";
                RenameButton.Enabled = false;
                CustomizeStringsButton.Enabled = false;
                FishingLabel.Text = "";
                FishingPB.Value = 0;
                GardeningLabel.Text = "";
                GardeningPB.Value = 0;
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            if (GameManager.CurrentPlayer.Inventory.Gold < StarterValues.PlayerRenamingCost)
            {
                OutputService.Write(true, [new($"Not enough gold to rename player. Cost: {StarterValues.PlayerRenamingCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                var dialog = new RenameDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string userInput = dialog.NewNameText.Trim();

                    // Verify input wasn't blank or the current name
                    if (userInput != "" && userInput != GameManager.CurrentPlayer.Name)
                    {
                        Loot lootToRemove = new();
                        lootToRemove.LootQuantities.Add(LootType.Gold, StarterValues.PlayerRenamingCost);

                        // Remove gold
                        if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                        {
                            // Update name
                            GameManager.CurrentPlayer.Name = userInput;

                            OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Player successfully renamed!", Properties.Settings.Default.PrimaryForeColor)]);
                        }
                        else
                        {
                            OutputService.Write(true, [new("Failed to use gold.", Properties.Settings.Default.ErrorTextColor)]);
                        }
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to rename player.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void CustomizeStringsButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex == -1)
                return;

            if (GameManager.CurrentPlayer.Inventory.Gold < StarterValues.CustomizeStringsCost)
            {
                OutputService.Write(true, [new($"Not enough gold to customize strings. Cost: {StarterValues.CustomizeStringsCost}", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                var dialog = new CustomizeDialog(playerIndex);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Compare the sequences
                    List<string> newMissionNames = [.. dialog.NewMissionNames];
                    List<string> newUnitNames = [.. dialog.NewUnitNames];
                    List<string> newMonsterUnitNames = [.. dialog.NewMonsterUnitNames];
                    List<string> newItemNames = [.. dialog.NewItemNames];
                    List<string> newJunkItemNames = [.. dialog.NewJunkItemNames];
                    List<string> newPlantItemNames = [.. dialog.NewPlantItemNames];

                    bool missionNamesEqual = newMissionNames.SequenceEqual(GameManager.CurrentPlayer.MissionFactoryNames);
                    bool unitNamesEqual = newUnitNames.SequenceEqual(GameManager.CurrentPlayer.UnitFactoryNames);
                    bool monsterUnitNamesEqual = newMonsterUnitNames.SequenceEqual(GameManager.CurrentPlayer.MonsterUnitFactoryNames);
                    bool itemNamesEqual = newItemNames.SequenceEqual(GameManager.CurrentPlayer.ItemFactoryNames);
                    bool junkItemNamesEqual = newJunkItemNames.SequenceEqual(GameManager.CurrentPlayer.JunkItemFactoryNames);
                    bool plantItemNamesEqual = newPlantItemNames.SequenceEqual(GameManager.CurrentPlayer.PlantItemFactoryNames);

                    // If at least one of them isn't equal, then go ahead and update all of them
                    if (!missionNamesEqual || !unitNamesEqual || !monsterUnitNamesEqual || !itemNamesEqual || !junkItemNamesEqual || !plantItemNamesEqual)
                    {
                        Loot lootToRemove = new();
                        lootToRemove.LootQuantities.Add(LootType.Gold, StarterValues.CustomizeStringsCost);

                        // Remove gold
                        if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                        {
                            // Update strings
                            GameManager.CurrentPlayer.MissionFactoryNames = newMissionNames;
                            GameManager.CurrentPlayer.UnitFactoryNames = newUnitNames;
                            GameManager.CurrentPlayer.MonsterUnitFactoryNames = newMonsterUnitNames;
                            GameManager.CurrentPlayer.ItemFactoryNames = newItemNames;
                            GameManager.CurrentPlayer.JunkItemFactoryNames = newJunkItemNames;
                            GameManager.CurrentPlayer.PlantItemFactoryNames = newPlantItemNames;

                            OutputService.Write(Properties.Settings.Default.TimestampTextOutput, [new("Strings successfully customized!", Properties.Settings.Default.PrimaryForeColor)]);
                        }
                        else
                        {
                            OutputService.Write(true, [new("Failed to use gold.", Properties.Settings.Default.ErrorTextColor)]);
                        }
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to customize strings", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }
    }
}