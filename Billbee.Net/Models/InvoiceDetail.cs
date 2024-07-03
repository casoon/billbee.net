using System;
using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Represents detailed information for an invoice.
/// </summary>
public class InvoiceDetail
{
    /// <summary>
    ///     Gets or sets the number that is printed as the invoice number.
    /// </summary>
    /// <value>The invoice number.</value>
    public string InvoiceNumber { get; set; }

    /// <summary>
    ///     Gets or sets the type of document, whether it is an invoice or a credit note.
    /// </summary>
    /// <value>The type of document (invoice or credit note).</value>
    public string Type { get; set; }

    /// <summary>
    ///     Gets or sets the last name in the invoice address.
    /// </summary>
    /// <value>The last name of the customer.</value>
    public string LastName { get; set; }

    /// <summary>
    ///     Gets or sets the first name in the invoice address.
    /// </summary>
    /// <value>The first name of the customer.</value>
    public string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the company name in the invoice address.
    /// </summary>
    /// <value>The company name of the customer.</value>
    public string Company { get; set; }

    /// <summary>
    ///     Gets or sets the customer number of the addressed customer.
    /// </summary>
    /// <value>The customer number.</value>
    public int CustomerNumber { get; set; }

    /// <summary>
    ///     Gets or sets the debtor number of the customer, if applicable.
    /// </summary>
    /// <value>The debtor number of the customer.</value>
    public int DebtorNumber { get; set; }

    /// <summary>
    ///     Gets or sets the date of the invoice.
    /// </summary>
    /// <value>The date when the invoice was issued.</value>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    ///     Gets or sets the total net value of this invoice.
    /// </summary>
    /// <value>The total net amount of the invoice.</value>
    public decimal TotalNet { get; set; }

    /// <summary>
    ///     Gets or sets the currency definition of this invoice.
    /// </summary>
    /// <value>The currency in which the invoice is issued.</value>
    public string Currency { get; set; }

    /// <summary>
    ///     Gets or sets the total gross value of this invoice.
    /// </summary>
    /// <value>The total gross amount of the invoice.</value>
    public decimal TotalGross { get; set; }

    /// <summary>
    ///     Gets or sets the type ID of payment for the order.
    /// </summary>
    /// <value>The payment type ID.</value>
    public byte? PaymentTypeId { get; set; }

    /// <summary>
    ///     Gets or sets the number of the corresponding order.
    /// </summary>
    /// <value>The order number.</value>
    public string OrderNumber { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the payment transaction, if applicable.
    /// </summary>
    /// <value>The payment transaction ID.</value>
    public string TransactionId { get; set; }

    /// <summary>
    ///     Gets or sets the contact email address of the customer.
    /// </summary>
    /// <value>The customer's email address.</value>
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets the name of the shop from which the original order came.
    /// </summary>
    /// <value>The name of the shop.</value>
    public string ShopName { get; set; }

    /// <summary>
    ///     Gets or sets all positions that belong to this invoice.
    /// </summary>
    /// <value>A list of positions in the invoice.</value>
    public List<InvoicePosition> Positions { get; set; }

    /// <summary>
    ///     Gets or sets the date when the order was paid. If null, the order has not been paid yet.
    /// </summary>
    /// <value>The payment date.</value>
    public DateTime? PayDate { get; set; }

    /// <summary>
    ///     Gets or sets the VAT mode applicable for this invoice.
    /// </summary>
    /// <value>The VAT mode.</value>
    public VatModeEnum VatMode { get; set; }

    /// <summary>
    ///     Gets or sets the unique internal ID of this invoice.
    /// </summary>
    /// <value>The unique internal identifier for the invoice.</value>
    public long BillbeeId { get; set; }
}