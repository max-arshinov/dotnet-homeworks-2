namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(string[] args, 
        out double val1, 
        out CalculatorOperation operation, 
        out double val2)
    {
        if (IsArgLengthSupported(args) == false) throw new ArgumentException();
        val1 = double.TryParse(args[0], out var sd) ? sd : throw new ArgumentException();
        operation = ParseOperation(args[1]);
        val2 = double.TryParse(args[2], out var cs) ? cs : throw new ArgumentException();
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static CalculatorOperation ParseOperation(string arg)
    {
        switch (arg)
        {
            case "+":
                return CalculatorOperation.Plus;
            case "-":
                return CalculatorOperation.Minus;
            case "/":
                return CalculatorOperation.Divide;
            case "*":
                return CalculatorOperation.Multiply;
            default: throw new InvalidOperationException();
        }
    }
}