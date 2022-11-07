using System.Linq.Expressions;

namespace Hw9.Services.MathCalculator;

public class MathExpressionVisitor : ExpressionVisitor
{
    private readonly Dictionary<Expression, Expression[]> _dependencies = new();

    private bool _isVisited = false;

    public IReadOnlyDictionary<Expression, Expression[]> Dependencies => _dependencies;

    protected override Expression VisitBinary(BinaryExpression node)
    {
        _dependencies.TryAdd(node, new [] { node.Left, node.Right });
        Visit(node.Left);
        Visit(node.Right);
        return node;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        _dependencies.TryAdd(node, new Expression[] { });
        return node;
    }

    protected override Expression VisitUnary(UnaryExpression node)
    {
        _dependencies.TryAdd(node, new [] { node.Operand });
        Visit(node.Operand);
        return node;
    }
}