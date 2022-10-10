module Hw5.Parser

open System
open Hw5.Calculator
open Hw5.MaybeBuilder
open Hw5.Utils

let (|CalculatorOperation|_|) (str) =
    match str with
    | Calculator.plus -> Some Plus
    | Calculator.minus -> Some Minus
    | Calculator.multiply -> Some Multiply
    | Calculator.divide -> Some Divide
    | _ -> None

let parseFrom f =
    Parser<string, _, _>.MakeConsume WrongArgLength
        (fun (s, xs) ->
            match f s with
            | Some f -> Right(xs, f)
            | _ -> Left WrongArgFormat)

let operationParser =
    Parser<_, _, _>.MakeConsume WrongArgLength
        (fun (s, xs) ->
            match s with
            | CalculatorOperation op -> Right(xs, op)
            | _ -> Left WrongArgFormatOperation)

let ensureEndParser<'a> =
    Parser<'a, _, _>.Make
        (fun (xs) ->
            match xs with
            | [] -> Right(xs, ())
            | _ -> Left WrongArgLength)

let createParser (f: string -> 't option) =
    Parser<_, _, _>.Pure (fun a1 op a2 _ -> (a1, op, a2))
    <*> parseFrom f
    <*> operationParser
    <*> parseFrom f
    <*> ensureEndParser

let parseArgs (args: string[]): Either<Message, ('b * CalculatorOperation * 'b)> =
        (fun (x, y) -> y) <-> Parser<_, _, _>.RunParser (createParser parseFloat) (Array.toList args)
        

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline isDividingByZero (arg1: ^a, operation, arg2: ^a): Either<Message, ('a * CalculatorOperation * 'a)> =
    if(float arg2 = 0 && operation = Divide) then
        Left DivideByZero
    else
        Right(arg1, operation, arg2)
    
let parseCalcArguments (args: string[]): Either<_, _> = either {
    let! parsedArgs = parseArgs args
    let! args = isDividingByZero parsedArgs
    return args
}