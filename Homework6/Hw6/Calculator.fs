module Hw6.Calculator

open System

type CalculatorOperation =
     | Plus
     | Minus
     | Multiply
     | Divide

[<Literal>] 
let Op_plus = "Plus"

[<Literal>] 
let Op_minus = "Minus"

[<Literal>] 
let Op_multiply = "Multiply"

[<Literal>] 
let Op_divide = "Divide"

let parseOperation x =
    match x with
    | Op_plus -> Ok Plus
    | Op_minus -> Ok Minus
    | Op_multiply -> Ok Multiply
    | Op_divide -> Ok Divide
    | _ -> Error $"Could not parse value '{x}'"
    

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline calculate (value1: ^a) operation (value2: ^a)  =
    match operation with
    | Plus -> Ok (value1 + value2)
    | Minus -> Ok (value1 - value2)
    | Multiply -> Ok (value1 * value2)
    | Divide ->
        if (int value2 <> 0)
        then Ok (value1 / value2)
        else Error "DivideByZero"
