(*
    Inheritance
*)

type Animal =
    val name: string
    new(name) = { name = name }
    new() = { name = "none" }

let bc1 = Animal()
let bc2 = Animal "Hello"

type Dog =
    inherit Animal
    val age: int
    new() = { inherit Animal(); age = 0 }
    new(name: string) = { inherit Animal(name); age = 0 }

    new(name: string, age: int) = { inherit Animal(name); age = age }

let c1 = Dog()
let c2 = Dog("Chips")
let c3 = Dog("Chips", 3)

c1
c2
c3

(*
    Simplified
*)

type Bird(name) =
    member this.Name = name
    member this.Fly() = printfn $"{name} is flywing"
    abstract member Walk: unit -> unit
    default x.Walk() = printfn $"{name} is walking"


type Parrot(name) =
    inherit Bird(name)

    [<DefaultValue>]
    val mutable age: int

    member x.Run() =
        printfn $"{base.Name} is also running..."

    override x.Walk() =
        printfn $"Parrot '{name}' is still walking"

let d1 = Parrot("Dove")
d1.Fly()
d1.Run()
d1.Walk()
(d1 :> Bird).Walk()


// The following doesn't work
// (d1 :> Bird).run()

(*
    anonymous class, inheritance
*)

open System

let obj1 =
    { new Object() with
        override x.ToString() : string = "Anonymous Object" }

obj1

let powerfulParrot =
    { new Parrot("Bolt") with
        override x.ToString() : string = "Running like a crazy parrot" }
// override x.Run() : unit = "Running like a stupid crazy bird"


powerfulParrot.ToString()
powerfulParrot.Run()
