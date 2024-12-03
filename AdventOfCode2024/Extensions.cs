using System.Globalization;

namespace AdventOfCode2024;

public static class Extensions
{
    public static T[] SplitByNewline<T>(this string input) => input.SplitBy<T>(["\r", "\n", "\r\n"]);

    public static string[] SplitByBlankLine(this string input) => input.SplitBy<string>(["\r\r", "\n\n", "\r\n\r\n"]);

    public static T[] SplitBy<T>(this string value, params string[] separators) => [.. value
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => (T)Convert.ChangeType(x, typeof(T), CultureInfo.InvariantCulture))];
}
