namespace Billbee.Net.Models;

/// <summary>
///     Contains information to add shipment details from an external system to Billbee.
/// </summary>
public class OrderShipment
{
    /// <summary>
    ///     Gets or sets the ID assigned to the shipment by the provider.
    /// </summary>
    public string ShippingId { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the order this shipment should be attached to.
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    ///     Gets or sets a note that should be attached to the shipment.
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of the provider the shipment was sent with, if applicable.
    /// </summary>
    public long? ShippingProviderId { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of the shipping product the shipment uses, if applicable.
    /// </summary>
    public long? ShippingProviderProductId { get; set; }

    /// <summary>
    ///     Gets or sets the ID of a shipping carrier that should be assigned to the shipment, if applicable.
    ///     This will override the carrier from the shipment product.
    /// </summary>
    public byte? CarrierId { get; set; }
}