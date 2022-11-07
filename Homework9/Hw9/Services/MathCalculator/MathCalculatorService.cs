using Hw9.Dto;
using Hw9.Services.StringToExpression;

namespace Hw9.Services.MathCalculator;

public class MathCalculatorService : IMathCalculatorService
{
    private readonly IStringToExpression _stringToExpression;

    public MathCalculatorService(IStringToExpression stringToExpression)
    {
        _stringToExpression = stringToExpression;
    }

    public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
    {
        try
        {
            if (expression is null)
                return new CalculationMathExpressionResultDto("Empty string");

            var result = await MathExpressionTaskBuilder.BuildFromExpression(_stringToExpression.Parse(expression));

            return new CalculationMathExpressionResultDto(result);
        }
        catch (Exception e)
        {
            return new CalculationMathExpressionResultDto(e.Message);
        }
    }
}