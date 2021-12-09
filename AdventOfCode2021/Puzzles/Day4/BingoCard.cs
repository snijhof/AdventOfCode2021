namespace AdventOfCode2021.Puzzles.Day4
{
    public class BingoCard
    {
        public List<List<BingoNumber>> Card { get; set; } = new List<List<BingoNumber>>();
        public int Score { get; set; }

        public bool HasHit(int drawnBingoNumber)
        {
            var isHit = false;
            foreach (var row in Card)
            {
                var bingoNumber = row.FirstOrDefault(bingoNumber => bingoNumber.Number == drawnBingoNumber);
                if (bingoNumber != null)
                {
                    bingoNumber.Hit = true;
                    isHit = true;
                }
            }

            return isHit;
        }

        public bool HasBingo()
        {
            var column1 = new List<BingoNumber>();
            var column2 = new List<BingoNumber>();
            var column3 = new List<BingoNumber>();
            var column4 = new List<BingoNumber>();
            var column5 = new List<BingoNumber>();

            foreach (var row in Card)
            {
                bool hasRowBingo = true;

                for (int column = 0; column < row.Count; column++)
                {
                    var bingoNumber = row[column];
                    if (bingoNumber == null)
                    {
                        return false;
                    }

                    if (bingoNumber.Hit is false)
                    {
                        hasRowBingo = false;
                    }

                    switch (column)
                    {
                        case 0: column1.Add(bingoNumber); break;
                        case 1: column2.Add(bingoNumber); break;
                        case 2: column3.Add(bingoNumber); break;
                        case 3: column4.Add(bingoNumber); break;
                        case 4: column5.Add(bingoNumber); break;
                        default:
                            break;
                    }
                }

                if (hasRowBingo)
                {
                    Score = CalculateScore();
                    return true;
                }
            }

            if (HasBingo(column1) || HasBingo(column2) || HasBingo(column3) || HasBingo(column4) || HasBingo(column5))
            {
                Score = CalculateScore();
                return true;
            }

            return false;
        }

        public bool ContainsNumber(int number)
        {
            foreach (var row in Card)
            {
                if (row.Any(bingoNumber => bingoNumber.Number == number))
                {
                    return true;
                }
            }

            return false;
        }

        private int CalculateScore()
        {
            int score = 0;

            foreach (var row in Card)
            {
                foreach (var bingoNumber in row)
                {
                    if (bingoNumber.Hit)
                    {
                        continue;
                    }

                    score += bingoNumber.Number;
                }
            }

            return score;
        }

        private bool HasBingo(List<BingoNumber> list)
        {
            return list.TrueForAll(bingoNumber => bingoNumber.Hit);
        }
    }
}
