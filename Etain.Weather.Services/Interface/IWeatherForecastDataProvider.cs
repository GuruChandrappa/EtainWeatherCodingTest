using Etain.Weather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etain.Weather.Services.Interface
{
    public interface IWeatherForecastDataProvider
    {
        Task<List<WeatherDto>> GetForecastForNDays(string locationName, int days);
        Task<int> GetWoeIdByLocationName(string locationName);
        Task<List<WeatherDto>> GetForecastByWoeId(int woeId, int nDays);
    }
}