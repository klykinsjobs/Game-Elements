using Game_Elements.Enums;

namespace Game_Elements.Models
{
    public class Loot
    {
        public Dictionary<LootType, int> LootQuantities { get; set; } = [];
        public List<Item> Items { get; set; } = [];
        public List<Unit> Units { get; set; } = [];
    }
}