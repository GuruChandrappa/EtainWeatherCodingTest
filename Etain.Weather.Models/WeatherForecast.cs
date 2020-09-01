using System;

namespace Etain.Weather.Models
{
    public class WeatherForecast
    {
        public string Date { get; set; }
        public string Temperature { get; set; }
        public string Summary { get; set; }
        public string WeatherAbbreviation { get; set; }
        public string AirPressure { get; set; }
        public string Humidity { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
    }
}
