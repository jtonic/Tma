open System


let (~~) = float
type MilesYards = MilesYards of wholeMiles : int * yards : int
module MilesYards =

    let fromMilesPointYards (milesPointYards: float): MilesYards =
        if milesPointYards < 0. then
            raise <| ArgumentOutOfRangeException(nameof(milesPointYards), "It should be positive or zero.")
        let wholeMiles = milesPointYards |> floor |> int
        let fraction = milesPointYards - ~~wholeMiles
        if fraction >= 0.1759 then
            raise <| ArgumentOutOfRangeException(nameof(milesPointYards), "The value must be < 0.1759")
        let yards = fraction * 10_000. |> round |> int
        MilesYards(wholeMiles, yards)

    let toDecimalMiles (MilesYards (wholeMiles, yards)) : float =
        ~~wholeMiles + ~~yards / 1_760.

MilesYards.fromMilesPointYards 1.0880
MilesYards.fromMilesPointYards -1.0880
MilesYards.fromMilesPointYards 1.1760

1.0880 |> MilesYards.fromMilesPointYards |> MilesYards.toDecimalMiles

module MilesChains =
    type MilesChains =
        private MilesChains of miles : int * chains : int

    let fromParts (miles : int, chains: int): MilesChains =
        if miles < 0 then
            raise <| ArgumentOutOfRangeException(nameof(miles), miles, "It should be >= 0")
        if chains < 0 || chains >= 80 then
            raise <| ArgumentOutOfRangeException(nameof(chains), chains, "It should be >= 0 and < 80")
        MilesChains(miles, chains)
    let toDecimalMiles (MilesChains(miles, chains)): float =
        ~~miles + ~~chains / 80.0

MilesChains.fromParts (51, 29)
MilesChains.fromParts (0, -1)
MilesChains.fromParts (0, 80)
MilesChains.fromParts (1, 40) |> MilesChains.toDecimalMiles


(51, 29) |> MilesChains.fromParts |> MilesChains.toDecimalMiles