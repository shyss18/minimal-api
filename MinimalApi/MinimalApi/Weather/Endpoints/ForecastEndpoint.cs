using MinimalApi.Weather.Models;
using MinimalApi.Weather.Services.Location;
using MinimalApi.Weather.Services.Summary;
using MinimalApi.Weather.Services.Temperature;

namespace MinimalApi.Weather.Endpoints;

public class ForecastEndpoint
{
    private readonly ISummary _summary;
    private readonly IConverter _converter;
    private readonly ILocationService _locationService;

    public ForecastEndpoint(
        ISummary summary,
        IConverter converter,
        ILocationService locationService)
    {
        _summary = summary;
        _converter = converter;
        _locationService = locationService;
    }

    public Task<WeatherForecast[]> GetAsync()
    {
        var forecast = Enumerable
            .Range(0, 5)
            .Select(day =>
            {
                var temperatureC = new Random().NextInt64(-50, 50);
                var temperatureF = _converter.ToFahrenheit(temperatureC);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(day),
                    City = _locationService.GetRandomCity(),
                    Summary = _summary.GetRandom(),
                    TemperatureC = temperatureC,
                    TemperatureF = temperatureF
                };
            })
            .ToArray();

        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast[]> GetInDaysAsync(int days)
    {
        var forecast = Enumerable
            .Range(0, days)
            .Select(day =>
            {
                var temperatureC = new Random().NextInt64(-50, 50);
                var temperatureF = _converter.ToFahrenheit(temperatureC);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(day),
                    City = _locationService.GetRandomCity(),
                    Summary = _summary.GetRandom(),
                    TemperatureC = temperatureC,
                    TemperatureF = temperatureF
                };
            })
            .ToArray();

        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast[]> GetForCityAsync(string city, int days)
    {
        var forecast = Enumerable
            .Range(0, days)
            .Select(day =>
            {
                var temperatureC = new Random().NextInt64(-50, 50);
                var temperatureF = _converter.ToFahrenheit(temperatureC);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(day),
                    City = _locationService.FindCity(city),
                    Summary = _summary.GetRandom(),
                    TemperatureC = temperatureC,
                    TemperatureF = temperatureF
                };
            })
            .ToArray();

        return Task.FromResult(forecast);
    }
}