#r "nuget: FSharpPlus"

let case = 3
match case with
| 1 -> printfn "1"
| 2 -> printfn "2"
| 3 |4 as x -> printfn $"Probably 3 or 4. Real value: %d{x}"
| _ -> printfn "Something else"

let case1 = 12
match case1 with
| 1 -> "One"
| 2 -> "Two"
| x when x < 12 -> "Less than a dozen"
| x when x = 12 -> "A dozen"
| _ -> "More than a dozen"


module Pond =
    let describe (fish: string[])  =
        match fish with
        | [||] -> "Empty pond"
        | [|f1|] -> sprintf $"Only one fish {f1}"
        | [|f1; f2|] -> sprintf $"Two fish pond. fish: {f1}, {f2}"
        | _ -> sprintf "Too many fish pond"

let f1 = [|"Fish1"|]
let f2 = [|"Fish1"; "Fish2"|]
let f3 = [|"Fish1"; "Fish2"; "Fish3"|]
let f4 = [|"Fish1"; "Fish2"; "Fish3"; "Fish4"|]

let fs = [|f1; f2; f3; f4|]
fs |> Array.map Pond.describe

module Pond1 =
    let describe (fish: string list)  =
        match fish with
        | [] -> "Empty pond"
        | [f] -> sprintf $"One fish ({f}) pond"
        | head::tail -> sprintf "Pond with fish (%s) and other %d fishes" head (tail |> List.length)

let f10 = []
let f11 = ["Fish1"]
let f12 = ["Fish1"; "Fish2"]
let f13 = ["Fish1"; "Fish2"; "Fish3"]
let f14 = "Fish1" :: "Fish2" :: "Fish3" :: "Fish4" :: []

let f1s = [f10; f11; f12; f13; f14]
f1s |> List.map Pond1.describe


(* Pattern match on records *)
type Track = { Title : string; Artist : string }

let songs =
    [ { Title = "Summertime"
        Artist = "Ray Barretto" }
      { Title = "La clave, maraca y guiro"
        Artist = "Chico Alvarez" }
      { Title = "Summertime"
        Artist = "DJ Jazzy Jeff & The Fresh Prince" } ]
let distinctTitles =
    songs
        |> Seq.map (fun song ->
            match song with
            | { Title = title } -> title)
        |> Seq.distinct
// seq ["Summertime"; "La clave, maraca y guiro"]
distinctTitles

type TrackDetails = {
        Id: int
        Name: string
        Artist: string
        Length: int
    }
let melody1 = {Id = 1; Name = "Summertime"; Artist = "Artist One"; Length = 5}
let melodies = [melody1]

let trackSummary ({Name = name; Artist = artist}) =
    sprintf "TrackSummary: Name= %s, Artist= %s" name artist

trackSummary melody1
melodies |> Seq.map trackSummary

sprintf "Integer: %07i" 123

(*-----*)
// ------
type Complex =
    | Complex of Real: float * Imaginary: float

let c1 = Complex (Real = 1.0, Imaginary = 2.0)
let (Complex (Real = real; Imaginary = imaginary)) = c1
real, imaginary
let (Complex (real1, imaginary1)) = c1
real1, imaginary1
let (Complex (onlyReal, _)) = c1
onlyReal


type Complex1 =
    | Real of float
    | Complex1 of Real: float * Imaginary: float

let c11 = Real 1.0
let c12 = Complex1(Real = 1.0, Imaginary = 2.0)

let (Complex1(real11, _)|Real (real11)) = c11
real11
let (Complex1(real12, _)|Real (real12)) = c12
real12

// ------

module Domain =
    [<Struct>]
    type Domain =
        private Domain of double
            member this.Value = this |> fun (Domain d) -> d

    let createDomain value = Domain value

open Domain
let dm1 = createDomain 10.0

module Heading =
    [<Struct>]
    type Heading =
        private Heading of double
            member this.Value = this |> fun (Heading h) -> h
    let rec create value =
        if value >= 0.0 then
            value % 360.0 |> Heading
        else
            value + 360.0 |> create
// "Heading: 180.0"
let heading1 = Heading.create 180.0
printfn "Heading: %0.1f" heading1.Value
// "Heading: 90.0"
let heading2 = Heading.create 450.0
printfn "Heading: %0.1f" heading2.Value
// "Heading: 270.0"
let heading3 = Heading.create -450.0
printfn "Heading: %0.1f" heading3.Value
// "Heading: 270.0"
let heading4 = Heading.create -810.0
printfn "Heading: %0.1f" heading4.Value

(* Active patterns *)
open System
Math.Round(1.331, 2)

open System
let (|Currency|) (x: float) =
    Math.Round (x, 2)

match 100./3. with
| Currency 33.33 -> true
| _ -> false

match (10./3.) with
| Currency 3.34 -> true
| Currency x ->
    printfn "That didn't match. %f" x
    false

let (Currency x) = 101.0 / 3.
printfn "Currency: %0.4f" x

let add (Currency a) (Currency b) = a + b

add (100./3.) (100./3.)

(* Multiple cases active patterns *)
// -----------
open FSharpPlus
open System.Text.RegularExpressions

let (|Mitsubishi|Samsung|Other|) (s: string) =
    let m = Regex.Match(s, @"([A-Z]{3})(\-?)(.*)")
    if m.Success then
        match m.Groups[1].Value with
        | "MWT" -> Mitsubishi
        | "SWT" -> Samsung
        | _ -> Other
    else Other

let turbines = [
    "MWT1000"; "MWT1000A"; "MWT102/2.4"; "MWT57/1.0"
    "SWT1.3_62"; "SWT2.3_101"; "SWT2.3_93"; "SWT-2.3-101"
    "40/500" ]
turbines |> iter (fun t ->
            match t with
            | Mitsubishi -> printfn "%s is a Mitsubishi turbine" t
            | Samsung -> printfn "%s is a Samsung turbine" t
            | Other -> printfn "%s is an unknown turbine" t
        )

(* Partial active patterns *)
// -----------
let (|Mitsubishi|_|) (s: string) =
    let m = Regex.Match(s, @"([A-Z]{3})(\-?)(.*)")
    if m.Success then
        match m.Groups[1].Value with
        | "MWT" -> Some s
        | _ -> None
    else None
turbines |> iter (fun t ->
                match t with
                | Mitsubishi m -> printfn "%s is a Mitsubishi turbine" m
                | _ as s -> printfn "%s is not a Mitsubishi turbine" s
            )

let myApiCall (s: string) =
    match s with
    | null -> "(NULL)"
    | _ -> s

myApiCall null, myApiCall "Hello Bobita"