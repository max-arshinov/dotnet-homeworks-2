namespace Hw9.Parser.Tokens;

/// <summary>
/// Токен оператора
/// </summary>
public abstract class TokenTypeOperator : TokenType
{
    /// <summary>
    /// Токен строки
    /// </summary>
    public abstract string StringRepresentation { get; }

    public abstract OperatorKind OperatorKind { get; }
    
    public override bool Matches(string lexeme)
    {
        return lexeme == StringRepresentation;
    }

    public override int Priority => 4;
}