using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Provides methods for automatic account provisioning and retrieving terms information.
/// </summary>
public class AutomaticProvisionEndpoint
{
    private readonly BillbeeClient _billbeeClient;
    private readonly string _endpointPath = "automaticprovision";

    /// <summary>
    ///     Initializes a new instance of the <see cref="AutomaticProvisionEndpoint" /> class.
    /// </summary>
    /// <param name="billbeeClient">The API client used to make requests.</param>
    public AutomaticProvisionEndpoint(BillbeeClient billbeeClient)
    {
        _billbeeClient = billbeeClient;
    }

    /// <summary>
    ///     Creates a new account asynchronously.
    /// </summary>
    /// <param name="account">The account information to create.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task CreateAccountAsync(Account account)
    {
        await _billbeeClient.PostAsync(_endpointPath, account);
    }

    /// <summary>
    ///     Retrieves terms information asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the terms information.</returns>
    public async Task<TermsResult> TermsInfoAsync()
    {
        return await _billbeeClient.GetAsync<TermsResult>($"{_endpointPath}/termsinfo");
    }
}