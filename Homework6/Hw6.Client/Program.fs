// For more information see https://aka.ms/fsharp-console-apps

open System
open System.Globalization
open System.Threading.Tasks
open Hw6.Client.HttpAction
open Hw6.Client.ResultBuilder
open Hw6.Client.TaskResultBuilder
open Microsoft.FSharp.Core

let Op_plus = "Plus"

[<Literal>]
let Op_minus = "Minus"

[<Literal>]
let Op_multiply = "Multiply"

[<Literal>]
let Op_divide = "Divide"

let apiClient =
    new CalculatorApi("http://localhost:5000")

let tryParseOperation (op: string) =
    match op with
    | "+" -> Ok Op_plus
    | "-" -> Ok Op_minus
    | "/" -> Ok Op_divide
    | "*" -> Ok Op_multiply
    | _ -> Error "Неизвестная операция"

let parseDecimal (str: string) =
    match Decimal.TryParse(str.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture) with
    | true, float -> Ok float
    | _ -> Error $"Невозможно преобразовать {str} в число"

let readCalculation () =
    result {
        printf "Введите первое число: "
        let! a = Console.ReadLine() |> parseDecimal
        printf "Введите символ операции(+-*/): "
        let! op = Console.ReadLine() |> tryParseOperation
        printf "Введите второе число: "
        let! b = Console.ReadLine() |> parseDecimal

        return
            { value1 = a
              operator = op
              value2 = b }
    }

let printResult (result: Result<string, string>) =
    match result with
    | Ok result -> printfn $"Результат: %s{result}"
    | Error error -> printfn $"Ошибка: %s{error}"

let doCalculation (calculation: CalculateRequest) =
    task {
        match! apiClient.Calculate(calculation) with
        | Ok result -> return Ok result
        | Error error -> return Error error.message
    }

let rec waitForExitOrContinue () =
    printfn "\nНажмите enter для продолжения или q для выхода\n"

    match Console.ReadKey().Key with
    | ConsoleKey.Q -> false
    | ConsoleKey.Enter -> true
    | _ -> waitForExitOrContinue ()

[<EntryPoint>]
let main argv =
    let workWithUser () =
        let computation = taskResult {
            let! calculation = readCalculation () |> Task.FromResult
            return! doCalculation calculation
        }
        task {
            let! calculatorResult = computation
            printResult calculatorResult
        }

    let rec loop () =
        workWithUser().Result |> ignore
        if waitForExitOrContinue() then
            loop()

    loop()
    0 // return an integer exit code
