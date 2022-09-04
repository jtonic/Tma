type House = { Address : string; Price : decimal }
module House =
    let private random = System.Random(Seed = 1)
    /// Make an array of 'count' random houses.
    let getRandom count =
        Array.init count (fun i ->
            { Address = sprintf "%i Stochastic Street" (i+1)
              Price = random.Next(50_000, 500_000) |> decimal })
module Distance =
    let private random = System.Random(Seed = 1)
    /// Try to get the distance to the nearest school.
    /// (Results are simulated)
    let tryToSchool (house : House) =
        // Because we simulate results, the house
        // parameter isn’t actually used.
        let dist = random.Next(10) |> double
        if dist < 5. then
            Some dist
        else
            None
type PriceBand = | Cheap | Medium | Expensive
module PriceBand =
    // Return a price band based on price.
    let fromPrice (price : decimal) =
        if price < 100_000m then
            Cheap
        elif price < 200_000m then
            Medium
        else
            Expensive

(* Mine *)

module Average =
    let inline averageZero (values: 'T []) =
        if values.Length <> 0
        then values |> Array.average
        else LanguagePrimitives.GenericZero<'T>

    let r1 = [|1.; 2.; 3.|] |> averageZero
    let r2: float = [||] |> averageZero
    let r3 = [|1.m; 20_000m; 30m|] |> averageZero

    let inline averageOr (defaultValue: 'T) (values: 'T []) =
        if values.Length <> 0
        then values |> Array.average
        else defaultValue
    let res21 = [|10_000.m; 20_000m; 30_000m|] |> averageOr 0m
    let res22 = [||] |> averageOr 0m

module Array =
    let inline tryAverage (values : 'T []) =
        if values.Length <> 0
        then values |> Array.average |> Some
        else None

    let inline tryAverageBy (projection: 'T -> 'U) (values: 'T []) =
        if values.Length = 0
        then None
        else values |> Array.averageBy projection |> Some

    let res31 = [|10_000.m; 20_000m|] |> tryAverage
    let res32: decimal option = [||] |> tryAverage

(* Exercise 4.10 *)
20  |> House.getRandom
    |> Array.filter (fun h -> h.Price > 200_000m)
    |> Array.tryAverageBy (fun h -> h.Price)

(* Exercise 4.11 *)
20  |> House.getRandom
    |> Array.filter (fun h -> h.Price < 100_000m)
    |> Array.tryPick (fun h ->
        match Distance.tryToSchool h with
            | Some d -> Some (h, d)
            | None -> None)

module SetExercises =
    let novelWords = Set ["The";"the";"quick";"brown";"Fox";"fox"]
    novelWords
        |> Set.map (fun w -> w.ToLowerInvariant())

