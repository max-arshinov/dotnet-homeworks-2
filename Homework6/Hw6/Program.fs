module Hw6.App


open System
open Hw6.InputValues
open Hw6.MaybeBuilder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe

let convertOperation operation =
    match operation with
    | "+" -> "Plus"
    | "-" -> "Minus"
    | "*" -> "Multiply"
    | "/" -> "Divide"

let calculatorHandler: HttpHandler =
    fun next ctx ->
        let result = maybe{
            let! args = ctx.TryBindQueryString<InputValues>()
            let! parsed = Parser.parseCalcArguments [| args.value1; args.operation; args.value2 |]
            let! calc = Calculator.calculate parsed
            return calc
        }
        match result with
        | Ok ok -> (setStatusCode 200 >=> text (ok.ToString())) next ctx
        | Error error ->
            match error with
            | "DivideByZero" -> (setStatusCode 200 >=> text (error.ToString())) next ctx
            | _ -> (setStatusCode 400 >=> text error) next ctx

let webApp =
    choose [
        GET >=> choose [
             route "/" >=> text "Use //calculate?value1=<VAL1>&operation=<OPERATION>&value2=<VAL2>"
             route "/calculate" >=> calculatorHandler
        ]
        setStatusCode 404 >=> text "Not Found" 
    ]
type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder) (_ : IHostEnvironment) (_ : ILoggerFactory) =
        app.UseGiraffe webApp

[<EntryPoint>]
let main _ =
    Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(fun whBuilder -> whBuilder.UseStartup<Startup>() |> ignore)
        .Build()
        .Run()
    0