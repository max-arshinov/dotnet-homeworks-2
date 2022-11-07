namespace Hw9.Parser.Tokens;

public record Token(TokenType Type, string Value, int Start, int End)
{
    public override string ToString()
    {
        return $"{{{Type}: {Value} {Start}:{End}}}";
    }
}