using CSharpWebApp;
using CSharpWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSingleton<IWeatherService, WeatherService>()
    .AddSingleton<IBookstoreRepository, BookstoreRepository>()
    .AddSingleton<IBookstoreService, BookstoreService>()
    .AddSingleton<GreetingService>()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add the routes to the app
app.AddWeatherForecastRoutes();
app.AddBookstoreRoutes();
app.AddGreetingRoutes();

app.Run();