using System;
using Business;
using TmaMessaging;

public class Program
{
  public static void Main()
  {

    // integrated with F# library
    Say.hello("John");
    int a = Say.alwaysTwo;

    // integrated with C# library
    var personRepo = new PersonsRepo();
    var personService = new PersonService(personRepo);
    var name = personService.GetById(1);
    Console.WriteLine(name);
  }
}
