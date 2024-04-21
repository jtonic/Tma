#r "nuget: FsToolkit.ErrorHandling"

open FsToolkit.ErrorHandling
open System

let tryParseNumber (number: string): int option =
    match Int32.TryParse number with
    | (true, n) -> Some n
    | _ -> None

// composing effects using Option.bind and Option.map
let sum1 =
    "1" |> tryParseNumber
        |> Option.bind (fun a -> tryParseNumber "2"
                                 |> Option.bind (fun b -> tryParseNumber "3"
                                                          |> Option.map (fun c -> a + b + c)))
        |> Option.defaultValue -1

// composing effects using computation expression
let sum2 =
    option {
        let! a = tryParseNumber "1"
        let! b = tryParseNumber "2"
        let! c = tryParseNumber "3"
        return a + b + c
    } |> Option.defaultValue -1
