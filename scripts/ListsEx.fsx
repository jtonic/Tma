open System

// Utility
let ap f x = fun y -> f y x

let nums = [1; 2; 3;]

"Version 1" |> Console.WriteLine
let str = sprintf "Incremented numbers %A\n" (nums |> List.map (ap (+) 1))
str |> Console.WriteLine

"Version 2" |> Console.WriteLine
printfn "Incremented numbers %A\n" (nums |> List.map (ap (+) 1))

"The coolest version" |> Console.WriteLine
nums
    |> List.map (ap (+) 1)
    |> (sprintf) "Incremented numbers %A\n"
    |> Console.WriteLine
