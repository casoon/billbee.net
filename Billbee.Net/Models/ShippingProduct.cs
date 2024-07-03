namespace Billbee.Net.Models;

/// <summary>
///     Represents a shipping product with its details.
/// </summary>
public class ShippingProduct
{
    /// <summary>
    ///     Gets or sets the identifier of this shipping product.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the human-readable name of this shipping product.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    ///     Gets or sets the provider-specific product name.
    /// </summary>
    public string ProductName { get; set; }
}