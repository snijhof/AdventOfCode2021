using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Puzzles.Day10
{
    public class Day10
    {
        public async Task RunAsync()
        {
            //var lines = await File.ReadAllLinesAsync(@"input\day10 - Copy.txt");
            var lines = await File.ReadAllLinesAsync(@"input\day10.txt");

            //Puzzle1(lines.ToList());
            Puzzle2(lines.ToList());
        }

        public void Puzzle1(List<string> lines)
        {
            List<char> wrongClosingCharacters = new List<char>();

            foreach (var line in lines)
            {
                var stack = new Stack<char>();
                foreach (var character in line)
                {
                    if (stack.Any() is false)
                    {
                        stack.Push(character);
                        continue;
                    }

                    if (character.IsOpeningCharacter())
                    {
                        stack.Push(character);
                        continue;
                    }

                    var lastOpenCharacter = stack.Peek();
                    if (lastOpenCharacter.MatchesWithClosingCharacter(character))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        wrongClosingCharacters.Add(character);
                        break;
                    }
                }
            }

            var score = 0;
            wrongClosingCharacters.ForEach(character =>
            {
                switch (character)
                {
                    case ')': score += 3; break;
                    case ']': score += 57; break;
                    case '}': score += 1197; break;
                    case '>': score += 25137; break;
                }
            });

            Console.WriteLine($"Score: {score}");
        }

        public void Puzzle2(List<string> lines)
        {
            var scores = new List<long>();

            foreach (var line in lines)
            {
                var closingCharacters = new List<char>();
                var isInvalidLine = false;
                var stack = new Stack<char>();

                foreach (var character in line)
                {
                    if (stack.Any() is false)
                    {
                        stack.Push(character);
                        continue;
                    }

                    if (character.IsOpeningCharacter())
                    {
                        stack.Push(character);
                        continue;
                    }

                    var lastOpenCharacter = stack.Peek();
                    if (lastOpenCharacter.MatchesWithClosingCharacter(character) is false)
                    {
                        isInvalidLine = true;
                        break;
                    }
                 
                    stack.Pop();
                }

                if (isInvalidLine)
                {
                    continue;
                }

                while (stack.Any())
                {
                    closingCharacters.Add(stack.Pop().GetClosingCharacter());
                }

                var score = 0l;
                closingCharacters.ForEach(character =>
                {
                    score *= 5;

                    switch (character)
                    {
                        case ')': score += 1; break;
                        case ']': score += 2; break;
                        case '}': score += 3; break;
                        case '>': score += 4; break;
                    }
                });

                scores.Add(score);
            }

            var orderedScoreList = scores.OrderByDescending(score => score).ToList();
            var middleScore = orderedScoreList[orderedScoreList.Count / 2];

            Console.WriteLine($"Score: {middleScore}");
        }
    }

    public static class CharacterExtensions
    {
        public static bool IsOpeningCharacter(this char character)
        {
            return character == '('
                || character == '['
                || character == '{'
                || character == '<';
        }

        public static bool IsClosingCharacter(this char character)
        {
            return character == ')'
                || character == ']'
                || character == '}'
                || character == '>';
        }

        public static bool MatchesWithClosingCharacter(this char openingCharacter, char closingCharacter)
        {
            return (openingCharacter == '(' && closingCharacter == ')')
                || (openingCharacter == '[' && closingCharacter == ']')
                || (openingCharacter == '{' && closingCharacter == '}')
                || (openingCharacter == '<' && closingCharacter == '>');
        }

        public static char GetClosingCharacter(this char openingCharacter)
        {
            return openingCharacter switch
            {
                '(' => ')',
                '[' => ']',
                '{' => '}',
                '<' => '>',
                _ => throw new ArgumentOutOfRangeException(nameof(openingCharacter))
            };
        }
    }
}
