using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etain.Weather.Models;
using Etain.Weather.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Etain.Weather.Controllers
{
    [Authorize]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    { 
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastDataProvider _weatherSvc;

        public WeatherForecastController(IWeatherForecastDataProvider svc, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _weatherSvc = svc;
        }

        [HttpGet]
        [Route("api/weather/")]
        public int Get()
        {
            return 2;
        }

        [HttpGet]
        [Route("/api/weather/{city}/{days}")]
        public IEnumerable<WeatherForecast> Get(string city, int days)
        {
            try
            {
                var res = _weatherSvc.GetForecastForNDays(city, days).GetAwaiter().GetResult();
                var toClientDtos = res.Where(x => x != null)
                    .Select(x => new WeatherForecast
                    {
                        Date = x?.Applicable_Date?.ToString("dd MMM, yyyy"),
                        Summary = x?.Weather_State_Name,
                        WeatherAbbreviation = x?.Weather_State_Abbr,
                        Temperature = x?.The_Temp?.ToString("N2") ,
                        AirPressure = x?.Air_Pressure?.ToString("N2"),
                        Humidity = x.Humidity?.ToString("N2"),
                        WindDirection = x.Wind_Direction?.ToString(),
                        WindSpeed = x.Wind_Speed?.ToString("N2")
                    })
                     .ToList();

                return toClientDtos;
            }
            catch(Exception ex)
            {
                //return 
                _logger.LogError(ex.Message);
                return new WeatherForecast[0];
            }

        }
    }
}
