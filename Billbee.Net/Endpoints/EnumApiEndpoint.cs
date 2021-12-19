using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IEnumApiEndpoint : IBaseEndpoint
    {
        Task<String> GetPaymentTypesAsync();
        Task<String> GetShippingCarriersAsync();
        Task<String> GetShipmentTypesAsync();
        Task<String> GetOrderStatesAsync();

    }

    public class EnumApiEndpoint : BaseEndpoint, IEnumApiEndpoint
    {
        public EnumApiEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "enums";
        }

        public async Task<String> GetPaymentTypesAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<String>(this.EndPoint + "/paymenttypes");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<String> GetShippingCarriersAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<String>(this.EndPoint + "/shippingcarriers");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<String> GetShipmentTypesAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<String>(this.EndPoint + "/shipmenttypes");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<String> GetOrderStatesAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<String>(this.EndPoint + "/orderstates");
                return result;
            }
            catch (ApiException)
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

