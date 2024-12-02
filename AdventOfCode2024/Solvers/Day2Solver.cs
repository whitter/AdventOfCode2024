namespace AdventOfCode2024.Solvers.Day2;

public class Day2Solver : BaseSolver<int[][], int>
{
    public override int[][] ParseData(string rawData) => [.. rawData
            .SplitByNewline<string>()
            .Select(line => line.SplitBy<int>(" "))];

    public override int SolvePart1(int[][] inputData) => inputData.Count(IsSafe);

    public override int SolvePart2(int[][] inputData) =>
        inputData.Count(line => line.ToDampened().Any(IsSafe));

    private bool IsSafe(int[] line)
    {
        var increasing = line[1] > line[0];

        return Enumerable.Zip(line[..^1], line[1..])
            .All(pair => Math.Abs(pair.Second - pair.First) >= 1 && Math.Abs(pair.Second - pair.First) <= 3 && (increasing ? pair.Second > pair.First : pair.Second < pair.First));
    }
}

internal static class Extensions
{
    public static IEnumerable<int[]> ToDampened(this int[] line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            var newLine = new List<int>(line);

            newLine.RemoveAt(i);

            yield return newLine.ToArray();
        }
    }
}
