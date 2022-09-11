namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(string[] args, 
        out double val1, 
        out CalculatorOperation operation, 
        out double val2)
    {
        val1 = (double)Parser.ParseOperation(args[0]);
        val2 = (double)Parser.ParseOperation(args[2]);

        if (args.Length > 3) { throw new ArgumentException(); }

        if (args[1] == "+") { operation = CalculatorOperation.Plus; }
        else if (args[1] == "-") { operation = CalculatorOperation.Minus; }
        else if (args[1] == "*") { operation = CalculatorOperation.Multiply; }
        else if (args[1] == "/") { operation = CalculatorOperation.Divide; }
        else throw new InvalidOperationException();

    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;


    private static CalculatorOperation ParseOperation(string arg)
    {
        return Enum.Parse<CalculatorOperation>(arg);
    }
}