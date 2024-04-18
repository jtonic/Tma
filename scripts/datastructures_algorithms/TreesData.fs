module TreesData

type TreeNode<'T> =
    {
        Value: 'T
        Left: Tree<'T>
        Right: Tree<'T>
    }

and Tree<'T> =
    | Node of TreeNode<'T>
    | Leaf of 'T

// initialize a tree with integers

let tree =
    Node {
        Value = 1
        Left = Node {
            Value = 2
            Left = Leaf 3
            Right = Leaf 4
        }
        Right = Node {
            Value = 5
            Left = Leaf 6
            Right = Leaf 7
        }
    }