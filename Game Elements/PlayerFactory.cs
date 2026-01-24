using System.ComponentModel;

namespace Game_Elements
{
    public static class PlayerFactory
    {
        public static Player GenerateRandomPlayer(string playerName)
        {
            string name = playerName;

            Statistics statistics = new()
            {
                MissionsStarted = 0,
                MissionsSucceeded = 0,
                MissionsFailed = 0,
                LootboxesOpened = 0,
                RushBoostsUsed = 0,
                ExperienceBoostsUsed = 0,
                RarityBoostsUsed = 0,
                ItemsSold = 0,
                ItemsBought = 0,
                AchievementsUnlocked = 0,
                QuestsCompleted = 0,
                QuestsDismissed = 0,
                FishCaught = 0,
                PlantsHarvested = 0,
                EggsHatched = 0,
                TilesTerraformed = 0,
                BuildingsConstructed = 0,
                NodesResearched = 0,
                ResearchCollected = 0,
                PowerCollected = 0,
                WaterCollected = 0,
                FoodCollected = 0,
                ConcreteCollected = 0,
                MetalCollected = 0,
                ItemsCollected = 0,
                UnitsCollected = 0,
                GoldCollected = 0,
                LootboxesCollected = 0,
                RushBoostsCollected = 0,
                ExperienceBoostsCollected = 0,
                RarityBoostsCollected = 0,
                MonsterEggsCollected = 0,
                FertilizerCollected = 0,
                MysterySeedsCollected = 0
            };

            // Initialize fish records, setting each type's weight record to 0
            var fishKeys = new string[]
            {
                "Robotic Fish Type A", "Robotic Fish Type B", "Robotic Fish Type C", "Robotic Fish Type D", "Robotic Fish Type E",
                "Robotic Fish Type F", "Robotic Fish Type G", "Robotic Fish Type H", "Robotic Fish Type I", "Robotic Fish Type J",
                "Robotic Fish Type K", "Robotic Fish Type L", "Robotic Fish Type M", "Robotic Fish Type N", "Robotic Fish Type O",
                "Robotic Fish Type P", "Robotic Fish Type Q", "Robotic Fish Type R", "Robotic Fish Type S", "Robotic Fish Type T",
                "Robotic Fish Type U", "Robotic Fish Type V", "Robotic Fish Type W", "Robotic Fish Type X", "Robotic Fish Type Y",
                "Robotic Fish Type Z"
            };
            statistics.FishRecords = new Dictionary<string, double>(fishKeys.Length);
            foreach (var k in fishKeys)
            {
                statistics.FishRecords[k] = 0;
            }

            ResearchTree researchTree = new() { ResearchNodes = new BindingList<ResearchNode>(ResearchTreeFactory.GetResearchTree()) };

            // Strings used for RNG
            List<string> missionFactoryNames = [
                "Defend the Castle", "Defend the Keep", "Defend the Tower", "Defend the Fort", "Defend the Outpost",
                "Defend the Encampment", "Defend the Watchtower", "Defend the Village", "Defend the Camp",
                "Guard the Castle", "Guard the Keep", "Guard the Tower", "Guard the Fort", "Guard the Outpost",
                "Guard the Encampment", "Guard the Watchtower", "Guard the Village", "Guard the Camp",
                "Protect the Castle", "Protect the Keep", "Protect the Tower", "Protect the Fort", "Protect the Outpost",
                "Protect the Encampment", "Protect the Watchtower", "Protect the Village", "Protect the Camp",
                "Secure the Castle", "Secure the Keep", "Secure the Tower", "Secure the Fort", "Secure the Outpost",
                "Secure the Encampment", "Secure the Watchtower", "Secure the Village", "Secure the Camp",
                "Reinforce the Castle", "Reinforce the Keep", "Reinforce the Tower", "Reinforce the Fort", "Reinforce the Outpost",
                "Reinforce the Encampment", "Reinforce the Watchtower", "Reinforce the Village", "Reinforce the Camp",
                "Reclaim the Castle", "Reclaim the Keep", "Reclaim the Tower", "Reclaim the Fort", "Reclaim the Outpost",
                "Reclaim the Encampment", "Reclaim the Watchtower", "Reclaim the Village", "Reclaim the Camp",
                "Patrol the Castle", "Patrol the Keep", "Patrol the Tower", "Patrol the Fort", "Patrol the Outpost",
                "Patrol the Encampment", "Patrol the Watchtower", "Patrol the Village", "Patrol the Camp",
                "Deliver to the Castle", "Deliver to the Keep", "Deliver to the Tower", "Deliver to the Fort", "Deliver to the Outpost",
                "Deliver to the Encampment", "Deliver to the Watchtower", "Deliver to the Village", "Deliver to the Camp",
                "Scout the Desert", "Scout the Mountain", "Scout the River", "Scout the Cave", "Scout the Lake", "Scout the Forest",
                "Explore the Desert", "Explore the Mountain", "Explore the River", "Explore the Cave", "Explore the Lake", "Explore the Forest",
                "Search the Desert", "Search the Mountain", "Search the River", "Search the Cave", "Search the Lake", "Search the Forest",
                "Map the Desert", "Map the Mountain", "Map the River", "Map the Cave", "Map the Lake", "Map the Forest",
                "Investigate the Desert", "Investigate the Mountain", "Investigate the River", "Investigate the Cave", "Investigate the Lake",
                "Investigate the Forest",
                "Build the Harbor", "Build the Barracks", "Build the Arena", "Build the Library", "Build the Market",
                "Build the Lighthouse", "Build the Dock", "Build the Workshop", "Build the Mine", "Build the Mill", "Build the Farm",
                "Rebuild the Harbor", "Rebuild the Barracks", "Rebuild the Arena", "Rebuild the Library", "Rebuild the Market",
                "Rebuild the Lighthouse", "Rebuild the Dock", "Rebuild the Workshop", "Rebuild the Mine", "Rebuild the Mill", "Rebuild the Farm",
                "Escort the Merchants", "Escort the Artisans", "Escort the Adventurers", "Escort the Travelers",
                "Recover the Artifact", "Recover the Treasure", "Recover the Map", "Recover the Cargo",
                "Retrieve the Artifact", "Retrieve the Treasure", "Retrieve the Map", "Retrieve the Cargo"
                ];

            List<string> unitFactoryNames = [
                "Alchemist", "Archaeologist", "Archer", "Artisan", "Bard", "Cleric", "Druid", "Mage", "Paladin",
                "Ranger", "Rogue", "Scribe", "Summoner", "Tamer", "Warrior", "Wizard"
                ];

            List<string> monsterUnitFactoryNames = [
                "Slime", "Bat", "Rat", "Spider", "Snake", "Slug", "Moth", "Snail", "Grub", "Crab"
                ];

            List<string> itemFactoryNames = [
                "Sword", "Axe", "Spear", "Dagger", "Staff", "Wand", "Shield", "Bow", "Crossbow",
                "Cloth Armor", "Leather Armor", "Chainmail Armor", "Plate Armor",
                "Health Potion", "Mana Potion", "Healing Salve", "Bandage",
                "Scroll of Fireball", "Scroll of Ice Blast", "Scroll of Mending",
                "Enchanted Thread", "Dragon Scale", "Glowing Fragment", "Spider Silk"
                ];

            List<string> junkItemFactoryNames = [
                "Lump of Coal", "Expired Coupon", "Dented Can", "Bent Spoon", "Rusted Bolt", "Junk Mail"
                ];

            List<string> plantItemFactoryNames = [
                "Red Plant", "Orange Plant", "Yellow Plant", "Green Plant", "Blue Plant", "Indigo Plant", "Violet Plant"
                ];

            var newPlayer = new Player
            {
                Name = name,

                Statistics = statistics,

                ResearchTree = researchTree,

                MissionFactoryNames = missionFactoryNames,
                UnitFactoryNames = unitFactoryNames,
                MonsterUnitFactoryNames = monsterUnitFactoryNames,
                ItemFactoryNames = itemFactoryNames,
                JunkItemFactoryNames = junkItemFactoryNames,
                PlantItemFactoryNames = plantItemFactoryNames
            };

            return newPlayer;
        }
    }
}