# C# features

- Local functions


- Extension methods

```csharp
public static class StringExtensions
{
    public static string TrimIdent(this string s)
    {
        return string.Join("\n", s.Split("\n").Select(x => x.Trim()));
    }
}
```

- Primary constructor for classes (`C# 12`)

```csharp
    public class ConfigurationKeyNotFoundException(string configKey) : Exception(configKey);
```

- Null coalescing (`C# 8`)

```csharp
    configuration.GetConnectionString("BookstoreDatabase") ?? throw new ConfigurationKeyNotFoundException("BookstoreDatabase");
```
