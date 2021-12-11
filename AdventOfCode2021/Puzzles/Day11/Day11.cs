using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2021.Puzzles.Day11.Day11;

namespace AdventOfCode2021.Puzzles.Day11
{
    public class Day11
    {
        public async Task RunAsync()
        {
            //var lines = await File.ReadAllLinesAsync(@"input\day11 - small.txt");
            //var lines = await File.ReadAllLinesAsync(@"input\day11 - Copy.txt");
            var lines = await File.ReadAllLinesAsync(@"input\day11.txt");

            var xColumns = lines.First().Length;
            var yColumns = lines.Count();

            var mapOfOctopus = CreateMapOfOctopus(lines, xColumns, yColumns);
            mapOfOctopus.ConnectNeighbours(xColumns, yColumns);

            Puzzle1(mapOfOctopus, xColumns, yColumns);
            //Puzzle2(map, xColumns, yColumns);
        }

        private static Octopus[,] CreateMapOfOctopus(string[] lines, int xColumns, int yColumns)
        {
            var mapOfOctopus = new Octopus[xColumns, yColumns];

            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    mapOfOctopus[x, y] = new Octopus(int.Parse(lines[y][x].ToString()));
                }
            }

            return mapOfOctopus;
        }

        public void Puzzle1(Octopus[,] mapOfOctopus, int xColumns, int yColumns)
        {
            var numberOfFlashes = 0L;
            
            mapOfOctopus.PrintMapWithFlashedOctopus(xColumns, yColumns);

            for (int day = 1; day <= 999999999; day++)
            {
                var numberOfFlashesThisDay = 0L;

                for (int y = 0; y < yColumns; y++)
                {
                    for (int x = 0; x < xColumns; x++)
                    {
                        numberOfFlashesThisDay += mapOfOctopus[x, y].IncrementChargeLevel();
                    }
                }

                numberOfFlashes += numberOfFlashesThisDay;

                mapOfOctopus.PrintMapWithFlashedOctopus(xColumns, yColumns);

                if (numberOfFlashesThisDay == xColumns * yColumns)
                {
                    Console.WriteLine($"day: {day}");

                    break;
                }

                for (int y = 0; y < yColumns; y++)
                {
                    for (int x = 0; x < xColumns; x++)
                    {
                        mapOfOctopus[x, y].ResetFlash();
                    }
                }
            }

            Console.WriteLine(numberOfFlashes);
        }

        public class Octopus
        {
            private int _charge;
            private bool _flashed = false;
            private readonly List<Octopus> _neighbours = new();

            public Octopus(int charge)
            {
                _charge = charge;
            }

            public bool Flashed => _flashed;
            public int Charge => _charge;

            public void AddNeighbour(Octopus neighbour)
            {
                if (neighbour == null)
                {
                    return;
                }

                _neighbours.Add(neighbour);
            }

            public long IncrementChargeLevel()
            {
                if (_flashed)
                {
                    return 0;
                }

                var numberOfFlashes = 0L;

                _charge++;

                if (_charge > 9)
                {
                    numberOfFlashes = Flash();
                    _charge = 0;

                }

                return numberOfFlashes;
            }

            public void ResetFlash()
            {
                _flashed = false;
            }

            private long Flash()
            {
                long numberOfFlashes = 1;

                _flashed = true;

                _neighbours.ForEach(x => numberOfFlashes += x.IncrementChargeLevel());

                return numberOfFlashes;
            }
        }
    }

    public static class OctopusExtensions
    {
        public static void ConnectNeighbours(this Octopus[,] mapOfOctopus, int xColumns, int yColumns)
        {
            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    var octopus = mapOfOctopus[x, y];

                    for (int neighbourY = -1; neighbourY < 2; neighbourY++)
                    {
                        var neighbourYPosition = y + neighbourY;

                        if (neighbourYPosition >= 0 && neighbourYPosition < yColumns)
                        {
                            if (neighbourY != 0)
                            {
                                octopus.AddNeighbour(mapOfOctopus[x, neighbourYPosition]);
                            }
                            if (x - 1 >= 0)
                            {
                                octopus.AddNeighbour(mapOfOctopus[x - 1, neighbourYPosition]);
                            }
                            if (x + 1 < xColumns)
                            {
                                octopus.AddNeighbour(mapOfOctopus[x + 1, neighbourYPosition]);
                            }
                        }
                    }
                }
            }
        }

        public static void PrintMapWithFlashedOctopus(this Octopus[,] map, int xColumns, int yColumns)
        {
            for (int y = 0; y < yColumns; y++)
            {
                for (int x = 0; x < xColumns; x++)
                {
                    if (map[x, y].Flashed)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(map[x, y].Charge);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //public static void PrintWithHighlightedBasins(this Octopus[,] map, int xColumns, int yColumns)
        //{
        //    for (int y = 0; y < yColumns; y++)
        //    {
        //        for (int x = 0; x < xColumns; x++)
        //        {
        //            if (map[x, y].IsInBasin)
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //            }
        //            else
        //            {
        //                Console.ForegroundColor = ConsoleColor.White;
        //            }
        //            Console.Write(map[x, y].Height);
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine();
        //}
    }
}
