using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling cloud storage operations.
/// </summary>
public class CloudStorageEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "cloudstorages";

    /// <summary>
    ///     Initializes a new instance of the <see cref="CloudStorageEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public CloudStorageEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Retrieves all cloud storage entries asynchronously.
    /// </summary>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a collection of cloud storage
    ///     entries.
    /// </returns>
    public async Task<IEnumerable<CloudStorage>> GetAllAsync()
    {
        return await _apiClient.GetAsync<IEnumerable<CloudStorage>>(_endpointPath);
    }
}