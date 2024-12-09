using AdventOfCode2024.Solvers.Day5;

namespace AdventOfCode2024.Test;

public class Day5Tests
{
    private readonly string _input = @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";

    [Fact]
    public void Day5_Part1()
    {
        var solver = new Day5Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart1(data);

        Assert.Equal(143, result);
    }

    [Fact]
    public void Day5_Part2()
    {
        var solver = new Day5Solver();

        var data = solver.ParseData(_input);

        var result = solver.SolvePart2(data);

        Assert.Equal(123, result);
    }
}
