using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;

namespace Billbee.Net.Endpoints
{
    public interface IExtendedEndpoint<T>
    {
        Task<T> AddAsync(T t, Dictionary<string, string> param = null);

        Task<T> GetAsync(long id);

        Task<List<T>> GetAllAsync(int page, int pageSize);

        Task<T> UpdateAsync(T t);
    }

    public abstract class ExtendedEndpoint<T> : BaseEndpoint, IExtendedEndpoint<T>
    {
        public ExtendedEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
        }

        public async Task<T> AddAsync(T t, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            try
            {
                var result = await billbeeClient.AddAsync(EndPoint, t, param);
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(long id)
        {
            var result = await billbeeClient.GetAsync<T>(EndPoint + "/" + id);
            return result;
        }

        public async Task<List<T>> GetAllAsync(int page = 0, int pageSize = 50)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            try
            {
                var result = await billbeeClient.GetAllAsync<T>(EndPoint, queryParams);
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }


        public async Task<T> UpdateAsync(T t)
        {
            try
            {
                var result = await billbeeClient.UpdateAsync(EndPoint, t);
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }
    }
}