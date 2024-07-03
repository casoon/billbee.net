using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;
using Billbee.Net.Responses;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling customer-related operations.
/// </summary>
public class CustomerEndpoint : IApiEndpoint<Customer>
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "customers";

    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public CustomerEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Retrieves all customers asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a collection of customers.</returns>
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<Customer>>(_endpointPath);
    }

    /// <summary>
    ///     Retrieves a specific customer by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the customer.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested customer.</returns>
    public async Task<Customer> GetAsync(long id)
    {
        return await _apiClient.GetAsync<Customer>($"{_endpointPath}/{id}");
    }

    /// <summary>
    ///     Adds a new customer asynchronously.
    /// </summary>
    /// <param name="entity">The customer to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(Customer entity)
    {
        await _apiClient.PostAsync(_endpointPath, entity);
    }

    /// <summary>
    ///     Updates an existing customer asynchronously.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="entity">The updated customer data.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(long id, Customer entity)
    {
        await _apiClient.PutAsync($"{_endpointPath}/{id}", entity);
    }

    /// <summary>
    ///     Retrieves orders for a specific customer asynchronously with pagination.
    /// </summary>
    /// <param name="id">The ID of the customer.</param>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of orders per page.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a paged response with the customer's
    ///     orders.
    /// </returns>
    public async Task<PagedResponse<Order>> GetOrdersForCustomerAsync(long id, int page, int pageSize)
    {
        return await _apiClient.GetPagedAsync<Order>($"{_endpointPath}/{id}/orders", page, pageSize);
    }

    /// <summary>
    ///     Retrieves addresses for a specific customer asynchronously with pagination.
    /// </summary>
    /// <param name="id">The ID of the customer.</param>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of addresses per page.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a paged response with the customer's
    ///     addresses.
    /// </returns>
    public async Task<PagedResponse<Address>> GetAddressesForCustomerAsync(long id, int page, int pageSize)
    {
        return await _apiClient.GetPagedAsync<Address>($"{_endpointPath}/{id}/addresses", page, pageSize);
    }
}