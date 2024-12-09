using System.Globalization;

namespace AdventOfCode2024.Solvers.Day7;

public class Day7Solver : BaseSolver<IEnumerable<(long Target, int[] Numbers)>, long>
{
    public override IEnumerable<(long, int[])> ParseData(string rawData) => rawData
        .SplitByNewline<string>()
        .Select(lines =>
        {
            var sections = lines.SplitBy<string>(":");

            return (long.Parse(sections[0], CultureInfo.InvariantCulture), sections[1].Trim().SplitBy<int>(" "));
        });

    public override long SolvePart1(IEnumerable<(long Target, int[] Numbers)> inputData) =>
        inputData.Where(x => IsEquationPart1(x.Numbers[0], x.Target, x.Numbers[1..])).Sum(x => x.Target);

    public override long SolvePart2(IEnumerable<(long Target, int[] Numbers)> inputData) =>
        inputData.Where(x => IsEquationPart2(x.Numbers[0], x.Target, x.Numbers[1..])).Sum(x => x.Target);

    private static bool IsEquationPart1(long total, long target, int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return total == target;
        }

        return IsEquationPart1(total * numbers[0], target, numbers[1..]) || IsEquationPart1(total + numbers[0], target, numbers[1..]);
    }

    private static bool IsEquationPart2(long total, long target, int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return total == target;
        }

        return IsEquationPart2(total * numbers[0], target, numbers[1..]) || IsEquationPart2(total + numbers[0], target, numbers[1..]) || IsEquationPart2(long.Parse($"{total}{numbers[0]}", CultureInfo.InvariantCulture), target, numbers[1..]);
    }
}
