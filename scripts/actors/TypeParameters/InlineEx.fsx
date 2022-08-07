(*
    Basic inline function examples
*)

let inline inc x = x + 1

type WrapInt32() =
    member inline _.inc x = x + 1
    static member inline incBy x = x + 1

inc 1

WrapInt32.incBy 3
WrapInt32().inc 10

let add a b = a + b
let inline add' a b = a + b

add 10.1 10.2
add' 10.1 10.2
