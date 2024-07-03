using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Represents a shipping provider with its details and available products.
/// </summary>
public class ShippingProvider
{
    /// <summary>
    ///     Gets or sets the internal identifier of this provider.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of this provider.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the list of available products offered by this provider.
    /// </summary>
    public List<ShippingProduct> Products { get; set; }
}