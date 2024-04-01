open System

let printOption opt =
    match opt with
        | Some a -> printfn $"Value: %A{a}"
        | None -> Console.WriteLine "None"

let op1 = Some 10
let op2 = Some "Hello world"
let op3 = None

printOption op1
printOption op2
printOption op3

(* New type *)

type IPrintable =
    abstract Print: unit -> unit

[<RequireQualifiedAccess>]
type Shape =
    | Circle of radius : float
    | Square of float
    | Rectangle of length : float * width : float
    | Triangle of b : float * h : float
    member this.area =
        match this with
            | Circle r -> Math.PI * r * r
            | Square l -> l * l
            | Rectangle (l, w) -> l * w
            | Triangle (b, h) -> b * h / 2.0

    interface IPrintable with
        member this.Print () =
            match this with
                | Circle radius -> printfn $"Circle: R=%A{radius}"
                | Square l -> printfn $"Square: l=%A{l}"
                | Rectangle (l, w) -> printfn $"Rectangle: L=%A{l}, W=%A{w}"
                | Triangle(b, h) -> printfn $"Triangle: B=%A{b}, H=%A{h}"


let printShape shape =
    match shape with
    | Shape.Circle radius -> printfn "Circle: R=%A" radius
    | Shape.Square l -> printfn "Square: l=%A" l
    | Shape.Rectangle (l, w) -> printfn "Rectangle: L=%A, W=%A" l w
    | Shape.Triangle(b, h) -> printfn "Triangle: B=%A, H=%A" b h

let area shape =
    match shape with
        | Shape.Circle r -> Math.PI * r * r
        | Shape.Square l -> l * l
        | Shape.Rectangle (l, w) -> l * w
        | Shape.Triangle (b, h) -> b * h / 2.0


let c1 = Shape.Circle (radius = 20.0)
printShape c1
area c1
c1.area

let c1P: IPrintable = c1
c1P.Print()
(c1 :> IPrintable).Print()

printfn $"Circle area: %f{c1.area}"

let square = Shape.Square 10
printShape square

let l, w = 10.0, 5.0
let rec1 = Shape.Rectangle (l, w)
printShape rec1

let Triangle = Shape.Triangle(b = 5, h = 7.5)
printShape Triangle

type Identity = | Identity of id : int
let printIdentity (Identity id) =
    printfn $"Identity's id: %d{id}"

let id1 = Identity 1
printIdentity id1