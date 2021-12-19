using System;
namespace Billbee.Net.Logging
{
    public class HttpTelemetry
    {
        public string Endpoint { get; set; }
        public bool Succeeded { get; set; }
        public string RequestBody { get; set; }
        public int? HttpStatusCode { get; set; }
        public string ResponseBody { get; set; }
    }
}

