open System
open Hw5

let getArgs (input : string[]) : string[] =
    match input.Length with
    | 0 ->
        let str = Console.ReadLine()
        let args = str.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        args
    | _ -> input

let messageToString message=
    match message with
    | Message.WrongArgLength -> "Неверное количество входных данных."
    | Message.WrongArgFormat -> "Число неправильного формата.";
    | Message.WrongArgFormatOperation -> "Нет такой операции!"
    | Message.DivideByZero -> "Деление на 0."
    
let calculate (a,operation:Calculator.CalculatorOperation, b) =
    Calculator.calculate a operation b
    
[<EntryPoint>]
let main (args: string[]) =
    let parsedArgs = getArgs args
    match Parser.parseCalcArguments parsedArgs with 
    | Ok num -> printf $"{calculate num}"
    | Error err -> printf $"Error occured: {messageToString err}"
    0          