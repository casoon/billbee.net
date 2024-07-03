using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Enums;
using Billbee.Net.Models;
using Billbee.Net.Responses;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling events.
/// </summary>
public class EventEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "events";

    /// <summary>
    ///     Initializes a new instance of the <see cref="EventEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public EventEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Retrieves events for a customer with pagination and filtering options asynchronously.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of events per page.</param>
    /// <param name="minDate">The minimum date filter.</param>
    /// <param name="maxDate">The maximum date filter.</param>
    /// <param name="typeIds">The list of event type IDs to filter by.</param>
    /// <param name="orderId">The order ID to filter by, if applicable.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a paged response with the filtered
    ///     events.
    /// </returns>
    public async Task<PagedResponse<Event>> GetOrdersForCustomerAsync(
        long page = 0,
        long pageSize = 50,
        DateTime? minDate = null,
        DateTime? maxDate = null,
        List<EventTypeEnum> typeIds = null,
        long? orderId = null)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("page", page.ToString());
        queryParams.Add("pageSize", pageSize.ToString());
        queryParams.AddDate("minDate", minDate);
        queryParams.AddDateWithoutTime("maxDate", maxDate);

        if (orderId.HasValue) queryParams.Add("orderId", orderId.Value.ToString());

        queryParams.AddList("typeId", typeIds?.Select(id => ((int) id).ToString()));

        return await _apiClient.GetPagedAsync<Event>(_endpointPath, queryParams.Build());
    }
}