namespace Hw1;
using System.Globalization;

public static class Parser
{
    public static void ParseCalcArguments(string[] args, 
        out double val1, 
        out CalculatorOperation operation, 
        out double val2)
    {
        operation = ParseOperation(args[1]);
        if (args == null || !IsArgLengthSupported(args) 
            || !double.TryParse(args[0],out val1) || !double.TryParse(args[2], out val2))
            throw new ArgumentException();

        else if (operation == CalculatorOperation.Undefined)
            throw new InvalidOperationException();
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static CalculatorOperation ParseOperation(string arg)
    {
        return arg switch
        {
            "+" => CalculatorOperation.Plus,
            "-" => CalculatorOperation.Minus,
            "*" => CalculatorOperation.Multiply,
            "/" => CalculatorOperation.Divide,
            _ => CalculatorOperation.Undefined
        };
    }
}