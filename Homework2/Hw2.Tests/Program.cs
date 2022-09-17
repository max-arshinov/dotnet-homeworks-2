using Hw2;

public class Program
{ 
    public static void Main(string[] args)
    {
        Parser.ParseCalcArguments(args, out double val1, out CalculatorOperation operation, out double val2);

        var result = Calculator.Calculate(val1, operation, val2);
        Console.WriteLine(result);
    }
}
