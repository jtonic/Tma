
let ex31 a b c =
    let inProgress = a + b
    let answer = inProgress * c
    $"The answer is {answer}"


let ex32 age =
    if age < "18" then "kid"
    elif age < 65 then "adult"
    else "retired"

let sayHello someValue =
    let group =
        if someValue < 10.0 then ex32 (int 15.0)
        else ex32 15
    group

sayHello 5

let n = 15.2

n |> int
floor n |> floor |> int
15.2 |> ceil |> int