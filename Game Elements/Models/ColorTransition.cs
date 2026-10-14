namespace Game_Elements.Models
{
    public class ColorTransition
    {
        public Panel? Panel { get; set; }
        public Color StartColor { get; set; }
        public Color TargetColor { get; set; }
        public int CurrentStep { get; set; }
        public int TotalSteps { get; set; }
    }
}