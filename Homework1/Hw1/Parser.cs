namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(string[] args,
        out double val1,
        out CalculatorOperation operation,
        out double val2)
    {
        if (double.TryParse(args[0], out val1) == false) { throw new ArgumentException(); }

        if (double.TryParse(args[2], out val2) == false) { throw new ArgumentException(); }


        if (args.Length > 3) { throw new ArgumentException(); }

        switch (args[1])
        {
            case "+":
                operation = CalculatorOperation.Plus;
                break;
            case "-":
                operation = CalculatorOperation.Minus;
                break;
            case "*":
                operation = CalculatorOperation.Multiply;
                break;
            case "/":
                operation = CalculatorOperation.Divide;
                break;
            default:
                operation = CalculatorOperation.Undefined;
                throw new InvalidOperationException();
        }
    }

}
