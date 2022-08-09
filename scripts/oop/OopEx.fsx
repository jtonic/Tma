(*
    Simple Person class
*)

type Person(name: string, age: int) =

    do printfn $"Name: {name}, age: {age}"
    let _name = name
    let _age = age


    new() as this = Person(name = "Tony", age = Person.ProduceAge())
                            then printfn "Calling the non args constructore %A" this.Name

    member val Name = name
    member val Age = age with get, set

    member this.printName() = printfn $"name: {this.Name}"

    member self.printAge() = printfn $"age: {self.Age}"

    member self.printAll = self.printName >> self.printAge

    static member private ProduceAge () =
        System.Random() |> fun r -> r.Next 100


let irina = Person("Irina Stan", 31)
let jtonic = Person()
jtonic.printName ()
jtonic.printAge ()
jtonic.printAll ()

let tony = Person(name = "Antonel-Ernest Pazargic", age = 52)
tony.Age = 60 // This is equality check not asignment
tony.Age <- 60 // Mutation is not good

tony.Name |> sprintf "Person: name=%A"
tony.Age |> sprintf "Person: age=%A"
tony |> sprintf "Person: %A"

tony



(*
    Properties without associated constructor attributes
*)

type Role =
    | SysAdmin
    | DevOp
    | DevSecOp
    | User

type Admin() =
    let random = new System.Random()
    member val Name = $"admin-%d{random.Next()}" with get, set
    member val Role = SysAdmin

    static member LOG = "LOG"

let admin = Admin()
admin.Name |> sprintf "Admin: name=%A"
admin

Admin.LOG

(*
    Default mutable members
*)
type Animal() =

    [<DefaultValue>]
    val mutable name: string

    [<DefaultValue>]
    val mutable species: string

    [<DefaultValue>]
    val mutable age: int

let dog = Animal()
dog.name <- "TRex"
dog.species <- "DOG"
dog.age <- 10

dog
