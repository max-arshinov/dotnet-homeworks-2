namespace Hw9.Parser.Utils;

public static class StringExtensions
{
    public static bool IsNumeric(this string input)
        => input.All(x => x.IsNumeric());
}