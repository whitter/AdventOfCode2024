using AdventOfCode2024.Solvers.Day4;

namespace AdventOfCode2024.Test;

public class Day4Tests
{
    [Fact]
    public void Day4_Part1()
    {
        var solver = new Day4Solver();

        var data = solver.ParseData(@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX");

        var result = solver.SolvePart1(data);

        Assert.Equal(18, result);
    }

    [Fact]
    public void Day4_Part2()
    {
        var solver = new Day4Solver();

        var data = solver.ParseData(@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX");

        var result = solver.SolvePart2(data);

        Assert.Equal(9, result);
    }
}