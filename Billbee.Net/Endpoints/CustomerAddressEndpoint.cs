using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
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
            this.EndPoint = "customer-addresses";
        }


        public async Task<CustomerAddress> AddAsync(CustomerAddress address)
        {
            var queryParams = new Dictionary<string, string>();

            try
            {
                var result = await billbeeClient.AddAsync<CustomerAddress>(this.EndPoint, address, queryParams);
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

        public async Task<CustomerAddress> GetAsync(long id)
        {
            try
            {
                var result = await billbeeClient.GetAsync<CustomerAddress>(this.EndPoint + "/" + id.ToString());
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

        public async Task<CustomerAddress> UpdateAsync(CustomerAddress address)
        {
            try
            {
                var result = await billbeeClient.UpdateAsync<CustomerAddress>(this.EndPoint + "/" + address.Id.ToString(), address);
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


        public async Task<List<CustomerAddress>> GetAllAsync(int page = 0, int pageSize = 50)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            try
            {
                var result = await billbeeClient.GetAllAsync<CustomerAddress>(this.EndPoint, queryParams);
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

