using Hw1;

// Как я понял просто для понимания что-где
var arg1 = args[0];
var operation = args[1];
var arg2 = args[2];
// ---

Parser.ParseCalcArguments(args, out var val1, out var operationResult, out var val2);

// TODO: implement calculator logic
var result = Calculator.Calculate(val1, operationResult, val2);
Console.WriteLine(result);