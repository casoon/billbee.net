using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billbee.Net
{
    public interface IBillbeeClient
    {
        Task<T> Get<T>(string endPoint, Dictionary<string, string> param);
        Task<List<T>> GetAll<T>(string endPoint, Dictionary<string, string> param);
    }
}

