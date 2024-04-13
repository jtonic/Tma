open System.Collections.Generic


// ------------------------------------------------------------
// reverse a string using a stack, using procedural style
// ------------------------------------------------------------

let name = "Antonel"

// using procedural style
let st = Stack<char>()
for c in name do
    st.Push(c)

while st.Count > 0 do
    printf $"%c{st.Pop()}"
printfn ""
    
// using functional style
name
    |> Seq.fold(fun (st: Stack<char>) c -> st.Push(c); st) (Stack<char>())
    |> Seq.fold(fun acc c -> acc + string(c)) ""

    