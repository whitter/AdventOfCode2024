using AdventOfCode2024.Solvers.Day6;

namespace AdventOfCode2024.Test;

public class Day6Tests
{
    private readonly string _input = @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

    [Fact]
    public void Day6_Part1()
    {
        var solver = new Day6Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart1(data);

        Assert.Equal(41, result);
    }

    [Fact]
    public void Day6_Part2()
    {
        var solver = new Day6Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart2(data);

        Assert.Equal(6, result);
    }
}
