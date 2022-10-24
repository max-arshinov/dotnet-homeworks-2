module Hw6.Client.TaskResultBuilder

open System.Threading.Tasks

type TaskResultBuilder() =
    member builder.Bind(a, f) : Task<Result<'b, 'd>> =
        task {
            match! a with
            | Ok x -> return! f x
            | Error e -> return Error e
        }
    member builder.Return x : Task<Result<'e, 'd>> = task { return Ok x }
    member builder.ReturnFrom x : Task<Result<'e, 'd>> = x
    member builder.Zero() : Task<Result<unit, 'd>> = task { return Ok () }

let taskResult = TaskResultBuilder()