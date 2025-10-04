namespace Billbee.Net.Logging
{
    public class HttpTelemetry
    {
        public string Endpoint { get; set; } = string.Empty;
        public bool Succeeded { get; set; }
        public string RequestBody { get; set; } = string.Empty;
        public int? HttpStatusCode { get; set; }
        public string ResponseBody { get; set; } = string.Empty;
    }
}