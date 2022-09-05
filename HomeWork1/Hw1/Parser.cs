namespace Hw1;

public static class Parser
{
    private static double ParseDoubleArgument(string arg)
        => double.TryParse(arg, out var value)
            ? value
            : throw new ArgumentException("Invalid argument", nameof(arg));

    public static void ParseCalcArguments(
        string[] args,
        out double val1,
        out CalculatorOperation operation,
        out double val2)
    {
        if (!IsArgLengthSupported(args))
            throw new ArgumentException();

        val1 = ParseDoubleArgument(args[0]);
        operation = ParseOperation(args[1]);
        val2 = ParseDoubleArgument(args[2]);

        if(operation == CalculatorOperation.Undefined)
            throw new InvalidOperationException("Unknown operation");
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static CalculatorOperation ParseOperation(string arg)
        => arg switch
        {
            "+" => CalculatorOperation.Plus,
            "-" => CalculatorOperation.Minus,
            "*" => CalculatorOperation.Multiply,
            "/" => CalculatorOperation.Divide,
            _ => CalculatorOperation.Undefined
        };
}