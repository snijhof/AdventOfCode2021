using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles.Day7
{
    public class Day7
    {
        public async Task RunAsync()
        {
            //var text = await File.ReadAllTextAsync(@"input\day7 - Copy.txt");
            var text = await File.ReadAllTextAsync(@"input\day7.txt");
            var horizontalPositions = text.Split(',')
                .Select(number => int.Parse(number))
                .ToList();

            Puzzle1(horizontalPositions);
            Puzzle2(horizontalPositions);
        }

        public void Puzzle1(List<int> horizontalPositions)
        {
            horizontalPositions.OrderBy(horizontalPosition => horizontalPosition)
                .ToList();

            var bestResult = int.MaxValue;
            for (int moveToPosition = 0; moveToPosition < horizontalPositions.Max(); moveToPosition++)
            {
                var fuelSpend = 0;
                foreach (var horizontalPosition in horizontalPositions)
                {
                    fuelSpend += Math.Abs(horizontalPosition - moveToPosition);

                    if (fuelSpend > bestResult)
                    {
                        break;
                    }
                }

                if (fuelSpend < bestResult)
                {
                    bestResult = fuelSpend;
                }
            }

            Console.WriteLine(bestResult);
        }

        public void Puzzle2(List<int> horizontalPositions)
        {
            horizontalPositions.OrderBy(horizontalPosition => horizontalPosition)
                .ToList();

            var bestResult = int.MaxValue;
            for (int moveToPosition = 0; moveToPosition < horizontalPositions.Max(); moveToPosition++)
            {
                var fuelSpend = 0;
                foreach (var horizontalPosition in horizontalPositions)
                {
                    var limit = Math.Abs(horizontalPosition - moveToPosition);
                    for (int x = 1; x <= limit; x++)
                    {
                        fuelSpend += x;
                    }

                    if (fuelSpend > bestResult)
                    {
                        break;
                    }
                }

                if (fuelSpend < bestResult)
                {
                    bestResult = fuelSpend;
                }
            }

            Console.WriteLine(bestResult);
        }
    }
}
