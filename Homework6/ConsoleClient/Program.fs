open System
open System.Net.Http
open System.Threading.Tasks

let handleQueryAsync(client : HttpClient) (url : string) =
    async {
        let! response = Async.AwaitTask (client.GetAsync url)
        let! res = Async.AwaitTask (response.Content.ReadAsStringAsync())
        return res
    }
let convertOperation operation =
    match operation with
    | "+" -> "Plus"
    | "-" -> "Minus"
    | "*" -> "Multiply"
    | "/" -> "Divide"
    
[<EntryPoint>]
let main args =
    use client = new HttpClient()
    let mutable input = Console.ReadLine()
    while not(input = "stop") do
        let mutable args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
        match args.Length with
        |3 ->
            let url = $"http://localhost:64445/calculate?value1={args[0]}&operation={args[1] |> convertOperation}&value2={args[2]}";
            printfn $"{args[0]} {args[1]} {args[2]} = {handleQueryAsync client url |> Async.RunSynchronously}"
        |_ -> Console.WriteLine("You must enter 3 args") 
        input <- Console.ReadLine()
    0