using System.Threading.Tasks;
using Billbee.Net.Models;
using Billbee.Net.Responses;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling customer addresses.
/// </summary>
public class CustomerAddressEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "customer-addresses";

    /// <summary>
    ///     Initializes a new instance of the <see cref="CustomerAddressEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public CustomerAddressEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Adds a new customer address asynchronously.
    /// </summary>
    /// <param name="address">The customer address to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(CustomerAddress address)
    {
        await _apiClient.PostAsync(_endpointPath, address);
    }

    /// <summary>
    ///     Retrieves a specific customer address by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the customer address.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested customer address.</returns>
    public async Task<CustomerAddress> GetAsync(long id)
    {
        return await _apiClient.GetAsync<CustomerAddress>($"{_endpointPath}/{id}");
    }

    /// <summary>
    ///     Updates an existing customer address asynchronously.
    /// </summary>
    /// <param name="address">The customer address to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(CustomerAddress address)
    {
        await _apiClient.PutAsync($"{_endpointPath}/{address.Id}", address);
    }

    /// <summary>
    ///     Retrieves all customer addresses asynchronously with pagination.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of addresses per page.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a paged response with the customer
    ///     addresses.
    /// </returns>
    public async Task<PagedResponse<CustomerAddress>> GetAllAsync(int page = 0, int pageSize = 50)
    {
        return await _apiClient.GetPagedAsync<CustomerAddress>(_endpointPath, page, pageSize);
    }
}