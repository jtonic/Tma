// -------------------------------------------------------------------
// 1. Extension properties
// -------------------------------------------------------------------
type System.Int32 with
    member this.IsEven = this % 2 = 0
// Usage
let i = 4
if i.IsEven then
    printfn "Even"
else
    printfn "Odd"

// -------------------------------------------------------------------
// 2. Extension methods
// -------------------------------------------------------------------
type System.String with
    member this.Reverse() = new string(Array.rev (this.ToCharArray()))

// Usage
let s = "Hello"
s.Reverse() |> printfn "%s"

// -------------------------------------------------------------------
// 3. Array, list, sequence comprehensions
// -------------------------------------------------------------------

let evensLst = [ for i in 1..10 do if i % 2 = 0 then yield i ]
evensLst |> List.iter (fun i -> printfn $"%d{i}")

let evensArr = [| for i in 1..10 do if i % 2 = 0 then yield i |]
evensArr |> Array.iter (fun i -> printfn $"%d{i}")

let evensSeq = seq { for i in 1..10 do if i % 2 = 0 then yield i }
evensSeq |> Seq.iter (fun i -> printfn $"%d{i}")

// -------------------------------------------------------------------
// 4. Point free and function composition
// -------------------------------------------------------------------
let add3andDoble = (+) 3 >> (*) 2
10 |> add3andDoble

// Warn: Pipe forward operator applies to the first argument.
//       So if the order of the arguments is important, you should use the pipe backward operator.

// THE FOLLOWING IS NOT CORRECT. The argument is partially applied to the first argument
let isEven = (%) 2 >> (=) 0  // => (%) 2 10 = 2

10 |> (%) <| 2 // => (%) 10 2
