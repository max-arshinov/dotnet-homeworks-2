using System.Diagnostics.CodeAnalysis;
using Hw1;

namespace Hw1
{
    public static class Program
    {
        public static double Result { get; private set; }

        public static void Main(string[] args)
        {
            try
            {
                Parser.ParseCalcArguments(args, out double val1, out CalculatorOperation val2, out double val3);
                Result = Calculator.Calculate(val1, val2, val3);
            }
            catch
            {
                Result = double.NaN;
            }
        }
    }
}