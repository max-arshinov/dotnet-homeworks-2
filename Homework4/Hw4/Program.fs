open Hw4.Parser
open Hw4.Calculator

let getArgs = System.Console.ReadLine().Split()
 
let args = getArgs
if args <> null && (isArgLengthSupported args) then
    let values = parseCalcArguments args
    let result = calculate values.arg1 values.operation values.arg2
    printf $"{result}"
else raise(System.ArgumentException("Invalid input format!"))