namespace AdventOfCode2024.Solvers.Day5;

public partial class Day5Solver : BaseSolver<IEnumerable<int[]>, int>
{
    private PageComparer _pageComparer = null!;

    public override IEnumerable<int[]> ParseData(string rawData)
    {
        var sections = rawData.SplitByBlankLine();

        var order = sections[0].SplitByNewline<string>();

        _pageComparer = new PageComparer(order);

        return sections[1].SplitByNewline<string>().Select(x => x.SplitBy<int>(","));
    }

    public override int SolvePart1(IEnumerable<int[]> inputData) =>
        inputData
            .Where(IsSorted)
            .Sum(MiddleValue);

    public override int SolvePart2(IEnumerable<int[]> inputData) =>
        inputData
            .Where(pages => !IsSorted(pages))
            .Select(pages => OrderPages(pages).ToArray())
            .Sum(MiddleValue);

    private bool IsSorted(int[] pages) => pages.SequenceEqual(OrderPages(pages));

    private int MiddleValue(int[] pages) => pages[pages.Length / 2];

    private IOrderedEnumerable<int> OrderPages(int[] pages) => pages.OrderBy(page => page, _pageComparer);
}

internal sealed class PageComparer : IComparer<int>
{
    private readonly IEnumerable<string> _order;

    public PageComparer(IEnumerable<string> order) => _order = order;

    public int Compare(int x, int y) => _order.Contains(x + "|" + y) ? -1 : 1;
}
