namespace MinimalApi.Weather.Services.Location;

public interface ILocationService
{
    string GetRandomCity();

    string FindCity(string city);
}