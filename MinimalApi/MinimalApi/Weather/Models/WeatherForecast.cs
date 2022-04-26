namespace MinimalApi.Weather.Models;

public class WeatherForecast
{
    public string City { get; set; }

    public float TemperatureC { get; set; }
    
    public float TemperatureF { get; set; }

    public DateTime Date { get; set; }

    public string Summary { get; set; }
}