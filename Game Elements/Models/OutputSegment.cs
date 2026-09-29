namespace Game_Elements.Models
{
    public class OutputSegment(string text, Color color, bool bold = false, bool italic = false, bool underline = false)
    {
        public string Text { get; set; } = text;
        public Color Color { get; set; } = color;
        public bool Bold { get; set; } = bold;
        public bool Italic { get; set; } = italic;
        public bool Underline { get; set; } = underline;
    }
}