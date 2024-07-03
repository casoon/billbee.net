namespace Billbee.Net.Models;

/// <summary>
///     Provides information about the current stock of an article.
/// </summary>
public class CurrentStockInfo
{
    /// <summary>
    ///     Gets or sets the SKU (Stock Keeping Unit) of the article.
    /// </summary>
    public string SKU { get; set; }

    /// <summary>
    ///     Gets or sets the amount currently available in stock.
    /// </summary>
    public decimal? CurrentStock { get; set; }
}