using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles.Day5
{
    public partial class Day5
    {
        public async Task RunAsync()
        {
            //var textLines = await File.ReadAllLinesAsync(@"input\day5 - Copy.txt");
            var textLines = await File.ReadAllLinesAsync(@"input\day5.txt");
            var lines = new List<Line>();

            foreach (var line in textLines)
            {
                var positions = line.Split(" -> ")
                    .Select(position =>
                    {
                        var xy = position
                            .Split(',')
                            .Select(x => int.Parse(x))
                            .ToList();

                        return new Position(xy[0], xy[1]);
                    })
                    .ToList();

                lines.Add(new Line { From = positions[0], To = positions[1] });
            }

            //Puzzle1(lines);
            Puzzle2(lines);
        }

        public void Puzzle1(List<Line> lines)
        {
            var field = new Field();

            foreach (var line in lines)
            {
                field.RunLine(line);
            }

            //field.PrintField();

            Console.WriteLine(field.NumberOfTilesCrossedMoreThanOnce());
        }

        public void Puzzle2(List<Line> lines)
        {
            var field = new Field();

            foreach (var line in lines)
            {
                field.RunLine(line);
            }

            //field.PrintField();

            Console.WriteLine(field.NumberOfTilesCrossedMoreThanOnce());
        }
    }
}
