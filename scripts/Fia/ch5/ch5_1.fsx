(*
    Tuples
*)

// 1. reference type tuples
let person = "Antonel", "Pazargic", 54, "Bucharest"

let _, _, age, _ = person
age


let makeDoctor ((_, sName), rating) =
    $"{rating} Dr. ", sName
    
makeDoctor (("Antonel", "Pazargic"), "Amazing")

// 2. value type tuples

let makeDoctor' (a: struct (string * string)) =
    let struct (_, sName) = a
    struct ("Dr", sName)

makeDoctor' (struct ("Antonel", "Pazargic"))

// 3. tuple with named fields don't exist in F#
// somehow emulated with single-case discriminated unions

type FirstName = FirstName of string
type LastName = LastName of string

let tony = FirstName "Antonel", LastName "Pazargic"
let FirstName fn, LastName ln = tony
fn, ln


(*
    Records
*)

type Address =
    {
        Town: string
        Country: string
    }

type Person =
    {
      FirstName: string
      LastName: string
      Address: Address
      Age: int
    }

type Student =
    {
      FirstName: string
      LastName: string
      Address: Address
      Age: int
    }

let anto: Person =
    {
        FirstName = "Antonel"
        LastName = "Pazargic"
        Address = {Town = "Bucharest"; Country = "Romania" } 
        Age = 54
    }
    
let getPerson theAddress =
    if (theAddress.Country = "UK") then
        {
            Person.FirstName = "Antonel"
            LastName = "Pazargic"
            Address = theAddress
            Age = 54
        }
    else
        {
            FirstName = "Antonel-Ernest"
            LastName = "Pazargic"
            Address = theAddress
            Age = 58 
        }
        
let fullName = $"{anto.FirstName} {anto.LastName} is {anto.Age} years old"

let anto2 = getPerson { Town = "London"; Country = "UK" }

let anto3 = { anto2 with FirstName = "Anto" }

// Anonymous records

let company =
    {|
        Name = "My Company Inc."
        Town = "The Town"
        Country = "UK"
        TaxNumber = 123456
    |}

let companyWithBankDetails =
    {|
        company with
            BankAccount = "ROINGXXX"
    |}
