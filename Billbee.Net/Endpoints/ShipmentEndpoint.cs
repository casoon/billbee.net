using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling shipment-related operations.
/// </summary>
public class ShipmentEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "shipment";

    /// <summary>
    ///     Initializes a new instance of the <see cref="ShipmentEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public ShipmentEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Retrieves a list of shipping providers asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of shipping providers.</returns>
    public async Task<List<ShippingProvider>> GetShippingProviderAsync()
    {
        return await _apiClient.GetAsync<List<ShippingProvider>>($"{_endpointPath}/shippingproviders");
    }

    /// <summary>
    ///     Retrieves a list of shipping carriers asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of shipping carriers.</returns>
    public async Task<List<ShippingCarrier>> GetShippingCarriersAsync()
    {
        return await _apiClient.GetAsync<List<ShippingCarrier>>($"{_endpointPath}/shippingcarriers");
    }

    /// <summary>
    ///     Adds a new shipment asynchronously.
    /// </summary>
    /// <param name="entity">The shipment entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddShipmentAsync(Shipment entity)
    {
        await _apiClient.PostAsync($"{_endpointPath}/shipment", entity);
    }

    /// <summary>
    ///     Ships an order with a label asynchronously.
    /// </summary>
    /// <param name="entity">The shipment with label entity.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ShipOrderWithLabelAsync(ShipmentWithLabel entity)
    {
        await _apiClient.PostAsync($"{_endpointPath}/shipwithlabel", entity);
    }
}