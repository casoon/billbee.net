using System.Threading.Tasks;
using Billbee.Net.Exceptions;

namespace Billbee.Net.Endpoints
{
    public interface IEnumApiEndpoint : IBaseEndpoint
    {
        Task<string> GetPaymentTypesAsync();
        Task<string> GetShippingCarriersAsync();
        Task<string> GetShipmentTypesAsync();
        Task<string> GetOrderStatesAsync();
    }

    public class EnumApiEndpoint : BaseEndpoint, IEnumApiEndpoint
    {
        public EnumApiEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "enums";
        }

        public async Task<string> GetPaymentTypesAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<string>(EndPoint + "/paymenttypes");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

        public async Task<string> GetShippingCarriersAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<string>(EndPoint + "/shippingcarriers");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

        public async Task<string> GetShipmentTypesAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<string>(EndPoint + "/shipmenttypes");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

        public async Task<string> GetOrderStatesAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<string>(EndPoint + "/orderstates");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }
    }
}