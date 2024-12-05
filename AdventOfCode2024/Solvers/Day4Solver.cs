namespace AdventOfCode2024.Solvers.Day4;

public partial class Day4Solver : BaseSolver<(char[] Grid, int Length), int>
{
    public override (char[] Grid, int Length) ParseData(string rawData)
    {
        var grid = rawData.SplitByNewline<string>();

        return (grid.SelectMany(x => x).ToArray(), grid.Length);
    }

    public override int SolvePart1((char[] Grid, int Length) inputData) =>
        inputData.Grid.SelectMany((cell, index) => new[] { (0, 1), (1, 1), (1, 0), (1, -1) }.Where(dir => IsMatch(inputData.Grid, index, dir, "XMAS", inputData.Length))).Count();

    public override int SolvePart2((char[] Grid, int Length) inputData) =>
        inputData.Grid.Where((cell, index) => IsMatch(inputData.Grid, index - inputData.Length - 1, (1, 1), "MAS", inputData.Length) && IsMatch(inputData.Grid, index - inputData.Length + 1, (1, -1), "MAS", inputData.Length)).Count();

    private static bool IsMatch(char[] grid, int start, (int Y, int X) dir, string match, int length)
    {
        var reversed = match.Reverse().ToArray();
        var offset = start;
        var set = new List<char>();

        for (var i = 0; i < match.Length; i++)
        {
            offset = start + (i * dir.Y * length) + (i * dir.X);

            if (offset < 0 || offset >= grid.Length || (start % length) + (i * dir.X) < 0 || (start % length) + (i * dir.X) >= length)
            {
                return false;
            }

            if (grid[offset] != match[i] && grid[offset] != reversed[i])
            {
                return false;
            }

            set.Add(grid[offset]);
        }

        return set.SequenceEqual(match) || set.SequenceEqual(reversed);
    }
}
