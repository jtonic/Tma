namespace Business
{
  public class PersonsRepo
  {
    public string GetById(int id)
    {
      var person = new Person { Id = 1, Name = "John" };
      return $"Person found for id: {id}. {person}";
    }
  }

  public struct Person
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString()
    {
      return $"Id: {Id}, Name: {Name}";
    }
  }

  public class PersonService
  {
    public PersonsRepo PersonsRepo { get; }

    public PersonService(PersonsRepo personsRepo) => PersonsRepo = personsRepo;

    public string GetById(int id)
    {
      return PersonsRepo.GetById(id);
    }
  }
}
