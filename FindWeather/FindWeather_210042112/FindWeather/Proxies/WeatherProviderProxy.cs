using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWeather
{
    public class WeatherProviderProxy : IWeatherProvider
    {
        private readonly IWeatherProvider provider;
        private readonly Dictionary<string, (WeatherData, DateTime)> cache = new Dictionary<string, (WeatherData, DateTime)>();
        private DateTime lastRequestTime = DateTime.MinValue;

        public WeatherProviderProxy(IWeatherProvider provider)
        {
            this.provider = provider;
        }

        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude)
        {
            string key = $"{latitude},{longitude}";

            
            if (cache.ContainsKey(key) && (DateTime.Now - cache[key].Item2).TotalMinutes < 10)
            {
                return cache[key].Item1;
            }

            
            if ((DateTime.Now - lastRequestTime).TotalSeconds < 30)
            {
                throw new Exception("Rate limit reached. Please wait.");
            }

            
            var data = await provider.GetWeatherAsync(latitude, longitude);

            
            cache[key] = (data, DateTime.Now);
            lastRequestTime = DateTime.Now;

            return data;
        }
    }
}
