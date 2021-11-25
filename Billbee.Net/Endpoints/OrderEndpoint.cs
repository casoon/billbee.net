using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface IOrderEndpoint : IEndpoint<Order>
    {

    }

    public class OrderEndpoint : BaseEndpoint<Order>, IOrderEndpoint
    {
        public OrderEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "orders";
        }

    }
}

