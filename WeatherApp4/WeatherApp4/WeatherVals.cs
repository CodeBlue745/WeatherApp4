using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp4
{
    /// <summary>
    /// Create get and set values for the application to change whenever it needs to perform an action.
    /// </summary>
    public partial class WeatherVals
    {
        public static string CurTemp { get; set; }
        public static string CityName { get; set; }
        public static string HighTemp { get; set; }
        public static string LowTemp { get; set; }
        public static string WindSpeed { get; set; }
        public static string Degrees { get; set; }
        public static string Pressure { get; set; }
        public static string Humidity { get; set; }
        public static string Sunrise { get; set; }
        public static string Sunset { get; set; }
        public static string SolarNoon { get; set; }
        public static string AstronomicalTwilight { get; set; }
    }
}
