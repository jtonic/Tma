namespace TmaCcLibrary;

public static class Conference
{
    public static IEnumerable<Person> Participants() => [
        new("Tony", 54), 
        new ("Irina", 34), 
        new ("Roxana", 38), 
        new ("Liviu", 42)
    ];
    
    public static Person? FindParticipant(string name)
    {
        foreach (var participant in Participants())
        {
            if (participant.Name == name)
            {
                return participant;
            }
        }
        return null;
    }
    
    public record struct Person(string Name, int Age); 
}