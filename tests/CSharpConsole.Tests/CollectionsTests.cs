using Xunit;

namespace CSharpConsole.Tests;

public class CollectionsTests : IAsyncLifetime
{
    private Lazy<string[]> _names = new(Array.Empty<string>);

    public Task InitializeAsync()
    {
        _names = new Lazy<string[]>(() => ["Ion", "Ana", "Tony", "Irina", "Roxane", "Liviu", "Bruce Willis", "Tom Hanks"
        ]);
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    
    [Fact]
    public void ArrayTest()
    {
        var names = _names.Value;
        Assert.Equal(8, names.Length);
        var filteredNames = names.Where(n => n.Length >= 4).ToList();
        filteredNames.ForEach(n => Console.Out.WriteLine(n));
        Assert.NotEmpty(filteredNames);
    }

    [Fact]
    public void ProcessNamesTest()
    {
        var names = _names.Value;

        var result =
            names
                .Select(name => name.ToUpper())
                .Where(name => name.Length > 3)
                .SelectMany(name => name.ToCharArray())
                .Where(char.IsUpper)
                .ToList();
        result.ForEach(Console.Write);
        Console.WriteLine();
        Assert.NotEmpty(result);
    }
}