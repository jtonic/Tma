open System
open Messaging
open Tma

[<EntryPoint>]
let main _ =

    let sum a b = a + b
    let inc a = a + 1
    sum 1 (inc 2) |> printfn "Result 1 = %d"
    sum 1 $ inc 2 |> printfn "Result 2 = %d"
    // run ()

    let rec loop () =
        "Press 'y' to close" |> Console.WriteLine

        if Console.ReadLine() = "y" then
            List.pair 1 2 |> printfn "Result : %A"
    0
        else
            loop ()

    loop ()
