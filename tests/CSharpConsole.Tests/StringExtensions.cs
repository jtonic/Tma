namespace CSharpConsole.Tests;

public static class StringExtensions
{
    public static string TrimIdent(this string s)
    {
        return string.Join("\n", s.Split("\n").Select(x => x.Trim()));
    }
}