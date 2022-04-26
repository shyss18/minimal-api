using Microsoft.AspNetCore.Mvc;
using MinimalApi.Weather.Endpoints;
using MinimalApi.Weather.Services.Location;
using MinimalApi.Weather.Services.Summary;
using MinimalApi.Weather.Services.Temperature;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddScoped<IConverter, Converter>();
builder.Services.AddScoped<ISummary, Summary>();
builder.Services.AddScoped<ILocationService, LocationService>();

var app = builder.Build();

var forecast = new ForecastEndpoint();

app.MapGet("/forecast",
    (IConverter converter, ISummary summary, ILocationService locationService) =>
        forecast.GetAsync(converter, summary, locationService));

app.MapGet("/forecast/days={days}",
    (int days, IConverter converter, ISummary summary, ILocationService locationService) =>
        forecast.GetInDaysAsync(days, converter, summary, locationService));

app.MapGet("/forecast/city={city}&days={days}",
    (string city, int days, IConverter converter, ISummary summary,
            ILocationService locationService) =>
        forecast.GetForCityAsync(city, days, converter, summary, locationService));

app.UseHttpLogging();

app.Run();