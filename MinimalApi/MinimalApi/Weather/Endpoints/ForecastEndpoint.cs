using MinimalApi.Weather.Models;
using MinimalApi.Weather.Services.Location;
using MinimalApi.Weather.Services.Summary;
using MinimalApi.Weather.Services.Temperature;

namespace MinimalApi.Weather.Endpoints;

public class ForecastEndpoint
{
    public Task<WeatherForecast[]> GetAsync(
        IConverter converter,
        ISummary summary,
        ILocationService locationService)
    {
        var forecast = Enumerable
            .Range(0, 5)
            .Select(day =>
            {
                var temperatureC = new Random().NextInt64(-50, 50);
                var temperatureF = converter.ToFahrenheit(temperatureC);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(day),
                    City = locationService.GetRandomCity(),
                    Summary = summary.GetRandom(),
                    TemperatureC = temperatureC,
                    TemperatureF = temperatureF
                };
            })
            .ToArray();

        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast[]> GetInDaysAsync(
        int days,
        IConverter converter,
        ISummary summary,
        ILocationService locationService)
    {
        var forecast = Enumerable
            .Range(0, days)
            .Select(day =>
            {
                var temperatureC = new Random().NextInt64(-50, 50);
                var temperatureF = converter.ToFahrenheit(temperatureC);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(day),
                    City = locationService.GetRandomCity(),
                    Summary = summary.GetRandom(),
                    TemperatureC = temperatureC,
                    TemperatureF = temperatureF
                };
            })
            .ToArray();

        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast[]> GetForCityAsync(
        string city,
        int days,
        IConverter converter,
        ISummary summary,
        ILocationService locationService)
    {
        var forecast = Enumerable
            .Range(0, days)
            .Select(day =>
            {
                var temperatureC = new Random().NextInt64(-50, 50);
                var temperatureF = converter.ToFahrenheit(temperatureC);

                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(day),
                    City = locationService.FindCity(city),
                    Summary = summary.GetRandom(),
                    TemperatureC = temperatureC,
                    TemperatureF = temperatureF
                };
            })
            .ToArray();

        return Task.FromResult(forecast);
    }
}