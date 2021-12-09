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

            //var text = await File.ReadAllTextAsync(@"input\day6.txt");
            var text = await File.ReadAllTextAsync(@"input\day6 - Copy.txt");
            var lanternFish = text.Split(',')
                .Select(number => new LanternFish(days, int.Parse(number)))
                .ToList();

            //Puzzle1(lanternFish);
            Puzzle2(lanternFish);
        }

        public void Puzzle1(List<LanternFish> lanternFish)
        {
            int days = 80;

            for (int i = 0; i < days; i++)
            {
                var newBornLanternFish = new List<LanternFish>();
                foreach (var fish in lanternFish)
                {
                    if (fish.DaysUntilBirth == 0)
                    {
                        newBornLanternFish.Add(new LanternFish(days, 8));
                        fish.ResetDaysUntilBirth();
                    }
                    else
                    {
                        fish.DaysUntilBirth--;
                    }
                }
                lanternFish.AddRange(newBornLanternFish);
            }

            Console.WriteLine(lanternFish.Count);
        }


        // Create fish with days in it, calculate new lanternfish, for every new lanternfish calculate it also.
        // Return number of created lanternfish.
        public void Puzzle2(List<LanternFish> lanternFish)
        {
            long nrOfNewFish = 0;
            var startingNumberOfFish = lanternFish.Count;

            //nrOfNewFish = lanternFish.First().CalculateNrOfChildren();
            foreach (var fish in lanternFish)
            {
                nrOfNewFish += CalculateNrOfChildren(fish);
            }

            Console.WriteLine(nrOfNewFish + startingNumberOfFish);
        }

        public long CalculateNrOfChildren(LanternFish lanternFish)
        {
            var children = new List<LanternFish>();
            lanternFish.Days -= (lanternFish.DaysUntilBirth + 1);

            if (lanternFish.Days < 0)
            {
                return 0;
            }

            children.Add(new LanternFish(lanternFish.Days));

            var nrOfNewChilds = (lanternFish.Days - lanternFish.Days % 7) / 7;

            for (int i = 1; i <= nrOfNewChilds; i++)
            {
                children.Add(new LanternFish(lanternFish.Days - i * 7));
            }

            var numberOfChildren = (long)children.Count;
            foreach (var child in children)
            {
                numberOfChildren += CalculateNrOfChildren(child);
            }
            return numberOfChildren;
        }
    }

    public class LanternFish
    {
        public int Days { get; set; }
        public int DaysUntilBirth { get; set; }

        public LanternFish(int days, int daysUntilBirth = 8)
        {
            DaysUntilBirth = daysUntilBirth;
            Days = days;
        }

        

        internal void ResetDaysUntilBirth()
        {
            DaysUntilBirth = 6;
        }
    }
}
