using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface ICustomerAddressEndpoint : IBaseEndpoint
    {
        Task<List<CustomerAddress>> GetAllAsync(int page = 0, int pageSize = 50);
        Task<CustomerAddress> AddAsync(CustomerAddress address);
        Task<CustomerAddress> GetAsync(long id);
        Task<CustomerAddress> UpdateAsync(CustomerAddress address);
    }

    public class CustomerAddressEndpoint : BaseEndpoint, ICustomerAddressEndpoint
    {
        public CustomerAddressEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "customer-addresses";
        }


        public async Task<CustomerAddress> AddAsync(CustomerAddress address)
        {
            var queryParams = new Dictionary<string, string>();

            var result = await billbeeClient.AddAsync(EndPoint, address, queryParams);
            return result;
        }

        public async Task<CustomerAddress> GetAsync(long id)
        {
            var result = await billbeeClient.GetAsync<CustomerAddress>(EndPoint + "/" + id);
            return result;
        }

        public async Task<CustomerAddress> UpdateAsync(CustomerAddress address)
        {
            var result = await billbeeClient.UpdateAsync(EndPoint + "/" + address.Id, address);
            return result;
        }


        public async Task<List<CustomerAddress>> GetAllAsync(int page = 0, int pageSize = 50)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            var result = await billbeeClient.GetAllAsync<CustomerAddress>(EndPoint, queryParams);
            return result;
        }
    }
}