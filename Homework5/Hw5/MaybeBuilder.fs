module Hw5.MaybeBuilder

open System

type MaybeBuilder() =
    member builder.Bind(a, f): Result<'e,'d> =
           match a with
           | Ok a -> f a
           | Error a -> Error a 
       member builder.Return x: Result<'a,'b> =
           Ok x
let maybe = MaybeBuilder()