(* Exercise 5-1 *)

// Option 1
[| 1.0; 2.3; 11.1; -5. |] |> Seq.map (min 10.)
// Option 2
let flip ceiling seq =
    seq |> Seq.map (min ceiling)

[| 1.0; 2.3; 11.1; -5. |] |> flip 10.

(* Exercise 5-2 *)

let extremes (s : seq<float>) =
    s |> Seq.min, s |> Seq.max

[| 1.0; 2.3; 11.1; -5. |] |> extremes
