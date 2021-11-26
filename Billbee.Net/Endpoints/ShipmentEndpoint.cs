using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IShipmentEndpoint : IBaseEndpoint
    {

    }


    public class ShipmentEndpoint : BaseEndpoint, IShipmentEndpoint
    {
        public ShipmentEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "";
        }
    }
}

