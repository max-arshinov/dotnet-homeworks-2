module Hw4.Parser

open System
open System.Globalization
open Hw4.Calculator

let (|Float|_|) (str: string) =
    match System.Double.TryParse(str.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture) with
    | true, float -> Some float
    | _ -> None


type CalcOptions =
    { arg1: float
      arg2: float
      operation: CalculatorOperation }

let isArgLengthSupported (args: string []) =
    match args.Length with
    | 3 -> true
    | _ -> false

let parseOperation (arg: string) =
    match arg with
    | "+" -> CalculatorOperation.Plus
    | "-" -> CalculatorOperation.Minus
    | "*" -> CalculatorOperation.Multiply
    | "/" -> CalculatorOperation.Divide
    | _ -> ArgumentException "Invalid operation" |> raise

let parseCalcArguments (args: string []) =
    if not (isArgLengthSupported args) then
        ArgumentException "Invalid arguments count"
        |> raise
    else
        let arg1 =
            match args.[0] with
            | Float float -> float
            | _ ->
                ArgumentException "Invalid first argument"
                |> raise

        let operation = parseOperation args.[1]

        let arg2 =
            match args.[2] with
            | Float float -> float
            | _ ->
                ArgumentException "Invalid second argument"
                |> raise

        { arg1 = arg1
          arg2 = arg2
          operation = operation }
