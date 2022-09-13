namespace Hw1;

public static class Parser
{
    public static void ParseCalcArguments(string[] args, 
        out double val1, 
        out CalculatorOperation operation, 
        out double val2)
    {
        if (IsArgLengthSupported(args) == false) throw new ArgumentException("Программа не распознает больше 3 входных данных");
        val1 = double.TryParse(args[0], out var sd) ? sd : throw new ArgumentException("Данные введены некорректно");
        operation = ParseOperation(args[1]);
        val2 = double.TryParse(args[2], out var cs) ? cs : throw new ArgumentException("Данные введены некорректно");
    }

    private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

    private static CalculatorOperation ParseOperation(string arg) =>
        arg switch
        {
            "+" => CalculatorOperation.Plus,
            "-" => CalculatorOperation.Minus,
            "/" => CalculatorOperation.Divide,
            "*" => CalculatorOperation.Multiply,
            _ => throw new InvalidOperationException("Данная операция не распознается программой"),
        };
}