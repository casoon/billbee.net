using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billbee.Net
{
    public interface IBillbeeClient
    {
        Task<T> Request<T>(string endPoint, Dictionary<string, string> param);
    }
}

