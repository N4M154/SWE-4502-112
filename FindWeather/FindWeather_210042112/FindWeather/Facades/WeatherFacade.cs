using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
