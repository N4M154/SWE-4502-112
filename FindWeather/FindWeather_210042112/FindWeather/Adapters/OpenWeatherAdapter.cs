using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindWeather
{
    public class OpenWeatherAdapter:IWeatherProvider
    {
        private readonly OpenWeatherBase baseClient = new OpenWeatherBase();
        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude)
        {
            var response = await baseClient.FetchWeatherDataByCoordinatesAsync(latitude, longitude);
            var json = JsonDocument.Parse(response);

            
        }

    }
}
