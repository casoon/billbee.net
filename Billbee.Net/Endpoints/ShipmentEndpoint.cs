using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;
using Billbee.Net.Models.Rechnungsdruck.WebApp.Model.Api;

namespace Billbee.Net.Endpoints
{
    public interface IShipmentEndpoint : IBaseEndpoint
    {
        Task<List<ShippingProvider>> GetShippingProviderAsync();
        Task<List<ShippingCarrier>> GetShippingCarriersAsync();
        Task<dynamic> AddShipmentAsync(PostShipment shipment);
        Task<dynamic> ShipOrderWithLabelAsync(ShipmentWithLabel shipment);
    }


    public class ShipmentEndpoint : BaseEndpoint, IShipmentEndpoint
    {
        public ShipmentEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "shipment";
        }

        public async Task<List<ShippingProvider>> GetShippingProviderAsync()
        {
            var result = await billbeeClient.GetAllAsync<ShippingProvider>(EndPoint + "/shippingproviders");
            return result;
        }

        public async Task<List<ShippingCarrier>> GetShippingCarriersAsync()
        {
            var result = await billbeeClient.GetAllAsync<ShippingCarrier>(EndPoint + "/shippingcarriers");
            return result;
        }

        public async Task<dynamic> AddShipmentAsync(PostShipment shipment)
        {
            var result = await billbeeClient.AddAsync<dynamic>(EndPoint + "/shipment", shipment);
            return result;
        }

        public async Task<dynamic> ShipOrderWithLabelAsync(ShipmentWithLabel shipment)
        {
            var result = await billbeeClient.AddAsync<dynamic>(EndPoint + "/shipwithlabel", shipment);
            return result;
        }
    }
}