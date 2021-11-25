using System;
using System.Threading.Tasks;

namespace Billbee.Net.Endpoints
{
    public interface IEndpoint<T>
    {

        Task<T> GetSingleAsync(string id);

        Task<T> GetAllAsync();

        Task<T> PostAsync(string query);

        Task<T> DeleteAsync();

        Task<T> PatchAsync(string query);

        Task<T> PutAsync(string query);

    }
}

