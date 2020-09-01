using System;
using System.Collections.Generic;

namespace Etain.Weather.Models
{
   
    public class ConsolidatedWeather
    {
        public List<WeatherDto> Consolidated_Weather { get; set; }
    }

    public class WeatherDto
    {
        public string Id { get; set; }
        public string Location_Name { get; set; }
        public string Weather_State_Name { get; set; }
        public string Weather_State_Abbr { get; set; }
        public string Wind_Direction_Compass { get; set; }

        public DateTime? Applicable_Date { get; set; }
        public DateTime? Created_Date { get; set; }

        public decimal? Min_Temp { get; set; }
        public decimal? Max_Temp { get; set; }
        public decimal? The_Temp { get; set; }
        public decimal? Wind_Direction { get; set; }
        public decimal? Wind_Speed { get; set; }
        public decimal? Air_Pressure { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Visibility { get; set; }
        public decimal? Predictability { get; set; }

    }

    public class LocationDto
    {
        public string Title { get; set; }
        public int WoeId { get; set; }
        public string LocationType { get; set; }
    }
}
