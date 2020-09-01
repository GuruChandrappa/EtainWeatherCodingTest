using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Etain.Weather.Services.Interface;
using Newtonsoft.Json;

namespace Etain.Weather.Services
{
    public class RestApiService : IRestApiService
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<T> Get<T>(string url)
        {
            try
            {
                // Add headers
                _client.DefaultRequestHeaders.Accept.Clear();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                _client.DefaultRequestHeaders.Accept.Add(contentType);

                var task = await _client.GetStringAsync(url);

                var data = JsonConvert.DeserializeObject<T>(task);

                return data;
            }
            catch(Exception ex)
            {
                return default(T);
            }
        }
    }
}
