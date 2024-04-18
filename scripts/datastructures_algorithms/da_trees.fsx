#load "TreesData.fs"

open TreesData

//-----------------------------------------------------------------
// Traverse and print the tree funtion
//-----------------------------------------------------------------
let treeToString indent tree : string =
    let initialIndent = indent
    let rec nestedTreeToString (indent: string) tree : string =
        let newIndent = indent + initialIndent
        match tree with
        | Node { Value = value
                 Left = left
                 Right = right } ->
            $"{indent}{value}\n" +
            nestedTreeToString newIndent left +
            nestedTreeToString newIndent right
        | Leaf(value) ->
            $"{indent}{value}\n"
    nestedTreeToString indent tree

// print the tree
"\n" + treeToString "  " tree

module Traverse =
    
    // --------------------------------------------------------------
    // 1. traverse the tree pre-order and add nodes to a list
    // --------------------------------------------------------------
    let rec preOrderTraverse (tree: 'T Tree) : 'T list =
        match tree with
        | Node { Value = value
                 Left = left
                 Right = right } ->
            [ value ]
            @ preOrderTraverse left @ preOrderTraverse right
        | Leaf (value) -> [ value ]

            
    // --------------------------------------------------------------§
    // 2. traverse the tree in-order and add nodes to a list
    // --------------------------------------------------------------
    let rec inOrderTraverse tree =
        match tree with
        | Node { Value = value
                 Left = left
                 Right = right } ->
            inOrderTraverse left @ [value] @ inOrderTraverse right
        | Leaf(value) ->
            [value]
            
    // --------------------------------------------------------------
    // 3. traverse the tree post-order and add nodes to a list
    // --------------------------------------------------------------
    let rec postOrderTraverse tree = 
        match tree with
        | Node { Value = value
                 Left = left
                 Right = right } ->
            postOrderTraverse left @ postOrderTraverse right @ [value] 
        | Leaf value -> [value]

open Traverse

preOrderTraverse tree

inOrderTraverse tree

postOrderTraverse tree