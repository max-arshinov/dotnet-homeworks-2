using System.Diagnostics.CodeAnalysis;
using Hw8.Calculator;
using Hw8.Common;
using Hw8.Parser;
using Microsoft.AspNetCore.Mvc;

namespace Hw8.Controllers;

public class CalculatorController : Controller
{ 
    private readonly IParser _parser;

    public CalculatorController([FromServices]IParser parser)
    {
        _parser = parser;
    }

    public ActionResult<double> Calculate([FromServices] ICalculator calculator,
        [FromQuery]string val1,
        [FromQuery]string operation,
        [FromQuery]string val2)
    {
        double value1;
        Operation op;
        double value2;
        try
        {
            _parser.ParseCalcArguments(val1, operation, val2, out value1, out op, out value2);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        try
        {
            return Ok(calculator.Calculate(value1, op, value2));
        }
        catch(Exception e)
        {
            return Ok(e.Message);
        }
    }
    
    [ExcludeFromCodeCoverage]
    public IActionResult Index()
    {
        return Content(
            "Заполните val1, operation(plus, minus, multiply, divide) и val2 здесь '/calculator/calculate?val1= &operation= &val2= '\n" +
            "и добавьте её в адресную строку.");
    }
}