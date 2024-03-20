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
    }
}