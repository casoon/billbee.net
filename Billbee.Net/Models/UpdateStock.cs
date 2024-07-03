namespace Billbee.Net.Models;

/// <summary>
///     Represents the information required to update the stock quantity of a product.
/// </summary>
public class UpdateStock
{
    /// <summary>
    ///     Gets or sets the SKU (Stock Keeping Unit) of the product to update.
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    ///     Gets or sets the stock ID for the product, if multi-stock feature is activated.
    ///     This is optional and only required if managing multiple stock locations.
    /// </summary>
    public long? StockId { get; set; }

    /// <summary>
    ///     Gets or sets an optional reason for the stock update.
    ///     This can be used to provide a description or explanation for the stock change.
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    ///     Gets or sets the old stock quantity.
    ///     This parameter is currently ignored and is included for future use or backward compatibility.
    /// </summary>
    public decimal? OldQuantity { get; set; }

    /// <summary>
    ///     Gets or sets the new absolute stock quantity for the product.
    ///     This specifies the updated stock level for the product.
    /// </summary>
    public decimal? NewQuantity { get; set; }

    /// <summary>
    ///     Gets or sets the quantity difference between the old and new stock levels.
    ///     This parameter is currently ignored and is included for future use or backward compatibility.
    /// </summary>
    public decimal DeltaQuantity { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to automatically reduce the <see cref="NewQuantity" /> by the currently not
    ///     fulfilled amount.
    /// </summary>
    /// <remarks>
    ///     If set to <c>true</c>, the <see cref="NewQuantity" /> is automatically reduced by the reserved (not fulfilled)
    ///     amount of the given article.
    ///     This is useful for adjusting the stock level based on pending orders or reservations.
    /// </remarks>
    public bool AutosubtractReservedAmount { get; set; }
}