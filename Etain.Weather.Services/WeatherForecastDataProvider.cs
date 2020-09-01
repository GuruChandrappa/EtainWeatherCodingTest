using Etain.Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etain.Weather.Services.Interface;

namespace Etain.Weather.Services
{
    public class WeatherForecastDataProvider : IWeatherForecastDataProvider
    {
        private readonly string hostUrl;
        private readonly IRestApiService restApiService;

        public WeatherForecastDataProvider(IRestApiService restService, string url)
        {
            this.hostUrl = url;
            this.restApiService = restService;
        }


        /// <summary>
        /// This method can be made more generic to return forecast for n number of Days
        /// </summary>
        /// <param name="locationName"></param>
        /// <param name="nDays"></param>
        /// <returns></returns>
        public async Task<List<WeatherDto>> GetForecastForNDays(string locationName, int nDays)
        {
            try
            {
                // Get the where on earth Id for a given location name
                var woeId = await GetWoeIdByLocationName(locationName);

                //Get the forecast for next n Days for a given woeId
                return await GetForecastByWoeId(woeId, nDays);
            }
            catch (Exception ex)
            {
                throw new OperationCanceledException("Failed to Get weather from external API", ex);
            }
        }

        public async Task<int> GetWoeIdByLocationName(string locationName)
        {
            var locationUrl = $"{hostUrl}/location/search/?query={locationName}";
            var locations = await restApiService.Get<List<LocationDto>>(locationUrl);

            var location = locations?.FirstOrDefault();
            if (location == null)
                throw new OperationCanceledException("Location not found");

            return location.WoeId;
        }

        public async Task<List<WeatherDto>> GetForecastByWoeId(int woeId, int nDays)
        {
            var weatherUrl1 = $"{hostUrl}/location/{woeId}";
            var forcastForNext5Days = await restApiService.Get<ConsolidatedWeather>(weatherUrl1);
            
            //modify below to take nDays
            var results = (from c in forcastForNext5Days.Consolidated_Weather select c).Take(5).ToList();
            
            return results;
        }
    }
}