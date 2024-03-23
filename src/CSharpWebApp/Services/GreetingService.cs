namespace CSharpWebApp.Services;

public class GreetingService(ILogger<GreetingService> logger)
{
    public void Greeting(Author author)
    {
        logger.LogInformation($"Greeting to {author.Name}");
    }
}