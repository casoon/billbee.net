using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IOrdersEndpoint : IEndpoint<Order>
    {

    }


    public class OrdersEndpoint : BaseEndpoint<Order>, IOrdersEndpoint
    {
        public OrdersEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "orders";
        }


    }
}

