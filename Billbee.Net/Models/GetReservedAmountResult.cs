namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of a query to get the reserved amount of an article.
/// </summary>
public class GetReservedAmountResult
{
    /// <summary>
    ///     Gets or sets the reserved (not fulfilled) quantity of the article.
    /// </summary>
    /// <value>The quantity of the article that is reserved but not yet fulfilled.</value>
    public decimal ReservedAmount { get; set; }
}