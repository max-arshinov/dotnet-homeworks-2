using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Hw8.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Hw8.Controllers;

public class CalculatorController : Controller
{
    private readonly ICalculator _calculator;

    public CalculatorController(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public IActionResult Calculate([FromServices] ICalculator calculator,
        string val1,
        string operation,
        string val2)
    {
        if (!double.TryParse(val1, NumberStyles.Any, CultureInfo.InvariantCulture, out var value1)
            || !double.TryParse(val2, NumberStyles.Any, CultureInfo.InvariantCulture, out var value2))
            return BadRequest(Messages.InvalidNumberMessage);

        if (!Enum.TryParse(typeof(Operation), operation, true, out var operationEnum))
            return BadRequest(Messages.InvalidOperationMessage);

        return operationEnum switch
        {
            Operation.Plus => Ok(_calculator.Plus(value1, value2)),
            Operation.Minus => Ok(_calculator.Minus(value1, value2)),
            Operation.Multiply => Ok(_calculator.Multiply(value1, value2)),
            Operation.Divide when value2 == 0 => BadRequest(Messages.DivisionByZeroMessage),
            Operation.Divide => Ok(_calculator.Divide(value1, value2)),
            _ => BadRequest(Messages.InvalidOperationMessage)
        };
    }

    [ExcludeFromCodeCoverage]
    public IActionResult Index()
    {
        return Content(
            "Заполните val1, operation(plus, minus, multiply, divide) и val2 здесь '/calculator/calculate?val1= &operation= &val2= '\n" +
            "и добавьте её в адресную строку.");
    }
}