using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Billbee.Net.Logging
{
    public class FlurlTelemetryLogger : IFlurlTelemetryLogger
    {
        private readonly ILogger<FlurlTelemetryLogger> _logger;

        public FlurlTelemetryLogger(ILogger<FlurlTelemetryLogger> logger)
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
                _logger.LogInformation("{@FlurlTelemetry}", JsonConvert.SerializeObject(flurlTelemetry));
            else
                _logger.LogError("{@FlurlTelemetry}", JsonConvert.SerializeObject(flurlTelemetry));
        }
    }
}