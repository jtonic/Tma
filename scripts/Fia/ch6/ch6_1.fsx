(*
    Functions
*)

// currying 
let add (firstNumber: int) (secondNumber: int) = firstNumber + secondNumber

let multiply (firstNumber: int) (secondNumber: int) = firstNumber * secondNumber

let addTen (number: int) = add 10 number

let timesTwo (number: int) = multiply 2 number

// partial applied functions
timesTwo 10 = 20
addTen 1 = 11


// functions composition
let addTenAndDouble = addTen >> timesTwo

addTenAndDouble 10 = 40


// functions piping 
let pipelineSingleLine = 10 |> add 5 |> add 7 |> multiply 2
 
let pipelineMultiline =
    10
    |> add 5
    |> add 7
    |> multiply 2
    
"123" |> int
