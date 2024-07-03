namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling delivery notes.
/// </summary>
public class DeliveryNoteEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "deliverynotes";

    /// <summary>
    ///     Initializes a new instance of the <see cref="DeliveryNoteEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public DeliveryNoteEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }


    /*
    /// <summary>
    /// Retrieves a delivery note by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the delivery note.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested delivery note.</returns>
    public async Task<DeliveryNote> GetDeliveryNoteAsync(long id)
    {
        return await _apiClient.GetAsync<DeliveryNote>($"{_endpointPath}/{id}");
    }
    */
}