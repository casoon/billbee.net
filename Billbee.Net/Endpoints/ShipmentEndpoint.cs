using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
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
            try
            {
                var result = await billbeeClient.GetAllAsync<ShippingProvider>(EndPoint + "/shippingproviders");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

        public async Task<List<ShippingCarrier>> GetShippingCarriersAsync()
        {
            try
            {
                var result = await billbeeClient.GetAllAsync<ShippingCarrier>(EndPoint + "/shippingcarriers");
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

        public async Task<dynamic> AddShipmentAsync(PostShipment shipment)
        {
            try
            {
                var result = await billbeeClient.AddAsync<dynamic>(EndPoint + "/shipment/shipment", shipment);
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

        public async Task<dynamic> ShipOrderWithLabelAsync(ShipmentWithLabel shipment)
        {
            try
            {
                var result = await billbeeClient.AddAsync<dynamic>(EndPoint + "/shipment/shipwithlabel", shipment);
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
        }

    }
}