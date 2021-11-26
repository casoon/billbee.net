using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;

namespace Billbee.Net.Endpoints
{

    public interface IBaseEndpoint
    {

    }


    public abstract class BaseEndpoint : IBaseEndpoint
    {

        protected IBillbeeClient billbeeClient;

        public BaseEndpoint(IBillbeeClient billbeeClient)
        {
            this.billbeeClient = billbeeClient;
        }

        protected string EndPoint { get; set; }



    }
}

