# Awesome stuff

## Modules

- Add new functions to an existing (core) module

  ```fsharp
  namespace FSharp.Collections

  module List =
      let pair item1 item2 = [ item1; item2 ]

  ```

  - call site

  ```fsharp
  open FSharp.Collections
  ```

## Lists

- list comprehension

## Functions

## Operators

- Partial application and pointfree

  ```fsharp
  [1; 2; 3;]
    |> List.map ((+) 1)
  ```
