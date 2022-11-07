using System.Linq.Expressions;

namespace Hw9.Services.StringToExpression;

public interface IStringToExpression
{
    Expression Parse(string expression);
}