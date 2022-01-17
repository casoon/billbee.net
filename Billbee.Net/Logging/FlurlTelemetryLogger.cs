using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using Serilog;

namespace Billbee.Net.Logging
{
    public class FlurlTelemetryLogger : IFlurlTelemetryLogger
    {
        private readonly ILogger _logger;

        public FlurlTelemetryLogger(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Log(FlurlCall call)
        {
            var flurlTelemetry = new HttpTelemetry
            {
                Endpoint = call.ToString(),
                Succeeded = call.Succeeded,
                RequestBody = call.RequestBody,
                HttpStatusCode = call.Response.StatusCode
            };

            if (call.Response != null &&
                call.Response.ResponseMessage.Content != null &&
                call.Response.ResponseMessage.Content.Headers.ContentType != null)
            {
                var ct = call.Response.ResponseMessage.Content.Headers.ContentType.ToString();
                if (ct.ToLower().Contains("application/json") || ct.ToLower().Contains("text/plain"))
                    flurlTelemetry.ResponseBody = await call.Response.ResponseMessage.Content.ReadAsStringAsync();
            }

            if (call.Response.StatusCode < 300)
                _logger.Information("{@FlurlTelemetry}", JsonConvert.SerializeObject(flurlTelemetry));
            else
                _logger.Error("{@FlurlTelemetry}", JsonConvert.SerializeObject(flurlTelemetry));
        }
    }
}