using Hw9.Parser.Tokens;

namespace Hw9.Parser.ErrorMessages;

public class ParsingError : Exception
{
    public Token? ErrorAt { get; set; }

    public ParsingError(string msg) : base(msg)
    {
    }
    
    public ParsingError(string msg, Token? errorAt) : this(msg)
    {
        ErrorAt = errorAt;        
    }
}