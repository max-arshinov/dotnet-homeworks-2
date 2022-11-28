using System.Linq.Expressions;
using Hw9.Parser.Parser;
using Hw9.Parser.Tokens;

namespace Hw11.Services.StringToExpression;

public class StringToExpression : IStringToExpression
{
    private readonly ITokenizer _tokenizer;
    private readonly IParser _parser;
    private readonly ToExpressionVisitor _visitor;

    public StringToExpression(ITokenizer tokenizer, IParser parser)
    {
        _tokenizer = tokenizer;
        _parser = parser;
        _visitor = new ToExpressionVisitor();
    }

    public Expression Parse(string expression) =>
        _visitor.Visit(
            _parser.Parse(
                _tokenizer.Tokenize(expression)));
}