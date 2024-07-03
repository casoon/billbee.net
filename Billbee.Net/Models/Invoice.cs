using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents shorthand information for an invoice, including the invoice as a PDF document.
/// </summary>
public class Invoice
{
    /// <summary>
    ///     Gets or sets the number of the corresponding order.
    /// </summary>
    /// <value>The order number associated with this invoice.</value>
    public string OrderNumber { get; set; }

    /// <summary>
    ///     Gets or sets the number that is printed as the invoice number on the invoice.
    /// </summary>
    /// <value>The invoice number.</value>
    public string InvoiceNumber { get; set; }

    /// <summary>
    ///     Gets or sets the PDF representation of the invoice, if it was requested.
    /// </summary>
    /// <value>A byte array containing the PDF data of the invoice.</value>
    public byte[] PDFData { get; set; }

    /// <summary>
    ///     Gets or sets the date of the invoice.
    /// </summary>
    /// <value>The date when the invoice was issued.</value>
    public DateTime? InvoiceDate { get; set; }

    /// <summary>
    ///     Gets or sets the total gross value of this invoice.
    /// </summary>
    /// <value>The total gross amount of the invoice.</value>
    public decimal TotalGross { get; set; }

    /// <summary>
    ///     Gets or sets the total net value of this invoice.
    /// </summary>
    /// <value>The total net amount of the invoice.</value>
    public decimal TotalNet { get; set; }

    /// <summary>
    ///     Gets or sets the URL from which the PDF file can be downloaded if it was not attached as a byte array.
    /// </summary>
    /// <value>The URL to download the PDF representation of the invoice.</value>
    public string PdfDownloadUrl { get; set; }
}