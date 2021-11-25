using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IEventEndpoint
    {

    }


    public class EventEndpoint : IEventEndpoint
    {
        public EventEndpoint(IBillbeeClient billbeeClient)
        {

        }
    }
}

