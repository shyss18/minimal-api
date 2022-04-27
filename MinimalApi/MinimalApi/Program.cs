using MinimalApi.Weather.Endpoints;
using MinimalApi.Weather.Services.Location;
using MinimalApi.Weather.Services.Summary;
using MinimalApi.Weather.Services.Temperature;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddScoped<IConverter, Converter>();
builder.Services.AddScoped<ISummary, Summary>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ForecastEndpoint>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

using (var scope = app.Services.CreateScope())
{
    var forecast = scope.ServiceProvider.GetService<ForecastEndpoint>() ?? throw new ArgumentNullException();

    app.MapGet("/forecast", () => forecast.GetAsync());
    app.MapGet("/forecast/days={days}", (int days) => forecast.GetInDaysAsync(days));
    app.MapGet("/forecast/city={city}&days={days}", (string city, int days) => forecast.GetForCityAsync(city, days));
}

app.UseHttpLogging();

app.UseSwaggerUI();

app.Run();