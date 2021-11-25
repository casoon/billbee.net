using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface IProductEndpoint : IEndpoint<Product>
    {

    }

    public class ProductEndpoint : BaseEndpoint<Product>, IProductEndpoint
    {
        public ProductEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "products";
        }

    }
}

