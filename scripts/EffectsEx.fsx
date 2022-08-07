(*
    Algebraical effect definition
    =========
    Syntactic sugar
*)
type Effect<'result> =
    | Log of string * (unit -> Effect<'result>)
    | Result of 'result

(*
    Version 1
    =========
*)
// effectful business logic
let sum' a b =
    Log ((sprintf "Add a=%i and b=%i" a b), fun () ->
        let res = a + b
        (Log ((sprintf "Result: %i" res), fun () ->
            Result res
        ))
    )

// handling the effect
let handle effect =
    let rec loop log = function
        | Log (str, cont) ->
            let log' = str :: log
            loop log' (cont ())
        | Result result -> result, log
    let result, log = loop [] effect
    result, log |> List.rev


(*
    Version 2
    =========
    Syntactic sugar
*)

// utils
let rec bind f = function
    | Log (str, cont) ->
        Log (str, fun () ->
            cont () |> bind f)
    | Result result -> f result

type EffectBuilder() =
    member __.Return(value) = Result value
    member __.Bind(effect, f) = bind f effect

let effect = EffectBuilder()

let log str = Log (str, fun () -> Result ())
let logf fmt = Printf.ksprintf log fmt

// effectfull business logic
let sum'' a b  =
    effect {
        do! logf "a=%i" a
        do! logf "b=%i" b
        let c = a + b
        do! logf "Side c=%i" c
        return c
    }

(*
    Call site
*)
// version 1
let c1, log1 =
    sum' 1 2
        |> handle

(c1, log1)
    ||> fun a b -> printfn "%A, %A"  a b

// version 2
let c2, log2 =
    sum'' 1 2
        |> handle

(c2, log2)
    ||> fun a b -> printfn "Syntactic sugar: %A, %A"  a b
