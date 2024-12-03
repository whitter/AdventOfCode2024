using AdventOfCode2024.Solvers.Day3;

namespace AdventOfCode2024.Test;

public class Day3Tests
{
    [Fact]
    public void Day3_Part1()
    {
        var solver = new Day3Solver();

        var data = solver.ParseData("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");

        var result = solver.SolvePart1(data);

        Assert.Equal(161, result);
    }

    [Fact]
    public void Day3_Part2()
    {
        var solver = new Day3Solver();

        var data = solver.ParseData("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");

        var result = solver.SolvePart2(data);

        Assert.Equal(48, result);
    }
}
