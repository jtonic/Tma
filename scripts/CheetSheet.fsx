open System

let sumOfLenghts (xs: string[]) =
    xs
        |> Array.map(fun x -> x.Length)
        |> Array.sum

let rec fac n =
    if n < 1 then 1
    else n * fac (n - 1)

let rec fib n =
    match n with
        | 1 | 2 -> 1
        | _ -> fib (n - 1) + fib (n - 2)

let printResult (prefix: string) =
        sprintf "%s: %d" prefix
        >> Console.WriteLine
        >> ignore

let run =
    fib 3
        |> sprintf "Fibonacci of 3: %d"
        |> Console.WriteLine
    fac 3
        |> printResult "Fibonacci of 3"
    sumOfLenghts [|"Tony"; "Irina";|]
        |> printfn "Sum of strings length: %d"
