using Game_Elements.Models;

namespace Game_Elements.Services
{
    public static class OutputService
    {
        // Event raised whenever output is written
        public static event Action<bool, List<OutputSegment>>? OnOutput;

        // Helper method to trigger the OnOutput event
        public static void Write(bool timestampPrefix, List<OutputSegment> segments) => OnOutput?.Invoke(timestampPrefix, segments);
    }
}