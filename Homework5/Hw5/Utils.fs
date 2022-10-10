module Hw5.Utils

open Hw5.MaybeBuilder

type Parser<'tok, 'a, 'b> =
    { parser: List<'tok> -> Either<'b, List<'tok> * 'a> }
    static member RunParser prs = prs.parser
    static member Make f = { parser = f }

    static member Pure f =
        Parser.Make (fun inp -> Right(inp, f))

    static member MakeConsume err f =
        Parser.Make
            (fun inp ->
                match inp with
                | [] -> Left err
                | x::xs -> f (x, xs))

    static member Ap (a: Parser<_, _, _>) (b: Parser<_, _, _>) =
        Parser.Make
            (fun tok -> either {
                let! tok', f = Parser.RunParser a tok
                let! tok'', x = Parser.RunParser b tok'
                return (tok'', f x) })

    static member (<*>)(a, b) = Parser<_, _, _>.Ap a b

