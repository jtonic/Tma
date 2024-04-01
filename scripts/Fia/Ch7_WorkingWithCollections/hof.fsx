

let sum a b =
    let answer = a + b
    printfn $"The answer is {answer}"
    answer

let subtract a b =
    let answer = a - b
    printfn $"The answer is {answer}"
    answer

let result = sum 5 10

let add1 logger a b =
    let answer = a + b
    logger $"The answer is {answer}"
    answer

add1 System.Console.WriteLine 5 10


let calculate op a b =
    let result = op a b
    printfn $"The result is {result}"
    result
    
calculate sum 5 10

calculate subtract 10 5




