using AdventOfCode2024.Solvers.Day1;

namespace AdventOfCode2024.Test;

public class Day1Tests
{
    private readonly string _input = @"3   4
4   3
2   5
1   3
3   9
3   3";

    [Fact]
    public void Day1_Part1()
    {
        var solver = new Day1Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart1(data);

        Assert.Equal(11, result);
    }

    [Fact]
    public void Day1_Part2()
    {
        var solver = new Day1Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart2(data);

        Assert.Equal(31, result);
    }
}
