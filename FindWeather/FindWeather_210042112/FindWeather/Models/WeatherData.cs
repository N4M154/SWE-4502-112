﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWeather.Models
{
    public class WeatherData
    {
        public string City { get; set; }
        public double Temperature { get; set; }
        public string Condition { get; set; }

        public string source { get; set; }
        
    }
}
