# C# goodies

## Switch (pattern match)

- 1st example

```csharp
private static int Sum2(int? a, int? b)
{
    var result = (a, b) switch
    {
        (_, null) or (null, _) => throw new ArgumentException("One or both operands are null"),
        _ => a.Value + b.Value,
    };
    return result;
}
```