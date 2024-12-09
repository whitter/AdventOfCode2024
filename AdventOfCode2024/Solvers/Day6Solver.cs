using System.Numerics;

namespace AdventOfCode2024.Solvers.Day6;

public class Day6Solver : BaseSolver<(Dictionary<Complex, char> Grid, Complex Start), int>
{
    public override (Dictionary<Complex, char>, Complex) ParseData(string rawData)
    {
        var grid = rawData.SplitByNewline<string>()
            .SelectMany((row, y) => row.Select((cell, x) => new KeyValuePair<Complex, char>((-Complex.ImaginaryOne * y) + x, cell)))
            .ToDictionary();

        var start = grid.First(x => x.Value == '^').Key;

        return (grid, start);
    }

    public override int SolvePart1((Dictionary<Complex, char> Grid, Complex Start) inputData) =>
        TraceRoute(inputData.Grid, inputData.Start).Path.Count();

    public override int SolvePart2((Dictionary<Complex, char> Grid, Complex Start) inputData)
    {
        var route = TraceRoute(inputData.Grid, inputData.Start).Path;

        var count = 0;

        foreach (var cell in route.Where(x => inputData.Grid[x] == '.'))
        {
            inputData.Grid[cell] = '#';

            var path = TraceRoute(inputData.Grid, inputData.Start);

            if (path.IsLoop)
            {
                count++;
            }

            inputData.Grid[cell] = '.';
        }

        return count;
    }

    private static (IEnumerable<Complex> Path, bool IsLoop) TraceRoute(Dictionary<Complex, char> grid, Complex position)
    {
        var path = new HashSet<(Complex Position, Complex Direction)>();
        var direction = Complex.ImaginaryOne;

        while (grid.ContainsKey(position) && !path.Contains((position, direction)))
        {
            path.Add((position, direction));

            if (grid.GetValueOrDefault(position + direction) == '#')
            {
                direction *= -Complex.ImaginaryOne;
            }
            else
            {
                position += direction;
            }
        }

        return (path.Select(x => x.Position).Distinct(), path.Contains((position, direction)));
    }
}
