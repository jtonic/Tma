#r "nuget: FSharp.Data, 4.2.9"

open FSharp.Data
open System

let a = DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()
a |> printfn "%d"


type People1 =
    JsonProvider<"""
  [ { "name":"John", "age":94 },
    { "name":"Tomas" } ] """, SampleIsList=true>

let person1 = People1.Parse("""{ "name":"Gustavo" }""")

(person1.Name, person1.Age)
|> function
    | p, Some a -> (p, a)
    | p, None -> (p, 0)
||> printfn "%A, %A"

[<Literal>]
let ResolutionFolder = __SOURCE_DIRECTORY__

type People2 = JsonProvider<"/Users/ws31wx/Developer/github/Tma/scripts/DataScience/spark/data/persons.json", ResolutionFolder=ResolutionFolder>

type People2C =
    { Name: string
      Age: int
      Salary: int option }

People2.GetSamples()
  |> Seq.filter (fun p -> p.Name.ToUpper() = "TONY")
  |> Seq.truncate 1
  |> Seq.map (fun p ->
      { Name = p.Name
        Age = p.Age
        Salary = p.Salary })
  |> Seq.tryHead
  |> (function
  | Some p -> p
  | None ->
      { Name = "<missing>"
        Age = 0
        Salary = None })
