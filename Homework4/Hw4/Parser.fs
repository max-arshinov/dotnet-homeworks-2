module Hw4.Parser

open System
open Hw4.Calculator


type CalcOptions = {
    arg1: float
    arg2: float
    operation: CalculatorOperation
}

let isArgLengthSupported (args : string[]) =
    if args.Length = 3 then true
    else false 

let parseOperation (arg : string) =
    match arg with
        | "+" -> CalculatorOperation.Plus
        | "-" -> CalculatorOperation.Minus
        | "*" -> CalculatorOperation.Multiply
        | "/" -> CalculatorOperation.Divide 
        | _ -> raise (System.ArgumentException())

type result (_arg1: float, _operation:CalculatorOperation, _arg2: float) =
    member this.arg1 = _arg1
    member this.operation = _operation
    member this.arg2 = _arg2

 
let rec parseCalcArguments(args : string[]) = 
    if isArgLengthSupported args 
        && System.Double.TryParse(args.[0]) |> fst  
        && System.Double.TryParse(args.[2]) |> fst 
    then 
        let _arg1 = System.Double.Parse(args.[0]) 
        let _arg2 = System.Double.Parse(args.[2]) 
        result(_arg1, parseOperation args.[1], _arg2)
    else raise(System.ArgumentException())