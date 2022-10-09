module Hw4.Calculator

open System

type CalculatorOperation =
     | Plus = 0
     | Minus = 1
     | Multiply = 2
     | Divide = 3
     | Undefined = 4
     
let calculate (value1) (operation : CalculatorOperation) (value2) =
    match operation with 
        | CalculatorOperation.Plus -> value1 + value2 + 0.0
        | CalculatorOperation.Minus -> value1 - value2 + 0.0
        | CalculatorOperation.Multiply -> value1 * value2 + 0.0
        | CalculatorOperation.Divide -> value1 / value2 + 0.0
        | CalculatorOperation.Undefined -> raise (System.ArgumentOutOfRangeException())
    
