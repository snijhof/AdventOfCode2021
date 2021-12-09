using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles.Day9
{
    public partial class Day9
    {
        public async Task RunAsync()
        {
            //var lines = await File.ReadAllLinesAsync(@"input\day9 - Copy.txt");
            var lines = await File.ReadAllLinesAsync(@"input\day9.txt");

            var xColumns = lines.First().Length;
            var yColumns = lines.Count();

            var map = CreateMap(lines, xColumns, yColumns);
            map.ConnectTiles(xColumns, yColumns);

            //Puzzle1(map, xColumns, yColumns);
            Puzzle2(map, xColumns, yColumns);
        }

        private static Tile[,] CreateMap(string[] lines, int xColumns, int yColumns)
        {
            var map = new Tile[xColumns, yColumns];

            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    map[x, y] = new Tile(int.Parse(lines[y][x].ToString()));
                }
            }

            return map;
        }

        public void Puzzle1(Tile[,] map, int xColumns, int yColumns)
        {
            int risk = 0;

            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    if (map[x,y].isLowPoint())
                    {
                        risk += map[x, y].RiskLevel();
                    }
                }
            }

            map.PrintWithHighlightedLowPoints(xColumns, yColumns);

            Console.WriteLine(risk);
        }

        public void Puzzle2(Tile[,] map, int xColumns, int yColumns)
        {
            var basinSizes = new List<int>(); 

            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    if (map[x, y].isLowPoint())
                    {
                        basinSizes.Add(map[x, y].GetBasinSize());
                    }
                }
            }

            map.PrintWithHighlightedBasins(xColumns, yColumns);

            var result = 1;
            basinSizes.OrderByDescending(x => x).Take(3).ToList().ForEach(x => result *= x);
            Console.WriteLine(result);
        }
    }
}
