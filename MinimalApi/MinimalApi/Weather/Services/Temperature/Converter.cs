namespace MinimalApi.Weather.Services.Temperature;

public class Converter : IConverter
{
    public float ToFahrenheit(float celsius)
        => celsius * 9 / 5 + 32;
}