open FSharp.Collections


[<EntryPoint>]
let main argv =
    printfn "Hello F# world!"
    List.pair 1 2 |> printfn "Result : %A"
    0
