using Hw9.Parser.Tokens;

namespace Hw9.Parser.Nodes;

/// <summary>
/// Бинарный оператор
/// </summary>
public abstract record NodeOperatorBinary(NodeBase Left, NodeBase Right) : NodeBase
{
    public override IReadOnlyList<NodeBase>? Children { get; } = new[] { Left, Right };
    
    public abstract TokenTypeOperator Operator { get; }
}