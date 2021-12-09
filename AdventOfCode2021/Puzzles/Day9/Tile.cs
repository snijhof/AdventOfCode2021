namespace AdventOfCode2021.Puzzles.Day9
{
    public partial class Day9
    {
        public class Tile
        {
            public Tile(int value)
            {
                Height = value;
            }

            public int Height { get; set; }
            public Tile Up { get; set; }
            public Tile Right { get; set; }
            public Tile Down { get; set; }
            public Tile Left { get; set; }
            public bool IsInBasin { get; set; }

            public bool isLowPoint()
            {
                if (Up != null && Height >= Up.Height)
                {
                    return false;
                }
                if (Right != null && Height >= Right.Height)
                {
                    return false;
                }
                if (Down != null && Height >= Down.Height)
                {
                    return false;
                }
                if (Left != null && Height >= Left.Height)
                {
                    return false;
                }
                return true;
            }

            public int RiskLevel() => Height + 1;

            public int GetBasinSize()
            {
                IsInBasin = true;
                var basinSize = 1;

                if (Up != null && Up.IsInBasin is false && Up.Height != 9)
                {
                    basinSize += Up.GetBasinSize();
                }
                if (Right != null && Right.IsInBasin is false && Right.Height != 9)
                {
                    basinSize += Right.GetBasinSize();
                }
                if (Down != null && Down.IsInBasin is false && Down.Height != 9)
                {
                    basinSize += Down.GetBasinSize();
                }
                if (Left != null && Left.IsInBasin is false && Left.Height != 9)
                {
                    basinSize += Left.GetBasinSize();
                }

                return basinSize;
            }
        }
    }
}