
let drive distance gas =
    if distance > 50 then gas / 2.0
    elif distance > 25 then gas - 10.0
    elif distance > 0 then gas - 1.0
    else gas
    
let gas = 100.0

let remainingGas =
    gas
    |> drive 55
    |> drive 26
    |> drive 1
