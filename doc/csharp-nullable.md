# C# goodies

## nullable types

- configuration of the nullable type check as compilation error

```xml
  <PropertyGroup>
    <Nullable>enable</Nullable>
    <WarningsAsErrors>nullable</WarningsAsErrors>
  </PropertyGroup>
```

- Example 
****
```csharp
  private static string GetAddress(string? person)
  {
    return person;
  }
```

- null-conditional operator `?.`
- null-coalescing operator `??`
