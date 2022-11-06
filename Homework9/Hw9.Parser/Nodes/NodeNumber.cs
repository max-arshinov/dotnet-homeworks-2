namespace Hw9.Parser.Nodes;

public record NodeNumber(double Value) : NodeBase
{
    public override IReadOnlyList<NodeBase> Children { get; } = new List<NodeBase>();

    public override string StringRepresentation => Value.ToString();
    
    public override NodeBase CloneWithChildren(NodeBase[] children)
    {
        return new NodeNumber(Value);
    }

    public override string ToString() => Value.ToString();
}