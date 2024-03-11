using Xunit;
using static Xunit.Assert;

namespace CSharpConsole.Tests;

public class DataHoldersTests
{
    [Fact]
    public void TestRecordStructPerson()
    {
        var tony = new Person("Tony", 54);
        
        Console.Out.WriteLine("person.ToString() = {0}", tony.ToString());
        
        Equal("Tony", tony.Name);
        Equal(54, tony.Age);
        
        var clonedTony = tony with { Age = tony.Age + 1 };
        Console.Out.WriteLine("clonedTony.ToString() = {0}", clonedTony.ToString());
        NotEqual(tony, clonedTony);
    }
}

public record struct Person(string Name, int Age);