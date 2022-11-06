namespace Hw9.Parser.Utils;

public static class CharExtensions
{
    public static bool IsNumeric(this char input) => char.IsDigit(input);
    
    public static bool IsWhitespace(this char input) => char.IsWhiteSpace(input);
}