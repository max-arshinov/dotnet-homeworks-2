using System.Linq.Expressions;
using Hw9.Parser.Nodes;

namespace Hw10.Services.StringToExpression;

public class ToExpressionVisitor
{
    public Expression Visit(NodeBase node)
    {
        return node switch
        {
            NodeNumber numberNode
                => Expression.Constant(numberNode.Value),
            NodeOperatorDivision divideNode
                => Expression.Divide(Visit(divideNode.Left), Visit(divideNode.Right)),
            NodeOperatorMultiply multiplyNode
                => Expression.Multiply(Visit(multiplyNode.Left), Visit(multiplyNode.Right)),
            NodeOperatorPlus plusNode
                => Expression.Add(Visit(plusNode.Left), Visit(plusNode.Right)),
            NodeOperatorMinus minusNode
                => Expression.Subtract(Visit(minusNode.Left), Visit(minusNode.Right)),
            NodeOperatorNegate negate
                => Expression.Negate(Visit(negate.Operand)),
            _ => throw new NotSupportedException()
        };
    }
}