(*
    Simple infix example
*)

let inline (+@) x y = x + x * y

(+@) 2 10
2 +@ 10


let inline (++) (x: 'x seq) (y: 'x seq) = [ x; y ] |> Seq.concat

let a = { 1..10 }
let b = { 10..100 }

[ a; b ] |> Seq.concat

a ++ b |> Seq.take 4 |> Seq.iter (printfn "%A")

let inline ($) (f: 'a -> 'b) (a: 'a) : 'b = f a

let add a b = a + b
let inc a = a + 1

add 1 (inc 2)
add 1 $ inc 2
