
using static AdventOfCode2021.Puzzles.Day9.Day9;

namespace AdventOfCode2021.Puzzles.Day9
{
    public static class MapExtensions
    {
        public static void ConnectTiles(this Tile[,] map, int xColumns, int yColumns)
        {
            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    map[x, y].Up = y - 1 >= 0 ? map[x, y - 1] : null;
                    map[x, y].Left = x - 1 >= 0 ? map[x - 1, y] : null;
                    map[x, y].Down = y + 1 < yColumns ? map[x, y + 1] : null;
                    map[x, y].Right = x + 1 < xColumns ? map[x + 1, y] : null;
                }
            }
        }

        public static void PrintWithHighlightedLowPoints(this Tile[,] map, int xColumns, int yColumns)
        {
            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    if (map[x, y].isLowPoint())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(map[x, y].Height);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void PrintWithHighlightedBasins(this Tile[,] map, int xColumns, int yColumns)
        {
            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    if (map[x, y].IsInBasin)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(map[x, y].Height);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
