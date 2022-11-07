using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public interface IParserProvider
{
    IInfixParser? GetInfixParser(TokenType tokenType);
    
    IPrefixParser? GetPrefixParser(TokenType tokenType);
}