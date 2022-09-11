namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(string[] args,
        out double val1,
        out CalculatorOperation operation,
        out double val2)
    {
        if (!IsArgLengthSupported(args))
            throw new ArgumentException("Too much arguments");

        if (!double.TryParse(args[0], out val1))
            throw new ArgumentException("Argument 1 is not a number");
        if (!double.TryParse(args[2], out val2))
            throw new ArgumentException("Argument 2 is not a number");
        operation = ParseOperation(args[1]);
        if (operation is CalculatorOperation.Undefined)
            throw new InvalidOperationException("Unsupported operation");
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static CalculatorOperation ParseOperation(string arg)
    {
        switch (arg)
        {
            case "+": return CalculatorOperation.Plus;
            case "-": return CalculatorOperation.Minus;
            case "*": return CalculatorOperation.Multiply;
            case "/": return CalculatorOperation.Divide;
            default: return CalculatorOperation.Undefined;
        }
    }
}