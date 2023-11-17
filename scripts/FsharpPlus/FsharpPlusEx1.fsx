#r "nuget: FSharpPlus, 1.3.0-CI02606"

open FSharpPlus

map string [|2;3;4;5|]

map ((+) 3) (Some 10)

let tryParseInt : string -> int option = tryParse
let tryDivide x n = if n = 0 then None else Some (x / n)

let y = Some "20" >>= tryParseInt >>= tryDivide 100

let parseAndDivide100By = tryParseInt >=> tryDivide 100
"20" |> parseAndDivide100By
Some "20" >>= parseAndDivide100By
Some "20" >>= (tryParseInt >=> tryDivide 100)

(* Miscs *)
open FSharpPlus.Data

// NonEmptyList
let lst = NonEmptyList.create 1 [2;3]
lst

[1;2;3;4] |> map ((+) 1)
[|1;2;3;4|] |> map string
[1;2;3] |> toSeq |> map string


// ------

let tripleIt i = [i;i;i]
let toString i : string list = [i] |> map string
let tripleAndToString = tripleIt >=> toString

let z1 = [1;2;3] >>= tripleIt >>= toString

let z2 = [1;2;3] >>= tripleAndToString
