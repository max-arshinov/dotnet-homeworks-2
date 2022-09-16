using System.Diagnostics.CodeAnalysis;
using Hw1;

namespace Hw1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Parser.ParseCalcArguments(args, out double val1, out CalculatorOperation val2, out double val3);
            Console.WriteLine(Calculator.Calculate(val1, val2, val3));
        }
    }
}