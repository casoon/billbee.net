using System;
using System.Collections.Generic;

namespace Billbee.Net.Responses
{
    public class ListResponse<T>
    {
        public Paging Paging { get; set; }

        public List<T> Data { get; set; }
    }
}

