using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Represents a product within an order.
/// </summary>
public class OrderItemProduct
{
    /// <summary>
    ///     Gets or sets the old ID of the product for migration scenarios when the internal ID changes.
    ///     For example, when switching to new inventory management in Etsy, the IDs for variants may change.
    /// </summary>
    public string OldId { get; set; }

    /// <summary>
    ///     Gets or sets the current ID of the product.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     Gets or sets the title of the product.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Gets or sets the weight of one item in grams.
    /// </summary>
    public int? Weight { get; set; }

    /// <summary>
    ///     Gets or sets the stock keeping unit (SKU) of the product.
    /// </summary>
    public string SKU { get; set; }

    /// <summary>
    ///     Gets the SKU if available; otherwise, gets the ID of the product.
    /// </summary>
    public string SkuOrId => string.IsNullOrEmpty(SKU) ? Id : SKU;

    /// <summary>
    ///     Gets or sets a value indicating whether the product is digital.
    /// </summary>
    public bool? IsDigital { get; set; }

    /// <summary>
    ///     Gets or sets the list of images associated with the product.
    /// </summary>
    public List<OrderProductImage> Images { get; set; }

    /// <summary>
    ///     Gets or sets the European Article Number (EAN) of the product.
    /// </summary>
    public string EAN { get; set; }

    /// <summary>
    ///     Gets or sets optional platform-specific data as a serialized JSON object for the product.
    /// </summary>
    public string PlatformData { get; set; }

    /// <summary>
    ///     Gets or sets the TARIC code of the product.
    /// </summary>
    public string TARICCode { get; set; }

    /// <summary>
    ///     Gets or sets the country of origin of the product.
    /// </summary>
    public string CountryOfOrigin { get; set; }

    /// <summary>
    ///     Gets or sets the internal Billbee ID of the product.
    /// </summary>
    public long? BillbeeId { get; set; }
}