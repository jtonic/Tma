# Scaffold

```shell
  mkdir -p src
  mkdir -p test
```

## Create projects

- src

```shell
  dotnet new console -lang "F#" -o src/TmaConsole
  touch src/TmaConsole/TmaConsole.fs
```

Edit src/TmaConsole/Program.fs

```fsharp
module TmaConsole

[<EntryPoint>]
let main argv =
    printfn "Hello F# world!"
    0

```

```shell
dotnet new classlib -lang "F#" -o src/TmaSystem
dotnet new classlib -lang "F#" -o src/TmaPersistence
dotnet new classlib -lang "F#" -o src/TmaMessaging
```

- test

```shell
dotnet new console -lang "F#" -o tests/TmaTests
touch tests/TmaTests/TmaTests.fs
```

Edit tests/TmaTests/TmaTests.fs
```fsharp
open Expecto

[<EntryPoint>]
let main argv =
    Tests.runTestsInAssembly defaultConfig argv

```

## Add project references

```shell
dotnet add src/TmaConsole/TmaConsole.fsproj reference src/TmaPersistence/TmaPersistence.fsproj
dotnet add src/TmaConsole/TmaConsole.fsproj reference src/TmaMessaging/TmaMessaging.fsproj
dotnet add src/TmaConsole/TmaConsole.fsproj reference src/TmaSystem/TmaSystem.fsproj
```

## Add external dependencies

```shell
dotnet add src/TmaConsole/TmaConsole.fsproj package Argu
dotnet add tests/TmaTests/TmaTests.fsproj package Expecto
```

## Add the solution

```shell
dotnet new sln -n Tma
dotnet sln add \
 src/TmaConsole/TmaConsole.fsproj \
 src/TmaMessaging/TmaMessaging.fsproj \
 src/TmaSystem/TmaSystem.fsproj \
 tests/TmaTests/TmaTests.fsproj
```
