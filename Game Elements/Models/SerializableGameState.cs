namespace Game_Elements.Models
{
    public class SerializableGameState
    {
        public List<Player> Players { get; set; } = [];
        public DateTime LastTick { get; set; }
    }
}