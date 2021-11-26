using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billbee.Net.Endpoints
{
    public interface IEndpoint<T>
    {

        Task<T> GetSingleAsync(long id);

        Task<List<T>> GetAllAsync(int page, int pageSize);

        Task<T> PostAsync(string query);

        Task<T> DeleteAsync();

        Task<T> PatchAsync(string query);

        Task<T> PutAsync(string query);

    }
}

