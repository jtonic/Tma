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
      .Select(n => n.Length)
      .Where(n => n >= 3)
      .GroupBy(n => n > 5 ? "Greater than 5" : "lower than 5")
      .ToDictionary(g => g.Key, g => g.ToList());
  }
}