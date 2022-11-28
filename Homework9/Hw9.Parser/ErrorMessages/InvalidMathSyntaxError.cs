using Hw9.Parser.Tokens;

namespace Hw9.Parser.ErrorMessages;

public class InvalidMathSyntaxError : ParsingError
{
    public InvalidMathSyntaxError(string msg) : base(msg)
    {
    }

    public InvalidMathSyntaxError(string msg, Token? errorAt) : base(msg, errorAt)
    {
    }
}