
type Result =
    {
        HomeTeam: string
        HomeGoals: int
        AwayTeam: string
        AwayGoals: int
    }

let create home hg away ag =
    { HomeTeam = home; HomeGoals = hg
      AwayTeam = away; AwayGoals = ag }

let results = [
    create "MessiVille" 1 "Ronaldo City" 2
    create "MessiVille" 1 "Bale Town" 3
    create "Ronaldo City" 2 "Bale Town" 3
    create "Bale Town" 2 "MessiVille" 1
]

(* Returns the team that won the most away games in the season *)
type TeamSummary = { Name: string; mutable AwayWins: int }
let summary = ResizeArray<TeamSummary>()

(* Imperative *)
for result in results do
    if result.AwayGoals > result.HomeGoals then
        let mutable found = false
        for entry in summary do
            if entry.Name = result.AwayTeam then
                found <- true
                entry.AwayWins <- entry.AwayWins + 1
        if not found then
           summary.Add { Name = result.AwayTeam; AwayWins = 1 }
let mutable wonAwayMost: TeamSummary = { Name = ""; AwayWins = 0 }

for row in summary do
    if row.AwayWins > wonAwayMost.AwayWins then
        wonAwayMost <- row
wonAwayMost

(* Functional *)
let isAwayWin result = result.AwayGoals > result .HomeGoals

let wonAwayMost2 =
    results
        |> List.filter isAwayWin
        |> List.countBy (fun result -> result.AwayTeam)
        |> List.sortByDescending snd
        |> List.head
 
let ronaldoPlayedIn result =
    result.AwayTeam = "Ronaldo City" || result.HomeTeam = "Ronaldo City" 
let RonaldoPlayedMatches =
    results
        |> List.filter ronaldoPlayedIn
        |> List.length
         