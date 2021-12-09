using Newtonsoft.Json;

namespace AdventOfCode2021.Puzzles
{
    public class Day1
    {
        void Run()
        {
            var inputDay1 = JsonConvert.DeserializeObject<InputDay1>(File.ReadAllText(@"input\day1.json"));

            if (inputDay1 == null)
            {
                Console.WriteLine($"{nameof(inputDay1)} is null");
                return;
            }

            Console.WriteLine($"result day 1 - puzzle 1: {Day1Puzzle1(inputDay1.Input)}");
            Console.WriteLine($"result day 1 - puzzle 2: {Day1Puzzle2(inputDay1.Input)}");
        }

        int Day1Puzzle1(List<int> input)
        {
            int result = 0;
            int? previous = null;
            foreach (var entry in input)
            {
                if (previous.HasValue && previous.Value < entry)
                {
                    result++;
                }
                previous = entry;
            }

            return result;
        }

        int Day1Puzzle2(List<int> input)
        {
            var queue = new Queue<int>();
            int result = 0;
            int? previousSum = null;

            for (int i = 0; i < input.Count; i++)
            {
                queue.Enqueue(input[i]);

                if (queue.Count != 3)
                {
                    continue;
                }

                var sum = queue.Sum(x => x);

                if (previousSum.HasValue && sum > previousSum.Value)
                {
                    result++;
                }

                previousSum = sum;
                queue.Dequeue();
            }

            return result;
        }
    }
}
