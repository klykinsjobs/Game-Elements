using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Services;
using System.ComponentModel;
using System.Text;

namespace Game_Elements.Models
{
    public class Inventory : INotifyPropertyChanged
    {
        private readonly Lock _inventoryLock = new();

        public BindingList<Item> Items { get; set; }
        public BindingList<Unit> Units { get; set; }

        public int Research { get; set; }

        private int _power;
        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (_power != value)
                {
                    _power = value;
                    OnPropertyChanged(nameof(Power));
                }
            }
        }

        private int _water;
        public int Water
        {
            get
            {
                return _water;
            }
            set
            {
                if (_water != value)
                {
                    _water = value;
                    OnPropertyChanged(nameof(Water));
                }
            }
        }

        private int _food;
        public int Food
        {
            get
            {
                return _food;
            }
            set
            {
                if (_food != value)
                {
                    _food = value;
                    OnPropertyChanged(nameof(Food));
                }
            }
        }

        private int _concrete;
        public int Concrete
        {
            get
            {
                return _concrete;
            }
            set
            {
                if (_concrete != value)
                {
                    _concrete = value;
                    OnPropertyChanged(nameof(Concrete));
                }
            }
        }

        private int _metal;
        public int Metal
        {
            get
            {
                return _metal;
            }
            set
            {
                if (_metal != value)
                {
                    _metal = value;
                    OnPropertyChanged(nameof(Metal));
                }
            }
        }

        private int _gold;
        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                if (_gold != value)
                {
                    _gold = value;
                    OnPropertyChanged(nameof(Gold));
                }
            }
        }

        private int _lootboxes;
        public int Lootboxes
        {
            get
            {
                return _lootboxes;
            }
            set
            {
                if (_lootboxes != value)
                {
                    _lootboxes = value;
                    OnPropertyChanged(nameof(Lootboxes));
                }
            }
        }

        private int _rushBoosts;
        public int RushBoosts
        {
            get
            {
                return _rushBoosts;
            }
            set
            {
                if (_rushBoosts != value)
                {
                    _rushBoosts = value;
                    OnPropertyChanged(nameof(RushBoosts));
                }
            }
        }

        private int _experienceBoosts;
        public int ExperienceBoosts
        {
            get
            {
                return _experienceBoosts;
            }
            set
            {
                if (_experienceBoosts != value)
                {
                    _experienceBoosts = value;
                    OnPropertyChanged(nameof(ExperienceBoosts));
                }
            }
        }

        private int _rarityBoosts;
        public int RarityBoosts
        {
            get
            {
                return _rarityBoosts;
            }
            set
            {
                if (_rarityBoosts != value)
                {
                    _rarityBoosts = value;
                    OnPropertyChanged(nameof(RarityBoosts));
                }
            }
        }

        private int _monsterEggs;
        public int MonsterEggs
        {
            get
            {
                return _monsterEggs;
            }
            set
            {
                if (_monsterEggs != value)
                {
                    _monsterEggs = value;
                    OnPropertyChanged(nameof(MonsterEggs));
                }
            }
        }

        private int _fertilizer;
        public int Fertilizer
        {
            get
            {
                return _fertilizer;
            }
            set
            {
                if (_fertilizer != value)
                {
                    _fertilizer = value;
                    OnPropertyChanged(nameof(Fertilizer));
                }
            }
        }

        private int _mysterySeeds;
        public int MysterySeeds
        {
            get
            {
                return _mysterySeeds;
            }
            set
            {
                if (_mysterySeeds != value)
                {
                    _mysterySeeds = value;
                    OnPropertyChanged(nameof(MysterySeeds));
                }
            }
        }

        public Inventory(int power, int water, int food, int concrete, int metal, int gold, int lootboxes,
            int rushBoosts, int experienceBoosts, int rarityBoosts, int monsterEggs, int fertilizer, int mysterySeeds)
        {
            Units = [];
            Items = [];

            Research = 0;

            Power = power;
            Water = water;
            Food = food;
            Concrete = concrete;
            Metal = metal;
            Gold = gold;
            Lootboxes = lootboxes;
            RushBoosts = rushBoosts;
            ExperienceBoosts = experienceBoosts;
            RarityBoosts = rarityBoosts;
            MonsterEggs = monsterEggs;
            Fertilizer = fertilizer;
            MysterySeeds = mysterySeeds;
        }

        public static void Add(int playerIndex, Loot loots, bool bypassOutput = false)
        {
            if (playerIndex == -1)
                return;

            StringBuilder stringBuilder = new("Added: ");

            // Add the relevant loot
            foreach (var loot in loots.LootQuantities)
            {
                switch (loot.Key)
                {
                    case LootType.Gold:
                        // Most maximums can be modified by adding/removing buildings
                        int maxGold = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxGold, StarterValues.MaxGold);
                        int clampedGold = Math.Clamp(GameManager.Players[playerIndex].Inventory.Gold + loot.Value, 0, maxGold);
                        int addedGold = clampedGold - GameManager.Players[playerIndex].Inventory.Gold;
                        int discardedGold = loot.Value - addedGold;

                        // Update the property with the clamped value
                        GameManager.Players[playerIndex].Inventory.Gold = clampedGold;

                        // Update quests and statistics
                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectGold, addedGold);
                        GameManager.Players[playerIndex].Statistics.GoldCollected += addedGold;

                        // Build output
                        stringBuilder.Append(discardedGold > 0 ? $"+{addedGold} Gold ({discardedGold} discarded) " : $"+{addedGold} Gold ");
                        break;
                    case LootType.Power:
                        int maxPower = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxPower, StarterValues.MaxPower);
                        int clampedPower = Math.Clamp(GameManager.Players[playerIndex].Inventory.Power + loot.Value, 0, maxPower);
                        int addedPower = clampedPower - GameManager.Players[playerIndex].Inventory.Power;
                        int discardedPower = loot.Value - addedPower;

                        GameManager.Players[playerIndex].Inventory.Power = clampedPower;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectPower, addedPower);
                        GameManager.Players[playerIndex].Statistics.PowerCollected += addedPower;

                        stringBuilder.Append(discardedPower > 0 ? $"+{addedPower} Power ({discardedPower} discarded) " : $"+{addedPower} Power ");
                        break;
                    case LootType.Water:
                        int maxWater = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxWater, StarterValues.MaxWater);
                        int clampedWater = Math.Clamp(GameManager.Players[playerIndex].Inventory.Water + loot.Value, 0, maxWater);
                        int addedWater = clampedWater - GameManager.Players[playerIndex].Inventory.Water;
                        int discardedWater = loot.Value - addedWater;

                        GameManager.Players[playerIndex].Inventory.Water = clampedWater;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectWater, addedWater);
                        GameManager.Players[playerIndex].Statistics.WaterCollected += addedWater;

                        stringBuilder.Append(discardedWater > 0 ? $"+{addedWater} Water ({discardedWater} discarded) " : $"+{addedWater} Water ");
                        break;
                    case LootType.Food:
                        int maxFood = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFood, StarterValues.MaxFood);
                        int clampedFood = Math.Clamp(GameManager.Players[playerIndex].Inventory.Food + loot.Value, 0, maxFood);
                        int addedFood = clampedFood - GameManager.Players[playerIndex].Inventory.Food;
                        int discardedFood = loot.Value - addedFood;

                        GameManager.Players[playerIndex].Inventory.Food = clampedFood;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectFood, addedFood);
                        GameManager.Players[playerIndex].Statistics.FoodCollected += addedFood;

                        stringBuilder.Append(discardedFood > 0 ? $"+{addedFood} Food ({discardedFood} discarded) " : $"+{addedFood} Food ");
                        break;
                    case LootType.Concrete:
                        int maxConcrete = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxConcrete, StarterValues.MaxConcrete);
                        int clampedConcrete = Math.Clamp(GameManager.Players[playerIndex].Inventory.Concrete + loot.Value, 0, maxConcrete);
                        int addedConcrete = clampedConcrete - GameManager.Players[playerIndex].Inventory.Concrete;
                        int discardedConcrete = loot.Value - addedConcrete;

                        GameManager.Players[playerIndex].Inventory.Concrete = clampedConcrete;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectConcrete, addedConcrete);
                        GameManager.Players[playerIndex].Statistics.ConcreteCollected += addedConcrete;

                        stringBuilder.Append(discardedConcrete > 0 ? $"+{addedConcrete} Concrete ({discardedConcrete} discarded) " : $"+{addedConcrete} Concrete ");
                        break;
                    case LootType.Metal:
                        int maxMetal = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMetal, StarterValues.MaxMetal);
                        int clampedMetal = Math.Clamp(GameManager.Players[playerIndex].Inventory.Metal + loot.Value, 0, maxMetal);
                        int addedMetal = clampedMetal - GameManager.Players[playerIndex].Inventory.Metal;
                        int discardedMetal = loot.Value - addedMetal;

                        GameManager.Players[playerIndex].Inventory.Metal = clampedMetal;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectMetal, addedMetal);
                        GameManager.Players[playerIndex].Statistics.MetalCollected += addedMetal;

                        stringBuilder.Append(discardedMetal > 0 ? $"+{addedMetal} Metal ({discardedMetal} discarded) " : $"+{addedMetal} Metal ");
                        break;
                    case LootType.Lootbox:
                        int maxLootboxes = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxLootboxes, StarterValues.MaxLootboxes);
                        int clampedLootboxes = Math.Clamp(GameManager.Players[playerIndex].Inventory.Lootboxes + loot.Value, 0, maxLootboxes);
                        int addedLootboxes = clampedLootboxes - GameManager.Players[playerIndex].Inventory.Lootboxes;
                        int discardedLootboxes = loot.Value - addedLootboxes;

                        GameManager.Players[playerIndex].Inventory.Lootboxes = clampedLootboxes;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectLootbox, addedLootboxes);
                        GameManager.Players[playerIndex].Statistics.LootboxesCollected += addedLootboxes;

                        stringBuilder.Append(addedLootboxes > 1 ? $"+{addedLootboxes} Lootboxes " : $"+{addedLootboxes} Lootbox ");
                        if (discardedLootboxes > 0)
                            stringBuilder.Append($"({discardedLootboxes} discarded) ");
                        break;
                    case LootType.RushBoost:
                        int maxRushBoosts = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRushBoosts, StarterValues.MaxRushBoosts);
                        int clampedRushBoosts = Math.Clamp(GameManager.Players[playerIndex].Inventory.RushBoosts + loot.Value, 0, maxRushBoosts);
                        int addedRushBoosts = clampedRushBoosts - GameManager.Players[playerIndex].Inventory.RushBoosts;
                        int discardedRushBoosts = loot.Value - addedRushBoosts;

                        GameManager.Players[playerIndex].Inventory.RushBoosts = clampedRushBoosts;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectRushBoost, addedRushBoosts);
                        GameManager.Players[playerIndex].Statistics.RushBoostsCollected += addedRushBoosts;

                        stringBuilder.Append(addedRushBoosts > 1 ? $"+{addedRushBoosts} Rush Boosts " : $"+{addedRushBoosts} Rush Boost ");
                        if (discardedRushBoosts > 0)
                            stringBuilder.Append($"({discardedRushBoosts} discarded) ");
                        break;
                    case LootType.ExperienceBoost:
                        int maxExperienceBoosts = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxExperienceBoosts, StarterValues.MaxExperienceBoosts);
                        int clampedExperienceBoosts = Math.Clamp(GameManager.Players[playerIndex].Inventory.ExperienceBoosts + loot.Value, 0, maxExperienceBoosts);
                        int addedExperienceBoosts = clampedExperienceBoosts - GameManager.Players[playerIndex].Inventory.ExperienceBoosts;
                        int discardedExperienceBoosts = loot.Value - addedExperienceBoosts;

                        GameManager.Players[playerIndex].Inventory.ExperienceBoosts = clampedExperienceBoosts;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectExperienceBoost, addedExperienceBoosts);
                        GameManager.Players[playerIndex].Statistics.ExperienceBoostsCollected += addedExperienceBoosts;

                        stringBuilder.Append(addedExperienceBoosts > 1 ? $"+{addedExperienceBoosts} Experience Boosts " : $"+{addedExperienceBoosts} Experience Boost ");
                        if (discardedExperienceBoosts > 0)
                            stringBuilder.Append($"({discardedExperienceBoosts} discarded) ");
                        break;
                    case LootType.RarityBoost:
                        int maxRarityBoosts = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxRarityBoosts, StarterValues.MaxRarityBoosts);
                        int clampedRarityBoosts = Math.Clamp(GameManager.Players[playerIndex].Inventory.RarityBoosts + loot.Value, 0, maxRarityBoosts);
                        int addedRarityBoosts = clampedRarityBoosts - GameManager.Players[playerIndex].Inventory.RarityBoosts;
                        int discardedRarityBoosts = loot.Value - addedRarityBoosts;

                        GameManager.Players[playerIndex].Inventory.RarityBoosts = clampedRarityBoosts;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectRarityBoost, addedRarityBoosts);
                        GameManager.Players[playerIndex].Statistics.RarityBoostsCollected += addedRarityBoosts;

                        stringBuilder.Append(addedRarityBoosts > 1 ? $"+{addedRarityBoosts} Rarity Boosts " : $"+{addedRarityBoosts} Rarity Boost ");
                        if (discardedRarityBoosts > 0)
                            stringBuilder.Append($"({discardedRarityBoosts} discarded) ");
                        break;
                    case LootType.MonsterEgg:
                        int maxMonsterEggs = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMonsterEggs, StarterValues.MaxMonsterEggs);
                        int clampedMonsterEggs = Math.Clamp(GameManager.Players[playerIndex].Inventory.MonsterEggs + loot.Value, 0, maxMonsterEggs);
                        int addedMonsterEggs = clampedMonsterEggs - GameManager.Players[playerIndex].Inventory.MonsterEggs;
                        int discardedMonsterEggs = loot.Value - addedMonsterEggs;

                        GameManager.Players[playerIndex].Inventory.MonsterEggs = clampedMonsterEggs;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectMonsterEgg, addedMonsterEggs);
                        GameManager.Players[playerIndex].Statistics.MonsterEggsCollected += addedMonsterEggs;

                        stringBuilder.Append(addedMonsterEggs > 1 ? $"+{addedMonsterEggs} Monster Eggs " : $"+{addedMonsterEggs} Monster Egg ");
                        if (discardedMonsterEggs > 0)
                            stringBuilder.Append($"({discardedMonsterEggs} discarded) ");
                        break;
                    case LootType.Fertilizer:
                        int maxFertilizer = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxFertilizer, StarterValues.MaxFertilizer);
                        int clampedFertilizer = Math.Clamp(GameManager.Players[playerIndex].Inventory.Fertilizer + loot.Value, 0, maxFertilizer);
                        int addedFertilizer = clampedFertilizer - GameManager.Players[playerIndex].Inventory.Fertilizer;
                        int discardedFertilizer = loot.Value - addedFertilizer;

                        GameManager.Players[playerIndex].Inventory.Fertilizer = clampedFertilizer;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectFertilizer, addedFertilizer);
                        GameManager.Players[playerIndex].Statistics.FertilizerCollected += addedFertilizer;

                        stringBuilder.Append(discardedFertilizer > 0 ? $"+{addedFertilizer} Fertilizer ({discardedFertilizer} discarded) " : $"+{addedFertilizer} Fertilizer ");
                        break;
                    case LootType.MysterySeed:
                        int maxMysterySeeds = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxMysterySeeds, StarterValues.MaxMysterySeeds);
                        int clampedMysterySeeds = Math.Clamp(GameManager.Players[playerIndex].Inventory.MysterySeeds + loot.Value, 0, maxMysterySeeds);
                        int addedMysterySeeds = clampedMysterySeeds - GameManager.Players[playerIndex].Inventory.MysterySeeds;
                        int discardedMysterySeeds = loot.Value - addedMysterySeeds;

                        GameManager.Players[playerIndex].Inventory.MysterySeeds = clampedMysterySeeds;

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectMysterySeed, addedMysterySeeds);
                        GameManager.Players[playerIndex].Statistics.MysterySeedsCollected += addedMysterySeeds;

                        stringBuilder.Append(addedMysterySeeds > 1 ? $"+{addedMysterySeeds} Mystery Seeds " : $"+{addedMysterySeeds} Mystery Seed ");
                        if (discardedMysterySeeds > 0)
                            stringBuilder.Append($"({discardedMysterySeeds} discarded) ");
                        break;
                    case LootType.Research:
                        // Research doesn't have a maximum as it isn't stockpiled.
                        GameManager.Players[playerIndex].Inventory.Research = Math.Max(GameManager.Players[playerIndex].Inventory.Research + loot.Value, 0);

                        GameManager.TryQuestProgress(playerIndex, QuestType.CollectResearch, loot.Value);
                        GameManager.Players[playerIndex].Statistics.ResearchCollected += loot.Value;

                        stringBuilder.Append($"+{loot.Value} Research ");
                        break;
                }
            }

            // If the loot includes any units, add those too
            if (loots.Units.Count > 0)
            {
                // Maximum can be modified by adding/removing a specific building
                int maxUnits = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxUnits, StarterValues.MaxUnits);
                int clampedUnits = Math.Clamp(GameManager.Players[playerIndex].Inventory.Units.Count + loots.Units.Count, 0, maxUnits);
                int addedUnits = clampedUnits - GameManager.Players[playerIndex].Inventory.Units.Count;
                int discardedUnits = loots.Units.Count - addedUnits;

                // Update quests and statistics
                GameManager.TryQuestProgress(playerIndex, QuestType.CollectUnit, addedUnits);
                GameManager.Players[playerIndex].Statistics.UnitsCollected += addedUnits;

                // Add the unit(s) and build output
                for (int i = 0; i < addedUnits; i++)
                {
                    GameManager.Players[playerIndex].Inventory.Units.Add(loots.Units[i]);
                    stringBuilder.Append($"+1 {loots.Units[i].Name} ({loots.Units[i].Rarity}) ");
                }
                if (discardedUnits > 0)
                    stringBuilder.Append(discardedUnits > 1 ? $"({discardedUnits} units discarded) " : $"({discardedUnits} unit discarded) ");
            }

            // If the loot includes any items, add those too
            if (loots.Items.Count > 0)
            {
                // Maximum can be modified by adding/removing a specific building
                int maxItems = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxItems, StarterValues.MaxItems);
                int clampedItems = Math.Clamp(GameManager.Players[playerIndex].Inventory.Items.Count + loots.Items.Count, 0, maxItems);
                int addedItems = clampedItems - GameManager.Players[playerIndex].Inventory.Items.Count;
                int discardedItems = loots.Items.Count - addedItems;

                // Update quests and statistics
                GameManager.TryQuestProgress(playerIndex, QuestType.CollectItem, addedItems);
                GameManager.Players[playerIndex].Statistics.ItemsCollected += addedItems;

                // Add the item(s) and build output
                for (int i = 0; i < addedItems; i++)
                {
                    GameManager.Players[playerIndex].Inventory.Items.Add(loots.Items[i]);
                    stringBuilder.Append($"+1 {loots.Items[i].Name} ({loots.Items[i].Rarity}) ");
                }
                if (discardedItems > 0)
                    stringBuilder.Append(discardedItems > 1 ? $"({discardedItems} items discarded) " : $"({discardedItems} item discarded) ");
            }

            // Output if current player (and output isn't being bypassed)
            if (!bypassOutput && GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
            {
                if (stringBuilder.ToString() != "Added: ")
                    OutputService.Write(true, [new($"{stringBuilder.ToString().TrimEnd()}", Properties.Settings.Default.PrimaryForeColor)]);
            }
        }

        public bool TryRemove(int playerIndex, Loot loots, bool bypassOutput = false)
        {
            if (playerIndex == -1)
                return false;

            // Remove the relevant loot
            lock (_inventoryLock)
            {
                // Get the amount to remove for each property
                if (loots.LootQuantities.TryGetValue(LootType.Gold, out var gold)
                    && GameManager.Players[playerIndex].Inventory.Gold < gold) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Power, out var power)
                    && GameManager.Players[playerIndex].Inventory.Power < power) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Water, out var water)
                    && GameManager.Players[playerIndex].Inventory.Water < water) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Food, out var food)
                    && GameManager.Players[playerIndex].Inventory.Food < food) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Concrete, out var concrete)
                    && GameManager.Players[playerIndex].Inventory.Concrete < concrete) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Metal, out var metal)
                    && GameManager.Players[playerIndex].Inventory.Metal < metal) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Lootbox, out var lootboxes)
                    && GameManager.Players[playerIndex].Inventory.Lootboxes < lootboxes) return false;
                if (loots.LootQuantities.TryGetValue(LootType.RushBoost, out var rushBoosts)
                    && GameManager.Players[playerIndex].Inventory.RushBoosts < rushBoosts) return false;
                if (loots.LootQuantities.TryGetValue(LootType.ExperienceBoost, out var experienceBoosts)
                    && GameManager.Players[playerIndex].Inventory.ExperienceBoosts < experienceBoosts) return false;
                if (loots.LootQuantities.TryGetValue(LootType.RarityBoost, out var rarityBoosts)
                    && GameManager.Players[playerIndex].Inventory.RarityBoosts < rarityBoosts) return false;
                if (loots.LootQuantities.TryGetValue(LootType.MonsterEgg, out var monsterEggs)
                    && GameManager.Players[playerIndex].Inventory.MonsterEggs < monsterEggs) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Fertilizer, out var fertilizer)
                    && GameManager.Players[playerIndex].Inventory.Fertilizer < fertilizer) return false;
                if (loots.LootQuantities.TryGetValue(LootType.MysterySeed, out var mysterySeeds)
                    && GameManager.Players[playerIndex].Inventory.MysterySeeds < mysterySeeds) return false;
                if (loots.LootQuantities.TryGetValue(LootType.Research, out var research)
                    && GameManager.Players[playerIndex].Inventory.Research < research) return false;

                // Update the relevant properties
                if (gold != 0)
                    GameManager.Players[playerIndex].Inventory.Gold -= gold;
                if (power != 0)
                    GameManager.Players[playerIndex].Inventory.Power -= power;
                if (water != 0)
                    GameManager.Players[playerIndex].Inventory.Water -= water;
                if (food != 0)
                    GameManager.Players[playerIndex].Inventory.Food -= food;
                if (concrete != 0)
                    GameManager.Players[playerIndex].Inventory.Concrete -= concrete;
                if (metal != 0)
                    GameManager.Players[playerIndex].Inventory.Metal -= metal;
                if (lootboxes != 0)
                    GameManager.Players[playerIndex].Inventory.Lootboxes -= lootboxes;
                if (rushBoosts != 0)
                    GameManager.Players[playerIndex].Inventory.RushBoosts -= rushBoosts;
                if (experienceBoosts != 0)
                    GameManager.Players[playerIndex].Inventory.ExperienceBoosts -= experienceBoosts;
                if (rarityBoosts != 0)
                    GameManager.Players[playerIndex].Inventory.RarityBoosts -= rarityBoosts;
                if (monsterEggs != 0)
                    GameManager.Players[playerIndex].Inventory.MonsterEggs -= monsterEggs;
                if (fertilizer != 0)
                    GameManager.Players[playerIndex].Inventory.Fertilizer -= fertilizer;
                if (mysterySeeds != 0)
                    GameManager.Players[playerIndex].Inventory.MysterySeeds -= mysterySeeds;
                if (research != 0)
                    GameManager.Players[playerIndex].Inventory.Research -= research;
            }

            StringBuilder stringBuilder = new("Removed: ");

            // If the loot includes any units, remove those too
            if (loots.Units.Count > 0)
            {
                // If removing more than one unit, using a ListChangedType.Reset approach to reduce unneeded UI updates
                if (loots.Units.Count > 1)
                    Units.RaiseListChangedEvents = false;

                // Remove the unit(s) and build output
                foreach (var unit in loots.Units)
                {
                    var unitToRemove = Units.FirstOrDefault(u => u.Id == unit.Id);
                    if (unitToRemove != null)
                    {
                        Units.Remove(unitToRemove);
                        stringBuilder.Append($"-1 {unitToRemove.Name} ({unitToRemove.Rarity}) ");
                    }
                }

                // If removing more than one unit, using a ListChangedType.Reset approach to reduce unneeded UI updates
                if (loots.Units.Count > 1)
                {
                    Units.RaiseListChangedEvents = true;
                    Units.ResetBindings();
                }
            }

            // If the loot includes any items, remove those too
            if (loots.Items.Count > 0)
            {
                // If removing more than one item, using a ListChangedType.Reset approach to reduce unneeded UI updates
                if (loots.Items.Count > 1)
                    Items.RaiseListChangedEvents = false;

                // Remove the item(s) and build output
                foreach (var item in loots.Items)
                {
                    var itemToRemove = Items.FirstOrDefault(i => i.Id == item.Id);
                    if (itemToRemove != null)
                    {
                        Items.Remove(itemToRemove);
                        stringBuilder.Append($"-1 {itemToRemove.Name} ({itemToRemove.Rarity}) ");
                    }
                }

                // If removing more than one item, using a ListChangedType.Reset approach to reduce unneeded UI updates
                if (loots.Items.Count > 1)
                {
                    Items.RaiseListChangedEvents = true;
                    Items.ResetBindings();
                }
            }

            // Build output
            foreach (KeyValuePair<LootType, int> kvp in loots.LootQuantities)
            {
                switch (kvp.Key)
                {
                    case LootType.Gold:
                        stringBuilder.Append($"-{kvp.Value} Gold ");
                        break;
                    case LootType.Power:
                        stringBuilder.Append($"-{kvp.Value} Power ");
                        break;
                    case LootType.Water:
                        stringBuilder.Append($"-{kvp.Value} Water ");
                        break;
                    case LootType.Food:
                        stringBuilder.Append($"-{kvp.Value} Food ");
                        break;
                    case LootType.Concrete:
                        stringBuilder.Append($"-{kvp.Value} Concrete ");
                        break;
                    case LootType.Metal:
                        stringBuilder.Append($"-{kvp.Value} Metal ");
                        break;
                    case LootType.Lootbox:
                        stringBuilder.Append(kvp.Value > 1 ? $"-{kvp.Value} Lootboxes " : $"-{kvp.Value} Lootbox ");
                        break;
                    case LootType.RushBoost:
                        stringBuilder.Append(kvp.Value > 1 ? $"-{kvp.Value} Rush Boosts " : $"-{kvp.Value} Rush Boost ");
                        break;
                    case LootType.ExperienceBoost:
                        stringBuilder.Append(kvp.Value > 1 ? $"-{kvp.Value} Experience Boosts " : $"-{kvp.Value} Experience Boost ");
                        break;
                    case LootType.RarityBoost:
                        stringBuilder.Append(kvp.Value > 1 ? $"-{kvp.Value} Rarity Boosts " : $"-{kvp.Value} Rarity Boost ");
                        break;
                    case LootType.MonsterEgg:
                        stringBuilder.Append(kvp.Value > 1 ? $"-{kvp.Value} Monster Eggs " : $"-{kvp.Value} Monster Egg ");
                        break;
                    case LootType.Fertilizer:
                        stringBuilder.Append($"-{kvp.Value} Fertilizer ");
                        break;
                    case LootType.MysterySeed:
                        stringBuilder.Append(kvp.Value > 1 ? $"-{kvp.Value} Mystery Seeds " : $"-{kvp.Value} Mystery Seed ");
                        break;
                    case LootType.Research:
                        stringBuilder.Append($"-{kvp.Value} Research ");
                        break;
                    default:
                        break;
                }
            }

            // Output if current player (and output isn't being bypassed)
            if (!bypassOutput && GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
            {
                if (stringBuilder.ToString() != "Removed: ")
                    OutputService.Write(true, [new($"{stringBuilder.ToString().TrimEnd()}", Properties.Settings.Default.PrimaryForeColor)]);
            }

            return true;
        }

        // Event raised whenever a property value changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // Helper method to trigger the PropertyChanged event
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}