let calculateAgeDescription age =
    if age < 18 then "Child"
    elif age < 65 then "Adult"
    else "OAP"

let describeAge age =
    let ageDescription = calculateAgeDescription age
    let greeting = "Hello"
    printfn $"{greeting} You are a {ageDescription}"

describeAge 54


let getCurrentDate () = System.DateTime.Now
let cd1 = getCurrentDate ()
let cd2 = getCurrentDate ()


let addDays days =
    let newDays = System.DateTime.Today.AddDays days
    printf $"You gave me {days} days, and I gave you {newDays}"
    newDays
    
addDays 5

let addSeveralDays =
    addDays 1 |> ignore
    addDays 5 |> ignore
    addDays 10

// mutation in F#

let mutable age = 53
printfn $"Age is {age}"
age <- 54
printfn $"Age is {age}"
age

54 = age

(*
    Exercise with the tank gas
*)

type Distance = FAR | MEDIUM | NEAR | STAY

// immutable version
let mDrive distance gas =
    match distance with
    | FAR -> gas / 2.0
    | MEDIUM -> gas - 10.0
    | NEAR -> gas - 1.0
    | STAY -> gas

let gasTank = 100.0
mDrive STAY gasTank
mDrive NEAR gasTank
mDrive MEDIUM gasTank
mDrive FAR gasTank

// mutable version

let mutable gas = 100.0
let iDrive distance =
    match distance with
    | FAR -> gas <- gas / 2.0
    | MEDIUM -> gas <- gas - 10.0
    | NEAR -> gas <- gas - 1.0
    | STAY -> gas <- gas
    gas

iDrive STAY
iDrive NEAR
iDrive MEDIUM
iDrive FAR
