using System.Threading.Tasks;

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
            var result = await billbeeClient.GetAsync<string>(EndPoint + "/paymenttypes");
            return result;
        }

        public async Task<string> GetShippingCarriersAsync()
        {
            var result = await billbeeClient.GetAsync<string>(EndPoint + "/shippingcarriers");
            return result;
        }

        public async Task<string> GetShipmentTypesAsync()
        {
            var result = await billbeeClient.GetAsync<string>(EndPoint + "/shipmenttypes");
            return result;
        }

        public async Task<string> GetOrderStatesAsync()
        {
            var result = await billbeeClient.GetAsync<string>(EndPoint + "/orderstates");
            return result;
        }
    }
}