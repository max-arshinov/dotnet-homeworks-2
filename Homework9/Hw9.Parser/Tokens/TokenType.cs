namespace Hw9.Parser.Tokens;

public abstract class TokenType
{
    /// <summary>
    /// Функция, которая проверят, является ли последовательность этим токеном
    /// </summary>
    /// <param name="lexeme"></param>
    /// <returns></returns>
    public abstract bool Matches(string lexeme);
    
    /// <summary>
    /// Приоритет токена
    /// </summary>
    public abstract int Priority { get; }
}