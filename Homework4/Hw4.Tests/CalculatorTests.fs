module Hw4Tests.CalculatorTests

open System
open Hw4.Calculator
open Xunit
        
[<Theory>]
[<InlineData(15, 5, CalculatorOperation.Plus, 20)>]
[<InlineData(15, 5, CalculatorOperation.Minus, 10)>]
[<InlineData(15, 5, CalculatorOperation.Multiply, 75)>]
[<InlineData(15, 5, CalculatorOperation.Divide, 3)>]
let ``+, -, *, / work return correct calculation results`` (value1, value2, operation, expectedValue) =
    // act
    let actual = calculate value1 operation value2
    
    //assert
    Assert.Equal(expectedValue, actual)
    
[<Fact>]
let ``Undefined operations throw ArgumentOutOfRangeException`` () =
    //assert
    Assert.Throws<ArgumentOutOfRangeException>(fun () -> calculate 15.0 CalculatorOperation.Undefined 5.0 |> ignore)
    
[<Fact>]
let ``0 / anything but 0 = 0`` () =
    //act 
    let actual = calculate 0. CalculatorOperation.Divide 10.0
    
    //assert
    Assert.Equal(0.0, actual)
    
[<Fact>]
let ``anything but 0 / 0 = Infinity`` () =
    //act 
    let actual = calculate 10.0 CalculatorOperation.Divide 0.0
    
    //assert
    Assert.Equal(Double.PositiveInfinity, actual)
    
[<Fact>]
let ``0 / 0 = NaN`` () =
    //act 
    let actual = calculate 0. CalculatorOperation.Divide 0.0
    
    //assert
    Assert.Equal(Double.NaN, actual)
    

