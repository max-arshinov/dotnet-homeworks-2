using System.Linq.Expressions;
using Hw9.ErrorMessages;

namespace Hw10.Services.MathCalculator;

public class MathExpressionCalculator
{
    public Task<double> CalculateConstant(ConstantExpression expression)
        => expression.Value is double value
            ? Task.FromResult(value)
            : throw new NotSupportedException($"Constant of type {expression.Value?.GetType()} is not supported");

    public async Task<double> CalculateUnary(UnaryExpression expression, Task<double> operand)
        => expression.NodeType switch
        {
            ExpressionType.Negate => -await operand,
            _ => throw new NotSupportedException()
        };

    public async Task<double> CalculateBinary(BinaryExpression expression, Task<double> left, Task<double> right)
    {
        _ = await Task.WhenAll(left, right);
        var leftValue = left.Result;
        var rightValue = right.Result;
        return expression.NodeType switch
        {
            ExpressionType.Divide => CalculateDivision(leftValue, rightValue),
            ExpressionType.Add => leftValue + rightValue,
            ExpressionType.Subtract => leftValue - rightValue,
            ExpressionType.Multiply => leftValue * rightValue,
            _ => throw new NotSupportedException()
        };
    }

    private double CalculateDivision(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException(MathErrorMessager.DivisionByZero);
        return a / b;
    }
}