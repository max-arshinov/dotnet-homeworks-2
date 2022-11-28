using Hw11.Services.MathCalculator;
using Hw11.Services.StringToExpression;
using Hw9.Parser.Parser;
using Hw9.Parser.Tokens;

namespace Hw11.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMathCalculator(this IServiceCollection services)
    {
        return services.AddTransient<IMathCalculatorService, MathCalculatorService>()
            .AddTransient<IParser>(_ => new Parser(new ParserProvider()))
            .AddTransient<ITokenizer, Tokenizer>()
            .AddTransient<IStringToExpression, StringToExpression>();
    }
}