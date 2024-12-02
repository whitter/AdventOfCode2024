namespace AdventOfCode2024.Solvers;

public class Day2Solver : BaseSolver<int[][], int>
{
    public override int[][] ParseData(string rawData) => rawData
            .SplitByNewline<string>()
            .Select(line => line.SplitBy<int>(" "))
            .ToArray();

    public override int SolvePart1(int[][] inputData) =>
        inputData.Where(line => {
            var increasing = line[1] > line[0];

            return Enumerable.Zip(line.Take(line.Length - 1), line.Skip(1))
                .All(pair => IsSafe(increasing, pair));
        })
        .Count();

    public override int SolvePart2(int[][] inputData) =>
        inputData.Where(line => {
            for (var i = 0; i < line.Length; i++)
            {
                var newLine = new List<int>(line);

                newLine.RemoveAt(i);

                var increasing = newLine[1] > newLine[0];

                if(Enumerable.Zip(newLine.Take(newLine.Count - 1), newLine.Skip(1))
                    .All(pair => IsSafe(increasing, pair)))
                {
                    return true;
                }
            }

            return false;
        })
        .Count();

    private bool IsSafe(bool increasing, (int First, int Second) pair) => (increasing && pair.Second - pair.First >= 1 && pair.Second - pair.First <= 3) || (!increasing && pair.First - pair.Second >= 1 && pair.First - pair.Second <= 3);
}