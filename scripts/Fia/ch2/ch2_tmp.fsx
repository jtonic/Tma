let filterOdds =
    Seq.filter (fun x -> x % 2 = 1)

// range from 1 to 10
let odds = filterOdds [1..10]
odds


type CarriageNumber = CarriageNumber of int
let cn = CarriageNumber 1
match cn with CarriageNumber n -> n


let add a b =
    let answer = "" + a + b
    answer

// add 1 1

let explicit = ResizeArray<int>()
let typeHole = ResizeArray<_>()
let omitted = ResizeArray()
 
typeHole.Add 99
omitted.Add 10


let combineElements a b c =
    let output = ResizeArray()
    output.Add a
    output.Add b
    output.Add c
    output
 
combineElements 1 2 3
$"%A{combineElements 1 2 3}"


let calculateGroup age =
    if age < 18 then "Child"
    elif age < 65 then "Adult"
    else "Pensioner"
 
let sayHello someValue =
    let group =
        if someValue < 10.0 then calculateGroup 15
        else calculateGroup 35
    "Hello " + group
 
let result = sayHello 10.5

let addThreeDays (theDate:System.DateTime) =
    theDate.AddDays 3
 
let addAYearAndThreeDays theDate =
    let threeDaysForward = addThreeDays theDate
    theDate.AddYears 1

