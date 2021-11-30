using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;
using Billbee.Net.Models.Rechnungsdruck.WebApp.Model.Api;

namespace Billbee.Net.Endpoints
{

    public interface IShipmentEndpoint : IBaseEndpoint
    {
        Task<ShippingProvider> GetShippingProviderAsync();
        Task<ShippingCarrier> GetShippingCarriersAsync();
        Task<dynamic> AddShipmentAsync(PostShipment shipment);
        Task<dynamic> ShipOrderWithLabel(ShipmentWithLabel shipment);
    }


    public class ShipmentEndpoint : BaseEndpoint, IShipmentEndpoint
    {
        public ShipmentEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "shipment";
        }

        public async Task<ShippingProvider> GetShippingProviderAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<ShippingProvider>(this.EndPoint + "/shippingproviders");
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

        public async Task<ShippingCarrier> GetShippingCarriersAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<ShippingCarrier>(this.EndPoint + "/shippingcarriers");
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

        public async Task<dynamic> AddShipmentAsync(PostShipment shipment)
        {
            try
            {
                var result = await billbeeClient.AddAsync<dynamic>(this.EndPoint + "/shipment", shipment);
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

        public async Task<dynamic> ShipOrderWithLabel(ShipmentWithLabel shipment)
        {
            try
            {
                var result = await billbeeClient.AddAsync<dynamic>(this.EndPoint + "/shipment", shipment);
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

