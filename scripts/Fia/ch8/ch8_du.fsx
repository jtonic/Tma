// single-case union
type PhoneNumber = PhoneNumber of string
type CountryCode = CountryCode of string

// discriminated unions (OR)
type TelephoneNumber =
    | Local of number: PhoneNumber
    | International of countryCode: CountryCode * number: PhoneNumber

type ContactMethod = 
    | Email of Address: string
    | Telephone of CountryCode: CountryCode * Number: PhoneNumber
    | Address of {| Line1: string; Line2: string; City: string; Country: string |}
    | SMS of TelephoneNumber

type Person = {
    Name: string
    Age: int
    ContactMethod: ContactMethod
}

let getCountryCode (CountryCode countryCode) = countryCode
    
let getPhoneNumber phoneNumber =
    match phoneNumber with
    | PhoneNumber number -> number

// pattern match
let contact person =
    match person.ContactMethod with
    | Email emailAddress -> $"sending an email to {person.Name} via {emailAddress}"
    | Telephone(countryCode, number) -> $"Calling {person.Name} by telephone number {countryCode}-{number}"
    | Address address -> $"Sending a letter to {person.Name} to the address: {address.Line1}, {address.Line2}, City: {address.City}, Country: {address.Country}"
    | SMS (Local localPhoneNumber) -> $"Sending a SMS to {person.Name} using local phone number {localPhoneNumber}"
    | SMS (International (CountryCode countryCode, PhoneNumber number)) -> $"Sending a SMS to {person.Name} using international phone number {countryCode} - {number}"

let tony = { Name = "Antonel-Ernest Pazargic"
             Age = 54
             ContactMethod = SMS (International (CountryCode "+40", PhoneNumber "1234567")) }

contact tony
