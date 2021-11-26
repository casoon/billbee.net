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

    }

    public class CustomerAddressEndpoint : ExtendedEndpoint<Address>, ICustomerAddressEndpoint
    {
        public CustomerAddressEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "customer-addresses";
        }


    }
}

