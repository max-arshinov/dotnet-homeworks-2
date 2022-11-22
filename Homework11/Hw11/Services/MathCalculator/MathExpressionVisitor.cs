using System.Linq.Expressions;

namespace Hw11.Services.MathCalculator;

public class MathExpressionVisitor
{
    private readonly Dictionary<Expression, Expression[]> _dependencies = new();

    private bool _isVisited = false;

    public IReadOnlyDictionary<Expression, Expression[]> Dependencies => _dependencies;

    public void Visit(Expression expression)
    {
        this.Visit((dynamic)expression);
    }

    protected Expression Visit(BinaryExpression node)
    {
        _dependencies.TryAdd(node, new [] { node.Left, node.Right });
        Visit(node.Left);
        Visit(node.Right);
        return node;
    }

    protected Expression Visit(ConstantExpression node)
    {
        _dependencies.TryAdd(node, new Expression[] { });
        return node;
    }

    protected Expression Visit(UnaryExpression node)
    {
        _dependencies.TryAdd(node, new [] { node.Operand });
        Visit(node.Operand);
        return node;
    }
}