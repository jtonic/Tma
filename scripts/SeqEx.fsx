open System

let tens = seq { 0 .. 10 .. 100 }

let integers = seq { for i = 0 to Int32.MaxValue do yield i }

let run =
    tens |> Seq.head |> printfn "First: %d" |> ignore
    tens |> Seq.isEmpty |> printfn "Empty: %b" |> ignore
    tens |> Seq.map ((+) 1) |> Seq.take 3 |> printfn "First three incremented: %A" |> ignore

    integers
        |> Seq.take 10
        |> Seq.fold (+) 0
        |> printfn "Sum of first 10 integers: %d"
        |> ignore
