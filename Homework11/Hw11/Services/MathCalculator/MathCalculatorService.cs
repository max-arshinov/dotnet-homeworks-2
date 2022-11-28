using Hw11.Dto;
using Hw11.Services.StringToExpression;

namespace Hw11.Services.MathCalculator;

public class MathCalculatorService : IMathCalculatorService
{
    private readonly IStringToExpression _stringToExpression;

    public MathCalculatorService(IStringToExpression stringToExpression)
    {
        _stringToExpression = stringToExpression;
    }

    public async Task<double> CalculateMathExpressionAsync(string? expression)
        => await MathExpressionTaskBuilder.BuildFromExpression(_stringToExpression.Parse(expression));
}