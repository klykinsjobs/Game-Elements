using Game_Elements.Data;
using Game_Elements.Engine;
using Game_Elements.Enums;
using Game_Elements.Factories;
using Game_Elements.Models;
using Game_Elements.Services;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Game_Elements
{
    public partial class TilesForm : Form
    {
        private int viewRow = 2;
        private int viewColumn = 2;

        private const int viewRows = 4;
        private const int viewColumns = 6;

        public const int tileGridRows = 11;
        public const int tileGridColumns = 11;

        private Tile? _selectedTile = null;

        private readonly Button[,] viewButtons;
        private readonly Panel[,] viewPanels;

        public TilesForm()
        {
            InitializeComponent();

            // Initialize arrays
            viewButtons = new Button[viewRows, viewColumns]
            {
                { button1, button2, button3, button4, button5, button6 },
                { button7, button8, button9, button10, button11, button12 },
                { button13, button14, button15, button16, button17, button18 },
                { button19, button20, button21, button22, button23, button24 }
            };
            viewPanels = new Panel[viewRows, viewColumns]
            {
                { panel1, panel2, panel3, panel4, panel5, panel6 },
                { panel7, panel8, panel9, panel10, panel11, panel12 },
                { panel13, panel14, panel15, panel16, panel17, panel18 },
                { panel19, panel20, panel21, panel22, panel23, panel24 }
            };

            // Initialize UI (properties, etc)
            InitializeUI();

            // Event subscriptions
            GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Tiles.ListChanged += Tiles_ListChanged;
            }

            // Update UI elements for current player
            UpdateGrid();
            UpdateUI();
        }

        private void TilesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Deselect selection (which will unsubscribe)
            if (_selectedTile != null)
                DeselectTile();

            // Dispose tool tip
            TilesToolTip.Dispose();

            // Unsubscribe
            GameManager.CurrentPlayerChanged -= GameManager_CurrentPlayerChanged;
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Tiles.ListChanged -= Tiles_ListChanged;
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

            // Deselect selection (which will unsubscribe)
            if (_selectedTile != null)
                DeselectTile();

            // Unsubscribe from previous player's events
            if (previousPlayer != null)
            {
                previousPlayer.Tiles.ListChanged -= Tiles_ListChanged;
            }

            // Subscribe to new player's events
            if (GameManager.CurrentPlayer != null)
            {
                GameManager.CurrentPlayer.Tiles.ListChanged += Tiles_ListChanged;
            }

            // Update UI elements for new player
            viewRow = 2;
            viewColumn = 2;
            UpdateGrid();
            UpdateUI();
        }

        private void SelectedTile_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Tile.Elapsed)
                || e.PropertyName == nameof(Tile.PendingBuildingType)
                || e.PropertyName == nameof(Tile.PendingTerrainType)
                || e.PropertyName == nameof(Tile.Building)
                || e.PropertyName == nameof(Tile.TileState))
            {
                // Update UI to reflect changes
                UpdateUI();
            }
        }

        private void Tiles_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset)
            {
                // Update UI to reflect changes
                UpdateGrid();
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null)
            {
                if (e.PropertyDescriptor.PropertyType == typeof(BuildingType)
                    || e.PropertyDescriptor.PropertyType == typeof(TerrainType))
                {
                    // Update UI to reflect changes
                    UpdateGrid();
                }
                else if (e.PropertyDescriptor.Name == "Terrain" || e.PropertyDescriptor.Name == "Building")
                {
                    // Update UI to reflect changes
                    UpdateGrid();
                }
            }
        }

        private void InitializeUI()
        {
            // Initialize UI (properties, etc)

            BackColor = Properties.Settings.Default.PrimaryBackColor;

            TilesTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            GridBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            GridBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            GridTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            GridTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            ControlsBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            ControlsTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            ControlsTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            StatusLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            StatusLabel.Font = new Font(StatusLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            RushButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            RushButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RushButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            RushButton.Font = new Font(RushButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            TerraformButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            TerraformButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            TerraformButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            TerraformButton.Font = new Font(TerraformButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            AddBuildingButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            AddBuildingButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            AddBuildingButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            AddBuildingButton.Font = new Font(AddBuildingButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            RemoveBuildingButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            RemoveBuildingButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RemoveBuildingButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            RemoveBuildingButton.Font = new Font(RemoveBuildingButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            RenameBuildingButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            RenameBuildingButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RenameBuildingButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            RenameBuildingButton.Font = new Font(RenameBuildingButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            PaintBuildingButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            PaintBuildingButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            PaintBuildingButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            PaintBuildingButton.Font = new Font(PaintBuildingButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            UpButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            UpButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            UpButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            UpButton.Font = new Font(UpButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            DownButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            DownButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            DownButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            DownButton.Font = new Font(DownButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            LeftButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            LeftButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            LeftButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            LeftButton.Font = new Font(LeftButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            RightButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            RightButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            RightButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            RightButton.Font = new Font(RightButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            SelectionBackPanel.Padding = new Padding(Properties.Settings.Default.Padding);
            SelectionBackPanel.BackColor = Properties.Settings.Default.SecondaryBackColor;

            SelectionTLP.Padding = new Padding(Properties.Settings.Default.Padding);
            SelectionTLP.BackColor = Properties.Settings.Default.PrimaryBackColor;

            DeselectButton.BackColor = Properties.Settings.Default.SecondaryBackColor;
            DeselectButton.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            DeselectButton.FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
            DeselectButton.Font = new Font(DeselectButton.Font.FontFamily, Properties.Settings.Default.MediumFontSize);

            SelectionLabel.ForeColor = Properties.Settings.Default.PrimaryForeColor;
            SelectionLabel.Font = new Font(SelectionLabel.Font.FontFamily, Properties.Settings.Default.SmallFontSize);

            // Store point in Tag and attach a common click handler
            for (int r = 0; r < viewRows; r++)
            {
                for (int c = 0; c < viewColumns; c++)
                {
                    // Panels
                    viewPanels[r, c].BackColor = Properties.Settings.Default.SecondaryBackColor;
                    viewPanels[r, c].Padding = new Padding(Properties.Settings.Default.Padding);
                    viewPanels[r, c].Tag = new Point(r, c);
                    viewPanels[r, c].Click += ViewButton_Click;

                    // Buttons
                    viewButtons[r, c].BackColor = Properties.Settings.Default.SecondaryBackColor;
                    viewButtons[r, c].ForeColor = Properties.Settings.Default.PrimaryForeColor;
                    viewButtons[r, c].FlatAppearance.MouseOverBackColor = Properties.Settings.Default.MouseOverBackColor;
                    viewButtons[r, c].Font = new Font(viewButtons[r, c].Font.FontFamily, Properties.Settings.Default.SmallFontSize);
                    viewButtons[r, c].Tag = new Point(r, c);
                    viewButtons[r, c].Click += ViewButton_Click;
                }
            }
        }

        public void UpdateGrid()
        {
            // Update grid for current player

            if (GameManager.CurrentPlayer == null)
                return;

            // Update the grid controls
            for (int row = 0; row < viewRows; row++)
            {
                for (int column = 0; column < viewColumns; column++)
                {
                    int r = viewRow + row;
                    int c = viewColumn + column;

                    if (r < tileGridRows && c < tileGridColumns)
                    {
                        var tile = GameManager.CurrentPlayer.Tiles.FirstOrDefault(t => t.X == r && t.Y == c);
                        if (tile == null) continue;

                        // Terrain color
                        viewPanels[row, column].BackColor = tile.Terrain switch
                        {
                            TerrainType.Water => Properties.Settings.Default.WaterTerrainColor,
                            TerrainType.Grassland => Properties.Settings.Default.GrasslandTerrainColor,
                            TerrainType.Desert => Properties.Settings.Default.DesertTerrainColor,
                            TerrainType.Mountain => Properties.Settings.Default.MountainTerrainColor,
                            _ => Color.OrangeRed
                        };

                        if (tile.Building != null)
                        {
                            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);

                            // Building color
                            viewButtons[row, column].BackColor = tile.CustomBuildingColor ?? playerIndex switch
                            {
                                0 => Properties.Settings.Default.P1BuildingColor,
                                1 => Properties.Settings.Default.P2BuildingColor,
                                2 => Properties.Settings.Default.P3BuildingColor,
                                3 => Properties.Settings.Default.P4BuildingColor,
                                _ => Color.OrangeRed
                            };

                            // Building name
                            viewButtons[row, column].Text = tile.CustomBuildingName ?? tile.Building switch
                            {
                                BuildingType.CityCenter => "City Center",
                                BuildingType.Dwelling => "Dwelling",
                                BuildingType.Storage => "Storage",
                                BuildingType.ResearchMaker => "Research Maker",
                                BuildingType.PowerMaker => "Power Maker",
                                BuildingType.WaterMaker => "Water Maker",
                                BuildingType.FoodMaker => "Food Maker",
                                BuildingType.ConcreteMaker => "Concrete Maker",
                                BuildingType.MetalMaker => "Metal Maker",
                                BuildingType.ItemMaker => "Item Maker",
                                BuildingType.UnitMaker => "Unit Maker",
                                BuildingType.GoldMaker => "Gold Maker",
                                BuildingType.LootboxMaker => "Lootbox Maker",
                                BuildingType.RushBoostMaker => "Rush Boost Maker",
                                BuildingType.ExperienceBoostMaker => "Experience Boost Maker",
                                BuildingType.RarityBoostMaker => "Rarity Boost Maker",
                                BuildingType.MonsterEggMaker => "Monster Egg Maker",
                                BuildingType.FertilizerMaker => "Fertilizer Maker",
                                BuildingType.MysterySeedMaker => "Mystery Seed Maker",
                                _ => "Unknown Building"
                            };

                            // Show button when building exists
                            viewButtons[row, column].Visible = true;
                        }
                        else
                        {
                            // Hide button when no building exists
                            viewButtons[row, column].Visible = false;
                        }

                        // Build tooltip with relevant tile details
                        string toolTipCaption = "";
                        if (tile.Building != null)
                        {
                            // Building and terrain details when building exists
                            toolTipCaption = $"{tile.CustomBuildingName ?? tile.Building switch
                            {
                                BuildingType.CityCenter => "City Center",
                                BuildingType.Dwelling => "Dwelling",
                                BuildingType.Storage => "Storage",
                                BuildingType.ResearchMaker => "Research Maker",
                                BuildingType.PowerMaker => "Power Maker",
                                BuildingType.WaterMaker => "Water Maker",
                                BuildingType.FoodMaker => "Food Maker",
                                BuildingType.ConcreteMaker => "Concrete Maker",
                                BuildingType.MetalMaker => "Metal Maker",
                                BuildingType.ItemMaker => "Item Maker",
                                BuildingType.UnitMaker => "Unit Maker",
                                BuildingType.GoldMaker => "Gold Maker",
                                BuildingType.LootboxMaker => "Lootbox Maker",
                                BuildingType.RushBoostMaker => "Rush Boost Maker",
                                BuildingType.ExperienceBoostMaker => "Experience Boost Maker",
                                BuildingType.RarityBoostMaker => "Rarity Boost Maker",
                                BuildingType.MonsterEggMaker => "Monster Egg Maker",
                                BuildingType.FertilizerMaker => "Fertilizer Maker",
                                BuildingType.MysterySeedMaker => "Mystery Seed Maker",
                                _ => "Unknown Building"
                            }}\n({tile.Terrain})";
                        }
                        else
                        {
                            // Terrain details only when no building exists
                            toolTipCaption = $"({tile.Terrain})";
                        }

                        // Set tooltips
                        string? currentToolTip = TilesToolTip.GetToolTip(viewPanels[row, column]);
                        if (currentToolTip != toolTipCaption)
                        {
                            TilesToolTip.SetToolTip(viewButtons[row, column], toolTipCaption);
                            TilesToolTip.SetToolTip(viewPanels[row, column], toolTipCaption);
                        }
                    }
                    else
                    {
                        // Reset button
                        viewButtons[row, column].BackColor = Properties.Settings.Default.SecondaryBackColor;
                        viewButtons[row, column].Text = "";
                        viewButtons[row, column].Visible = false;

                        // Reset tooltips
                        TilesToolTip.SetToolTip(viewButtons[row, column], "");
                        TilesToolTip.SetToolTip(viewPanels[row, column], "");
                    }
                }
            }

            // Navigation
            UpButton.Enabled = viewRow > 0;
            DownButton.Enabled = viewRow + viewRows < tileGridRows;
            LeftButton.Enabled = viewColumn > 0;
            RightButton.Enabled = viewColumn + viewColumns < tileGridColumns;

            // If the current view no longer contains the selection, then deselect
            if (_selectedTile != null)
            {
                if (_selectedTile.X < viewRow || _selectedTile.X >= viewRow + viewRows
                    || _selectedTile.Y < viewColumn || _selectedTile.Y >= viewColumn + viewColumns)
                {
                    DeselectTile();
                    UpdateUI();
                }
            }
        }

        private void UpdateUI()
        {
            // Update UI elements for current player

            if (_selectedTile != null)
            {
                DeselectButton.Enabled = true;

                var progress = _selectedTile.Elapsed.TotalSeconds / _selectedTile.Duration.TotalSeconds;
                ProgressPB.Value = Math.Clamp((int)(progress * 100), 0, 100);

                if (_selectedTile.Building != null)
                {
                    // Building and terrain details when building exists
                    SelectionLabel.Text = $"Selected: {_selectedTile.CustomBuildingName ?? _selectedTile.Building switch
                    {
                        BuildingType.CityCenter => "City Center",
                        BuildingType.Dwelling => "Dwelling",
                        BuildingType.Storage => "Storage",
                        BuildingType.ResearchMaker => "Research Maker",
                        BuildingType.PowerMaker => "Power Maker",
                        BuildingType.WaterMaker => "Water Maker",
                        BuildingType.FoodMaker => "Food Maker",
                        BuildingType.ConcreteMaker => "Concrete Maker",
                        BuildingType.MetalMaker => "Metal Maker",
                        BuildingType.ItemMaker => "Item Maker",
                        BuildingType.UnitMaker => "Unit Maker",
                        BuildingType.GoldMaker => "Gold Maker",
                        BuildingType.LootboxMaker => "Lootbox Maker",
                        BuildingType.RushBoostMaker => "Rush Boost Maker",
                        BuildingType.ExperienceBoostMaker => "Experience Boost Maker",
                        BuildingType.RarityBoostMaker => "Rarity Boost Maker",
                        BuildingType.MonsterEggMaker => "Monster Egg Maker",
                        BuildingType.FertilizerMaker => "Fertilizer Maker",
                        BuildingType.MysterySeedMaker => "Mystery Seed Maker",
                        _ => "Unknown Building"
                    }} ({_selectedTile.Terrain})";

                    // Status
                    if (_selectedTile.Building == BuildingType.CityCenter || _selectedTile.Building == BuildingType.Dwelling || _selectedTile.Building == BuildingType.Storage)
                        StatusLabel.Text = "";
                    else
                        StatusLabel.Text = "Producing";

                    RushButton.Enabled = _selectedTile.TileState == TileState.Producing;
                    TerraformButton.Enabled = false;
                    AddBuildingButton.Enabled = false;
                    RemoveBuildingButton.Enabled = true;
                    RenameBuildingButton.Enabled = true;
                    PaintBuildingButton.Enabled = true;
                }
                else
                {
                    // Terrain details only when no building exists
                    SelectionLabel.Text = $"Selected: ({_selectedTile.Terrain})";

                    // Status
                    if (_selectedTile.PendingTerrainType != null)
                        StatusLabel.Text = "Terraforming";
                    else if (_selectedTile.PendingBuildingType != null)
                        StatusLabel.Text = "Constructing";
                    else
                        StatusLabel.Text = "";

                    RushButton.Enabled = _selectedTile.TileState == TileState.Terraforming || _selectedTile.TileState == TileState.Constructing;
                    TerraformButton.Enabled = _selectedTile.TileState != TileState.Terraforming && _selectedTile.TileState != TileState.Constructing;
                    AddBuildingButton.Enabled = _selectedTile.TileState != TileState.Terraforming && _selectedTile.TileState != TileState.Constructing;
                    RemoveBuildingButton.Enabled = false;
                    RenameBuildingButton.Enabled = false;
                    PaintBuildingButton.Enabled = false;
                }
            }
            else
            {
                DeselectButton.Enabled = false;
                ProgressPB.Value = 0;
                SelectionLabel.Text = "Selected: None";
                StatusLabel.Text = "";
                RushButton.Enabled = false;
                TerraformButton.Enabled = false;
                AddBuildingButton.Enabled = false;
                RemoveBuildingButton.Enabled = false;
                RenameBuildingButton.Enabled = false;
                PaintBuildingButton.Enabled = false;
            }
        }

        private void SelectTile(int x, int y)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            // Deselect if anything already selected
            if (_selectedTile != null)
                DeselectTile();

            if (x >= 0 && x < tileGridRows && y >= 0 && y < tileGridColumns)
            {
                // Get new selection
                _selectedTile = GameManager.CurrentPlayer.Tiles.FirstOrDefault(t => t.X == x && t.Y == y);
                if (_selectedTile != null)
                {
                    // Subscribe to its property changes
                    _selectedTile.PropertyChanged += SelectedTile_PropertyChanged;
                }
            }

            // Update UI to reflect changes
            UpdateUI();
        }

        private void ViewButton_Click(object? sender, EventArgs e)
        {
            // Ensure sender is a control and it's tag is a point
            if (sender is not Control control) return;
            if (control.Tag is not Point p) return;

            // Get x and y from point
            int viewR = p.X;
            int viewC = p.Y;

            // Adjust for current view
            int actualR = viewRow + viewR;
            int actualC = viewColumn + viewC;

            // Select the tile
            SelectTile(actualR, actualC);
        }

        private void DeselectTile()
        {
            if (_selectedTile != null)
            {
                // Unsubscribe
                _selectedTile.PropertyChanged -= SelectedTile_PropertyChanged;

                // Reset
                _selectedTile = null;
            }
        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            if (_selectedTile != null)
            {
                DeselectTile();
                UpdateUI();
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            // Move the view up by one row
            if (viewRow > 0)
            {
                viewRow--;
                UpdateGrid();
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            // Move the view down by one row
            if (viewRow + viewRows < tileGridRows)
            {
                viewRow++;
                UpdateGrid();
            }
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            // Move the view left by one column
            if (viewColumn > 0)
            {
                viewColumn--;
                UpdateGrid();
            }
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            // Move the view right by one column
            if (viewColumn + viewColumns < tileGridColumns)
            {
                viewColumn++;
                UpdateGrid();
            }
        }

        private void AddBuilding(BuildingType buildingType)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedTile == null || _selectedTile.Building != null)
                return;

            // Look up building specs
            var (constructionDuration, _, _, _, _, constructionMaterials, _) = TileFactory.BuildingLookups()[buildingType];

            // Get construction material cost
            Loot lootToRemove = new()
            {
                LootQuantities = constructionMaterials
            };

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex != -1)
            {
                // Remove construction materials
                if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                {
                    // Set relevant tile properties for this building type
                    _selectedTile.PendingBuildingType = buildingType;
                    _selectedTile.Elapsed = TimeSpan.Zero;
                    _selectedTile.Duration = TimeSpan.FromMilliseconds(constructionDuration);
                    _selectedTile.TileState = TileState.Constructing;

                    OutputService.Write(true, [new($"Construction started on new building", Properties.Settings.Default.PrimaryForeColor)]);
                }
                else
                {
                    // Build output
                    StringBuilder stringBuilder = new("Failed to start construction on new building due to missing construction materials. Materials required: ");
                    foreach (var material in constructionMaterials)
                        stringBuilder.Append($"{material.Value}x {material.Key} ");

                    OutputService.Write(true, [new(stringBuilder.ToString().TrimEnd(), Properties.Settings.Default.ErrorTextColor)]);
                }
            }
        }

        private void AddBuildingButton_Click(object sender, EventArgs e)
        {
            if (_selectedTile != null && _selectedTile.Building == null)
            {
                ContextMenuStrip addBuildingMenu = new();

                // Populate context menu with all the building types that can be constructed on this tile
                if (_selectedTile.Terrain == TerrainType.Water)
                {
                    addBuildingMenu.Items.Add("Water Maker", null, (s, e) => AddBuilding(BuildingType.WaterMaker));
                    addBuildingMenu.Items.Add("Rush Boost Maker", null, (s, e) => AddBuilding(BuildingType.RushBoostMaker));
                    addBuildingMenu.Items.Add("Monster Egg Maker", null, (s, e) => AddBuilding(BuildingType.MonsterEggMaker));
                }
                else if (_selectedTile.Terrain == TerrainType.Grassland)
                {
                    addBuildingMenu.Items.Add("City Center", null, (s, e) => AddBuilding(BuildingType.CityCenter));
                    addBuildingMenu.Items.Add("Dwelling", null, (s, e) => AddBuilding(BuildingType.Dwelling));
                    addBuildingMenu.Items.Add("Storage", null, (s, e) => AddBuilding(BuildingType.Storage));
                    addBuildingMenu.Items.Add("Research Maker", null, (s, e) => AddBuilding(BuildingType.ResearchMaker));
                    addBuildingMenu.Items.Add("Power Maker", null, (s, e) => AddBuilding(BuildingType.PowerMaker));
                    addBuildingMenu.Items.Add("Food Maker", null, (s, e) => AddBuilding(BuildingType.FoodMaker));
                    addBuildingMenu.Items.Add("Fertilizer Maker", null, (s, e) => AddBuilding(BuildingType.FertilizerMaker));
                    addBuildingMenu.Items.Add("Item Maker", null, (s, e) => AddBuilding(BuildingType.ItemMaker));
                    addBuildingMenu.Items.Add("Unit Maker", null, (s, e) => AddBuilding(BuildingType.UnitMaker));
                    addBuildingMenu.Items.Add("Gold Maker", null, (s, e) => AddBuilding(BuildingType.GoldMaker));
                }
                else if (_selectedTile.Terrain == TerrainType.Desert)
                {
                    addBuildingMenu.Items.Add("City Center", null, (s, e) => AddBuilding(BuildingType.CityCenter));
                    addBuildingMenu.Items.Add("Dwelling", null, (s, e) => AddBuilding(BuildingType.Dwelling));
                    addBuildingMenu.Items.Add("Storage", null, (s, e) => AddBuilding(BuildingType.Storage));
                    addBuildingMenu.Items.Add("Research Maker", null, (s, e) => AddBuilding(BuildingType.ResearchMaker));
                    addBuildingMenu.Items.Add("Power Maker", null, (s, e) => AddBuilding(BuildingType.PowerMaker));
                    addBuildingMenu.Items.Add("Concrete Maker", null, (s, e) => AddBuilding(BuildingType.ConcreteMaker));
                    addBuildingMenu.Items.Add("Item Maker", null, (s, e) => AddBuilding(BuildingType.ItemMaker));
                    addBuildingMenu.Items.Add("Unit Maker", null, (s, e) => AddBuilding(BuildingType.UnitMaker));
                    addBuildingMenu.Items.Add("Gold Maker", null, (s, e) => AddBuilding(BuildingType.GoldMaker));
                    addBuildingMenu.Items.Add("Lootbox Maker", null, (s, e) => AddBuilding(BuildingType.LootboxMaker));
                    addBuildingMenu.Items.Add("Rarity Boost Maker", null, (s, e) => AddBuilding(BuildingType.RarityBoostMaker));
                }
                else if (_selectedTile.Terrain == TerrainType.Mountain)
                {
                    addBuildingMenu.Items.Add("Dwelling", null, (s, e) => AddBuilding(BuildingType.Dwelling));
                    addBuildingMenu.Items.Add("Research Maker", null, (s, e) => AddBuilding(BuildingType.ResearchMaker));
                    addBuildingMenu.Items.Add("Metal Maker", null, (s, e) => AddBuilding(BuildingType.MetalMaker));
                    addBuildingMenu.Items.Add("Lootbox Maker", null, (s, e) => AddBuilding(BuildingType.LootboxMaker));
                    addBuildingMenu.Items.Add("Experience Boost Maker", null, (s, e) => AddBuilding(BuildingType.ExperienceBoostMaker));
                    addBuildingMenu.Items.Add("Mystery Seed Maker", null, (s, e) => AddBuilding(BuildingType.MysterySeedMaker));
                }

                addBuildingMenu.Show(Cursor.Position);
            }
        }

        private void Terraform(TerrainType terrainType)
        {
            if (_selectedTile != null && _selectedTile.Building == null)
            {
                // Set relevant tile properties for terraforming
                _selectedTile.PendingTerrainType = terrainType;
                _selectedTile.Duration = TimeSpan.FromMilliseconds(StarterValues.TerraformingDuration);
                _selectedTile.TileState = TileState.Terraforming;
            }
        }

        private void TerraformButton_Click(object sender, EventArgs e)
        {
            if (_selectedTile != null && _selectedTile.Building == null)
            {
                ContextMenuStrip terraformMenu = new();

                // Populate context menu with all the terrain types that this tile can be terraformed to
                if (_selectedTile.Terrain != TerrainType.Water)
                    terraformMenu.Items.Add("Water", null, (s, e) => Terraform(TerrainType.Water));
                if (_selectedTile.Terrain != TerrainType.Grassland)
                    terraformMenu.Items.Add("Grassland", null, (s, e) => Terraform(TerrainType.Grassland));
                if (_selectedTile.Terrain != TerrainType.Desert)
                    terraformMenu.Items.Add("Desert", null, (s, e) => Terraform(TerrainType.Desert));
                if (_selectedTile.Terrain != TerrainType.Mountain)
                    terraformMenu.Items.Add("Mountain", null, (s, e) => Terraform(TerrainType.Mountain));

                terraformMenu.Show(Cursor.Position);
            }
        }

        private void RushButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedTile == null || _selectedTile.IsDone)
                return;

            if (GameManager.CurrentPlayer.Inventory.RushBoosts < 1)
            {
                OutputService.Write(true, [new("No rush boosts available.", Properties.Settings.Default.ErrorTextColor)]);
            }
            else
            {
                Loot lootToRemove = new();
                lootToRemove.LootQuantities.Add(LootType.RushBoost, 1);

                int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
                if (playerIndex != -1)
                {
                    // Remove rush boost
                    if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove))
                    {
                        // Boost elapsed
                        _selectedTile.Elapsed = _selectedTile.Duration;

                        if (_selectedTile.TileState != TileState.Idle)
                        {
                            // Output
                            string tileState = _selectedTile.TileState switch
                            {
                                TileState.Terraforming => "Terraforming",
                                TileState.Constructing => "Construction",
                                TileState.Producing => "Production",
                                _ => "Unknown TileState"
                            };
                            OutputService.Write(true, [new($"{tileState} was rushed using a boost!", Properties.Settings.Default.PrimaryForeColor)]);
                        }

                        // Update quests and statistics
                        GameManager.CurrentPlayer.Statistics.RushBoostsUsed += 1;
                        GameManager.TryQuestProgress(playerIndex, QuestType.UseRushBoost, 1);
                    }
                    else
                    {
                        OutputService.Write(true, [new("Failed to use rush boost.", Properties.Settings.Default.ErrorTextColor)]);
                    }
                }
            }
        }

        private void RemoveBuildingButton_Click(object sender, EventArgs e)
        {
            if (GameManager.CurrentPlayer == null)
                return;

            if (_selectedTile == null || _selectedTile.Building == null)
                return;

            // Look up building specs
            var (_, _, _, _, _, _, modifier) = TileFactory.BuildingLookups()[(BuildingType)_selectedTile.Building];

            int playerIndex = GameManager.Players.IndexOf(GameManager.CurrentPlayer);
            if (playerIndex != -1)
            {
                if (modifier != null)
                {
                    if (modifier.ModifierTarget == ModifierTarget.MaxInProgressMissions)
                    {
                        int maxInProgressMissions = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxInProgressMissions, StarterValues.MaxInProgressMissions);

                        // Check if one less modifier would put things over max, and if so, return early
                        if (GameManager.Players[playerIndex].Missions.Where(m => m.MissionState == MissionState.InProgress).Count() > maxInProgressMissions - (int)modifier.ModifierAmount)
                        {
                            OutputService.Write(true, [new($"Can't currently remove building because you would exceed maximum in progress missions.", Properties.Settings.Default.ErrorTextColor)]);
                            return;
                        }
                    }
                    else if (modifier.ModifierTarget == ModifierTarget.MaxItems)
                    {
                        int maxItems = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxItems, StarterValues.MaxItems);

                        // Check if one less modifier would put things over max, and if so, return early
                        if (GameManager.Players[playerIndex].Inventory.Items.Count > maxItems - (int)modifier.ModifierAmount)
                        {
                            OutputService.Write(true, [new($"Can't currently remove building because you would exceed maximum items.", Properties.Settings.Default.ErrorTextColor)]);
                            return;
                        }
                    }
                    else if (modifier.ModifierTarget == ModifierTarget.MaxUnits)
                    {
                        int maxUnits = (int)GameManager.ApplyModifiers(playerIndex, ModifierTarget.MaxUnits, StarterValues.MaxUnits);

                        // Check if one less modifier would put things over max, and if so, return early
                        if (GameManager.Players[playerIndex].Inventory.Units.Count > maxUnits - (int)modifier.ModifierAmount)
                        {
                            OutputService.Write(true, [new($"Can't currently remove building because you would exceed maximum units.", Properties.Settings.Default.ErrorTextColor)]);
                            return;
                        }
                    }
                }

                // Output
                string buildingType = _selectedTile.Building switch
                {
                    BuildingType.CityCenter => "City Center",
                    BuildingType.Dwelling => "Dwelling",
                    BuildingType.Storage => "Storage",
                    BuildingType.ResearchMaker => "Research Maker",
                    BuildingType.PowerMaker => "Power Maker",
                    BuildingType.WaterMaker => "Water Maker",
                    BuildingType.FoodMaker => "Food Maker",
                    BuildingType.ConcreteMaker => "Concrete Maker",
                    BuildingType.MetalMaker => "Metal Maker",
                    BuildingType.ItemMaker => "Item Maker",
                    BuildingType.UnitMaker => "Unit Maker",
                    BuildingType.GoldMaker => "Gold Maker",
                    BuildingType.LootboxMaker => "Lootbox Maker",
                    BuildingType.RushBoostMaker => "Rush Boost Maker",
                    BuildingType.ExperienceBoostMaker => "Experience Boost Maker",
                    BuildingType.RarityBoostMaker => "Rarity Boost Maker",
                    BuildingType.MonsterEggMaker => "Monster Egg Maker",
                    BuildingType.FertilizerMaker => "Fertilizer Maker",
                    BuildingType.MysterySeedMaker => "Mystery Seed Maker",
                    _ => "Unknown Building"
                };
                OutputService.Write(true, [new($"Removed Building: {buildingType}", Properties.Settings.Default.PrimaryForeColor)]);

                // If this building had a modifier, remove it
                if (modifier != null)
                    GameManager.RemoveModifier(playerIndex, modifier);

                // Set relevant tile properties for a tile without a building
                _selectedTile.TileState = TileState.Idle;
                _selectedTile.Elapsed = TimeSpan.Zero;
                _selectedTile.Building = null;
                _selectedTile.CustomBuildingName = null;
                _selectedTile.CustomBuildingColor = null;
            }
        }

        private void RenameBuildingButton_Click(object sender, EventArgs e)
        {
            if (_selectedTile != null && _selectedTile.Building != null)
            {
                var dialog = new RenameDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string userInput = dialog.NewNameText.Trim();

                    // Verify input wasn't blank or the current custom name
                    if (userInput != "" && userInput != _selectedTile.CustomBuildingName)
                    {
                        // Update custom name
                        _selectedTile.CustomBuildingName = userInput;

                        // Update UI to reflect changes
                        UpdateGrid();
                    }
                }
            }
        }

        private void PaintBuildingButton_Click(object sender, EventArgs e)
        {
            if (_selectedTile != null && _selectedTile.Building != null)
            {
                if (BuildingColorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Verify chosen color wasn't the current custom color
                    if (BuildingColorDialog.Color != _selectedTile.CustomBuildingColor)
                    {
                        // Update custom color
                        _selectedTile.CustomBuildingColor = BuildingColorDialog.Color;

                        // Update UI to reflect changes
                        UpdateGrid();
                    }
                }
            }
        }
    }
}