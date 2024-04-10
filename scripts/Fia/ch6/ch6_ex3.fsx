#load "Car.fs"

open Car

let gas = 100.0

let result =
    gas
    |> drive 75
    |> fun { GasLeft = gasLeft } -> drive 10 gasLeft

