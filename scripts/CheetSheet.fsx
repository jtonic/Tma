open System

let sumOfLenghts (xs: string[]) =
    xs
        |> Array.map(fun x -> x.Length)
        |> Array.sum

let rec fac n =
    if n < 1 then 1
    else n * fac (n - 1)

let rec fib1 n =
    match n with
        | 0 | 1 -> n
        | _ -> fib1 (n - 1) + fib1 (n - 2)

let rec fib2 = function
    | 0 -> 0
    | 1 -> 1
    | x -> fib2 (x - 1) + fib2 (x - 2)

let printResult (prefix: string) =
        sprintf "%s: %d" prefix
        >> Console.WriteLine
        >> ignore

let run =
    fib1 3
        |> sprintf "Fibonacci of 3: %d"
        |> Console.WriteLine
        |> ignore
    fac 3
        |> printResult "Fibonacci of 3"
    sumOfLenghts [|"Tony"; "Irina";|]
        |> printfn "Sum of strings length: %d"
        |> ignore
