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

        bool isVal1Correct = double.TryParse(args[0], out val1);
        if (!isVal1Correct)
            throw new ArgumentException();

        bool isVal2Correct = double.TryParse(args[2], out val2);
        if (!isVal2Correct)
            throw new ArgumentException();

        operation = ParseOperation(args[1]);
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
            case "*":
                return CalculatorOperation.Multiply;
            case "/":
                return CalculatorOperation.Divide;
            default:
                throw new InvalidOperationException();
        }
    }
}