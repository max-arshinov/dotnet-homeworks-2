using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public class ParserProvider : IParserProvider
{
    private Dictionary<TokenType, IInfixParser> _infixParsers = new()
    {
        [TokenTypes.Minus] =
            new BinaryOperatorParser(Priority.Addition, (left, right) => new NodeOperatorMinus(left, right)),
        [TokenTypes.Plus] =
            new BinaryOperatorParser(Priority.Addition, (left, right) => new NodeOperatorPlus(left, right)),
        [TokenTypes.Multiply] =
            new BinaryOperatorParser(Priority.Multiplication, (left, right) => new NodeOperatorMultiply(left, right)),
        [TokenTypes.Divide] =
            new BinaryOperatorParser(Priority.Multiplication, (left, right) => new NodeOperatorDivision(left, right)),
    };

    private Dictionary<TokenType, IPrefixParser> _prefixParser = new()
    {
        [TokenTypes.Number] = new NumberParser(),
        [TokenTypes.BraceOpen] = new BraceParser(),
        [TokenTypes.Minus] = new NegateParser(), 
    };
    
    public IInfixParser? GetInfixParser(TokenType tokenType)
        => _infixParsers.TryGetValue(tokenType, out var parser) ? parser : null;

    public IPrefixParser? GetPrefixParser(TokenType tokenType)
        => _prefixParser.TryGetValue(tokenType, out var parser) ? parser : null;
}