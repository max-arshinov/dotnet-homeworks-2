open Hw4

[<EntryPoint>]
let main args =
    let res = Parser.parseCalcArguments args
    printf $"%f{Calculator.calculate res.arg1 res.operation res.arg2}"
    0 // return an integer exit code