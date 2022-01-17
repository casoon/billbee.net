namespace Billbee.Net.Endpoints
{
    public interface IDeliveryNoteEndpoint : IBaseEndpoint
    {
    }


    public class DeliveryNoteEndpoint : BaseEndpoint, IDeliveryNoteEndpoint
    {
        public DeliveryNoteEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "";
        }
    }
}