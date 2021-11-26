using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface ICustomerEndpoint : IExtendedEndpoint<Customer>
    {
        Task<List<Order>> GetOrdersForCustomerAsync(long id, int page, int pageSize);
        Task<List<Order>> GetAddressesForCustomerAsync(long id, int page, int pageSize);
    }

    public class CustomerEndpoint : ExtendedEndpoint<Customer>, ICustomerEndpoint
    {
        public CustomerEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "customers";
        }


        public async Task<List<Order>> GetOrdersForCustomerAsync(long id, int page, int pageSize)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            try
            {
                var result = await billbeeClient.GetAllAsync<Order>(this.EndPoint + "/" + id.ToString() + "/" + "orders", queryParams);
                return result;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Order>> GetAddressesForCustomerAsync(long id, int page, int pageSize)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            try
            {
                var result = await billbeeClient.GetAllAsync<Order>(this.EndPoint + "/" + id.ToString() + "/" + "addresses", queryParams);
                return result;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
 
    }
}

