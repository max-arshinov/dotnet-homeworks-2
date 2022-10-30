module Hw6.Calculator

open System
open Microsoft.FSharp.Core.CompilerServices

type CalculatorOperation =
     | Plus = 0
     | Minus = 1
     | Multiply = 2
     | Divide = 3

[<Literal>] 
let plus = "Plus"

[<Literal>] 
let minus = "Minus"

[<Literal>] 
let multiply = "Multiply"

[<Literal>] 
let divide = "Divide"

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline calculate (value1, operation, value2): 'a =
    match operation with
        | CalculatorOperation.Plus -> Ok (value1 + value2)
        | CalculatorOperation.Minus -> Ok (value1 - value2)
        | CalculatorOperation.Multiply -> Ok (value1 * value2)
        | CalculatorOperation.Divide -> Ok (value1 / value2)
        | _ -> Error "unknown operation"