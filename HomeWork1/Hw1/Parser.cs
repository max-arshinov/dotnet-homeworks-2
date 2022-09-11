using System;

namespace Hw1;

public class Parser
    {
        public static void ParseCalcArguments(string[] args, 
            out double val1, 
            out CalculatorOperation operation, 
            out double val2)
        {
            if (!IsArgLengthSupported(args))
                throw new ArgumentException();
            if (!Double.TryParse(args[0], out val1))
                throw new ArgumentException();
            if (!Double.TryParse(args[2], out val2))
                throw new ArgumentException();
            operation = ParseOperation(args[1]);
        }

        private static bool IsArgLengthSupported(string[] args) => args.Length == 3;

        private static CalculatorOperation ParseOperation(string arg)
        {
            var operation = arg switch
            {
                "+" => CalculatorOperation.Plus,
                "-" => CalculatorOperation.Minus,
                "/" => CalculatorOperation.Divide,
                "*" => CalculatorOperation.Multiply,
                _ => throw new InvalidOperationException()
            };
            return operation;
        }
    }
