open System

let printMiddleName (middleName: string option) =
    match middleName with
    | Some middle -> sprintf "%s" middle
    | None -> sprintf "no-middle-name"

let tonyMiddleName = Some "Ernest"
let irinaMiddleName = None

printMiddleName tonyMiddleName
printMiddleName irinaMiddleName

type BillingDetails = {
    Name: string
    Billing: string
    Delivery: string option
}
let myBilling = { Name = "Tony"; Billing = "Voineasa 36-38"; Delivery = None }
let herBilling = { Name = "Irina"; Billing = "Barbosi"; Delivery = Some "Stirbei Voda 25" }

let addressForPackage billingDetails =
    let address =
        match billingDetails.Delivery with
            | Some delivery -> sprintf "%s" delivery
            | None -> billingDetails.Billing
    sprintf "Address: %s" address
let addressForPackage' (billingDetails: BillingDetails) =
    let address : string = billingDetails.Delivery |> Option.defaultValue billingDetails.Billing
    sprintf "Name: %s, Address: %s" billingDetails.Name address

let printAddressForPackage (billingDetails : BillingDetails) =
    billingDetails.Delivery |> Option.iter (fun delivery -> printfn "Name: %s, Address: %s" billingDetails.Name delivery)

addressForPackage myBilling
addressForPackage herBilling

addressForPackage' myBilling
addressForPackage' herBilling

printAddressForPackage myBilling
printAddressForPackage herBilling

let zipCode (deliveryAddress: string) : string option =
    match deliveryAddress.Split ([|'\n'|], StringSplitOptions.RemoveEmptyEntries) with
    | [||] -> None
    | parts -> parts |> Array.last |> Some

let tryPase (zipCode : string) : int option =
    match Int32.TryParse zipCode with
    | true, i -> i |> Some
    | false, _ -> None

let tryHub (zipCode : int) : string option =
    match zipCode with
    | 123456 -> Some "Hub 1"
    | _ -> None

let myDeliveryAddress = "Str. Voineasa 36-38
Sector 3, Bucuresti, Romania
123456"

let irinaDeliveryAddress = "Str. Stirbei 25
Sector 3, Bucuresti, Romania
100000"

myDeliveryAddress |> zipCode |> Option.bind tryPase |> Option.bind tryHub
irinaDeliveryAddress |> zipCode |> Option.bind tryPase |> Option.bind tryHub

