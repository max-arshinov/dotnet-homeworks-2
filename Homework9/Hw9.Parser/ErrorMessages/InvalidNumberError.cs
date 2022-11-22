using Hw9.Parser.Tokens;

namespace Hw9.Parser.ErrorMessages;

public class InvalidNumberError : ParsingError
{
    public InvalidNumberError(string msg) : base(msg)
    {
    }

    public InvalidNumberError(string msg, Token? errorAt) : base(msg, errorAt)
    {
    }
}