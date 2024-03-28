# C# features

- `Top Level Statement Type` - Entry Application Class w/o enclosing class and main method

- Local functions

- `Extension methods`

```csharp
public static class StringExtensions
{
    public static string TrimIdent(this string s)
    {
        return string.Join("\n", s.Split("\n").Select(x => x.Trim()));
    }
}
```

- `Primary constructor for classes` (`C# 12`)

```csharp
    public class ConfigurationKeyNotFoundException(string configKey) : Exception(configKey);
```

- Null coalescing (`C# 8`)

```csharp
configuration.GetConnectionString("BookstoreDatabase") ?? throw new ConfigurationKeyNotFoundException("BookstoreDatabase");
```

- Collection expression

```csharp
var numbers = [1, 2, 3, 4, 5];
```

- Target-typed new expressions (`C# 9`)

```csharp
List<string> names = new() { "Alice", "Bob", "Charlie" };
```

- Object Initializer and immutable properties

```csharp

```charp
public class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
```
