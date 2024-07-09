namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling delivery notes.
/// </summary>
public class DeliveryNoteEndpoint
{
    private readonly BillbeeClient _billbeeClient;
    private readonly string _endpointPath = "deliverynotes";

    /// <summary>
    ///     Initializes a new instance of the <see cref="DeliveryNoteEndpoint" /> class.
    /// </summary>
    /// <param name="billbeeClient">The API client used to make requests.</param>
    public DeliveryNoteEndpoint(BillbeeClient billbeeClient)
    {
        _billbeeClient = billbeeClient;
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