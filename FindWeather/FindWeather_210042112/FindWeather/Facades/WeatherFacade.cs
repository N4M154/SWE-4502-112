using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWeather
{
    public class WeatherFacade
    {
        private readonly WeatherProviderProxy weatherStackProxy;
        private readonly WeatherProviderProxy openWeatherProxy;
        private (double Latitude, double Longitude)? cachedLocation = null;
    }
}
