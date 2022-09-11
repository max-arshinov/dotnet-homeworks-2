using Hw1;

Parser.ParseCalcArguments(args, out var a1, out var op, out var a2);
var result = Calculator.Calculate(a1, op, a2);
Console.WriteLine(result);