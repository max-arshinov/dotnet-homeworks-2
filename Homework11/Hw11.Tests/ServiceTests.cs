using System.Linq.Expressions;
using Hw11.Services.MathCalculator;
using Hw11.Services.StringToExpression;
using Xunit;

namespace Hw11Tests;

public class ServiceTests
{
    [Fact]
    public void MathExpressionCalculator_ShouldThrowOnUnknownBinaryExpression()
    {
        Assert.ThrowsAsync<InvalidOperationException>(
            (async () =>
            {
                await new MathExpressionCalculator().CalculateBinary(
                    Expression.Equal(
                        Expression.Constant(1),
                        Expression.Constant(2)),
                    Task.FromResult(1d),
                    Task.FromResult(1d));
            }));
    }

    [Fact]
    public void MathExpressionCalculator_ShouldThrowOnUnknownUnaryExpression()
    {
        Assert.ThrowsAsync<InvalidOperationException>(
            (async () =>
            {
                await new MathExpressionCalculator().CalculateUnary(
                    Expression.UnaryPlus(Expression.Constant(1)),
                    Task.FromResult(1d));
            }));
    }

    [Fact]
    public void MathExpressionCalculator_ShouldThrowOnUnknownConstantExpression()
    {
        Assert.ThrowsAsync<InvalidOperationException>(
            (async () =>
            {
                await new MathExpressionCalculator().CalculateConstant(Expression.Constant("12"));
            }));
        Assert.ThrowsAsync<InvalidOperationException>(
            (async () =>
            {
                await new MathExpressionCalculator().CalculateConstant(Expression.Constant(null));
            }));
    }

    [Fact]
    public void ToExpressionVisitor_ShouldThrowOnUnknownNode()
    {
        Assert.Throws<NotSupportedException>(
            (() =>
            {
                new ToExpressionVisitor().Visit(null!);
            }));
    }

}