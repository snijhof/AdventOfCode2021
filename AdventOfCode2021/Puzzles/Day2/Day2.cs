namespace AdventOfCode2021.Puzzles
{
    public record InputDay2(string Direction, int Positions);

    internal class Day2
    {
        public async Task RunAsync()
        {
            var lines = await File.ReadAllLinesAsync(@"input\day2.txt");
            var input = lines.Select(line =>
            {
                var x = line.Split(' ');
                return new InputDay2(x[0], int.Parse(x[1]));
            });
        }

        void Puzzle2(IEnumerable<InputDay2> input)
        {
            var forward = 0;
            var depth = 0;
            var aim = 0;

            foreach (var entry in input)
            {
                switch (entry.Direction)
                {
                    case "forward":
                        forward += entry.Positions;
                        depth += aim * entry.Positions;
                        break;
                    case "down":
                        aim += entry.Positions;
                        break;
                    case "up":
                        aim -= entry.Positions;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"aim: {aim}");
            Console.WriteLine($"forward: {forward}");
            Console.WriteLine($"depth: {depth}");
            Console.WriteLine($"forward * depth = {forward * depth}");
        }

        void Puzzle1(IEnumerable<InputDay2> input)
        {
            var forward = 0;
            var depth = 0;

            foreach (var entry in input)
            {
                switch (entry.Direction)
                {
                    case "forward":
                        forward += entry.Positions;
                        break;
                    case "down":
                        depth += entry.Positions;
                        break;
                    case "up":
                        depth -= entry.Positions;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"forward: {forward}");
            Console.WriteLine($"depth: {depth}");
            Console.WriteLine($"forward * depth = {forward * depth}");
        }
    }
}
