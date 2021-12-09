using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles
{
    public class Day3
    {
        // start with the full list of binary numbers from your diagnostic report
        // and 
        // consider just the first bit of those numbers
        public async Task RunAsync()
        {
            var lines = await File.ReadAllLinesAsync(@"input\day3.txt");
            var input = lines.Select(line => line.Select(bit => Convert.ToInt32(char.GetNumericValue(bit))).ToList()).ToList();

            //Puzzle1(input);
            Puzzle2(input);
        }

        public int GammaRate { get; set; } = 0;
        public int EpsilonRate { get; set; } = 0;
        public int PowerConsumption => GammaRate * EpsilonRate;

        public void Puzzle1(List<List<int>> input)
        {
            var mostCommonBits = new List<int>();
            var numberOfBits = input.First().Count();

            for (int i = 0; i < numberOfBits; i++)
            {
                mostCommonBits.Add(input.Select(bits => bits[i])
                    .GroupBy(x => x)
                    .OrderByDescending(x => x.Count())
                    .First()
                    .Key);
            }

            mostCommonBits.Reverse();

            for (int i = 1; i <= mostCommonBits.Count; i++)
            {
                var decimalResult = CalculateDecimalFromBit(i);
                if (mostCommonBits[i - 1] == 0)
                {
                    EpsilonRate += decimalResult;
                }
                else
                {

                    GammaRate += decimalResult;
                }
            }

            int CalculateDecimalFromBit(int limit, int index = 1, int x = 1)
            {
                if (index == limit)
                {
                    return x;
                }

                return CalculateDecimalFromBit(limit, ++index, x * 2);
            }

            Console.WriteLine(EpsilonRate);
            Console.WriteLine(GammaRate);
            Console.WriteLine(PowerConsumption);
        }

        public int OxygenGeneratorRating { get; set; } = 0;
        public int CO2ScrubberRating { get; set; } = 0;
        public int LifeSupportRating => OxygenGeneratorRating * CO2ScrubberRating;

        public void Puzzle2(List<List<int>> input)
        {
            var mostCommonBits = new List<int>();
            var numberOfBits = input.First().Count();

            for (int i = 0; i < numberOfBits; i++)
            {
                //mostCommonBits.Add(input.Select(bits => new { First = bits[i], Complete = bits })
                //    .GroupBy(x => x.First)
                //    .OrderByDescending(x => x.Count())
                //    .ToList()
                //    .ForEach(x => Console.WriteLine(x.ToString())));

                var orderedGroup = input.Select(bits => new { First = bits[i], Complete = bits })
                    .GroupBy(x => x.First)
                    .OrderByDescending(x => x.Count());

                Console.WriteLine(orderedGroup.Count());
                Console.WriteLine();

                //orderedGroup.ToList()
                //    .ForEach(x => Console.WriteLine(x.Key));

                //Console.WriteLine(orderedGroup.SelectMany(x => x)
                //    .F
                //    .Count());
                //.ToList()
                //.ForEach(x => Console.WriteLine(JsonConvert.SerializeObject(x)));
            }

            mostCommonBits.Reverse();

            for (int i = 1; i <= mostCommonBits.Count; i++)
            {
                var decimalResult = CalculateDecimalFromBit(i);
                if (mostCommonBits[i - 1] == 0)
                {
                    EpsilonRate += decimalResult;
                }
                else
                {

                    GammaRate += decimalResult;
                }
            }

            int CalculateDecimalFromBit(int limit, int index = 1, int x = 1)
            {
                if (index == limit)
                {
                    return x;
                }

                return CalculateDecimalFromBit(limit, ++index, x * 2);
            }

            Console.WriteLine(EpsilonRate);
            Console.WriteLine(GammaRate);
            Console.WriteLine(PowerConsumption);
        }
    }
}
