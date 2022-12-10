module Hw5.Parser

open System
open Hw5.Calculator
open Hw5.MaybeBuilder

let isArgLengthSupported (args:string[]): Result<'a,'b> =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error Message.WrongArgLength

let parseOpr (str : string) =
    match str with 
    | "+" -> Some CalculatorOperation.Plus
    | "-" -> Some CalculatorOperation.Minus
    | "*" -> Some CalculatorOperation.Multiply
    | "/" -> Some CalculatorOperation.Divide
    | _ -> None

let (|Double|_|) arg =
    match Double.TryParse(arg: string) with
    | true, double -> Some double
    | _ -> None
    
[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline isOperationSupported (arg1, operation, arg2): Result<('a * CalculatorOperation * 'b), Message> =
    match parseOpr operation with
    | Some opr -> Ok (arg1, opr, arg2)
    | None -> Error Message.WrongArgFormatOperation


let parseArgs (args: string[]): Result<('a * string * 'b), Message> =
    match  args[0] with    
    | Double a ->
        match  args[2] with        
        | Double b -> Ok (a, args[1], b)
        | _ -> Error Message.WrongArgFormat
    | _ -> Error Message.WrongArgFormat
            
let inline isDividingByZero (arg1, operation, arg2): Result<('a * CalculatorOperation * 'b), Message> =
    if arg2 = 0.0 && operation = CalculatorOperation.Divide then Error Message.DivideByZero
    else Ok (arg1, operation, arg2)
    
let parseCalcArguments (args: string[]): Result<'a, 'b> =
    maybe {
        let! argLengthSupported = args |> isArgLengthSupported   
        let! argsParse = argLengthSupported |> parseArgs 
        let! operationParse = argsParse |> isOperationSupported 
        let! checkDividindByZero = operationParse |> isDividingByZero 
        return checkDividindByZero
    }
