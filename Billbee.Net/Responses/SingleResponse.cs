using System;
namespace Billbee.Net.Responses
{

    public class SingleResponse<T>
    {
        public int ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }
    }
}

