(*
    OOP members examples
*)


type Role(name: string) =
    let mutable _type: string = "default"

    // new (name: string, _type: string) = {Role(name); _type <- _type}

    member this.Name = name
    member this.Type with get() = _type
    member this.Type with set value = _type <- value

    member this.Act (?insteadOf, ?times) =
        let _inSteadOf = defaultArg insteadOf "Guru"
        let _times = defaultArg times 1
        printfn "Act as having the role %s instead of %s times: %d" this.Name _inSteadOf _times

    member this.Reports to' how =
        printfn $"%s{this.Name} reports to %s{to'} using the procedure %s{how}"

    override x.ToString() : string = sprintf "name: %A, type: %A" x.Name x.Type

    static member GetAll() = [ Role("Admin"); Role("User"); Role("DbAdmin"); Role("SysAdmin") ]

let admin = Role("admin")
admin.Name |> printfn "%A"
admin.Type <- "super_admin"
admin.Type |> printfn "%A"
admin.Act()
admin.Act(?times=Some(3))
admin.Reports "Tony The Guru" "Daily"

Role.GetAll() |> List.iter (printfn "%A")

type Account() =
    let mutable balance = 0.0
    let mutable number = 0
    let mutable firstName = ""
    let mutable lastName = ""
    member this.AccountNumber
       with get() = number
       and set(value) = number <- value
    member this.FirstName
       with get() = firstName
       and set(value) = firstName <- value
    member this.LastName
       with get() = lastName
       and set(value) = lastName <- value
    member this.Balance
       with get() = balance
       and set(value) = balance <- value
    member this.Deposit(amount: float) = this.Balance <- this.Balance + amount
    member this.Withdraw(amount: float) = this.Balance <- this.Balance - amount

let MyAccount = Account(AccountNumber = 1, FirstName = "John", LastName = "Doe", Balance = 12)
MyAccount