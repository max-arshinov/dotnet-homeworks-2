module Hw4.Parser

open System
open Hw4.Calculator


type CalcOptions = {
    arg1: float
    arg2: float
    operation: CalculatorOperation
}

let (|Double|_|) str =
   match Double.TryParse(str:string) with
   | (true,value) -> Some(value)
   | _ -> ArgumentException($"Argument {str} is not double!") |> raise

let isArgLengthSupported (args : string[]) =
    args <> null && args.Length = 3

let parseOperation (arg : string) =
    match arg with
    | "+" -> CalculatorOperation.Add
    | "-" -> CalculatorOperation.Subtract
    | "*" -> CalculatorOperation.Multiply
    | "/" -> CalculatorOperation.Divide
    | _ -> ArgumentException("Incorrect operation! Available: +, -, *, /") |> raise
    
let parseCalcArguments(args : string[]) =
    if not (isArgLengthSupported args)
        then ArgumentException("There must be 3 arguments!") |> raise
    else
        let opr = parseOperation args[1]
        let value1 = (|Double|_|) args[0]
        let value2 = (|Double|_|) args[2]

        {arg1 = value1.Value; arg2 = value2.Value; operation = opr}