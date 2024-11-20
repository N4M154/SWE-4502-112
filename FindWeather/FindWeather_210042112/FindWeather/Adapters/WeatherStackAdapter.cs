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
            
        }

        
    }
}
