using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Model
{
    public class CurrentWeather
    {
        public Coord coord { get; set; }

        public Weather weather { get; set; }

        public Main main { get; set; }

        public string q { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }

        public double lat { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }

        public string description { get; set; }

        public string icon { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }

        public float feels_like { get; set; }

        public float temp_min { get; set; }

        public float temp_max { get; set; }

        public int humidity { get; set; }
    }
}