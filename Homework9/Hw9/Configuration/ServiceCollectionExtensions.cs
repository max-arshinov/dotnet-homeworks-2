using Hw9.Parser.Parser;
using Hw9.Parser.Tokens;
using Hw9.Services.MathCalculator;
using Hw9.Services.StringToExpression;

namespace Hw9.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMathCalculator(this IServiceCollection services) =>
        services
            .AddTransient<IMathCalculatorService, MathCalculatorService>()
            .AddTransient<IParser>(_ => new Parser.Parser.Parser(new ParserProvider()))
            .AddTransient<ITokenizer, Tokenizer>()
            .AddTransient<IStringToExpression, StringToExpression>();
}