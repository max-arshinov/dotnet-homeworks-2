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
            val1 = Convert.ToDouble(args[0]);
        }
        catch (Exception e)
        {
            throw new ArgumentException();
        }
        try
        {
            val2 = Convert.ToDouble(args[2]);
        }
        catch (Exception e)
        {
            throw new ArgumentException();
        }
        operation = ParseOperation(args[1]);
        val2 = Convert.ToDouble(args[2]);
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
            _ => throw new InvalidOperationException()
        };

    }
}