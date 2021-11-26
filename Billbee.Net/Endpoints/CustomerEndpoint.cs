using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface ICustomerEndpoint : IEndpoint<Customer>
    {
        Task<List<Order>> GetOrdersForCustomer(long id, int page, int pageSize);
    }

    public class CustomerEndpoint : BaseEndpoint<Customer>, ICustomerEndpoint
    {
        public CustomerEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "customers";
        }


        public async Task<List<Order>> GetOrdersForCustomer(long id, int page, int pageSize)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            try
            {
                var result = await billbeeClient.GetAll<Order>(this.EndPoint + "/" + id.ToString() + "/" + "orders", queryParams);
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

