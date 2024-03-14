using Xunit;

namespace CSharpConsole.Tests;

public class MiscTests
{
    [Fact]
    public void TestReferences()
    {
        string tony = "Tony";

        var type = tony.GetType();
        
        Assert.Equal("System.String", type.ToString());

        Object obj = 1;
        
        Assert.Equal("System.Int32", obj.GetType().ToString());

        bool val = (bool)obj;
        Assert.True(val);
    }
    
    [Fact]
    public void TestStringInterpolation()
    {
        string name = "Tony";
        int age = 54;
        
        string message = $"Hello, '{name, 6}'! You are {age:F2} years old.";
        Console.WriteLine(message);
        
        Assert.Equal("Hello, '  Tony'! You are 54,00 years old.", message);
    }
    
    [Fact]
    public void TestSimplePatternMatching()
    {
        string name = "Tony";
        var result = name switch
        {
            "Tony" => "Hello, Tony!",
            "Irina" => "Hello, Irina!",
            _ => "Hello, Stranger!"
        };
        
        Assert.Equal("Hello, Tony!", result);
    }
}