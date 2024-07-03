namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling webhook-related operations.
/// </summary>
public class WebhookEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "webhooks";

    /// <summary>
    ///     Initializes a new instance of the <see cref="WebhookEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public WebhookEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}