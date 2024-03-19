namespace CSharpWebApp;

public static class Routes
{
    public static void MapWeatherForecastRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", (IWeatherService weatherService) => weatherService.GetForecast())
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
}