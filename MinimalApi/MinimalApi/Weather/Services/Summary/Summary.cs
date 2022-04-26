namespace MinimalApi.Weather.Services.Summary;

public class Summary : ISummary
{
    private static readonly string[] Conditions =
    {
        "Warm",
        "Cold",
        "Windy",
        "Rainy",
        "Sunny",
        "Cloudy"
    };
    
    public string GetRandom()
    {
        var index = new Random().Next(Conditions.Length);
        return Conditions[index];
    }
}