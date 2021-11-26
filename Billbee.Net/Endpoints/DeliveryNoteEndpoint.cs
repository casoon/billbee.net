using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IDeliveryNoteEndpoint : IBaseEndpoint
    {

    }


    public class DeliveryNoteEndpoint : BaseEndpoint, IDeliveryNoteEndpoint
    {
        public DeliveryNoteEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "";
        }
    }
}

