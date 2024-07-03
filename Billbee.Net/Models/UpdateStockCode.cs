namespace Billbee.Net.Models;

/// <summary>
///     Represents the information needed to update a stock code.
/// </summary>
public class UpdateStockCode
{
    /// <summary>
    ///     Gets or sets the SKU (Stock Keeping Unit) of the item.
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    ///     Gets or sets the identifier of the stock.
    /// </summary>
    public long? StockId { get; set; }

    /// <summary>
    ///     Gets or sets the stock code to be updated.
    /// </summary>
    public string StockCode { get; set; }
}