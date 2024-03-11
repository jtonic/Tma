using Business;
using TmaMessaging;

namespace CSharpConsole;

public static class Program
{
  public static void Main()
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

    var processNames = ProcessNames(new List<string>{"Tony", "Irina", "Roxane", "Liviu", "Bruce Willis", "Tom Hanks"});
    Console.WriteLine($"ns = {processNames.Join()}");
  }

  private static int Sum2(int? a, int? b)
  {
    var result = (a, b) switch
    {
      (_, null) or (null, _) => throw new ArgumentException("One or both operands are null"),
      _ => a.Value + b.Value,
    };
    return result;
  }

  private static Dictionary<string, List<int>> ProcessNames(IList<string> names)
  {
    return names
      .Select(GetNameLength)
      .Where(IsGreaterOrEqualThan3)
      .GroupBy(GetNameForLength)
      .ToDictionary(GroupingExtensions.GetKey, GroupingExtensions.GetValues);
  }

  private static int GetNameLength(string name)
  {
    return name.Length;
  }
  private static bool IsGreaterOrEqualThan3(int n) => n > 3;
  private static string GetNameForLength(int n) => n > 5 ? "Greater than 5" : "lower than 5";
}

public static class GroupingExtensions
{
  public static TKey GetKey<TKey, TElement>(this IGrouping<TKey, TElement> group) => group.Key;
  public static List<TElement> GetValues<TKey, TElement>(this IGrouping<TKey, TElement> group) => group.ToList();
}
