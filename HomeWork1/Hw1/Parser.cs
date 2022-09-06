namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(string[] args, 
        out double val1, 
        out CalculatorOperation operation, 
        out double val2)
    {
        if (!IsArgLengthSupported(args))
            throw new ArgumentException();
        try
        {
            val1 = double.Parse(args[0]);
            val2 = double.Parse(args[2]);
        }
        catch (FormatException)
        {
            throw new ArgumentException();
        }
        operation = ParseOperation(args[1]);
        if (operation == CalculatorOperation.Undefined)
            throw new InvalidOperationException();
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static CalculatorOperation ParseOperation(string arg)
    {
        if (arg == "+")
            return CalculatorOperation.Plus;
        else if (arg == "-")
            return CalculatorOperation.Minus;
        else if (arg == "*")
            return CalculatorOperation.Multiply;
        else if (arg == "/")
            return CalculatorOperation.Divide;
        else return CalculatorOperation.Undefined;
    }
}