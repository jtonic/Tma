// ----------------------------------------------
// 1. Merge sort algorithm using recursion
// ----------------------------------------------

(* 
Merge sort is a divide and conquer algorithm that was invented by John von Neumann in 1945.
It is a comparison-based algorithm that divides the input array into two halves,
calls itself for the two halves, and then merges the two sorted halves.
The merge() function is used for merging two halves.

O(n log n) time complexity
*)
let unsorted = [3; 1; 4; 1; 5; 9; 2; 6; 5; 3; 5]

unsorted

let rec merge left right =
    match left, right with
    | [], _ -> right
    | _, [] -> left
    | x :: xs, y :: ys ->
        if x <= y then x :: merge xs right
        else y :: merge left ys

let rec mergeSort list =
    let len = List.length list
    if len < 2 then list
    else
        let middle = len / 2
        let left = List.take middle list
        let right = List.skip middle list
        merge (mergeSort left) (mergeSort right)

let sorted = mergeSort unsorted
sorted
