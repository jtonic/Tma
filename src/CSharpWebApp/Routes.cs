namespace CSharpWebApp;

public static class Routes
{
    public static void AddWeatherForecastRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", (IWeatherService weatherService) => weatherService.GetForecast())
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
}