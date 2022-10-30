using System.Globalization;
using Hw8.Common;

namespace Hw8.Parser;

public class Parser:IParser
{

    private static bool TryParseOperation(string arg, out Operation operation)
    {
        switch(arg)
        {
            case "Plus": 
                operation = Operation.Plus;
                return true;
            case "Minus": 
                operation = Operation.Minus;
                return true;
            case "Multiply": 
                operation = Operation.Multiply;
                return true;
            case "Divide": 
                operation = Operation.Divide;
                return true;
            default:
                operation = Operation.Invalid;
                return false;
        }
    }
    public void ParseCalcArguments(string arg1, string arg2, string arg3, out double val1, out Operation operation,
        out double val2)
    {
        if (!(double.TryParse(arg1, NumberStyles.AllowDecimalPoint,CultureInfo.InvariantCulture,  out val1) 
              && double.TryParse(arg3,NumberStyles.AllowDecimalPoint,CultureInfo.InvariantCulture,  out val2)))
            throw new ArgumentException(Messages.InvalidNumberMessage);
        if (!TryParseOperation(arg2, out operation))
            throw new InvalidOperationException(Messages.InvalidOperationMessage);
    }
}