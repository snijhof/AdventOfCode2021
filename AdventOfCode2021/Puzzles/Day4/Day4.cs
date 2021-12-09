using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles.Day4
{
    public class Day4
    {
        public async Task RunAsync()
        {
            var lines = await File.ReadAllLinesAsync(@"input\day4.txt");
            var bingoNumbers = lines.First().Split(',').Select(number => int.Parse(number)).ToList();
            var bingoCards = new List<BingoCard>();

            BingoCard newBingoCard = null;
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    if (newBingoCard != null)
                    {
                        bingoCards.Add(newBingoCard);
                    }
                    newBingoCard = new BingoCard();
                    continue;
                }

                newBingoCard.Card.Add(lines[i].Split(' ')
                    .Where(number => string.IsNullOrWhiteSpace(number) is false)
                    .Select(number => new BingoNumber
                    {
                        Number = int.Parse(number)
                    }).ToList());


                if (i + 1 == lines.Length)
                {
                    if (newBingoCard != null)
                    {
                        bingoCards.Add(newBingoCard);
                    }
                    newBingoCard = new BingoCard();
                    continue;
                }
            }

            Puzzle1(bingoNumbers, bingoCards);
            Puzzle2(bingoNumbers, bingoCards);
        }

        public void Puzzle1(List<int> bingoNumbers, List<BingoCard> bingoCards)
        {
            foreach (var bingoNumber in bingoNumbers)
            {
                foreach (var bingoCard in bingoCards)
                {
                    if (bingoCard.HasHit(bingoNumber) is false)
                    {
                        continue;
                    }

                    PrintCard(bingoCard);

                    if (bingoCard.HasBingo() is false)
                    {
                        continue;
                    }

                    Console.WriteLine(bingoCard.Score);
                    Console.WriteLine(bingoNumber);
                    Console.WriteLine(bingoCard.Score * bingoNumber);
                    return;
                }
            }
        }

        public void Puzzle2(List<int> bingoNumbers, List<BingoCard> bingoCards)
        {
            int completedBingoCards = 0;

            foreach (var bingoNumber in bingoNumbers)
            {
                foreach (var bingoCard in bingoCards)
                {
                    if (bingoCard.Score > 0)
                    {
                        continue;
                    }

                    if (bingoCard.HasHit(bingoNumber) is false)
                    {
                        continue;
                    }

                    PrintCard(bingoCard);

                    if (bingoCard.HasBingo() is false)
                    {
                        continue;
                    }

                    if (completedBingoCards + 1 < bingoCards.Count())
                    {
                        completedBingoCards++;
                    }
                    else
                    {
                        Console.WriteLine(bingoCard.Score * bingoNumber);
                    }
                }
            }
        }

        private static void PrintCard(BingoCard bingoCard)
        {
            bingoCard.Card.ForEach(row =>
            {
                row.ForEach(number =>
                {
                    if (number.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(number.Number);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(number.Number.ToString());
                    }
                    Console.Write(' ');
                });
                Console.WriteLine();
            });
            Console.WriteLine();
        }
    }
}
