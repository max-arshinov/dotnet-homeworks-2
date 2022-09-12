using System.Collections.ObjectModel;

namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(ReadOnlyCollection<string> args, 
        out double val1, 
        out CalculatorOperation operation, 
        out double val2)
    {
        if(!IsArgLengthSupported(args))
            throw new ArgumentException("Invalid count of input arguments");
        var val1Flag = double.TryParse(args[0], out val1);
        var val2Flag = double.TryParse(args[2], out val2);
        operation = ParseOperation(args[1]);
        if (!(val1Flag && val2Flag))
            throw new ArgumentException(
                "Wrong request syntax or unsupported type of values given. Format: {value operation value}. As values can be entered all integer or fractional numbers");
    }

    private static bool IsArgLengthSupported(ReadOnlyCollection<string> args) => args.Count == 3;

    private static CalculatorOperation ParseOperation(string arg)
    {
        switch(arg)
        {
            case "+":
                return CalculatorOperation.Plus;
            case "-":
                return CalculatorOperation.Minus;
            case "*":
                return CalculatorOperation.Multiply;
            case "/":
                return CalculatorOperation.Divide;
            default:
                throw new InvalidOperationException("Unsupported operation given");
        }
    }
}