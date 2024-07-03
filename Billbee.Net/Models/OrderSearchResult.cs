namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of an order search in Billbee.
/// </summary>
public class OrderSearchResult
{
    /// <summary>
    ///     Gets or sets the ID of the order.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the external reference of the order.
    /// </summary>
    public string ExternalReference { get; set; }

    /// <summary>
    ///     Gets or sets the name of the buyer.
    /// </summary>
    public string BuyerName { get; set; }

    /// <summary>
    ///     Gets or sets the invoice number of the order.
    /// </summary>
    public string InvoiceNumber { get; set; }

    /// <summary>
    ///     Gets or sets the name of the customer.
    /// </summary>
    public string CustomerName { get; set; }

    /// <summary>
    ///     Gets or sets the texts of the articles in the order.
    /// </summary>
    public string ArticleTexts { get; set; }
}