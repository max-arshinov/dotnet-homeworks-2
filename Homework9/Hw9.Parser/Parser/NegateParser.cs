using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public class NegateParser : IPrefixParser
{
    public NodeBase Parse(Parser parser, Token token)
        => new NodeOperatorNegate(parser.Parse((int)Priority.Prefix));
    
}