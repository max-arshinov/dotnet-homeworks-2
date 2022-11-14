using System.Linq.Expressions;

namespace Hw10.Services.MathCalculator;

public static class MathExpressionTaskBuilder
{
    public static Task<double> BuildFromExpression(Expression mathExpression)
    {
        var visitor = new MathExpressionVisitor();
        visitor.Visit(mathExpression);

        var mathCalc = new MathExpressionCalculator();

        var dependencies = visitor.Dependencies;

        var lazy = new Dictionary<Expression, Lazy<Task<double>>>();

        foreach (var (current, dependsOn) in dependencies)
            lazy[current] = new Lazy<Task<double>>(
                async () =>
                {
                    if (dependsOn.Length > 0)
                    {
                        await Task.WhenAll(dependsOn.Select(d => lazy[d].Value));
                        await Task.Yield();
                        await Task.Delay(1000);
                    }

                    return current switch
                    {
                        BinaryExpression binary => await mathCalc.CalculateBinary(
                            binary,
                            lazy[binary.Left].Value,
                            lazy[binary.Right].Value),
                        UnaryExpression unary => await mathCalc.CalculateUnary(unary, lazy[unary.Operand].Value),
                        ConstantExpression constant => await mathCalc.CalculateConstant(constant),
                    };
                });

        return lazy[mathExpression].Value;
    }
}