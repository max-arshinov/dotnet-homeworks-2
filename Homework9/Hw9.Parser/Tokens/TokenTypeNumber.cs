using System.Globalization;
using Hw9.Parser.Utils;

namespace Hw9.Parser.Tokens;

public class TokenTypeNumber : TokenType
{
    public override bool Matches(string lexeme) 
        => lexeme[0].IsNumeric() && double.TryParse(lexeme, NumberStyles.Float, CultureInfo.InvariantCulture, out _);

    public override int Priority => 5;
}