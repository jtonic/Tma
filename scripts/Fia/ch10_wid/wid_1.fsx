#r "nuget:FSharp.Data"
open FSharp.Data
 
[<Literal>]
let SampleJson = """{
    "Brand": "Ibanez",
    "Strings": "7",
    "Pickups": [ "H", "S", "H" ] }"""
type GuitarJson = JsonProvider<SampleJson>
let sample = GuitarJson.GetSample()
let description = $"{sample.Brand} has {sample.Strings} strings."
