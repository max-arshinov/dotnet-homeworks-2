using Hw10.DbModels;
using Hw10.Dto;
using Hw10.Services.MathCalculator;
using Microsoft.EntityFrameworkCore;

namespace Hw10.Services.CachedCalculator;

public class MathCachedCalculatorService : IMathCalculatorService
{
	private readonly ApplicationContext _dbContext;
	private readonly IMathCalculatorService _simpleCalculator;

	public MathCachedCalculatorService(ApplicationContext dbContext, IMathCalculatorService simpleCalculator)
	{
		_dbContext = dbContext;
		_simpleCalculator = simpleCalculator;
	}

	public async Task<CalculationMathExpressionResultDto> CalculateMathExpressionAsync(string? expression)
	{
		var cached = await _dbContext.SolvingExpressions.FirstOrDefaultAsync(x => 
			x.Expression == expression);
		
		if(cached != null)
			return new CalculationMathExpressionResultDto
			{
				IsSuccess = true,
				Result = cached.Result
			};

		var newCalculation = await _simpleCalculator.CalculateMathExpressionAsync(expression);
		
		if (newCalculation.IsSuccess)
		{
			await _dbContext.SolvingExpressions.AddAsync(new SolvingExpression
			{
				Expression = expression,
				Result = newCalculation.Result
			});
			await _dbContext.SaveChangesAsync();
		}

		return newCalculation;
	}
}