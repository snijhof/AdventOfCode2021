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
            //var lines = await File.ReadAllLinesAsync(@"input\day8 - Copy.txt");
            var lines = await File.ReadAllLinesAsync(@"input\day8.txt");

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

        // Sort the input and output numbers
        public void Puzzle2(List<Something> inputs)
        {
            int score = 0;

            foreach (var input in inputs)
            {
                var options = input.Options;
                var rightColumns = options.First(x => x.Length == 2)
                    .ToList();

                var upperColumn = options.First(x => x.Length == 3)
                    .ToList()
                    .Except(rightColumns)
                    .ToList();

                var upperLeftAndMiddleColumns = options.First(x => x.Length == 4)
                    .ToList()
                    .Except(rightColumns)
                    .Except(upperColumn)
                    .ToList();

                var lowerLeftAndLowestColumn = options.First(x => x.Length == 7)
                    .ToList()
                    .Except(rightColumns)
                    .Except(upperColumn)
                    .Except(upperLeftAndMiddleColumns)
                    .ToList();

                // 1, 4, 7, 8
                var one = options.First(x => x.Length == 2)
                    .OrderBy(x => x)
                    .ToList();

                var four = options.First(x => x.Length == 4)
                    .OrderBy(x => x)
                    .ToList();

                var seven = options.First(x => x.Length == 3)
                    .OrderBy(x => x)
                    .ToList();

                var eight = options.First(x => x.Length == 7)
                    .OrderBy(x => x)
                    .ToList();

                // 5, 2, 3
                var three = options.First(x => x.Length == 5 && rightColumns.Intersect(x.ToList()).Count() == 2)
                    .OrderBy(x => x)
                    .ToList();

                var five = options.First(x => x.Length == 5 && upperLeftAndMiddleColumns.Intersect(x.ToList()).Count() == 2)
                    .OrderBy(x => x)
                    .ToList();

                var two = options.First(x => x.Length == 5 && lowerLeftAndLowestColumn.Intersect(x.ToList()).Count() == 2)
                    .OrderBy(x => x)
                    .ToList();

                // 0, 6, 9
                var six = options.First(x => x.Length == 6 && lowerLeftAndLowestColumn.Union(upperLeftAndMiddleColumns).Intersect(x.ToList()).Count() == 4)
                    .OrderBy(x => x)
                    .ToList();

                var nine = options.First(x => x.Length == 6 && rightColumns.Union(upperLeftAndMiddleColumns).Intersect(x.ToList()).Count() == 4)
                    .OrderBy(x => x)
                    .ToList();

                var zero = options.First(x => x.Length == 6 && upperLeftAndMiddleColumns.Intersect(x.ToList()).Count() == 1)
                    .OrderBy(x => x)
                    .ToList();

                var numbers = new List<List<char>>
                {
                    zero, one, two, three, four, five, six, seven, eight, nine
                };

                var result = "";
                foreach (var x in input.Input)
                {
                    result += numbers.FindIndex(number => number.Count == x.Length && x.Intersect(number).Count() == x.Length);
                }

                score += int.Parse(result);
            }

            Console.WriteLine(score);
        }
    }

    public class Something
    {
        public List<string> Options { get; set; }
        public List<string> Input { get; set; }
    }
}
