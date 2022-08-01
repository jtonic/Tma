namespace Tma

[<AutoOpen>]
module System =
    let inline ($) (f: 'a -> 'b) (a: 'a) : 'b = f a
