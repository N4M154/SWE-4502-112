﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWeather
{
    public interface IWeatherProvider
    {
        Task<WeatherData> GetWeatherAsync(double latitude, double longitude);
        Task<WeatherData> GetWeatherByCityAsync(string city);
    }
}
