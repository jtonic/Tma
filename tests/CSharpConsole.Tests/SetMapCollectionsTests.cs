using System.Collections;
using Xunit;

namespace CSharpConsole.Tests;

public class SetMapCollectionsTests
{

    [Fact]
    public void TestHashtable()
    {
        Hashtable phonebook = new()
        {
            {"Tony", "11111" },
            {"Irina", "22222"}
        };
        
        Assert.Equal(2, phonebook.Count);
        Assert.True(phonebook.ContainsKey("Tony"));
        Assert.False(phonebook.ContainsKey("Boo"));
    }
}