using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Provides methods for automatic account provisioning and retrieving terms information.
/// </summary>
public class AutomaticProvisionEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "automaticprovision";

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutomaticProvisionEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public AutomaticProvisionEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Creates a new account asynchronously.
    /// </summary>
    /// <param name="account">The account information to create.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task CreateAccountAsync(Account account)
    {
        await _apiClient.PostAsync(_endpointPath, account);
    }

    /// <summary>
    ///     Retrieves terms information asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the terms information.</returns>
    public async Task<TermsResult> TermsInfoAsync()
    {
        return await _apiClient.GetAsync<TermsResult>($"{_endpointPath}/termsinfo");
    }
}