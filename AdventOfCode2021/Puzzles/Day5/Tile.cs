namespace AdventOfCode2021.Puzzles.Day5
{
    public partial class Day5
    {
        public class Tile
        {
            public int TimesCrossed { get; set; } = 0;

            public bool IsCrossed => TimesCrossed > 0;
        }
    }
}
