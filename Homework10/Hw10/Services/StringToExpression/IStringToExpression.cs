using System.Linq.Expressions;

namespace Hw10.Services.StringToExpression;

public interface IStringToExpression
{
    Expression Parse(string expression);
}