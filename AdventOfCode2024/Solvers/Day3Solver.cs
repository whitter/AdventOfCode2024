using System.Globalization;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Solvers.Day3;

public partial class Day3Solver : BaseSolver<string, int>
{
    public override string ParseData(string rawData) => rawData;

    public override int SolvePart1(string inputData) => MulRegex().Matches(inputData).Sum(CalcMatch);

    public override int SolvePart2(string inputData)
    {
        var enable = true;

        return EnabledMulRegex().Matches(inputData).Sum(match =>
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
                    return enable ? CalcMatch(match) : 0;
            }
        });
    }

    private int CalcMatch(Match match) =>
        int.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture) * int.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

    [GeneratedRegex(@"mul\((\d*),(\d*)\)")]
    private static partial Regex MulRegex();

    [GeneratedRegex(@"mul\((\d*),(\d*)\)|(do\(\))|(don't\(\))")]
    private static partial Regex EnabledMulRegex();
}
