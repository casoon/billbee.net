using System;
using Billbee.Net.Enums;

namespace Billbee.Net.Models;

/// <summary>
///     Represents a payment transaction in Billbee.
/// </summary>
public class Payment
{
    /// <summary>
    ///     Gets or sets the internal ID of Billbee.
    /// </summary>
    public long? BillbeeId { get; set; }

    /// <summary>
    ///     Gets or sets the transaction ID.
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    ///     Gets or sets the date and time of the payment.
    /// </summary>
    public DateTime PayDate { get; set; }

    /// <summary>
    ///     Gets or sets the type of payment.
    /// </summary>
    public PaymentTypeEnum? PaymentType { get; set; }

    /// <summary>
    ///     Gets or sets the source technology of the payment.
    /// </summary>
    public string SourceTechnology { get; set; }

    /// <summary>
    ///     Gets or sets the source text of the payment.
    /// </summary>
    public string SourceText { get; set; }

    /// <summary>
    ///     Gets or sets the value of the payment.
    /// </summary>
    public decimal PayValue { get; set; }

    /// <summary>
    ///     Gets or sets the purpose of the payment.
    /// </summary>
    public string Purpose { get; set; }

    /// <summary>
    ///     Gets or sets the name associated with the payment.
    /// </summary>
    public string Name { get; set; }
}