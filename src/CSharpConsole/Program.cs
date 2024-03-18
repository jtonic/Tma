using Business;
using Cocona;
using CSharpConsole;
using Microsoft.Extensions.DependencyInjection;
using TmaMessaging;

var builder = CoconaApp.CreateBuilder();
builder.Services.AddSingleton<IRun, AppRun>();
builder.Services.AddSingleton<Greet>();
var app = builder.Build();

/*
 * Run the greet CLI command:
 * # dotnet run -- greet --first-name=Tony --last-name=Pazargic
 *
 * Get the help for the greet CLI command:
 * # dotnet run -- greet --help
 *
 * Get the help for the CLI command:
 * #dotnet run -- --help
 */
app.AddCommand("run", (
    [Option(Description = "App Name")] string appName,
    IRun run
    ) => run.Run());
app.AddCommand("greet", (
    [Option(Description = "The First Name")] string firstName,
    [Option(Description = "The Last Name")] string? lastName,
    Greet greet
    ) => greet.Run());
app.Run();

internal interface IRun
{
    void Run();
}

internal class AppRun : IRun
{
    public void Run()
    {
        // integrated with F# library
        Say.hello("Tony");
        int a = Say.alwaysTwo;

        // integrated with C# library
        var personRepo = new PersonsRepo();
        var personService = new PersonService(personRepo);
        var name = personService.GetById(1);
        Console.WriteLine(name);

        // Console.WriteLine($"Sum2(1, null) = {Sum2(1, null)}");

        var processNames =
            ProcessNames(new List<string> { "Tony", "Irina", "Roxane", "Liviu", "Bruce Willis", "Tom Hanks" });
        Console.WriteLine($"ns = {processNames.Join()}");

        static int Sum2(int? a, int? b)
        {
            var result = (a, b) switch
            {
                (_, null) or (null, _) => throw new ArgumentException("One or both operands are null"),
                _ => a.Value + b.Value,
            };
            return result;
        }

        static Dictionary<string, List<int>> ProcessNames(IList<string> names)
        {
            return names
                .Select(GetNameLength)
                .Where(IsGreaterOrEqualThan3)
                .GroupBy(GetNameForLength)
                .ToDictionary(GroupingExtensions.GetKey, GroupingExtensions.GetValues);
        }

        static int GetNameLength(string name)
        {
            return name.Length;
        }

        static bool IsGreaterOrEqualThan3(int n) => n > 3;
        static string GetNameForLength(int n) => n > 5 ? "Greater than 5" : "lower than 5";
    }
}

internal class Greet
{
    public void Run()
    {
        Console.WriteLine("Hello from Greet");
    }
}

public static class GroupingExtensions
{
    public static TKey GetKey<TKey, TElement>(this IGrouping<TKey, TElement> group) => group.Key;
    public static List<TElement> GetValues<TKey, TElement>(this IGrouping<TKey, TElement> group) => group.ToList();
}

