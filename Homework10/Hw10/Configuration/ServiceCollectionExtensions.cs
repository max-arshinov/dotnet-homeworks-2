using Hw10.DbModels;
using Hw10.Services;
using Hw10.Services.CachedCalculator;
using Hw10.Services.MathCalculator;
using Hw10.Services.StringToExpression;
using Hw9.Parser.Parser;
using Hw9.Parser.Tokens;

namespace Hw10.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMathCalculator(this IServiceCollection services)
    {
        return services.AddTransient<IMathCalculatorService, MathCalculatorService>()
            .AddTransient<IParser>(_ => new Parser(new ParserProvider()))
            .AddTransient<ITokenizer, Tokenizer>()
            .AddTransient<IStringToExpression, StringToExpression>();
    }

    public static IServiceCollection AddCachedMathCalculator(this IServiceCollection services)
    {
        return services.AddScoped<IMathCalculatorService>(s =>
            new MathCachedCalculatorService(
                s.GetRequiredService<ApplicationContext>(),
                s.GetRequiredService<MathCalculatorService>()));
    }
}