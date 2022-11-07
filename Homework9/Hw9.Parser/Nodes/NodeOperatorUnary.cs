using Hw9.Parser.Tokens;

namespace Hw9.Parser.Nodes;

public abstract record NodeOperatorUnary(NodeBase Operand) : NodeBase
{
    public override IReadOnlyList<NodeBase>? Children { get; } = new[] { Operand };
    
    public abstract TokenTypeOperator Operator { get; }
}