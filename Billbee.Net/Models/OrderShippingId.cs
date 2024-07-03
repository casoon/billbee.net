using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents shipping IDs that are attached to an order.
/// </summary>
public class OrderShippingId
{
    /// <summary>
    ///     Gets or sets the ID of the shipment.
    /// </summary>
    public string ShippingId { get; set; }

    /// <summary>
    ///     Gets or sets the name of the shipping provider.
    /// </summary>
    public string Shipper { get; set; }

    /// <summary>
    ///     Gets or sets the date when this shipment was created.
    /// </summary>
    public DateTime? Created { get; set; }

    /// <summary>
    ///     Gets or sets the tracking URL.
    /// </summary>
    public string TrackingUrl { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the used shipping provider.
    /// </summary>
    public long? ShippingProviderId { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the used shipping provider product.
    /// </summary>
    public long? ShippingProviderProductId { get; set; }

    /// <summary>
    ///     Gets or sets the carrier used to ship the parcel.
    /// </summary>
    public byte? ShippingCarrier { get; set; }
}