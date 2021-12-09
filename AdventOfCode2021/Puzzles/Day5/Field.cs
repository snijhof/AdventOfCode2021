namespace AdventOfCode2021.Puzzles.Day5
{
    public partial class Day5
    {
        public class Field
        {
            public static readonly int _xPositions = 999;
            public static readonly int _yPositions = 999;
            //public static readonly int _xPositions = 10;
            //public static readonly int _yPositions = 10;

            public Tile[,] Tiles { get; set; } = new Tile[_xPositions, _yPositions];

            public Field()
            {
                for (int x = 0; x < _xPositions; x++)
                {
                    for (int y = 0; y < _yPositions; y++)
                    {
                        Tiles[x, y] = new Tile();
                    }
                }
            }

            public void RunLine(Line line)
            {
                foreach (var linePosition in line.GetLinePositions())
                {
                    var tile = Tiles[linePosition.X, linePosition.Y];

                    tile.TimesCrossed++;
                }
            }

            public void PrintField()
            {
                for (int y = 0; y < _yPositions; y++)
                {
                    for (int x = 0; x < _xPositions; x++)
                    {
                        var tile = Tiles[x, y];

                        if (tile.IsCrossed)
                        {
                            Console.Write(tile.TimesCrossed);
                        }
                        else
                        {
                            Console.Write('.');
                        }
                    }
                    Console.WriteLine();
                }
            }

            public int NumberOfTilesCrossedMoreThanOnce()
            {
                int result = 0;

                for (int x = 0; x < _xPositions; x++)
                {
                    for (int y = 0; y < _yPositions; y++)
                    {
                        var tile = Tiles[x, y];

                        if (tile.TimesCrossed > 1)
                        {
                            result++;
                        }
                    }
                }

                return result;
            }
        }
    }
}
