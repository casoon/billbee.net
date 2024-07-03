using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of a shipment with label creation, containing various shipment details.
/// </summary>
public class ShipmentWithLabelResult
{
    /// <summary>
    ///     Gets or sets the identifier of the order that was shipped.
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    ///     Gets or sets the reference number of the carrier or provider.
    /// </summary>
    public string OrderReference { get; set; }

    /// <summary>
    ///     Gets or sets the order or tracking number of the carrier or provider.
    /// </summary>
    public string ShippingId { get; set; }

    /// <summary>
    ///     Gets or sets the URL to track the shipment.
    /// </summary>
    public string TrackingUrl { get; set; }

    /// <summary>
    ///     Gets or sets the PDF data of the label as base64 encoded data, if applicable.
    /// </summary>
    public byte[] LabelDataPdf { get; set; }

    /// <summary>
    ///     Gets or sets the PDF data of the export documents as base64 encoded data, if applicable.
    /// </summary>
    public byte[] ExportDocsPdf { get; set; }

    /// <summary>
    ///     Gets or sets the text representation of the used carrier.
    /// </summary>
    public string Carrier { get; set; }

    /// <summary>
    ///     Gets or sets the datetime defining when the order should be sent.
    /// </summary>
    public DateTime ShippingDate { get; set; }
}