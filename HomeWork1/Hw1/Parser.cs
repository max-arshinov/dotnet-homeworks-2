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

        val1 = ParseValue(args[0]);
        val2 = ParseValue(args[2]);
        operation = ParseOperation(args[1]);

        if (operation == CalculatorOperation.Undefined)
            throw new InvalidOperationException();
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static double ParseValue(string arg)
    {
        return double.TryParse(arg, out double val) ? val : throw new ArgumentException();
    }

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