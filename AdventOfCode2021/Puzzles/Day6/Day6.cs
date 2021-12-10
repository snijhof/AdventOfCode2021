using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles.Day6
{
    public class Day6
    {
        public async Task RunAsync()
        {
            int days = 200;

            var text = await File.ReadAllTextAsync(@"input\day6.txt");
            //var text = await File.ReadAllTextAsync(@"input\day6 - Copy.txt");
            var lanternFish = text.Split(',')
                .Select(number => long.Parse(number))
                .ToList();

            //Puzzle1(lanternFish);
            Puzzle2(lanternFish, 256);
        }

        public void Puzzle2(List<long> lanternFish, int days)
        {
            var fishPools = new long[9];

            foreach (var fish in lanternFish)
            {
                fishPools[fish]++;
            }

            for (int day = 0; day < days; day++)
            {
                var newFishes = fishPools[0];

                long x = 0;
                for (int i = fishPools.Length - 1; i >= 0; i--)
                {
                    if (i == fishPools.Length - 1)
                    {
                        x = fishPools[i];
                    }
                    else
                    {
                        var temp = fishPools[i];
                        fishPools[i] = x;
                        x = temp;
                    }
                }

                fishPools[8] = newFishes;
                fishPools[6] += newFishes;
            }

            Console.WriteLine(fishPools.Sum());
        }
    }
}
