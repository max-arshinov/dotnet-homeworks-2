using Hw9.Parser.Tokens;

namespace Hw9.Parser.ErrorMessages;

public class InvalidMathSymbolError : ParsingError
{
    public InvalidMathSymbolError(string msg) : base(msg)
    {
    }

    public InvalidMathSymbolError(string msg, Token? errorAt) : base(msg, errorAt)
    {
    }
}