using AdventOfCode2024.Solvers.Day7;

namespace AdventOfCode2024.Test;

public class Day7Tests
{
    private readonly string _input = @"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20";

    [Fact]
    public void Day6_Part1()
    {
        var solver = new Day7Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart1(data);

        Assert.Equal(3749, result);
    }

    [Fact]
    public void Day6_Part2()
    {
        var solver = new Day7Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart2(data);

        Assert.Equal(11387, result);
    }
}
