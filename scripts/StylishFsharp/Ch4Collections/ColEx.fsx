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

(* Exercise 4.1 *)
10  |> House.getRandom
    |> Array.map (fun h -> sprintf "Address: %s - Price: %f" h.Address h.Price)

(* Exercise 4.2 *)
20  |> House.getRandom
    |> Array.averageBy (fun h -> h.Price)

(* Exercise 4.3 *)
20  |> House.getRandom
    |> Array.filter (fun h -> h.Price > 250_000m)

(* Exercise 4.4 *)
20  |> House.getRandom
    |> Array.choose (fun h -> match Distance.tryToSchool h with | Some d -> Some (h, d) | None -> None)

(* Exercise 4.5 *)
20  |> House.getRandom
    |> Array.filter (fun h -> h.Price > 100_000m)
    |> Array.iter (fun h -> printfn "Address: %s, Price: %f" h.Address h.Price)

(* Exercise 4.6 *)
20  |> House.getRandom
    |> Array.filter (fun h -> h.Price > 100_000m)
    |> Array.sortByDescending (fun h -> h.Price)
    |> Array.iter (fun h -> printfn "Address: %s, Price: %f" h.Address h.Price)

(* Exercise 4.7 *)
20  |> House.getRandom
    |> Array.filter (fun h -> h.Price > 200_000m)
    |> Array.averageBy (fun h -> h.Price)

(* Exercise 4.8 *)
20  |> House.getRandom
    |> Array.filter (fun h -> h.Price < 100_000m)
    |> Array.pick (fun h ->
        match Distance.tryToSchool h with
        | Some d -> Some (h, d)
        | None -> None
    )

(* Exercise 4.9 *)
20  |> House.getRandom
    |> Array.groupBy (fun h -> h.Price |> PriceBand.fromPrice)
    |> Array.map (fun (pb, hs) -> pb, hs |> Array.sortBy (fun h -> h.Price))
