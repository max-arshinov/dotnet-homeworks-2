module Hw5Tests.ParserTests

open Hw5
open Hw5.MaybeBuilder
open Hw5.Parser
open Microsoft.FSharp.Core
open Xunit
open Xunit.Sdk

let epsilon: decimal = 0.001m

let floatTestData: obj [] list = [
    [|"1.2"; Some 1.2|]
    [|"1,2"; Some 1.2|]
    [|"-1,2"; Some -1.2|]
    [| "frdwsfd"; None |]
]

[<Theory>]
[<MemberData(nameof(floatTestData))>]
let ``Float should work`` (value, expected) =
    Assert.Equal(expected, parseFloat value)

[<Theory>]
[<InlineData("15", "+", "5", 20)>]
[<InlineData("15", "-", "5", 10)>]
[<InlineData("15", "*", "5", 75)>]
[<InlineData("15", "/", "5",  3)>]
[<InlineData("15.6", "+", "5.6", 21.2)>]
[<InlineData("15.6", "-", "5.6", 10)>]
[<InlineData("15.6", "*", "5.6", 87.36)>]
[<InlineData("15.6", "/", "5.6", 2.7857)>]
let ``values parsed correctly`` (value1, operation, value2, expectedValue) =
    //arrange
    let values = [|value1;operation;value2|]
    
    //act
    let result = parseCalcArguments values
    
    //assert
    match result with
    | Right resultOk ->
        match resultOk with
        | arg1, operation, arg2 -> Assert.True((abs (expectedValue - Calculator.calculate arg1 operation arg2)) |> decimal < epsilon)
    | Left m -> XunitException $"Should return Right received {m}" |> raise
        
[<Theory>]
[<InlineData("f", "+", "3")>]
[<InlineData("3", "+", "f")>]
[<InlineData("a", "+", "f")>]
let ``Incorrect values return Error`` (value1, operation, value2) =
    //arrange
    let args = [|value1;operation;value2|]
    
    //act
    let result = parseCalcArguments args
    
    //assert
    match result with
    | Right _ -> XunitException "Should return WrongArgFormat" |> raise
    | Left resultError -> Assert.Equal(resultError, Message.WrongArgFormat)
    
[<Fact>]
let ``Incorrect operations return Error`` () =
    //arrange
    let args = [|"3";".";"4"|]
    
    //act
    let result = parseCalcArguments args
    
    //assert
    match result with
    | Right _ -> XunitException "Should return WrongArgFormatOperation" |> raise
    | Left resultError -> Assert.Equal(resultError, Message.WrongArgFormatOperation)
    
[<Fact>]
let ``Incorrect argument count returns WrongArgLength`` () =
    //arrange
    let args = [|"3";"+";"4";"5"|]
    
    //act
    let result = parseCalcArguments args

    //assert
    match result with
    | Right _ -> XunitException "Should return WrongArgLength" |> raise
    | Left resultError -> Assert.Equal(resultError, Message.WrongArgLength)
    
[<Fact>]
let ``any / 0 -> Error(Message.DivideByZero)`` () =
    //arrange
    let args = [|"3";"/";"0"|]
    
    //act
    let result = parseCalcArguments args
    
    //assert
    match result with
    | Right _ -> XunitException "Should return DivideByZero" |> raise
    | Left resultError -> Assert.Equal(resultError, Message.DivideByZero)

