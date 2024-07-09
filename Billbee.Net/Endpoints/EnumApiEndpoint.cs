using System.Threading.Tasks;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for retrieving various enumeration types.
/// </summary>
public class EnumApiEndpoint
{
    private readonly BillbeeClient _billbeeClient;
    private readonly string _endpointPath = "enums";

    /// <summary>
    ///     Initializes a new instance of the <see cref="EnumApiEndpoint" /> class.
    /// </summary>
    /// <param name="billbeeClient">The API client used to make requests.</param>
    public EnumApiEndpoint(BillbeeClient billbeeClient)
    {
        _billbeeClient = billbeeClient;
    }

    /// <summary>
    ///     Retrieves the payment types asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a JSON string of payment types.</returns>
    public async Task<string> GetPaymentTypesAsync()
    {
        return await _billbeeClient.GetAsync<string>($"{_endpointPath}/paymenttypes");
    }

    /// <summary>
    ///     Retrieves the shipping carriers asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a JSON string of shipping carriers.</returns>
    public async Task<string> GetShippingCarriersAsync()
    {
        return await _billbeeClient.GetAsync<string>($"{_endpointPath}/shippingcarriers");
    }

    /// <summary>
    ///     Retrieves the shipment types asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a JSON string of shipment types.</returns>
    public async Task<string> GetShipmentTypesAsync()
    {
        return await _billbeeClient.GetAsync<string>($"{_endpointPath}/shipmenttypes");
    }

    /// <summary>
    ///     Retrieves the order states asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a JSON string of order states.</returns>
    public async Task<string> GetOrderStatesAsync()
    {
        return await _billbeeClient.GetAsync<string>($"{_endpointPath}/orderstates");
    }
}