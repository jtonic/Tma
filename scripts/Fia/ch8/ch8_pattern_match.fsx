type OverdraftDetails =
    {
        Approved: bool
        MaxAmount: decimal
        CurrentAmount: decimal
    }

type CustomerWithOverdraft = 
    {
        Name: string
        Address: string
        YearsOfHistory: int
        Overdraft: OverdraftDetails
    }
    
// Version 1 - using recursive pattern matching
let canTakeOverdraftV1 (customer: CustomerWithOverdraft) =
    match customer with
    | { YearsOfHistory = 0; Overdraft = {  Approved = true }; Address = "US" } -> true
    | { YearsOfHistory = 0 } -> false
    | { YearsOfHistory = 1; Overdraft = {  Approved = true  }; Address = "US" } -> true
    | { YearsOfHistory = 1 } -> false
    | _ -> true

// Version 1 - using recursive pattern matching and nested OR
let canTakeOverdraftV2 (customer: CustomerWithOverdraft) =
    match customer with
    | { YearsOfHistory = 0 | 1; Overdraft = {  Approved = true }; Address = "US" } -> true
    | { YearsOfHistory = 0 | 1 } -> false
    | _ -> true
    
let tony = { Name = "Tony"; Address = "RO"; YearsOfHistory = 0; Overdraft = { Approved = true; MaxAmount = 1000m; CurrentAmount = 500m } }
let cofi = { Name = "Cofi"; Address = "US"; YearsOfHistory = 0; Overdraft = { Approved = true; MaxAmount = 1000m; CurrentAmount = 1000m } }

canTakeOverdraftV1 tony
canTakeOverdraftV1 cofi
