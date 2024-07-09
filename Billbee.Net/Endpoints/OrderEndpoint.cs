using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Enums;
using Billbee.Net.Models;
using Billbee.Net.Responses;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling orders.
/// </summary>
public class OrderEndpoint : IApiEndpoint<Order>
{
    private readonly BillbeeClient _billbeeClient;
    private readonly string _endpointPath = "orders";

    /// <summary>
    ///     Initializes a new instance of the <see cref="OrderEndpoint" /> class.
    /// </summary>
    /// <param name="billbeeClient">The API client used to make requests.</param>
    public OrderEndpoint(BillbeeClient billbeeClient)
    {
        _billbeeClient = billbeeClient;
    }

    /// <summary>
    ///     Retrieves all orders asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a collection of orders.</returns>
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _billbeeClient.GetAsync<IEnumerable<Order>>(_endpointPath);
    }

    /// <summary>
    ///     Retrieves a specific order by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the order.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested order.</returns>
    public async Task<Order> GetAsync(long id)
    {
        return await _billbeeClient.GetAsync<Order>($"{_endpointPath}/{id}");
    }

    /// <summary>
    ///     Adds a new order asynchronously.
    /// </summary>
    /// <param name="entity">The order to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(Order entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _billbeeClient.PostAsync(_endpointPath, entity);
    }

    /// <summary>
    ///     Updates an existing order asynchronously.
    /// </summary>
    /// <param name="id">The ID of the order to update.</param>
    /// <param name="entity">The updated order data.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(long id, Order entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _billbeeClient.PutAsync($"{_endpointPath}/{id}", entity);
    }

    /// <summary>
    ///     Adds a new order asynchronously with a specified shop ID.
    /// </summary>
    /// <param name="entity">The order to add.</param>
    /// <param name="shopId">The ID of the shop.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(Order entity, long shopId)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("shopId", shopId);
        await _billbeeClient.PostAsync(_endpointPath, entity, queryParams.Build());
    }

    /// <summary>
    ///     Retrieves the available order layouts asynchronously.
    /// </summary>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a string representing the available
    ///     layouts.
    /// </returns>
    public async Task<string> GetLayoutsAsync()
    {
        return await _billbeeClient.GetAsync<string>($"{_endpointPath}/layouts");
    }

    /// <summary>
    ///     Retrieves the fields that can be patched asynchronously.
    /// </summary>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a string representing the patchable
    ///     fields.
    /// </returns>
    public async Task<string> GetPatchableFieldsAsync()
    {
        return await _billbeeClient.GetAsync<string>($"{_endpointPath}/patchablefields");
    }

    /// <summary>
    ///     Patches an order asynchronously with the specified changes.
    /// </summary>
    /// <param name="id">The ID of the order to patch.</param>
    /// <param name="changes">The changes to apply.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task PatchOrderAsync(long id, Dictionary<string, object> changes)
    {
        if (changes == null) throw new ArgumentNullException(nameof(changes));
        await _billbeeClient.PatchAsync<Order>($"{_endpointPath}/{id}", changes);
    }

    /// <summary>
    ///     Retrieves an order by its external reference asynchronously.
    /// </summary>
    /// <param name="id">The external reference ID of the order.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested order.</returns>
    public async Task<Order> GetOrderByExternalReferenceAsync(long id)
    {
        return await _billbeeClient.GetAsync<Order>($"{_endpointPath}/findbyextref/{id}");
    }

    /// <summary>
    ///     Retrieves all orders with pagination and filtering options asynchronously.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of orders per page.</param>
    /// <param name="minOrderDate">The minimum order date filter.</param>
    /// <param name="maxOrderDate">The maximum order date filter.</param>
    /// <param name="shopId">The list of shop IDs to filter by.</param>
    /// <param name="orderStateId">The list of order state IDs to filter by.</param>
    /// <param name="tag">The list of tags to filter by.</param>
    /// <param name="minimumBillBeeOrderId">The minimum BillBee order ID filter.</param>
    /// <param name="modifiedAtMin">The minimum modification date filter.</param>
    /// <param name="modifiedAtMax">The maximum modification date filter.</param>
    /// <param name="excludeTags">Whether to exclude tags.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a paged response with the filtered
    ///     orders.
    /// </returns>
    public async Task<PagedResponse<Order>> GetAllAsync(
        int page = 0,
        int pageSize = 50,
        DateTime? minOrderDate = null,
        DateTime? maxOrderDate = null,
        List<long> shopId = null,
        List<OrderStateEnum> orderStateId = null,
        List<string> tag = null,
        long? minimumBillBeeOrderId = null,
        DateTime? modifiedAtMin = null,
        DateTime? modifiedAtMax = null,
        bool excludeTags = false
    )
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("page", page);
        queryParams.Add("pageSize", pageSize);
        queryParams.Add("excludeTags", excludeTags);
        queryParams.Add("minimumBillBeeOrderId", minimumBillBeeOrderId);
        queryParams.AddDate("minOrderDate", minOrderDate);
        queryParams.AddDate("maxOrderDate", maxOrderDate);
        queryParams.AddDate("modifiedAtMin", modifiedAtMin);
        queryParams.AddDate("modifiedAtMax", modifiedAtMax);
        queryParams.AddList("shopId", shopId);
        queryParams.AddList("tag", tag);
        queryParams.AddList("orderStateId", orderStateId?.Select(id => (int) id));

        return await _billbeeClient.GetPagedAsync<Order>(_endpointPath, queryParams.Build());
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
    public async Task<PagedResponse<Invoice>> GetInvoicesAsync(
        int page = 0,
        int pageSize = 50,
        DateTime? minInvoiceDate = null,
        DateTime? maxInvoiceDate = null,
        List<long> shopId = null,
        List<int> orderStateId = null,
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
        queryParams.AddList("orderStateId", orderStateId?.Select(id => id));

        return await _billbeeClient.GetPagedAsync<Invoice>($"{_endpointPath}/invoices", queryParams.Build());
    }

    /// <summary>
    ///     Adds tags to an order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="tags">The tags to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddTagsAsync(long orderId, List<string> tags)
    {
        if (tags == null) throw new ArgumentNullException(nameof(tags));
        await _billbeeClient.PostAsync($"{_endpointPath}/{orderId}/tags", tags);
    }

    /// <summary>
    ///     Updates tags of an order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="tags">The tags to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateTagsAsync(long orderId, List<string> tags)
    {
        if (tags == null) throw new ArgumentNullException(nameof(tags));
        await _billbeeClient.PutAsync($"{_endpointPath}/{orderId}/tags", tags);
    }

    /// <summary>
    ///     Adds a shipment to an order asynchronously.
    /// </summary>
    /// <param name="shipment">The shipment details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddShipmentAsync(OrderShipment shipment)
    {
        if (shipment == null) throw new ArgumentNullException(nameof(shipment));
        await _billbeeClient.PostAsync($"{_endpointPath}/{shipment.OrderId}/shipment", shipment);
    }

    /// <summary>
    ///     Adds a delivery note to an order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="includePdf">Whether to include a PDF in the response.</param>
    /// <param name="sendToCloudId">The ID to send the delivery note to the cloud.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddDeliveryNoteAsync(long orderId, bool includePdf = false, long? sendToCloudId = null)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("includePdf", includePdf);
        queryParams.Add("sendToCloudId", sendToCloudId);
        await _billbeeClient.PostAsync($"{_endpointPath}/CreateDeliveryNote/{orderId}/shipment", new DeliveryNote(),
            queryParams.Build());
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
        await _billbeeClient.PostAsync($"{_endpointPath}/CreateInvoice/{orderId}/shipment", new Invoice(),
            queryParams.Build());
    }

    /// <summary>
    ///     Updates the state of an order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="state">The new state of the order.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateOrderStateAsync(long orderId, OrderStateEnum state)
    {
        if (!Enum.IsDefined(typeof(OrderStateEnum), state))
            throw new InvalidEnumArgumentException(nameof(state), (int) state, typeof(OrderStateEnum));
        await _billbeeClient.PutAsync($"{_endpointPath}/{orderId}/orderstate", new {NewStateId = (int) state});
    }

    /// <summary>
    ///     Sends a message associated with an order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="message">The message to send.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SendMailAsync(long orderId, SendMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        await _billbeeClient.PostAsync($"{_endpointPath}/{orderId}/send-message", message);
    }

    /// <summary>
    ///     Creates an event associated with an order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="delayInMinutes">The delay in minutes before the event is triggered.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task CreateEventAsync(long orderId, string eventName, uint delayInMinutes = 0)
    {
        var model = new TriggerEventContainer
        {
            DelayInMinutes = delayInMinutes,
            Name = eventName
        };
        await _billbeeClient.PostAsync($"{_endpointPath}/{orderId}/trigger-event", model);
    }
}