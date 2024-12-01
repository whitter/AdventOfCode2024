namespace AdventOfCode2024.Solvers;

public abstract class BaseSolver<TData, TResult>
{
    public abstract TData ParseData(string rawData);
    public abstract TResult SolvePart1(TData inputData);
    public abstract TResult SolvePart2(TData inputData);
}