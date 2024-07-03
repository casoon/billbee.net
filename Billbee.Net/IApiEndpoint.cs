using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billbee.Net;

public interface IApiEndpoint<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(long id);
    Task AddAsync(T entity);
    Task UpdateAsync(long id, T entity);
}