using CSharpWebApp.Services;

namespace CSharpWebApp;

public static class Routes
{
    public static void AddWeatherForecastRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", (IWeatherService weatherService) => weatherService.GetForecast())
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
    public static void AddBookstoreRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/bookstore/authors", (IBookstoreService service) => service.GetAuthorsAsync())
            .WithName("GetBookstoreAuthors")
            .WithOpenApi();
        
        app.MapPost("/bookstore/authors", (IBookstoreService service, Author author) => service.AddAuthorAsync(author))
            .WithName("AddBookstoreAuthor")
            .WithOpenApi();
    }

    public static void AddGreetingRoutes(this IEndpointRouteBuilder app)
    {
        app.MapPost("/greeting", (GreetingService service, Author author) => service.Greeting(author))
            .WithName("GreetingAuthor")
            .WithOpenApi();
    }
}