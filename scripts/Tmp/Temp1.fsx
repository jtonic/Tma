#r "nuget:FsToolkit.ErrorHandling"

open FsToolkit.ErrorHandling

//----------------------------------------------------------------------------------------
// 1. Basic validation (fail fast) with Result effect
//----------------------------------------------------------------------------------------
let validateName (name: string) =
    if name.StartsWith "To" then Ok name
    else Error $"{name} is invalid name. Should start with 'To'"
    
let multipleValidation = result {
    let! tony = "Tony" |> validateName |> Result.map (fun n -> n + n)
    let! magda = "Magda" |> validateName
    return $"{magda} and {tony}"
}

let result: string = multipleValidation |> Result.either (fun succ -> succ.ToLower()) (_.ToString())
result