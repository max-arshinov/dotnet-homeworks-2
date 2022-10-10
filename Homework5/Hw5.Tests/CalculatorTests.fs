module Hw5Tests.CalculatorTests

open Hw5
open Hw5.Calculator
open Microsoft.FSharp.Core
open Xunit

let epsilon: decimal = 0.001m
        
let intTest: obj [] list = [
    [| 15; 5; CalculatorOperation.Plus; 20 |]
    [| 15; 5; CalculatorOperation.Minus; 10 |]
    [| 15; 5; CalculatorOperation.Multiply; 75 |]
    [| 15; 5; CalculatorOperation.Divide; 3 |]
]
        
[<Theory>]
[<MemberData(nameof(intTest))>]
let ``+, -, *, / work return correct calculation results with ints`` (value1 : int, value2: int, operation, expectedValue : int) =
    //act
    let actual = calculate value1 operation value2
    
    //assert
    Assert.Equal(expectedValue, actual)

let doubleTest: obj [] list = [
    [| 15.6; 5.6; CalculatorOperation.Plus; 21.2 |]
    [| 15.6; 5.6; CalculatorOperation.Minus; 10 |]
    [| 15.6; 5.6; CalculatorOperation.Multiply; 87.36 |]
    [| 15.6; 5.6; CalculatorOperation.Divide; 2.7857 |]
]

[<Theory>]
[<MemberData(nameof(doubleTest))>]
let ``+, -, *, / work return correct calculation results with floats``
    (value1 : float, value2: float, operation, expectedValue : float) =
    //act
    let actual = abs (expectedValue - calculate value1 operation value2)
        
    //assert
    Assert.True(actual |> decimal < epsilon)
    
let decimalTest: obj [] list = [
    [| 15.6m; 5.6m; CalculatorOperation.Plus; 21.2m |]
    [| 15.6m; 5.6m; CalculatorOperation.Minus; 10m |]
    [| 15.6m; 5.6m; CalculatorOperation.Multiply; 87.36m |]
    [| 15.6m; 5.6m; CalculatorOperation.Divide; 2.7857m |]
]

[<Theory>]
[<MemberData(nameof(decimalTest))>]
let ``+, -, *, / work return correct calculation results with decimals``
    (value1 : decimal, value2: decimal, operation, expectedValue : decimal) =
    //act
    let actual = abs (expectedValue - calculate value1 operation value2)
        
    //assert
    Assert.True(actual |> decimal < epsilon)
    