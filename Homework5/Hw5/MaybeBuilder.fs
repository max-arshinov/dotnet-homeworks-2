module Hw5.MaybeBuilder

open System
open System.Globalization

let parseFloat (str: string) =
    match System.Double.TryParse(str.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture) with
    | true, float -> Some float
    | _ -> None

type Either<'a, 'b> =
    | Left of 'a
    | Right of 'b
    static member Fmap f m =
        match m with
        | Left x -> Left x
        | Right x -> Right(f x)

    static member Bind x f =
        match x with
        | Right b -> f b
        | Left a -> Left a

    static member Return x = Right x
    
    static member (<->) (f, x) = Either<_, _>.Fmap f x

type EitherBuilder() =
    member builder.Bind(a, f) : Either<'e, 'd> = Either<'e, 'd>.Bind a f
    member builder.Return x : Either<'a, 'b> = Either<'a, 'b>.Return x

let either = EitherBuilder()
