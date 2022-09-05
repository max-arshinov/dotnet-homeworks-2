namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(string[] args, 
        out double val1, 
        out CalculatorOperation operation, 
        out double val2)
    {
        try
        {
            val1 = Convert.ToDouble(args[0]);
            val2 = Convert.ToDouble(args[2]);
        }
        catch
        {
            throw new ArgumentException();
        }
        if (!IsArgLengthSupported(args))
            throw new ArgumentException();

        operation = ParseOperation(args[1]);
        
        Calculator.Calculate(val1, operation, val2);
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static CalculatorOperation ParseOperation(string arg)
    {
        return arg switch
        {
            "+" => CalculatorOperation.Plus,
            "-" => CalculatorOperation.Minus,
            "/" => CalculatorOperation.Divide,
            "*" => CalculatorOperation.Multiply,
            _ => throw new InvalidOperationException()
        };
    }
}