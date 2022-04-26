namespace MinimalApi.Weather.Services.Temperature;

public interface IConverter
{
    float ToFahrenheit(float celsius);
}