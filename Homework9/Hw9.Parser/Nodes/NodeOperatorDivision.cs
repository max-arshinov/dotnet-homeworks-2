using Hw9.Parser.Tokens;

namespace Hw9.Parser.Nodes;

public record NodeOperatorDivision(NodeBase Left, NodeBase Right) : NodeOperatorBinary(Left, Right)
{
    public override string StringRepresentation => "/";

    public override NodeBase CloneWithChildren(NodeBase[] children)
    {
        return new NodeOperatorDivision(children[0], children[1]);
    }

    public override TokenTypeOperator Operator { get; } = (TokenTypeOperator)TokenTypes.Divide;
}