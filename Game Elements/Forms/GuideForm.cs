namespace Game_Elements
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent();

            // Initialize UI (properties, populate tree view, etc)
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, populate tree view, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            GuideTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            TopicsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            TopicsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            TopicsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            TopicsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            TopicsTreeView.BackColor = Properties.Settings.Default.SecondaryBackColor;
            TopicsTreeView.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            TopicsTreeView.Font = new Font(TopicsTreeView.Font.FontFamily, Properties.Settings.Default.SmallFontSize);
            TopicsTreeView.ItemHeight = TextRenderer.MeasureText("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-=!@#$%^&*()_+", TopicsTreeView.Font).Height;

            DescriptionBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            DescriptionBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            DescriptionTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            DescriptionTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            DescriptionTextBox.BackColor = Properties.Settings.Default.SecondaryBackColor;
            DescriptionTextBox.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            DescriptionTextBox.Font = new Font(DescriptionTextBox.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            // Populate tree view
            var A = new TreeNode()
            {
                Text = "Overview",
                Tag = "Game Elements is an idling mission table game.\r\n\r\n" +
                "A mission will automatically have units assigned to it, and then that mission will start automatically. After a period of time, the mission will succeed or fail. The outcome of the mission determines whether full or partial loot is awarded. The units assigned to the mission gain experience and gradually level up.\r\n\r\n" +
                "There are multiple player slots that are idling simultaneously. The < and > buttons on the bottom can be used to switch between them. Each player slot has its own missions, units, and so on. Each player slot can be customized, including modifying the pool of potential names for missions, units, and more. The text output at the top is only for the current player.\r\n\r\n" +
                "Some of the game features include tiles, buildings, a research tree, inventory, an item shop, lootboxes, quests, monster egg hatching, fishing, gardening, statistics, achievements, and more.\r\n\r\n" +
                "This is a work in progress. Aspects of it are subject to change."
            };
            var B = new TreeNode()
            {
                Text = "Missions",
                Tag = "A mission will automatically have units assigned to it. Three units are required for each mission. Once these units have been assigned, the mission will start automatically. After a period of time, the mission will succeed or fail.\r\n\r\n" +
                "Missions can have different rarity levels, ranging from common to legendary. Higher rarity missions take longer to complete and are more difficult, but they have better loot. If a mission fails, the units assigned to the mission gain a portion of the experience. If a mission succeeds, the units assigned to it gain the full experience and the player gains all the loot from the mission.\r\n\r\n" +
                "Success chance is influenced by multiple aspects: Mission level, rarity, and elements. Unit levels, rarities, and elements. Research tree nodes too. There is a limit to the number of missions a player can have in progress at once, but that number can be increased by constructing City Center buildings.\r\n\r\n" +
                "A mission can be rushed by using a rush boost to speed things up. Missions that aren't completed within a certain amount of time will expire and be removed. Missions are automatically generated so there will always be missions available to complete. Each player slot can customize the pool of potential mission names, so you can give each player slot a different theme if you prefer."
            };
            var C = new TreeNode()
            {
                Text = "Units",
                Tag = "A unit will automatically be assigned to a mission, as long as there are enough available units for a mission and the success chance wouldn't be too low. If a mission fails, the units assigned to it gain a portion of the experience. If a mission succeeds, the units assigned to it gain the full experience.\r\n\r\n" +
                "A unit that gains enough experience will have their level increased. When a unit levels up, there is a chance that they will unlock their element. A unit can also gain experience by using an experience boost. Similarly, their rarity can be improved by using a rarity boost. Higher rarity units have a higher chance of unlocking their element.\r\n\r\n" +
                "Level, rarity, and element are all used to determine an individual unit's contribution toward a mission's success chance. Units have a hydration and nourishment level that drop over time. They will automatically drink and eat, as long as the player has water and food. Units also have a happiness level that will increase or decrease depending on the water and food situation.\r\n\r\n" +
                "There is a limit to the number of units a player can have at once, but that number can be increased by constructing Dwelling buildings. Units can be released as long as they aren't currently assigned to a mission. Each player slot can customize the pool of potential unit names, so you can give each player slot a different theme if you prefer. Units can also be renamed at any time."
            };
            var D = new TreeNode()
            {
                Text = "Players",
                Tag = "A player or player slot has its own set of missions, units, inventory, tiles, quests, skills, and much more.\r\n\r\n" +
                "Each player idles simultaneously, with their units being assigned to their missions, whether they are the current player or not. You can switch between the players with the < and > buttons on the bottom. The text output at the top is only for the current player.\r\n\r\n" +
                "Each player can have its own theme if you customize the potential names for things like missions and units. Each player can also be renamed at any time.\r\n\r\n" +
                "Daily rewards are given for each player, based on their average unit happiness levels. (Low unit happiness levels = bad rewards.) The daily rewards are given the first time you switch to that player for the day."
            };
            var E = new TreeNode()
            {
                Text = "Tiles and Buildings",
                Tag = "A tile is a portion of the 2d grid. This grid can be navigated by clicking the four navigation buttons (up, down, left, right.) Each tile has its own terrain type. Different buildings can be constructed on these tiles, depending on the terrain types. Buildings can increase maximums and/or produce new things over time\r\n\r\n" +
                "A tile without a building can have its terrain type changed through terraforming. An empty tile can have a new building constructed on it. Construction time can vary depending upon the building type. After a building has been constructed, any relevant modifiers for maximums take affect immediately, and production starts right away for production-type buildings.\r\n\r\n" +
                "Buildings can be removed, but any corresponding modifiers will decrease. City center, dwelling, and storage buildings can't be removed if it would cause you to be over their respective maximum capacities.\r\n\r\n" +
                "Most production-type buildings require power to produce things. Terraforming, construction, and production can all be rushed by using a rush boost. Buildings can also be given custom names and custom paint.\r\n\r\n" +
                "Players don't start with any constructed buildings by default."
            };
            E.Nodes.Add(new TreeNode()
            {
                Text = "Terrain Types",
                Tag = "Water\r\nValid buildings: Water, Rush Boost, Monster Egg\r\n\r\n" +
                "Grassland\r\nValid buildings: City Center, Dwelling, Storage, Research, Power, Food, Fertilizer, Item, Unit, Gold\r\n\r\n" +
                "Desert\r\nValid buildings: City Center, Dwelling, Storage, Research, Power, Concrete, Item, Unit, Gold, Lootbox, Rarity Boost\r\n\r\n" +
                "Mountain\r\nValid buildings: Dwelling, Research, Metal, Lootbox, Experience Boost, Mystery Seed"
            });
            E.Nodes.Add(new TreeNode()
            {
                Text = "Building Types",
                Tag = "City Center\r\nMaterials required: 25 Concrete, 25 Metal | Construction duration: 300 seconds | Increases maximum in progress missions by 1\r\n\r\n" +
                "Dwelling\r\nMaterials required: 15 Concrete, 10 Metal | Construction duration: 150 seconds | Increases maximum units by 5\r\n\r\n" +
                "Storage\r\nMaterials required: 10 Concrete, 5 Metal | Construction duration: 90 seconds | Increases maximum items by 25\r\n\r\n" +
                "Research\r\nMaterials required: 6 Concrete, 4 Metal | Construction duration: 60 seconds | Produces research every 15 seconds\r\n\r\n" +
                "Power\r\nMaterials required: 3 Concrete, 7 Metal | Construction duration: 30 seconds | Increases maximum power by 100 | Produces power every 60 seconds\r\n\r\n" +
                "Water\r\nMaterials required: 2 Concrete, 3 Metal | Construction duration: 30 seconds | Increases maximum water by 50 | Produces water every 90 seconds\r\n\r\n" +
                "Food\r\nMaterials required: 3 Concrete, 2 Metal | Construction duration: 30 seconds | Increases maximum food by 50 | Produces food every 90 seconds\r\n\r\n" +
                "Concrete\r\nMaterials required: 6 Concrete, 4 Metal | Construction duration: 60 seconds | Increases maximum concrete by 25 | Produces concrete every 150 seconds\r\n\r\n" +
                "Metal\r\nMaterials required: 4 Concrete, 6 Metal | Construction duration: 60 seconds | Increases maximum metal by 25 | Produces metal every 150 seconds\r\n\r\n" +
                "Item\r\nMaterials required: 15 Concrete, 10 Metal | Construction duration: 150 seconds | Produces an item every 600 seconds\r\n\r\n" +
                "Unit\r\nMaterials required: 10 Concrete, 15 Metal | Construction duration: 150 seconds | Produces a unit every 600 seconds\r\n\r\n" +
                "Gold\r\nMaterials required: 5 Concrete, 10 Metal | Construction duration: 90 seconds | Increases maximum gold by 1000 | Produces gold every 45 seconds\r\n\r\n" +
                "Lootbox\r\nMaterials required: 10 Concrete, 15 Metal | Construction duration: 150 seconds | Increases maximum lootboxes by 5 | Produces lootboxes every 600 seconds\r\n\r\n" +
                "Rush Boost\r\nMaterials required: 5 Concrete, 10 Metal | Construction duration: 90 seconds | Increases maximum rush boosts by 10 | Produces rush boosts every 300 seconds\r\n\r\n" +
                "Experience Boost\r\nMaterials required: 10 Concrete, 5 Metal | Construction duration: 90 seconds | Increases maximum experience boosts by 10 | Produces experience boosts every 300 seconds\r\n\r\n" +
                "Rarity Boost\r\nMaterials required: 7 Concrete, 8 Metal | Construction duration: 90 seconds | Increases maximum rarity boosts by 10 | Produces rarity boosts every 300 seconds\r\n\r\n" +
                "Monster Egg\r\nMaterials required: 20 Concrete, 5 Metal | Construction duration: 150 seconds | Increases maximum monster eggs by 5 | Produces monster eggs every 600 seconds\r\n\r\n" +
                "Fertilizer\r\nMaterials required: 5 Concrete, 5 Metal | Construction duration: 60 seconds | Increases maximum fertilizer by 5 | Produces fertilizer every 150 seconds\r\n\r\n" +
                "Mystery Seed\r\nMaterials required: 5 Concrete, 20 Metal | Construction duration: 150 seconds | Increases maximum mystery seeds by 5 | Produces mystery seeds every 600 seconds"
            });
            var F = new TreeNode()
            {
                Text = "Research Tree",
                Tag = "A research tree is a collection of various nodes that can be researched to adjust several aspects of this game.\r\n\r\n" +
                "The research building produces the research necessary to research these nodes. You can queue any research node, and all the pre-requisites will automatically be queued first. The queue can also be cleared at any time.\r\n\r\n" +
                "Research is not stockpiled so if nothing is queued, then excess research will be discarded until something is queued up again\r\n\r\n" +
                "Players don't start with any research nodes queued by default."
            };
            var G = new TreeNode()
            {
                Text = "Inventory",
                Tag = "The inventory is where you can see your items and some of your resources. Items are things that you can sell for gold, and resources include things like building construction materials, boosts, lootboxes, etc.\r\n\r\n" +
                "Some of the resources that aren't visible in inventory can be seen at the bottom of the screen instead. Unlike items, resources can not be sold for gold. You can sell all of your items at once.\r\n\r\n" +
                "When you are at maximum capacity for items, units, and resources, any new additions are automatically discarded."
            };
            var H = new TreeNode()
            {
                Text = "Item Shop",
                Tag = "The item shop is where you can spend gold to buy resources. Only some of the resources are available for purchase."
            };
            var I = new TreeNode()
            {
                Text = "Lootbox",
                Tag = "A lootbox is a container you can open that contains four things. These things can be items, units, gold, boosts, construction materials, water, and food. Some resources types are not found in lootboxes and must be acquired through other methods."
            };
            var J = new TreeNode()
            {
                Text = "Quests",
                Tag = "A quest is a dynamically generated goal. An example would be starting 3 missions. Quests automatically complete once their criteria has been met.\r\n\r\n" +
                "A quest only gains progress toward completion for actions that occur while you have the quest. Quests give gold rewards when they are completed.\r\n\r\n" +
                "Quests come in different rarities, and higher rarity quests offer more gold but the criteria required for the quest to be completed is increased too.\r\n\r\n" +
                "Quests can be dismissed at any time. More quests are periodically generated to keep quests refilled. Additional quest slots can be gained through the research tree."
            };
            var K = new TreeNode()
            {
                Text = "Hatchery",
                Tag = "A monster egg is a special resource that can be placed in an egg hatcher slot. After a period of time, you will gain a new random unit.\r\n\r\n" +
                "Each player slot can customize the pool of potential monster unit names and the units that are generated from monster eggs use these names. Additional egg hatcher slots can be unlocked for gold."
            };
            var L = new TreeNode()
            {
                Text = "Fishing",
                Tag = "Fishing is a simple minigame where you cast and reel. Players have a fishing skill level that increases with use. There are multiple types of fish and your fish journal displays your records for each type.\r\n\r\n" +
                "The fish are strictly catch and release, but you can sometimes catch items from fishing too. The odds of catching items is also increased at higher skill levels. If you find the reel timer is too fast, the reel window can be increased through the research tree."
            };

            var M = new TreeNode()
            {
                Text = "Gardening",
                Tag = "Gardening is a simple minigame where you plant mystery seeds and harvest plants later. Players have a gardening skill level that increases with use.\r\n\r\n" +
                "A gardening plot has to be tilled before a mystery seed can be planted. Once a mystery seed is planted, it starts growing immediately. If you have them, you can speed things up by optionally adding water and fertilizer to a growing plant.\r\n\r\n" +
                "When a plant is ready, you can harvest it to gain an item with a plant name. These items are typically worth more gold than other items, and you can sell them just like other items. As your skill level improves, the odds of a gardening plot needing to be retilled decreases, and the odds of gaining mystery seeds during harvesting increases.\r\n\r\n" +
                "Each player slot can customize the pool of potential plant names and the items that are harvested from mystery seeds use these names. Additional gardening plots can be unlocked for gold."
            };
            var N = new TreeNode()
            {
                Text = "Statistics",
                Tag = "The statistics screen allows you to see some of the stats for the current player."
            };
            var O = new TreeNode()
            {
                Text = "Achievements",
                Tag = "An achievement is something that unlocks once a particular milestone has been reached. The description for an achievement is hidden until that achievement has been unlocked. Achievements award gold when unlocked, and some achievements even add extra modifiers to increase specific maximums.\r\n\r\n" +
                "When an achievement is unlocked, a toast notification will appear in addition to the usual text output. Newly unlocked achievements will appear visually different from locked achievements. Move the mouse over them or use the mark all as seen button to remove this effect."
            };

            TopicsTreeView.BeginUpdate();
            TopicsTreeView.Nodes.Add(A);
            TopicsTreeView.Nodes.Add(B);
            TopicsTreeView.Nodes.Add(C);
            TopicsTreeView.Nodes.Add(D);
            TopicsTreeView.Nodes.Add(E);
            TopicsTreeView.Nodes.Add(F);
            TopicsTreeView.Nodes.Add(G);
            TopicsTreeView.Nodes.Add(H);
            TopicsTreeView.Nodes.Add(I);
            TopicsTreeView.Nodes.Add(J);
            TopicsTreeView.Nodes.Add(K);
            TopicsTreeView.Nodes.Add(L);
            TopicsTreeView.Nodes.Add(M);
            TopicsTreeView.Nodes.Add(N);
            TopicsTreeView.Nodes.Add(O);
            TopicsTreeView.EndUpdate();
        }

        private void TopicsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Populate the description textbox for the selected tree view node
            if (TopicsTreeView.SelectedNode != null && TopicsTreeView.SelectedNode.Tag != null)
                DescriptionTextBox.Text = TopicsTreeView.SelectedNode.Tag.ToString();
        }
    }
}