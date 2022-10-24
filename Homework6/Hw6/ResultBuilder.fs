module Hw6.ResultBuilder

type ResultBuilder() =
    member builder.Bind(a, f) : Result<'e, 'd> =
        match a with
        | Ok a -> f a
        | Error e -> Error e
    member builder.ReturnFrom x : Result<'a, 'b> = x

let result = ResultBuilder()