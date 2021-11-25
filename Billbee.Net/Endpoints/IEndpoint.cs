using System;
using System.Threading.Tasks;

namespace Billbee.Net.Endpoints
{
    public interface IEndpoint<T>
    {

        Task<T> GetAsync(string id);

        Task<T> PostAsync(string query);

        Task<T> DeleteAsync();

        Task<T> PatchAsync(string query);

        Task<T> PutAsync(string query);

    }
}

