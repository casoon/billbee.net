namespace Billbee.Net.Models;

/// <summary>
///     Represents a shipping carrier with its identifier and name.
/// </summary>
public class ShippingCarrier
{
    /// <summary>
    ///     Gets or sets the identifier of the shipping carrier.
    /// </summary>
    public byte Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the shipping carrier.
    /// </summary>
    public string Name { get; set; }
}