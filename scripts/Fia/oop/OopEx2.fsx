(*
    Interface definition
*)

type INumberic =
    abstract member Add: x: int -> y: int -> int
    abstract member Substract: x: int * y: int -> int // don't use this

(*
    Implementation and usage by class
*)
type SimpleMath() =
    member this.Add = (this :> INumberic).Add
    // member this.Substract = (this :> INumberic).Substract

    interface INumberic with
        member this.Add (x: int) (y: int) : int = x + y
        member this.Substract(x: int, y: int) : int = x - y // don't use this

let iMyMath: INumberic = SimpleMath()
iMyMath.Add 2 1
iMyMath.Substract(2, 1)

(SimpleMath() :> INumberic).Add 10 20

let myMath = SimpleMath()
myMath.Add 100 200
// myMath.Substract(100, 200) // this doesn't work because is not exposed as class member

(*
    Implementation and usage by object expression
*)

let myMathF =
    { new INumberic with
        member this.Add (x: int) (y: int) : int = x + y
        member this.Substract(x: int, y: int) : int = x - y }

myMathF.Add 20 10
myMathF.Substract(20, 10)

(*
    Interface inheritance
*)
type IAdd =
    abstract member Add: x: int -> y: int -> int

type ISubstract =
    abstract member Substract: x: int -> y: int -> int

type IBasicMath =
    inherit IAdd
    inherit ISubstract

type BasicMath() =
    interface IBasicMath with
        member this.Add (x: int) (y: int) : int = x + y
        member this.Substract (x: int) (y: int) : int = x - y

let basicMath1 =
    { new IBasicMath with
        member this.Add (x: int) (y: int) : int = x + y
        member this.Substract (x: int) (y: int) : int = x - y }

basicMath1.Add 10 1
basicMath1.Substract 10 1

let basicMath2 = BasicMath() :> IBasicMath
basicMath2.Add 10 1
basicMath2.Substract 10 1

(*
    Interface and generics
*)

type IGet<'T> =
    abstract member Get: unit -> 'T

type Producer() =
    interface IGet<int> with
        member this.Get() = 1

    interface IGet<string> with
        member this.Get() = "empty"

let prd = Producer()
let prd1: IGet<string> = prd
let prd2 = prd :> IGet<int>

prd1.Get()
prd2.Get()
