
type Person = {
    Ssn: string
    Name: string
    Age: int
}

let persons: Person[] = [|
    { Ssn = "1"; Name = "Antonel-Ernest Pazargic"; Age = 52 }
    { Ssn = "2"; Name = "Liviu Pazargic"; Age = 39 }
|]

open System
persons |> Array.iter (fun person ->  printfn $"Person: %A{person}" )

let olderTony = {(Array.get persons 0) with Age = 53}

persons |> Array.insertAt 0 olderTony |> Array.iter (fun person -> printfn $"Person: %A{person}")

persons