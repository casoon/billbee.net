namespace Billbee.Net.Endpoints
{
    public interface IWebhookEndpoint : IBaseEndpoint
    {
    }


    public class WebhookEndpoint : BaseEndpoint, IWebhookEndpoint
    {
        public WebhookEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "";
        }
    }
}