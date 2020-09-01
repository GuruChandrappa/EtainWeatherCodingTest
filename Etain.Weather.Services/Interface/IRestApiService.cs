using System.Threading.Tasks;

namespace Etain.Weather.Services.Interface
{
    public interface IRestApiService
    {
        Task<T> Get<T>(string url);
    }
}