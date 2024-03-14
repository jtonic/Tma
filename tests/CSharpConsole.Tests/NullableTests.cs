using Xunit;

namespace CSharpConsole.Tests;

public class NullableTests
{

    [Fact]
    public void NullableTest()
    {
        string? name = null;
        Assert.Null(name);
        
        string newName = name ?? "Irina";
        Assert.Equal("Irina", newName);
        
        name ??= "Tony";
        Assert.Equal("Tony", name);
    }
}