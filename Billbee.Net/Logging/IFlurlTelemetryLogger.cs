using System.Threading.Tasks;
using Flurl.Http;

namespace Billbee.Net.Logging
{
    
    public interface IFlurlTelemetryLogger
    {
        Task Log(FlurlCall call);
    }
}

