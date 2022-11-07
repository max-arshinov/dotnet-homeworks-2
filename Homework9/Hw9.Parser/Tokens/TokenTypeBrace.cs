namespace Hw9.Parser.Tokens;

/// <summary>
/// Токен скобки
/// </summary>
public class TokenTypeBrace : TokenType
{
    public Side Side { get; init; }

    /// <inheritdoc />
    public override bool Matches(string lexeme)
        => Side switch
        {
            Side.Open => lexeme == "(",
            Side.Close => lexeme == ")",
            _ => throw new ArgumentOutOfRangeException()
        };

    public TokenTypeBrace(Side side)
    {
        Side = side;        
    }

    /// <inheritdoc />
    public override int Priority => 3;
}