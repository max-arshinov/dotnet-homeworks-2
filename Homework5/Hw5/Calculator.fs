module Hw5.Calculator

open System

type CalculatorOperation =
     | Plus
     | Minus
     | Multiply
     | Divide

[<Literal>] 
let plus = "+"

[<Literal>] 
let minus = "-"

[<Literal>] 
let multiply = "*"

[<Literal>] 
let divide = "/"

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline calculate value1 operation value2 =
    match operation with
    | Plus -> value1 + value2
    | Minus -> value1 - value2
    | Multiply -> value1 * value2
    | Divide -> value1 / value2