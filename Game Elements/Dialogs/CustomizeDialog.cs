using Game_Elements.Engine;

namespace Game_Elements
{
    public partial class CustomizeDialog : Form
    {
        private readonly string[] _defaultMissionNames = [
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
        private readonly string[] _defaultUnitNames = [
            "Alchemist", "Archaeologist", "Archer", "Artisan", "Bard", "Cleric", "Druid", "Mage", "Paladin",
            "Ranger", "Rogue", "Scribe", "Summoner", "Tamer", "Warrior", "Wizard"
            ];
        private readonly string[] _defaultMonsterUnitNames = [
            "Slime", "Bat", "Rat", "Spider", "Snake", "Slug", "Moth", "Snail", "Grub", "Crab"
            ];
        private readonly string[] _defaultItemNames = [
            "Sword", "Axe", "Spear", "Dagger", "Staff", "Wand", "Shield", "Bow", "Crossbow",
            "Cloth Armor", "Leather Armor", "Chainmail Armor", "Plate Armor",
            "Health Potion", "Mana Potion", "Healing Salve", "Bandage",
            "Scroll of Fireball", "Scroll of Ice Blast", "Scroll of Mending",
            "Enchanted Thread", "Dragon Scale", "Glowing Fragment", "Spider Silk"
            ];
        private readonly string[] _defaultJunkItemNames = [
            "Lump of Coal", "Expired Coupon", "Dented Can", "Bent Spoon", "Rusted Bolt", "Junk Mail"
            ];
        private readonly string[] _defaultPlantItemNames = [
            "Red Plant", "Orange Plant", "Yellow Plant", "Green Plant", "Blue Plant", "Indigo Plant", "Violet Plant"
            ];

        public string[] NewMissionNames => MissionNamesTextBox.Text.Trim() != string.Empty ? MissionNamesTextBox.Lines : _defaultMissionNames;
        public string[] NewUnitNames => UnitNamesTextBox.Text.Trim() != string.Empty ? UnitNamesTextBox.Lines : _defaultUnitNames;
        public string[] NewMonsterUnitNames => MonsterUnitNamesTextBox.Text.Trim() != string.Empty ? MonsterUnitNamesTextBox.Lines : _defaultMonsterUnitNames;
        public string[] NewItemNames => ItemNamesTextBox.Text.Trim() != string.Empty ? ItemNamesTextBox.Lines : _defaultItemNames;
        public string[] NewJunkItemNames => JunkItemNamesTextBox.Text.Trim() != string.Empty ? JunkItemNamesTextBox.Lines : _defaultJunkItemNames;
        public string[] NewPlantItemNames => PlantItemNamesTextBox.Text.Trim() != string.Empty ? PlantItemNamesTextBox.Lines : _defaultPlantItemNames;

        public CustomizeDialog(int playerIndex)
        {
            InitializeComponent();

            // Initialize UI (properties, etc)
            InitializeUI();

            // Update UI elements for current player
            UpdateUI(playerIndex);
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            CustomizeDialogTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;
            CustomizeDialogTLP.Padding = new Padding(Properties.Settings.Default.Padding);

            CustomizeLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            CustomizeLabel.Font = new Font(CustomizeLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MissionNamesLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MissionNamesLabel.Font = new Font(MissionNamesLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MissionNamesTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            MissionNamesTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MissionNamesTextBox.Font = new Font(MissionNamesTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            UnitNamesLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UnitNamesLabel.Font = new Font(UnitNamesLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            UnitNamesTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            UnitNamesTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UnitNamesTextBox.Font = new Font(UnitNamesTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MonsterUnitNamesLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MonsterUnitNamesLabel.Font = new Font(MonsterUnitNamesLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            MonsterUnitNamesTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            MonsterUnitNamesTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            MonsterUnitNamesTextBox.Font = new Font(MonsterUnitNamesTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ItemNamesLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ItemNamesLabel.Font = new Font(ItemNamesLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            ItemNamesTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            ItemNamesTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            ItemNamesTextBox.Font = new Font(ItemNamesTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            JunkItemNamesLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            JunkItemNamesLabel.Font = new Font(JunkItemNamesLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            JunkItemNamesTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            JunkItemNamesTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            JunkItemNamesTextBox.Font = new Font(JunkItemNamesTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            PlantItemNamesLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PlantItemNamesLabel.Font = new Font(PlantItemNamesLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            PlantItemNamesTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            PlantItemNamesTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PlantItemNamesTextBox.Font = new Font(PlantItemNamesTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            OkButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            OkButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            OkButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            OkButton.Font = new Font(OkButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            CancelCustomizeButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            CancelCustomizeButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            CancelCustomizeButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            CancelCustomizeButton.Font = new Font(CancelCustomizeButton.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
        }

        private void UpdateUI(int playerIndex)
        {
            // Update UI elements for current player

            if (GameManager.Players.Count == 0 || playerIndex == -1)
                return;

            MissionNamesTextBox.Lines = [.. GameManager.Players[playerIndex].MissionFactoryNames];

            UnitNamesTextBox.Lines = [.. GameManager.Players[playerIndex].UnitFactoryNames];
            MonsterUnitNamesTextBox.Lines = [.. GameManager.Players[playerIndex].MonsterUnitFactoryNames];

            ItemNamesTextBox.Lines = [.. GameManager.Players[playerIndex].ItemFactoryNames];
            JunkItemNamesTextBox.Lines = [.. GameManager.Players[playerIndex].JunkItemFactoryNames];
            PlantItemNamesTextBox.Lines = [.. GameManager.Players[playerIndex].PlantItemFactoryNames];
        }
    }
}