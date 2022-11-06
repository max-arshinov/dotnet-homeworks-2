namespace Hw9.Parser.Tokens;

public class TokenTypeUnknown : TokenType
{
    public override bool Matches(string lexeme)
    {
        return true;
    }

    public override int Priority { get; } = 1000;
}