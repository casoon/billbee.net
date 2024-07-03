namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of a shipment creation, containing the shipment ID and label data.
/// </summary>
public class ShipmentResult
{
    /// <summary>
    ///     Gets or sets the identifier of the created shipment.
    /// </summary>
    public string ShippingId { get; set; }

    /// <summary>
    ///     Gets or sets the byte array containing the label of the created shipment in PDF format.
    /// </summary>
    public byte[] LabelData { get; set; }
}