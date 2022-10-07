open System

open Hw5.MaybeBuilder
open Hw5.Calculator
open Hw5.Parser

[<EntryPoint>]
let main args =
    let res = either {
        let! (a, op, b) = parseCalcArguments args
        return calculate a op b
    }
    
    match res with
    | Left err -> printfn "Error: %s" (err.ToString())
    | Right res -> printfn "Result: %f" res

    0 // return an integer exit code