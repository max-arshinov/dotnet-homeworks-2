using Hw1;

Parser.ParseCalcArguments(args, out var left, out var op, out var right);
Console.WriteLine(Calculator.Calculate(left, op, right));