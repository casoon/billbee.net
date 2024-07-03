using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Enums;
using Billbee.Net.Models;
using Billbee.Net.Responses;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling invoices.
/// </summary>
public class InvoiceEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "orders";

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvoiceEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public InvoiceEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Retrieves all invoices with pagination and filtering options asynchronously.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of invoices per page.</param>
    /// <param name="minInvoiceDate">The minimum invoice date filter.</param>
    /// <param name="maxInvoiceDate">The maximum invoice date filter.</param>
    /// <param name="shopId">The list of shop IDs to filter by.</param>
    /// <param name="orderStateId">The list of order state IDs to filter by.</param>
    /// <param name="tag">The list of tags to filter by.</param>
    /// <param name="minPayDate">The minimum pay date filter.</param>
    /// <param name="maxPayDate">The maximum pay date filter.</param>
    /// <param name="includePositions">Whether to include positions in the response.</param>
    /// <param name="excludeTags">Whether to exclude tags.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a paged response with the filtered
    ///     invoices.
    /// </returns>
    public async Task<PagedResponse<Invoice>> GetAllAsync(
        int page = 0,
        int pageSize = 50,
        DateTime? minInvoiceDate = null,
        DateTime? maxInvoiceDate = null,
        List<long> shopId = null,
        List<OrderStateEnum> orderStateId = null,
        List<string> tag = null,
        DateTime? minPayDate = null,
        DateTime? maxPayDate = null,
        bool includePositions = false,
        bool excludeTags = false
    )
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("page", page);
        queryParams.Add("pageSize", pageSize);
        queryParams.Add("excludeTags", excludeTags);
        queryParams.AddDate("minInvoiceDate", minInvoiceDate);
        queryParams.AddDate("maxInvoiceDate", maxInvoiceDate);
        queryParams.AddDate("minPayDate", minPayDate);
        queryParams.AddDate("maxPayDate", maxPayDate);
        queryParams.AddList("shopId", shopId);
        queryParams.AddList("tag", tag);
        queryParams.AddList("orderStateId", orderStateId?.Select(id => (int) id));

        return await _apiClient.GetPagedAsync<Invoice>(_endpointPath, queryParams.Build());
    }

    /// <summary>
    ///     Adds an invoice to an order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="includePdf">Whether to include a PDF in the response.</param>
    /// <param name="templateId">The template ID to use for the invoice.</param>
    /// <param name="sendToCloudId">The ID to send the invoice to the cloud.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddInvoiceAsync(long orderId, bool includePdf = false, long? templateId = null,
        long? sendToCloudId = null)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("includeInvoicePdf", includePdf);
        queryParams.Add("sendToCloudId", sendToCloudId);
        queryParams.Add("templateId", templateId);

        await _apiClient.PostAsync($"{_endpointPath}/CreateInvoice/{orderId}", new Invoice(), queryParams.Build());
    }
}