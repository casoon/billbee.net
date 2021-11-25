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

    }

    public class CustomerEndpoint : BaseEndpoint<Customer>, ICustomerEndpoint
    {
        public CustomerEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "customers";
        }


    }
}

