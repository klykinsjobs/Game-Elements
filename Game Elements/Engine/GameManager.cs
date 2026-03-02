using Game_Elements.Data;
using Game_Elements.Enums;
using Game_Elements.Factories;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace Game_Elements.Engine
{
    public static class GameManager
    {
        public static List<Player> Players { get; set; } = [];

        private static Player? _currentPlayer;
        public static Player? CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                if (_currentPlayer != value)
                {
                    var previousPlayer = _currentPlayer;
                    _currentPlayer = value;
                    OnCurrentPlayerChanged(previousPlayer);

                    LoadDailyRewards();
                }
            }
        }

        private static readonly JsonSerializerOptions s_options = new() { WriteIndented = true };

        public static DateTime LastTick { get; set; } = DateTime.Now;
        public static DateTime LastAutoSave { get; set; } = DateTime.Now;
        public static DateTime LastOutputAlmostFullOrEmpty { get; set; } = DateTime.Now;
        public static DateTime LastOutputAverageUnitHappiness { get; set; } = DateTime.Now;
        public static DateTime LastOutputLoremIpsum { get; set; } = DateTime.Now;

        public static void InitializeGame()
        {
            // If loading fails, then start a new game
            if (!LoadProgress())
                NewGame();
        }

        public static bool LoadProgress()
        {
            // Clear any existing players
            if (Players.Count > 0)
                Players.Clear();

            // Try loading save file
            string serializableGameStateSavePath = "serializableGameState.json";
            if (File.Exists(serializableGameStateSavePath))
            {
                var json = File.ReadAllText(serializableGameStateSavePath);

                var gameState = JsonSerializer.Deserialize<SerializableGameState>(json, s_options);
                if (gameState != null)
                {
                    LastTick = gameState.LastTick;
                    for (int i = 0; i < gameState.Players.Count; i++)
                    {
                        var player = gameState.Players[i];

                        // Load achievement conditions
                        var achievementConditions = AchievementFactory.UnlockConditions(i);
                        foreach (var achievement in player.Achievements)
                        {
                            if (achievementConditions.TryGetValue($"{achievement.Title}", out var achievementCondition))
                                achievement.UnlockCondition = achievementCondition;
                            else
                                achievement.UnlockCondition = () => false;  // fallback
                        }

                        Players.Add(player);
                    }
                }

                return Players.Count > 0;
            }
            else
            {
                return false;
            }
        }

        public static void SaveProgress()
        {
            var gameState = new SerializableGameState
            {
                Players = Players,
                LastTick = LastTick
            };

            // Try saving save file
            string serializableGameStateSavePath = "serializableGameState.json";
            var json = JsonSerializer.Serialize(gameState, s_options);
            File.WriteAllText(serializableGameStateSavePath, json);
        }

        public static void NewGame()
        {
            // Clear any existing players
            if (Players.Count > 0)
                Players.Clear();

            // Generate 4 player slots
            for (int i = 1; i <= 4; i++)
            {
                var player = PlayerFactory.GenerateRandomPlayer($"Player #{i}");
                Players.Add(player);
            }

            // Populate these player slots with some starter things
            for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
            {
                // 7 units
                for (int j = 0; j < 7; j++)
                {
                    Players[playerIndex].Inventory.Units.Add(UnitFactory.GenerateRandomUnit(playerIndex));
                }

                // 15 missions
                for (int k = 0; k < 15; k++)
                {
                    Players[playerIndex].Missions.Add(MissionFactory.GenerateRandomMission(playerIndex));
                }

                // 11 x 11 tile grid
                int tileGridRows = 11;
                int tileGridColumns = 11;
                int centerRow = tileGridRows / 2;
                int centerColumn = tileGridColumns / 2;
                for (int row = 0; row < tileGridRows; row++)
                {
                    for (int column = 0; column < tileGridColumns; column++)
                    {
                        // simple terrain generation based on distance from center
                        int distance = Math.Max(Math.Abs(centerRow - row), Math.Abs(centerColumn - column));

                        TerrainType terrainType = distance switch
                        {
                            > 5 => TerrainType.Water,
                            > 4 => Random.Shared.Next(0, 100) switch { > 15 => TerrainType.Water, > 10 => TerrainType.Mountain, > 5 => TerrainType.Desert, _ => TerrainType.Grassland },
                            > 3 => Random.Shared.Next(0, 100) switch { > 35 => TerrainType.Water, > 30 => TerrainType.Mountain, > 25 => TerrainType.Desert, _ => TerrainType.Grassland },
                            > 2 => Random.Shared.Next(0, 100) switch { > 55 => TerrainType.Water, > 50 => TerrainType.Mountain, > 45 => TerrainType.Desert, _ => TerrainType.Grassland },
                            > 1 => Random.Shared.Next(0, 100) switch { > 75 => TerrainType.Water, _ => TerrainType.Grassland },
                            _ => TerrainType.Grassland
                        };

                        Players[playerIndex].Tiles.Add(TileFactory.GenerateTile(row, column, terrainType, null));
                    }
                }

                // 3 quests
                for (int l = 0; l < 3; l++)
                {
                    Players[playerIndex].Quests.Add(QuestFactory.GenerateRandomQuest(playerIndex));
                }

                // 1 egg hatcher
                Players[playerIndex].EggHatchers.Add(new EggHatcher());

                // 1 gardening plot
                Players[playerIndex].GardeningPlots.Add(new GardeningPlot());

                // achievements
                Players[playerIndex].Achievements = new BindingList<Achievement>(AchievementFactory.GetAchievements(playerIndex));
            }
        }

        public static void Tick()
        {
            if (Players.Count == 0)
                return;

            for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
            {
                // Clear expired and complete
                TryClearExpiredMissions(playerIndex);
                TryClearCompleteMissions(playerIndex);
                TryClearCompleteQuests(playerIndex);

                // Refill
                TryRefillMissions(playerIndex);
                TryRefillQuests(playerIndex);

                // Auto start
                TryAutoStartMission(playerIndex);

                // Ticks
                foreach (var mission in Players[playerIndex].Missions)
                    mission.Tick(playerIndex, DateTime.Now - LastTick);

                foreach (var unit in Players[playerIndex].Inventory.Units)
                    unit.Tick(playerIndex);

                int availablePower = Players[playerIndex].Inventory.Power;
                Loot buildingProduction = new();
                foreach (var tile in Players[playerIndex].Tiles)
                    tile.Tick(playerIndex, DateTime.Now - LastTick, ref availablePower, ref buildingProduction);
                Players[playerIndex].Inventory.Power = availablePower;
                Inventory.Add(playerIndex, buildingProduction, false);

                Players[playerIndex].ResearchTree.Tick(playerIndex);

                // Discard unused research
                if (Players[playerIndex].Inventory.Research > 0)
                    Players[playerIndex].Inventory.Research = 0;

                foreach (var quest in Players[playerIndex].Quests)
                    quest.Tick(playerIndex);

                foreach (var eggHatcher in Players[playerIndex].EggHatchers)
                    eggHatcher.Tick(playerIndex, DateTime.Now - LastTick);

                foreach (var gardeningPlot in Players[playerIndex].GardeningPlots)
                    gardeningPlot.Tick(playerIndex, DateTime.Now - LastTick);

                foreach (var achievement in Players[playerIndex].Achievements)
                    achievement.Tick(playerIndex);

                // Extra text output for current player
                if (CurrentPlayer != null)
                {
                    int currentPlayerIndex = Players.IndexOf(CurrentPlayer);

                    // Full, almost full, almost empty, or empty
                    if (playerIndex == currentPlayerIndex && (DateTime.Now - LastOutputAlmostFullOrEmpty).TotalSeconds >= 90)
                    {
                        var inv = CurrentPlayer.Inventory;

                        StringBuilder emptyOrAlmost = new("Empty or almost empty: ");
                        if (inv.Power < 25) emptyOrAlmost.Append($"Power ({inv.Power}) ");
                        if (inv.Water < 10) emptyOrAlmost.Append($"Water ({inv.Water}) ");
                        if (inv.Food < 10) emptyOrAlmost.Append($"Food ({inv.Food}) ");
                        if (inv.Concrete < 3) emptyOrAlmost.Append($"Concrete ({inv.Concrete}) ");
                        if (inv.Metal < 3) emptyOrAlmost.Append($"Metal ({inv.Metal}) ");

                        StringBuilder fullOrAlmost = new("Full or almost full: ");
                        if ((double)(inv.Units.Count / ApplyModifiers(playerIndex, ModifierTarget.MaxUnits, StarterValues.MaxUnits)) > 0.95)
                            fullOrAlmost.Append($"Units ({inv.Units.Count}/{ApplyModifiers(playerIndex, ModifierTarget.MaxUnits, StarterValues.MaxUnits)}) ");
                        if ((double)(inv.Items.Count / ApplyModifiers(playerIndex, ModifierTarget.MaxItems, StarterValues.MaxItems)) > 0.95)
                            fullOrAlmost.Append($"Items ({inv.Items.Count}/{ApplyModifiers(playerIndex, ModifierTarget.MaxItems, StarterValues.MaxItems)}) ");
                        if ((double)(inv.Gold / ApplyModifiers(playerIndex, ModifierTarget.MaxGold, StarterValues.MaxGold)) > 0.95)
                            fullOrAlmost.Append($"Gold ({inv.Gold}/{ApplyModifiers(playerIndex, ModifierTarget.MaxGold, StarterValues.MaxGold)}) ");
                        if ((double)(inv.Lootboxes / ApplyModifiers(playerIndex, ModifierTarget.MaxLootboxes, StarterValues.MaxLootboxes)) > 0.95)
                            fullOrAlmost.Append($"Lootboxes ({inv.Lootboxes}/{ApplyModifiers(playerIndex, ModifierTarget.MaxLootboxes, StarterValues.MaxLootboxes)}) ");
                        if ((double)(inv.RushBoosts / ApplyModifiers(playerIndex, ModifierTarget.MaxRushBoosts, StarterValues.MaxRushBoosts)) > 0.95)
                            fullOrAlmost.Append($"Rush Boosts ({inv.RushBoosts}/{ApplyModifiers(playerIndex, ModifierTarget.MaxRushBoosts, StarterValues.MaxRushBoosts)}) ");
                        if ((double)(inv.ExperienceBoosts / ApplyModifiers(playerIndex, ModifierTarget.MaxExperienceBoosts, StarterValues.MaxExperienceBoosts)) > 0.95)
                            fullOrAlmost.Append($"Experience Boosts ({inv.ExperienceBoosts}/{ApplyModifiers(playerIndex, ModifierTarget.MaxExperienceBoosts, StarterValues.MaxExperienceBoosts)}) ");
                        if ((double)(inv.RarityBoosts / ApplyModifiers(playerIndex, ModifierTarget.MaxRarityBoosts, StarterValues.MaxRarityBoosts)) > 0.95)
                            fullOrAlmost.Append($"Rarity Boosts ({inv.RarityBoosts}/{ApplyModifiers(playerIndex, ModifierTarget.MaxRarityBoosts, StarterValues.MaxRarityBoosts)}) ");
                        if ((double)(inv.MonsterEggs / ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs)) > 0.95)
                            fullOrAlmost.Append($"Monster Eggs ({inv.MonsterEggs}/{ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs)}) ");
                        if ((double)(inv.Fertilizer / ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer)) > 0.95)
                            fullOrAlmost.Append($"Fertilizer ({inv.Fertilizer}/{ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer)}) ");
                        if ((double)(inv.MysterySeeds / ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds)) > 0.95)
                            fullOrAlmost.Append($"Mystery Seeds ({inv.MysterySeeds}/{ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds)}) ");

                        if (emptyOrAlmost.ToString() != "Empty or almost empty: ")
                            OutputService.Write(true, [new(emptyOrAlmost.ToString().TrimEnd(), Properties.Settings.Default.PrimaryForeColor)]);
                        if (fullOrAlmost.ToString() != "Full or almost full: ")
                            OutputService.Write(true, [new(fullOrAlmost.ToString().TrimEnd(), Properties.Settings.Default.PrimaryForeColor)]);

                        LastOutputAlmostFullOrEmpty = DateTime.Now;
                    }

                    // Average unit happiness
                    if (playerIndex == currentPlayerIndex && (DateTime.Now - LastOutputAverageUnitHappiness).TotalSeconds >= 150)
                    {
                        int averageUnitHappiness = (int)CurrentPlayer.Inventory.Units.Average(u => u.HappinessLevel);
                        OutputService.Write(true,
                            [
                            new($"{CurrentPlayer.Name}", Properties.Settings.Default.PrimaryForeColor),
                            new($"'s units have {averageUnitHappiness}% average unit happiness.", Properties.Settings.Default.PrimaryForeColor)
                            ]);
                        LastOutputAverageUnitHappiness = DateTime.Now;
                    }

                    // Unit quotes
                    if (playerIndex == currentPlayerIndex)
                    {
                        TimeSpan modifiedUnitQuoteInterval = TimeSpan.FromMilliseconds(ApplyModifiers(playerIndex, ModifierTarget.UnitQuoteInterval, StarterValues.UnitQuoteInterval));
                        if ((DateTime.Now - LastOutputLoremIpsum).TotalSeconds >= modifiedUnitQuoteInterval.TotalSeconds)
                        {
                            if (Random.Shared.NextDouble() < 0.10)
                            {
                                string unitName = $"{CurrentPlayer.Inventory.Units[Random.Shared.Next(0, CurrentPlayer.Inventory.Units.Count)].Name}";
                                OutputService.Write(true,
                                    [
                                    new($"{unitName}: ", Properties.Settings.Default.PrimaryForeColor),
                                    new("Lorem ipsum...", Properties.Settings.Default.FlavorTextColor, false, true, false)
                                    ]);
                                LastOutputLoremIpsum = DateTime.Now;
                            }
                        }
                    }
                }
            }

            LastTick = DateTime.Now;

            // Auto save
            if ((DateTime.Now - LastAutoSave).TotalSeconds >= 600)
            {
                SaveProgress();
                OutputService.Write(true, [new("Auto saved progress.", Properties.Settings.Default.PrimaryForeColor)]);
                LastAutoSave = DateTime.Now;
            }
        }

        public static void LoadDailyRewards()
        {
            if (CurrentPlayer != null && CurrentPlayer.LastDailyReward < DateTime.Today)
            {
                CurrentPlayer.LastDailyReward = DateTime.Today;

                int playerIndex = Players.IndexOf(CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Daily rewards are tied to average unit happiness to give it some low stakes
                    int averageUnitHappiness = (int)Players[playerIndex].Inventory.Units.Average(u => u.HappinessLevel);

                    // Fill loot
                    Loot loots = new();
                    switch (averageUnitHappiness)
                    {
                        case 100:
                            loots.LootQuantities.Add(LootType.Lootbox, 5);
                            break;
                        case >= 90 and < 100:
                            loots.LootQuantities.Add(LootType.Lootbox, 4);
                            break;
                        case >= 80 and < 90:
                            loots.LootQuantities.Add(LootType.Lootbox, 3);
                            break;
                        case >= 70 and < 80:
                            loots.LootQuantities.Add(LootType.Lootbox, 2);
                            break;
                        case >= 50 and < 70:
                            loots.LootQuantities.Add(LootType.Lootbox, 1);
                            break;
                        default:
                            loots.Items.Add(ItemFactory.GenerateRandomJunkItem(playerIndex));
                            break;
                    }

                    OutputService.Write(true, [new("Daily Reward!", Properties.Settings.Default.PrimaryForeColor, true, false, false),]);

                    // Add loot
                    Inventory.Add(playerIndex, loots);
                }
            }
        }

        public static void TryClearExpiredMissions(int playerIndex)
        {
            if (playerIndex == -1)
                return;

            var expiredMissions = Players[playerIndex].Missions
                    .Where(m => m.MissionState == MissionState.Available && m.Expiration <= DateTime.Now)
                    .ToList();

            if (expiredMissions.Count > 0)
            {
                Players[playerIndex].Missions.RaiseListChangedEvents = false;
                foreach (var expiredMission in expiredMissions)
                    Players[playerIndex].Missions.Remove(expiredMission);
                Players[playerIndex].Missions.RaiseListChangedEvents = true;
                Players[playerIndex].Missions.ResetBindings();
            }
        }

        public static void TryClearCompleteMissions(int playerIndex)
        {
            if (playerIndex == -1)
                return;

            // MissionStateLastChanged is used here so complete missions can be seen in the UI for a minute before they are cleared
            var completeMissions = Players[playerIndex].Missions
                    .Where(m => (m.MissionState == MissionState.Success || m.MissionState == MissionState.Fail)
                    && DateTime.Now - m.MissionStateLastChanged >= TimeSpan.FromSeconds(60))
                    .ToList();

            if (completeMissions.Count > 0)
            {
                Players[playerIndex].Missions.RaiseListChangedEvents = false;
                foreach (var completeMission in completeMissions)
                    Players[playerIndex].Missions.Remove(completeMission);
                Players[playerIndex].Missions.RaiseListChangedEvents = true;
                Players[playerIndex].Missions.ResetBindings();
            }
        }

        public static void TryClearCompleteQuests(int playerIndex)
        {
            if (playerIndex == -1)
                return;

            // CompletedOrDismissedAt is used here so there is a blank quest slot in the UI for a few seconds before another quest appears
            var completeQuests = Players[playerIndex].Quests
                .Where(r => (r.Completed || r.Dismissed) && DateTime.Now - r.CompletedOrDismissedAt >= TimeSpan.FromSeconds(5))
                .ToList();

            if (completeQuests.Count > 0)
            {
                Players[playerIndex].Quests.RaiseListChangedEvents = false;
                foreach (var completeQuest in completeQuests)
                    Players[playerIndex].Quests.Remove(completeQuest);
                Players[playerIndex].Quests.RaiseListChangedEvents = true;
                Players[playerIndex].Quests.ResetBindings();
            }
        }

        public static void TryRefillMissions(int playerIndex)
        {
            if (playerIndex == -1)
                return;

            int missions = Players[playerIndex].Missions.Count(m => m.MissionState == MissionState.Available);
            int maxMissions = 15;

            if (missions < maxMissions)
            {
                Players[playerIndex].Missions.RaiseListChangedEvents = false;
                for (int i = missions; i < maxMissions; i++)
                    Players[playerIndex].Missions.Add(MissionFactory.GenerateRandomMission(playerIndex));
                Players[playerIndex].Missions.RaiseListChangedEvents = true;
                Players[playerIndex].Missions.ResetBindings();
            }
        }

        public static void TryRefillQuests(int playerIndex)
        {
            if (playerIndex == -1)
                return;

            int quests = Players[playerIndex].Quests.Count;
            int modifiedMaxQuests = (int)ApplyModifiers(playerIndex, ModifierTarget.MaxQuests, StarterValues.MaxQuests);

            if (quests < modifiedMaxQuests)
            {
                Players[playerIndex].Quests.RaiseListChangedEvents = false;
                for (int i = quests; i < modifiedMaxQuests; i++)
                    Players[playerIndex].Quests.Add(QuestFactory.GenerateRandomQuest(playerIndex));
                Players[playerIndex].Quests.RaiseListChangedEvents = true;
                Players[playerIndex].Quests.ResetBindings();
            }
        }

        public static void TryAutoStartMission(int playerIndex)
        {
            if (playerIndex == -1)
                return;

            // Return early if in progress missions are currently maxed
            if (Players[playerIndex].Missions.Count(m => m.MissionState == MissionState.InProgress) >=
                ApplyModifiers(playerIndex, ModifierTarget.MaxInProgressMissions, StarterValues.MaxInProgressMissions))
                return;

            // Return early if there aren't enough idle units available to start a mission
            if (Players[playerIndex].Inventory.Units.Count(u => u.UnitState == UnitState.Idle && !u.PendingDelete) < 3)
                return;

            // Sort the available units by level and rarity
            var availableUnits = Players[playerIndex].Inventory.Units
                .Where(u => u.UnitState == UnitState.Idle && !u.PendingDelete)
                .OrderByDescending(u => u.Level)
                .ThenByDescending(u => u.Rarity)
                .ToList();

            // Sort the available missions by rarity and level
            var prioritizedMissions = Players[playerIndex].Missions.Where(m => m.MissionState == MissionState.Available && m.Expiration > DateTime.Now)
                .OrderByDescending(m => m.Rarity)
                .ThenByDescending(m => m.Level)
                .ToList();

            foreach (var mission in prioritizedMissions)
            {
                // Calculate each unit's success chance
                var bestUnits = availableUnits
                    .OrderByDescending(u => mission.GetSuccessChance(playerIndex, [u.Id]))
                    .ToList();

                var topThreeUnitGuids = bestUnits
                    .Take(3)
                    .Select(u => u.Id)
                    .ToList();

                // Calculate success with the top 3 units
                double successChance = mission.GetSuccessChance(playerIndex, topThreeUnitGuids);

                // If success chance for this mission is below a certain threshold, then skip it and try the next mission
                if (successChance < 25.0)
                    continue;

                // Assign the units and start the mission
                mission.AssignedUnitGuids = topThreeUnitGuids;
                mission.MissionState = MissionState.InProgress;
                foreach (var guid in mission.AssignedUnitGuids)
                {
                    var unit = Players[playerIndex].Inventory.Units.FirstOrDefault(u => u.Id == guid);
                    if (unit != null)
                        unit.UnitState = UnitState.OnMission;
                }

                // Update quests and statistics
                TryQuestProgress(playerIndex, QuestType.StartMission, 1);
                Players[playerIndex].Statistics.MissionsStarted++;

                // Output if current player
                if (CurrentPlayer != null && playerIndex == Players.IndexOf(CurrentPlayer))
                {
                    OutputService.Write(true,
                        [
                        new("Started mission: ", Properties.Settings.Default.PrimaryForeColor),
                        new($"{mission.Name} ({mission.Level} | {mission.Rarity} | {successChance}%)", Properties.Settings.Default.PrimaryForeColor)
                        ]);
                }

                // Stagger after one mission has been started to keep from spamming output
                break;
            }
        }

        public static void TryQuestProgress(int playerIndex, QuestType questType, int amount)
        {
            if (playerIndex == -1)
                return;

            // Update the progress for any matching quest types for this player
            foreach (var quest in Players[playerIndex].Quests)
                if (!quest.Completed && !quest.Dismissed && quest.QuestType == questType)
                    quest.Progress = Math.Min(quest.Progress + amount, quest.Target);   // Math.Min so Progress doesn't exceed Target
        }

        public static void AddModifier(int playerIndex, Modifier modifier)
        {
            if (playerIndex == -1)
                return;

            // Increment quantity if a matching modifier already exists, otherwise add the modifier
            var mod = Players[playerIndex].Modifiers
                    .FirstOrDefault(m => m.ModifierTarget == modifier.ModifierTarget && m.ModifierSource == modifier.ModifierSource
                    && m.ModifierType == modifier.ModifierType && m.ModifierAmount == modifier.ModifierAmount);
            if (mod != null)
            {
                mod.ModifierQuantity++;
            }
            else
            {
                Players[playerIndex].Modifiers.Add(modifier);
            }
        }

        public static void RemoveModifier(int playerIndex, Modifier modifier)
        {
            if (playerIndex == -1)
                return;

            // Decrement quantity if a matching modifier already exists with quantity over 1, otherwise remove the modifier
            var mod = Players[playerIndex].Modifiers
                    .FirstOrDefault(m => m.ModifierTarget == modifier.ModifierTarget && m.ModifierSource == modifier.ModifierSource
                    && m.ModifierType == modifier.ModifierType && m.ModifierAmount == modifier.ModifierAmount);
            if (mod != null)
            {
                if (mod.ModifierQuantity > 1)
                    mod.ModifierQuantity--;
                else
                    Players[playerIndex].Modifiers.Remove(mod);
            }
            else
            {
                return;
            }

            // Clamp resources to account for the new adjusted maximums.
            // Units and Items are not clamped. Instead, the calling code checks the adjusted maximums first,
            // and only proceeds if it wouldn't be over capacity afterwards.
            switch (modifier.ModifierTarget)
            {
                case ModifierTarget.MaxPower:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Power, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxPower, StarterValues.MaxPower));
                        if (Players[playerIndex].Inventory.Power > clamped) Players[playerIndex].Inventory.Power = clamped;
                    }
                    break;
                case ModifierTarget.MaxWater:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Water, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxWater, StarterValues.MaxWater));
                        if (Players[playerIndex].Inventory.Water > clamped) Players[playerIndex].Inventory.Water = clamped;
                    }
                    break;
                case ModifierTarget.MaxFood:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Food, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxFood, StarterValues.MaxFood));
                        if (Players[playerIndex].Inventory.Food > clamped) Players[playerIndex].Inventory.Food = clamped;
                    }
                    break;
                case ModifierTarget.MaxConcrete:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Concrete, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxConcrete, StarterValues.MaxConcrete));
                        if (Players[playerIndex].Inventory.Concrete > clamped) Players[playerIndex].Inventory.Concrete = clamped;
                    }
                    break;
                case ModifierTarget.MaxMetal:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Metal, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxMetal, StarterValues.MaxMetal));
                        if (Players[playerIndex].Inventory.Metal > clamped) Players[playerIndex].Inventory.Metal = clamped;
                    }
                    break;
                case ModifierTarget.MaxGold:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Gold, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxGold, StarterValues.MaxGold));
                        if (Players[playerIndex].Inventory.Gold > clamped) Players[playerIndex].Inventory.Gold = clamped;
                    }
                    break;
                case ModifierTarget.MaxLootboxes:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Lootboxes, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxLootboxes, StarterValues.MaxLootboxes));
                        if (Players[playerIndex].Inventory.Lootboxes > clamped) Players[playerIndex].Inventory.Lootboxes = clamped;
                    }
                    break;
                case ModifierTarget.MaxRushBoosts:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.RushBoosts, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxRushBoosts, StarterValues.MaxRushBoosts));
                        if (Players[playerIndex].Inventory.RushBoosts > clamped) Players[playerIndex].Inventory.RushBoosts = clamped;
                    }
                    break;
                case ModifierTarget.MaxExperienceBoosts:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.ExperienceBoosts, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxExperienceBoosts, StarterValues.MaxExperienceBoosts));
                        if (Players[playerIndex].Inventory.ExperienceBoosts > clamped) Players[playerIndex].Inventory.ExperienceBoosts = clamped;
                    }
                    break;
                case ModifierTarget.MaxRarityBoosts:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.RarityBoosts, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxRarityBoosts, StarterValues.MaxRarityBoosts));
                        if (Players[playerIndex].Inventory.RarityBoosts > clamped) Players[playerIndex].Inventory.RarityBoosts = clamped;
                    }
                    break;
                case ModifierTarget.MaxMonsterEggs:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.MonsterEggs, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs));
                        if (Players[playerIndex].Inventory.MonsterEggs > clamped) Players[playerIndex].Inventory.MonsterEggs = clamped;
                    }
                    break;
                case ModifierTarget.MaxFertilizer:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.Fertilizer, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer));
                        if (Players[playerIndex].Inventory.Fertilizer > clamped) Players[playerIndex].Inventory.Fertilizer = clamped;
                    }
                    break;
                case ModifierTarget.MaxMysterySeeds:
                    {
                        int clamped = (int)Math.Clamp(Players[playerIndex].Inventory.MysterySeeds, 0, ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds));
                        if (Players[playerIndex].Inventory.MysterySeeds > clamped) Players[playerIndex].Inventory.MysterySeeds = clamped;
                    }
                    break;
            }
        }

        public static double ApplyModifiers(int playerIndex, ModifierTarget modifierTarget, double unmodifiedValue)
        {
            // Get the relevant modifiers
            var filtered = Players[playerIndex].Modifiers.Where(r => r.ModifierTarget == modifierTarget);

            // Sum all flat modifiers
            double flat = filtered
                .Where(r => r.ModifierType == ModifierType.Flat)
                .Sum(r => r.ModifierAmount * r.ModifierQuantity);

            // Sum all percent modifiers
            double percent = filtered
                .Where(r => r.ModifierType == ModifierType.Percent)
                .Sum(r => r.ModifierAmount * r.ModifierQuantity);

            // Apply flat addition first, then scale by percent multiplier
            return (unmodifiedValue + flat) * (1.0 + percent);
        }

        // Event raised whenever current player is changed
        public static event Action<Player?>? CurrentPlayerChanged;

        // Helper method to trigger the CurrentPlayerChanged event
        private static void OnCurrentPlayerChanged(Player? previousPlayer) => CurrentPlayerChanged?.Invoke(previousPlayer);
    }
}