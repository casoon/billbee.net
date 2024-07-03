using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents a request object to ship an order in Billbee with various shipment details.
/// </summary>
public class ShipmentWithLabel
{
    /// <summary>
    ///     Gets or sets the Billbee internal identifier of the order that should be shipped.
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    ///     Gets or sets the Billbee internal identifier of the provider that should be used for shipping.
    /// </summary>
    public long ProviderId { get; set; }

    /// <summary>
    ///     Gets or sets the Billbee internal identifier of the product that should be used for shipping.
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the state of the given order should be set to "sent" after creation of the
    ///     label.
    ///     Optional. Default value is true.
    /// </summary>
    public bool? ChangeStateToSend { get; set; }

    /// <summary>
    ///     Gets or sets the name of a cloud drive or printer that should be used to automatically store the label after
    ///     creation.
    ///     Optional.
    /// </summary>
    public string PrinterName { get; set; }

    /// <summary>
    ///     Gets or sets the total weight of the parcel in grams.
    ///     Optional.
    /// </summary>
    public int? WeightInGram { get; set; }

    /// <summary>
    ///     Gets or sets the date when the parcel should be sent.
    ///     Optional.
    /// </summary>
    public DateTime? ShipDate { get; set; }

    /// <summary>
    ///     Gets or sets a reference that will be added to the parcel process as an individual reference.
    ///     Optional.
    /// </summary>
    public string ClientReference { get; set; }

    /// <summary>
    ///     Gets or sets the dimensions of the package.
    ///     Optional.
    /// </summary>
    public ShipmentDimensions Dimension { get; set; }
}