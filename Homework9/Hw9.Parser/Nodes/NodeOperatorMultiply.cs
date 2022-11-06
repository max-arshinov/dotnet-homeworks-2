using Hw9.Parser.Tokens;

namespace Hw9.Parser.Nodes;

public record NodeOperatorMultiply(NodeBase Left, NodeBase Right) : NodeOperatorBinary(Left, Right)
{
    public override TokenTypeOperator Operator => (TokenTypeOperator)TokenTypes.Multiply;

    public override string StringRepresentation => "*";
    
    public override string ToString() => $"({Left} * {Right})";
    
    public override NodeBase CloneWithChildren(NodeBase[] children)
        => new NodeOperatorMultiply(children[0], children[1]);
}