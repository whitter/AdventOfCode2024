namespace AdventOfCode2024.Solvers.Day4;

public partial class Day4Solver : BaseSolver<string[], int>
{
    public override string[] ParseData(string rawData) => rawData.SplitByNewline<string>();

    public override int SolvePart1(string[] inputData)
    {
        var count = 0;

        var match = "XMAS";

        (int, int)[] directions = [(-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1)];

        for (var y = 0; y < inputData.Length; y++)
        {
            for (var x = 0; x < inputData[y].Length; x++)
            {
                foreach (var direction in directions)
                {
                    var y1 = y;
                    var x1 = x;

                    var result = true;

                    for (var c = 0; c < match.Length; c++)
                    {
                        if (y1 < 0 || y1 > inputData.Length - 1 || x1 < 0 || x1 > inputData[y1].Length - 1)
                        {
                            result = false;
                            break;
                        }

                        if (inputData[y1][x1] != match[c])
                        {
                            result = false;
                            break;
                        }

                        y1 += direction.Item1;
                        x1 += direction.Item2;
                    }

                    if (result)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    public override int SolvePart2(string[] inputData)
    {
        var count = 0;

        var match = "MS";

        (int, int)[][] directions = [[(-1, -1), (1, 1)], [(1, 1), (-1, -1)], [(1, -1), (-1, 1)], [(-1, 1), (1, -1)]];

        for (var y = 0; y < inputData.Length; y++)
        {
            for (var x = 0; x < inputData[y].Length; x++)
            {
                if (inputData[y][x] != 'A')
                {
                    continue;
                }

                var matches = 0;

                foreach (var direction in directions)
                {
                    var result = true;

                    for (var c = 0; c < match.Length; c++)
                    {
                        var y1 = y + direction[c].Item1;
                        var x1 = x + direction[c].Item2;

                        if (y1 < 0 || y1 > inputData.Length - 1 || x1 < 0 || x1 > inputData[y1].Length - 1)
                        {
                            result = false;
                            break;
                        }

                        if (inputData[y1][x1] != match[c])
                        {
                            result = false;
                            break;
                        }
                    }

                    if (result)
                    {
                        matches++;
                    }
                }

                if (matches == 2)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
