using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IWebhookEndpoint : IBaseEndpoint
    {

    }


    public class WebhookEndpoint : BaseEndpoint, IWebhookEndpoint
    {
        public WebhookEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "";
        }
    }
}

