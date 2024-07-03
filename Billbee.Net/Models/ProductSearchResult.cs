namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of a product search, providing key details about the product.
/// </summary>
public class ProductSearchResult
{
    /// <summary>
    ///     Gets or sets the unique identifier for the product.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets a brief description or title of the product.
    /// </summary>
    public string ShortText { get; set; }

    /// <summary>
    ///     Gets or sets the Stock Keeping Unit (SKU) associated with the product.
    /// </summary>
    public string SKU { get; set; }

    /// <summary>
    ///     Gets or sets a comma-separated string of tags associated with the product.
    /// </summary>
    public string Tags { get; set; }
}