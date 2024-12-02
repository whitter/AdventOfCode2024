using AdventOfCode2024.Solvers.Day2;

namespace AdventOfCode2024.Test;

public class Day2Tests
{
    private readonly string _input = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";

    [Fact]
    public void Day2_Part1()
    {
        var solver = new Day2Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart1(data);

        Assert.Equal(2, result);
    }

    [Fact]
    public void Day2_Part2()
    {
        var solver = new Day2Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart2(data);

        Assert.Equal(4, result);
    }
}
