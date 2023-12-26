using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface ICustomerEndpoint : IExtendedEndpoint<Customer>
    {
        Task<List<Order>> GetOrdersForCustomerAsync(long id, int page, int pageSize);
        Task<List<Address>> GetAddressesForCustomerAsync(long id, int page, int pageSize);
    }

    public class CustomerEndpoint : ExtendedEndpoint<Customer>, ICustomerEndpoint
    {
        public CustomerEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "customers";
        }


        public async Task<List<Order>> GetOrdersForCustomerAsync(long id, int page, int pageSize)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            var result = await billbeeClient.GetAllAsync<Order>(EndPoint + "/" + id + "/" + "orders", queryParams);
            return result;
        }

        public async Task<List<Address>> GetAddressesForCustomerAsync(long id, int page, int pageSize)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            var result =
                await billbeeClient.GetAllAsync<Address>(EndPoint + "/" + id + "/" + "addresses", queryParams);
            return result;
        }
    }
}