namespace CSharpConsole.Tests;

public static class StringExtensions
{
    public static string TrimIdent(this string s) =>
        string.Join("\n", s.Split("\n").Select(x => x.Trim()));

    public static string Join<T>(this T[] values, char separator = ' ') =>
        string.Join(separator, values);
}
