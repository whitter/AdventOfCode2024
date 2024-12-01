namespace AdventOfCode2024.Solvers;

public class Day1Solver : BaseSolver<(int[] First, int[] Second), int>
{
    public override (int[], int[]) ParseData(string rawData)
    {
        var lines = rawData
            .SplitByNewline<string>()
            .Select(line => line.SplitBy<int>("   "));

        return ([.. lines.Select(x => x[0]).OrderBy(x => x)], [.. lines.Select(x => x[1]).OrderBy(x => x)]);
    }

    public override int SolvePart1((int[] First, int[] Second) inputData)
        => inputData.First.Zip(inputData.Second, (first, second) => Math.Abs(first - second)).Sum();

    public override int SolvePart2((int[] First, int[] Second) inputData)
    {
        var counts = inputData.Second.CountBy(x => x).ToDictionary();

        return inputData.First.Select(x => x * counts.GetValueOrDefault(x)).Sum();
    }
}