using Cocona;

namespace CSharpConsole;

// ReSharper disable once ClassNeverInstantiated.Global
internal class CliCommands
{
    private readonly IUserInfoRetriever _userInfoRetriever;

    public CliCommands(IUserInfoRetriever userInfoRetriever)
    {
        _userInfoRetriever = userInfoRetriever;
    }

    [Command("user-info", Description = "Getting the user info")]
    public void Run([Option('i', Description = "The user ID")] string userId)
    {
        var userInfo = _userInfoRetriever.GetUserInfo(userId);
        Console.Out.WriteLine(userInfo);
    }
}

internal interface IUserInfoRetriever
{
    string GetUserInfo(string userId);
}

internal class UserInfoRetriever : IUserInfoRetriever
{
    public string GetUserInfo(string userId)
    {
        return $"User info for ID = {userId}";
    }
}