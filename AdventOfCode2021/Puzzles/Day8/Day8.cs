using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles.Day8
{
    public class Day8
    {
        public async Task RunAsync()
        {
            var lines = await File.ReadAllLinesAsync(@"input\day8 - Copy.txt");
            //var lines = await File.ReadAllLinesAsync(@"input\day8.txt");

            var input = new List<Something>();
            foreach (var line in lines)
            {
                var splitText = line.Split('|');
                input.Add(new Something
                {
                    Options = splitText[0].Trim().Split(' ').ToList(),
                    Input = splitText[1].Trim().Split(' ').ToList()
                });
            }

            //Puzzle1(input);
            Puzzle2(input);
        }

        public void Puzzle1(List<Something> input)
        {
            var result = input.Select(x => x.Input.Where(number => number.Length == 2
                 || number.Length == 3
                 || number.Length == 4
                 || number.Length == 7)
                .Count()).Sum();

            Console.WriteLine(result);
        }

        public void Puzzle2(List<Something> input)
        {
            var options = input.First().Options;

            var rightColumns = options.First(x => x.Length == 2)
                .ToList();

            rightColumns.ForEach(x => Console.WriteLine(x));

            var upperColumn = options.First(x => x.Length == 3)
                .ToList()
                .Except(rightColumns)
                .ToList();

            upperColumn.ForEach(x => Console.WriteLine(x));

            var upperLeftAndMiddleColumns = options.First(x => x.Length == 4)
                .ToList()
                .Except(rightColumns)
                .Except(upperColumn)
                .ToList();

            upperLeftAndMiddleColumns.ForEach(x => Console.WriteLine(x));

            var lowerLeftAndLowestColumn = options.First(x => x.Length == 7)
                .ToList()
                .Except(rightColumns)
                .Except(upperColumn)
                .Except(upperLeftAndMiddleColumns)
                .ToList();

            lowerLeftAndLowestColumn.ForEach(x => Console.WriteLine(x));
        }
    }

    public class Something
    {
        public List<string> Options { get; set; }
        public List<string> Input { get; set; }
    }
}
