namespace Game_Elements
{
    public class SerializableGameState
    {
        public List<Player> Players { get; set; } = [];
        public DateTime LastTick { get; set; }
    }
}