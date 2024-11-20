using FindWeather.APIs;
using FindWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWeather.Adapters
{
    public class WeatherStackAdapter:IWeatherProvider
    {
        private readonly WeatherStackBase baseClient = new WeatherStackBase();
        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude)
        {
            var response = await baseClient.FetchWeatherDataAsync(latitude, longitude);
            var json = JsonDocument.Parse(response);

            return new WeatherData
            {
                City = json.RootElement.GetProperty("location").GetProperty("name").GetString(),
                Temperature = json.RootElement.GetProperty("current").GetProperty("temperature").GetDouble(),
                Condition = json.RootElement.GetProperty("current").GetProperty("weather_descriptions")[0].GetString(),
                Source = "WeatherStack"
            };
        }
        public async Task<WeatherData> GetWeatherByCityAsync(string city)
        {
            throw new NotImplementedException("This adapter does not support city-based lookups.");
        }

    }
}
