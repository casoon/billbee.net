namespace Billbee.Net.Models;

/// <summary>
///     Represents a stock with various properties including ID, name, description, and whether it is the default stock.
/// </summary>
public class Stock
{
    /// <summary>
    ///     Gets or sets the unique identifier of the stock.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the stock.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the description of the stock.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this stock is the default stock.
    /// </summary>
    public bool IsDefault { get; set; }
}