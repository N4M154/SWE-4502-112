﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindWeather
{
    public class WeatherFacade
    {
        public WeatherProviderProxy weatherStackProxy;
        public WeatherProviderProxy openWeatherProxy;
        public (double Latitude, double Longitude)? cachedLocation = null;

        public WeatherFacade()
        {
            var weatherStack = new WeatherStackAdapter();
            var openWeather = new OpenWeatherAdapter();
            weatherStackProxy = new WeatherProviderProxy(weatherStack);
            openWeatherProxy = new WeatherProviderProxy(openWeather);
        }

        public async Task<WeatherData> GetWeatherByIPAsync()
        {
            var location = await GetLocationAsync();
            cachedLocation = location;
            return await weatherStackProxy.GetWeatherAsync(location.Latitude, location.Longitude);
        }

        public async Task<(double Latitude, double Longitude)> GetLocationAsync()
        {
            if(cachedLocation.HasValue)
            {
                Console.WriteLine("Using cached data...);
                return cachedLocation.Value;
            }
            string ip = await new HttpClient().GetStringAsync("https://api.ipify.org");
            string url = $"http://api.ipstack.com/{ip}?access_key=de9240a0520081a9ce9e78214ec3e707";
            var response = await new HttpClient().GetStringAsync(url);
            var json = JsonDocument.Parse(response);
            double latitude = json.RootElement.GetProperty("latitude").GetDouble();
            double longitude = json.RootElement.GetProperty("longitude").GetDouble();

            cachedLocation = (latitude, longitude);                   
            return (latitude, longitude);
        }

        public async Task<WeatherData> GetWeatherByCityAsync(string city)
        {
            if (cachedLocation.HasValue)
            {
                var location = cachedLocation.Value;
                Console.WriteLine($"Using cached location for latitude: {location.Latitude}, longitude: {location.Longitude}");
                return await openWeatherProxy.GetWeatherAsync(location.Latitude, location.Longitude);

            }
            return await openWeatherProxy.GetWeatherByCityAsync(city);



        }

    }
}
