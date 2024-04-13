// create a simple tree with values in nodes and leaves
// using algebraic data types
// and pattern matching
// in F#

type Tree<'T> =
    | Node of 'T * Tree<'T> * Tree<'T>
    | Leaf of 'T

// create a function to represent the tree as a string
let treeToString indent tree : string =
    let initialIndent = indent
    let rec nestedTreeToString (indent: string) tree : string =
        let newIndent = indent + initialIndent
        match tree with
        | Node(value, left, right) ->
            $"{indent}{value}\n" +
            nestedTreeToString newIndent left +
            nestedTreeToString newIndent right
        | Leaf(value) ->
            $"{indent}{value}\n"
    nestedTreeToString indent tree

// initialize a tree with integers
let tree = Node(1,
                Node(2,
                     Leaf(3),
                     Leaf(4)),
                Node(5,
                     Leaf(6),
                     Node(7,
                        Leaf(8),
                        Leaf(9)
                     )
                )
            )

// print the tree
let treeString = "\n" + treeToString "  " tree
treeString
        
type Math =
    static member add (m, ?n) =
        let n = defaultArg n 1
        m + n 

Math.add(1, 2)
Math.add 3