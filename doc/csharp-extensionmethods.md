# C# goodies

## Extension methods

```csharp
public static class CollectionExtensions
{
    public static string Join<K,TItem>(this IDictionary<K,IEnumerable<TItem>> dict, string separator = ": ")
    {
        return string.Join(separator, dict.Select(d => $"{d.Key}: {string.Join(separator, d.Value)}"));
    }
    public static string Join<TK, TItem>(this IDictionary<TK,List<TItem>> dict, string separator = ": ", string valueSeparator = ", ")
    {
        return string.Join(separator, dict.Select(d => $"{d.Key}: {string.Join(valueSeparator, d.Value)}"));
    }
}
```

## Documentation

- [Reference](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
