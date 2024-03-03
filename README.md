# TMA F# Project

## Project Structure

```text
Tma
  src
    TmaConsole
      TmaConsole.fsharp
      Program.fs
    TmaPersistence
      TmaPersistence.fsharp
      Library.fs
    TmaMessaging
      TmaMessaging.fsharp
      Library.fs
  test
    TmaTests.fsharp
    TmaTests.fs
Tma.sln
```

## Used libraries:
 - Argu (cli)
 - Expecto (test)

## [Scaffold](./scaffold.md)

## Build solution

```shell
dotnet build
```

## Run app

```shell
dotnet run --project src/TmaConsole/TmaConsole.fsproj
```

## Run the application in watch mode

```shell
dotnet watch run --project src/CSharpConsole
```

## Run tests

```shell
dotnet run --project tests/TmaTests/TmaTests.fsproj
```

## publish the executable

- add the following in `src/TmaConsole/TmaConsole.fsproj` to create the executable with `dotnet build`

```xml
<RuntimeIdentifiers>osx-x64</RuntimeIdentifiers>
<!-- or -->
<RuntimeIdentifiers>linux-x64;win-x64;osx-x64</RuntimeIdentifiers>
```
-and create and run the executable (for the current platform)

```shell
dotnet publish
./src/TmaConsole/bin/Debug/net6.0/TmaConsole
```
-- or targeting another platform

```shell
dotnet publish -r win-x64
```

## Useful links

- https://atlemann.github.io/fsharp/2018/02/28/fsharp-solutions-from-scratch.html
- [expecto](https://github.com/haf/expecto#IDE-integrations)
