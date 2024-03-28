using Xunit;
using static System.Console;

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
        result.ForEach(Write);
        WriteLine();
        Assert.NotEmpty(result);
    }

    [Fact]
    public void CalculateSumTest()
    {
        var numbers = new List<int> {1, 2, 3, 4, 5};
        var sum = numbers.Aggregate(0, (acc, i) => acc + i);
        Assert.Equal(15, sum);
    }

    [Fact]
    public void GroupByAgeTest()
    {
        var persons = new List<Person>
        {
            new("Ligia", 6),
            new("Natty", 4),
            new("Tony", 54),
            new("Irina", 34),
            new("Roxane", 38),
            new("Liviu", 42),
            new("Bruce Willis", 66),
            new("Tom Hanks", 65)
        };
        var groupedPersons = persons
            .GroupBy(p => p.Age)
            .ToDictionary(g => g.Key, g => g.ToList())
            .Values.ToList();

        groupedPersons.ForEach(ps =>
            ps.ForEach(p => Console.Out.WriteLine($"{p.Name} - {p.Age}"))
            );
    }

    private record struct Person(string Name, int Age);
}
