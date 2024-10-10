#r "nuget:FSToolkit.ErrorHandling"
open System
open FsToolkit.ErrorHandling


type Status =
    | Started
    | NotStarted
    | Completed
    
let classify (fist: 't option) (last: 'u option) =
    match fist, last with
    | Some _, Some _ -> Completed
    | Some _, _ -> Started
    | _ -> NotStarted
    
let status = classify (Some 1) (Some 2)
let started = classify (Some 1) None

let notStarted = classify None (Some 1)

let classify2 (first: 't option) (last: 'u option) = raise <| NotImplementedException()

classify2 (Some 1) (Some 2)


let classify3 (first: 't option) (last: 'u option) =
    option {
        let! first = first
        let! last = last
        return Completed
    }