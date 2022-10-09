module Hw4.Calculator

open System

type CalculatorOperation =
     | Add = 0
     | Subtract = 1
     | Multiply = 2
     | Divide = 3
     | Undefined = 4
     
let calculate (value1 : float) (operation : CalculatorOperation) (value2 : float) =
    match operation with 
    | CalculatorOperation.Add -> value1 + value2
    | CalculatorOperation.Subtract -> value1 - value2
    | CalculatorOperation.Multiply -> value1 * value2
    | CalculatorOperation.Divide -> value1 / value2
    | _ -> ArgumentOutOfRangeException("Undefined operation! Available: +, -, *, /") |> raise