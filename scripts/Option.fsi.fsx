(*
    More info at
    https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html
*)
open  FSharp.Core.Option

(1, None)
    ||> fold (fun acc x -> acc + x * 2)
;;

(0, Some 1) ||> fold (fun accum x -> accum + x * 2)
;;

Some 42 |> get
;;

System.Nullable<int>(2) |> ofNullable
;;

("not null": string) |> ofObj
;;
(null: string) |> ofObj
;;

(None: string option) |> toObj // evaluates to null
;;

Some "not a null string" |> toObj // evaluates to "not a null string"