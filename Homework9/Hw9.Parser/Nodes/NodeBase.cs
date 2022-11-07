namespace Hw9.Parser.Nodes;

/// <summary>
/// Нода дерева выражений
/// </summary>
public abstract record NodeBase
{
    public abstract IReadOnlyList<NodeBase>? Children { get; }

    public abstract string StringRepresentation { get; }

    public abstract NodeBase CloneWithChildren(NodeBase[] children);
}