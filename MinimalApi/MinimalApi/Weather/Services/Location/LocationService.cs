using MinimalApi.Weather.Exceptions;

namespace MinimalApi.Weather.Services.Location;

public class LocationService : ILocationService
{
    private readonly HashSet<string> Cities = new()
    {
        "New York",
        "London",
        "Los Angeles",
        "Vancouver",
        "New Castle",
        "Manchester"
    };

    public string GetRandomCity()
    {
        var index = new Random().Next(Cities.Count);
        return Cities.ToList()[index];
    }

    public string FindCity(string city)
    {
        if (Cities.TryGetValue(city, out _))
            return city;

        throw new CityNotFoundException();
    }
}