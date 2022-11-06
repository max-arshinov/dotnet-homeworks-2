using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public interface IPrefixParser
{
    NodeBase Parse(Parser parser, Token token);
}