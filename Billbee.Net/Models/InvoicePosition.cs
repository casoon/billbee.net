namespace Billbee.Net.Models;

/// <summary>
///     Represents detailed information about a position in an invoice.
/// </summary>
public class InvoicePosition
{
    /// <summary>
    ///     Gets or sets the rank of this position in the order.
    /// </summary>
    /// <value>The rank or sequence of this position within the order.</value>
    public int Position { get; set; }

    /// <summary>
    ///     Gets or sets the quantity of the given article in this position.
    /// </summary>
    /// <value>The quantity of items for this position.</value>
    public decimal Amount { get; set; }

    /// <summary>
    ///     Gets or sets the net value of a single article.
    /// </summary>
    /// <value>The net price of a single item in this position.</value>
    public decimal NetValue { get; set; }

    /// <summary>
    ///     Gets or sets the net value of all articles in this position.
    /// </summary>
    /// <value>The total net price for all items in this position.</value>
    public decimal TotalNetValue { get; set; }

    /// <summary>
    ///     Gets or sets the gross value of a single article.
    /// </summary>
    /// <value>The gross price of a single item in this position.</value>
    public decimal GrossValue { get; set; }

    /// <summary>
    ///     Gets or sets the gross value of all articles in this position.
    /// </summary>
    /// <value>The total gross price for all items in this position.</value>
    public decimal TotalGrossValue { get; set; }

    /// <summary>
    ///     Gets or sets the VAT rate used for this position.
    /// </summary>
    /// <value>The VAT rate as a percentage.</value>
    public decimal? VatRate { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of the referenced article.
    /// </summary>
    /// <value>The internal identifier of the article.</value>
    public long? ArticleBillbeeId { get; set; }

    /// <summary>
    ///     Gets or sets the SKU of the article in this position.
    /// </summary>
    /// <value>The stock keeping unit identifier for the article.</value>
    public string Sku { get; set; }

    /// <summary>
    ///     Gets or sets the title to be shown on the invoice for this position.
    /// </summary>
    /// <value>The title or description of the item for display on the invoice.</value>
    public string Title { get; set; }

    /// <summary>
    ///     Gets or sets the unique internal ID of this position.
    /// </summary>
    /// <value>The unique identifier for this position within the invoice.</value>
    public long BillbeeId { get; set; }
}