using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solvers.Day3;

public partial class Day3Solver : BaseSolver<string, int>
{
    public override string ParseData(string rawData) => rawData;

    public override int SolvePart1(string inputData) => MulRegex().Matches(inputData).Sum(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));

    public override int SolvePart2(string inputData)
    {
        var enable = true;

        return EnabledMulRegex().Matches(inputData).Select(match =>
        {
            switch (match.Groups[0].Value)
            {
                case "do()":
                    enable = true;
                    return 0;
                case "don't()":
                    enable = false;
                    return 0;
                default:
                    return enable ? int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value) : 0;
            }
        }).Sum();
    }

    [GeneratedRegex(@"mul\((\d*),(\d*)\)")]
    private static partial Regex MulRegex();

    [GeneratedRegex(@"mul\((\d*),(\d*)\)|(do\(\))|(don't\(\))")]
    private static partial Regex EnabledMulRegex();
}
