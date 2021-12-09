namespace AdventOfCode2021.Puzzles.Day5
{
    public partial class Day5
    {
        public record Line
        {
            public Position From { get; set; }
            public Position To { get; set; }

            public List<Position> GetLinePositions()
            {

                var linePositions = new List<Position> { From };

                if (From.X != To.X && From.Y != To.Y)
                {
                    if (From.Y < To.Y && From.X < To.X)
                    {
                        int y = From.Y + 1;
                        int x = From.X + 1;
                        for (; x < To.X && y < To.Y; x++, y++)
                        {
                            linePositions.Add(new Position(x, y));
                        }
                    }
                    else if (From.Y > To.Y && From.X > To.X)
                    {
                        int y = From.Y - 1;
                        int x = From.X - 1;
                        for (; x > To.X && y > To.Y; x--, y--)
                        {
                            linePositions.Add(new Position(x, y));
                        }
                    }
                    else if (From.Y < To.Y && From.X > To.X)
                    {
                        int y = From.Y + 1;
                        int x = From.X - 1;
                        for (; x > To.X && y < To.Y; x--, y++)
                        {
                            linePositions.Add(new Position(x, y));
                        }
                    }
                    else if (From.Y > To.Y && From.X < To.X)
                    {
                        int y = From.Y - 1;
                        int x = From.X + 1;
                        for (; x < To.X && y > To.Y; x++, y--)
                        {
                            linePositions.Add(new Position(x, y));
                        }
                    }
                }
                else if (From.X != To.X)
                {
                    if (From.X < To.X)
                    {
                        for (int x = From.X + 1; x < To.X; x++)
                        {
                            linePositions.Add(new Position(x, From.Y));
                        }
                    }
                    else
                    {
                        for (int x = From.X - 1; x > To.X; x--)
                        {
                            linePositions.Add(new Position(x, From.Y));
                        }
                    }
                }
                else if (From.Y != To.Y)
                {
                    if (From.Y < To.Y)
                    {
                        for (int y = From.Y + 1; y < To.Y; y++)
                        {
                            linePositions.Add(new Position(From.X, y));
                        }
                    }
                    else
                    {
                        for (int y = From.Y - 1; y > To.Y; y--)
                        {
                            linePositions.Add(new Position(From.X, y));
                        }
                    }
                }

                linePositions.Add(To);

                return linePositions;
            }
        }
    }
}
