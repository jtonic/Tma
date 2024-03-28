using CSharpFunctionalExtensions;
using Xunit;
using static System.Console;

namespace CSharpConsole.Tests;

public class FpTests
{
    [Fact]
    void OptionalTests()
    {
        Person person = new Person()
        {
            Name = "Tony",
            Age = 54
        };
        Maybe.From(person)
            .Map(p => p.Name)
            .GetValueOrDefault("No name");
        WriteLine(person);
    }
}