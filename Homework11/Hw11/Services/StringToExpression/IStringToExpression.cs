using System.Linq.Expressions;

namespace Hw11.Services.StringToExpression;

public interface IStringToExpression
{
    Expression Parse(string expression);
}