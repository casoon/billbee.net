using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IInvoiceEndpoint : IBaseEndpoint
    {

    }


    public class InvoiceEndpoint : BaseEndpoint, IInvoiceEndpoint
    {
        public InvoiceEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "";
        }
    }
}

