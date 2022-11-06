namespace Hw9.Parser.Tokens;

public static class TokenTypes
{
    public static TokenType Unknown = new TokenTypeUnknown();
    public static TokenType Number => TokenRegistry.Registry[TokenNames.Number];
    public static TokenType Plus => TokenRegistry.Registry[TokenNames.Plus];
    public static TokenType Minus => TokenRegistry.Registry[TokenNames.Minus];
    public static TokenType Multiply => TokenRegistry.Registry[TokenNames.Multiply];
    public static TokenType Divide => TokenRegistry.Registry[TokenNames.Divide];
    public static TokenType BraceOpen => TokenRegistry.Registry[TokenNames.BraceOpen];
    public static TokenType BraceClose => TokenRegistry.Registry[TokenNames.BraceClose];
}