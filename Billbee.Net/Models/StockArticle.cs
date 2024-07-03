namespace Billbee.Net.Models;

/// <summary>
///     Represents a stock article with various stock-related properties.
/// </summary>
public class StockArticle
{
    /// <summary>
    ///     Gets or sets the name of the stock article.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the identifier of the stock.
    /// </summary>
    public long StockId { get; set; }

    /// <summary>
    ///     Gets or sets the current stock level.
    /// </summary>
    public decimal? StockCurrent { get; set; }

    /// <summary>
    ///     Gets or sets the warning level for the stock.
    ///     When the stock level falls below this value, a warning may be triggered.
    /// </summary>
    public decimal? StockWarning { get; set; }

    /// <summary>
    ///     Gets or sets the stock code associated with the stock article.
    /// </summary>
    public string StockCode { get; set; }

    /// <summary>
    ///     Gets or sets the amount of stock that is unfulfilled.
    ///     This represents the quantity that has been ordered but not yet fulfilled.
    /// </summary>
    public decimal? UnfulfilledAmount { get; set; }

    /// <summary>
    ///     Gets or sets the desired stock level.
    ///     This represents the optimal stock level that is aimed to be maintained.
    /// </summary>
    public decimal? StockDesired { get; set; }
}