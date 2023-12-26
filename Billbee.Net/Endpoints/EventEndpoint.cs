using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Enums;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface IEventEndpoint : IBaseEndpoint
    {
        Task<List<Event>> GetAllAsync(int page = 0, int pageSize = 50, DateTime? minDate = null,
            DateTime? maxDate = null, List<EventTypeEnum> typeIds = null, long? orderId = null);
    }


    public class EventEndpoint : BaseEndpoint, IEventEndpoint
    {
        public EventEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "events";
        }

        public async Task<List<Event>> GetAllAsync(int page = 0, int pageSize = 50, DateTime? minDate = null,
            DateTime? maxDate = null, List<EventTypeEnum> typeIds = null, long? orderId = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            if (minDate.HasValue) queryParams.Add("minDate", minDate.Value.ToString("yyyy-MM-dd HH:mm"));

            if (maxDate.HasValue) queryParams.Add("maxDate", maxDate.Value.ToString("yyyy-MM-dd"));

            if (orderId != null) queryParams.Add("orderId", orderId.ToString());

            var index = 0;
            if (typeIds != null)
                foreach (var typeId in typeIds)
                {
                    queryParams.Add($"typeId[{index}]", ((int) typeId).ToString());
                    index++;
                }

            var result = await billbeeClient.GetAllAsync<Event>(EndPoint, queryParams);
            return result;
        }
    }
}