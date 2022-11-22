using Hw9.ErrorMessages;
using Hw9.Parser.ErrorMessages;
using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public class NumberParser : IPrefixParser
{
    public NodeBase Parse(Parser parser, Token token)
    {
        var laToken = parser.LookAhead();
        if (laToken?.Type == TokenTypes.Unknown && laToken.Value.Contains("."))
        {
            throw new InvalidNumberError(MathErrorMessager.NotNumberMessage($"{token.Value}{laToken.Value}") ,laToken);
        }
        return new NodeNumber(double.Parse(token.Value));
    }
}