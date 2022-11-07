using Hw9.Parser.Nodes;
using Hw9.Parser.Tokens;

namespace Hw9.Parser.Parser;

public interface IParser
{
    NodeBase Parse(TokenPipe pipe);
}