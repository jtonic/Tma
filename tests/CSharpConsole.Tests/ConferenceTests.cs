using CSharpFunctionalExtensions;
using TmaCcLibrary;
using Xunit;

namespace CSharpConsole.Tests;

public class ConferenceTests
{

    [Fact]
    public void TestParticipants()
    {
        Assert.NotEmpty(Conference.Participants());
    }    
    
    [Fact]
    public void TestFindParticipant()
    {
        var missing = Conference.FindParticipant("Ionel") ?? new("Missing", -1);
        Assert.Equal("Missing", missing!.Name);

        var missingJohn = Conference.FindParticipant("John");
        var missingAnna = Conference.FindParticipant("Anna");

        // plain C#
        var result = (missingAnna.HasValue && missingJohn.HasValue)
            ? $"{missingAnna.Value.Name} - {missingJohn.Value.Name}" 
            : "Either Anna or John are missing";
        Assert.Equal("Either Anna or John are missing", result);
        
        // with LINQ
        var res2 = new[] {missingAnna, missingJohn}
            .Where(x => x.HasValue)
            .Select(x => x?.Name)
            .DefaultIfEmpty("Either Anna or John are missing")
            .Aggregate((a, j) => $"{a} - {j}");
        Assert.Equal("Either Anna or John are missing", res2);

        // with CSharpFunctionalExtensions.MaybeExtensions  
        var res3 = missingAnna.AsMaybe()
            .Bind(a => missingJohn.AsMaybe().Map(b => $"{a.Name} - {b.Name}"))
            .GetValueOrDefault("Either Anna or John are missing");
        Assert.Equal("Either Anna or John are missing", res3);
    }
}