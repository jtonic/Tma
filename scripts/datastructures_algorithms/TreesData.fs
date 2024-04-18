module TreesData

type Tree<'T> =
    | Node of 'T * Tree<'T> * Tree<'T>
    | Leaf of 'T

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
