namespace AdventOfCode2024.Solvers;

internal interface ISolver<TData, TResult>
{
    TData ParseData(string rawData);
    TResult SolvePart1(TData inputData);
    TResult SolvePart2(TData inputData);
}