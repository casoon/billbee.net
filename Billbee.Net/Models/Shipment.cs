using System;
using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Container for creating a shipment without context to a Billbee order.
/// </summary>
public class Shipment
{
    /// <summary>
    ///     Gets or sets the name of the shipping provider to use.
    /// </summary>
    public string ProviderName { get; set; }

    /// <summary>
    ///     Gets or sets the product code of the shipping provider to use as the shipment method.
    /// </summary>
    public string ProductCode { get; set; }

    /// <summary>
    ///     Gets or sets the name of the cloud printer to send the labels to.
    /// </summary>
    public string PrinterName { get; set; }

    /// <summary>
    ///     Gets or sets the list of services to attach to the shipping product.
    /// </summary>
    public List<object> Services { get; set; }

    /// <summary>
    ///     Gets or sets the address of the addressee.
    /// </summary>
    public ShipmentAddress ReceiverAddress { get; set; }

    /// <summary>
    ///     Gets or sets the reference number for this parcel.
    /// </summary>
    public string ClientReference { get; set; }

    /// <summary>
    ///     Gets or sets the customer number to which this parcel should be sent.
    /// </summary>
    public string CustomerNumber { get; set; }

    /// <summary>
    ///     Gets or sets the gross weight of the parcel in grams.
    /// </summary>
    public decimal? WeightInGram { get; set; }

    /// <summary>
    ///     Gets or sets the total gross value of the parcel.
    /// </summary>
    public decimal OrderSum { get; set; }

    /// <summary>
    ///     Gets or sets the currency code of the currency in which the order was made.
    /// </summary>
    public string OrderCurrencyCode { get; set; }

    /// <summary>
    ///     Gets or sets the content description for export parcels.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    ///     Gets or sets the date and time of shipment.
    /// </summary>
    public DateTime? ShipDate { get; set; }

    /// <summary>
    ///     Gets or sets the ID of a connected cloud printer to send the export documents to.
    /// </summary>
    public long? PrinterIdForExportDocs { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the carrier the parcel will be sent with.
    /// </summary>
    public byte ShippingCarrier { get; set; }

    /// <summary>
    ///     Gets or sets the net value of the shipment's content.
    /// </summary>
    public decimal TotalNet { get; set; }

    /// <summary>
    ///     Gets or sets the dimensions of the shipment.
    /// </summary>
    public ShipmentDimensions Dimension { get; set; }
}