﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IInvoiceEndpoint
    {

    }


    public class InvoiceEndpoint : IInvoiceEndpoint
    {
        public InvoiceEndpoint(IBillbeeClient billbeeClient)
        {

        }
    }
}
