
let mutable dt2 = System.DateTime.Now
dt2
let b2 = System.DateTime.TryParse("12-20-04 12:21:00", &dt2)

printfn "%b %A" b2 dt2
