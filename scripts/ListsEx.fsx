open System
open FSharp.Collections

let lst1 = [for i = 0 to 200 do yield i];

let lst2 = [for i = 0 to 200 do if i < 10 then yield i]

let lst3 = [for i in 1 .. 3 do yield i]

let run =
    1 :: 2 :: 3 :: [] |> printfn "Result: %A"

    [1; 2; 3] |> printfn "Result: %A"

    [1..3] |> printfn "Result: %A"

    lst1 |> List.takeWhile (fun i -> i < 10)
         |> printfn "Result: %A"

    lst2 |> printfn "Result: %A"

    lst3 |> printfn "Result: %A"

    lst3
        |> List.tryItem 10
        |> printfn "Item 10: %A"

    let booleans = [true; false; true; true]
    let numbers = [1..4]
    List.zip booleans numbers
        |> List.choose (function (false, v) -> Some v | _ -> None)
        |> printfn "Chose: %A"

    List.zip booleans numbers
        |> List.filter (fst >> not)
        |> List.map snd
        |> printfn "Only falses: %A"

    [1; 2; 3;]
        |> List.map ((+) 1)
        |> (sprintf) "Incremented numbers %A\n"
        |> Console.WriteLine
