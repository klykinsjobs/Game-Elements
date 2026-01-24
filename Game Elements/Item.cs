namespace Game_Elements
{
    public class Item
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string? Name { get; set; }
        public Rarity Rarity { get; set; }
        public int SellPrice { get; set; }
        public bool IsSellable { get; set; } = true;

        public override string ToString() => $"{Name}";
    }
}