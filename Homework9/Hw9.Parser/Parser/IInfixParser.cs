using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public interface IInfixParser
{
    public Priority Priority { get; }
    
    NodeBase Parse(Parser parser, NodeBase left, Token token);
}