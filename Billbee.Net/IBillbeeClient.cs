using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billbee.Net
{
    public interface IBillbeeClient
    {
        Task<T> AddAsync<T>(string endPoint, T t, Dictionary<string, string>? param = null);
        Task<T> GetAsync<T>(string endPoint, Dictionary<string, string>? param = null);
        Task<T> UpdateAsync<T>(string endPoint, T t, Dictionary<string, string>? param = null);
        Task<List<T>> GetAllAsync<T>(string endPoint, Dictionary<string, string>? param = null);
        Task<T> PatchAsync<T>(string endPoint, Dictionary<string, object> fields);
        Task DeleteAsync<T>(string endPoint);
        Task DeleteAsync<T>(string endPoint, T t);
    }
}