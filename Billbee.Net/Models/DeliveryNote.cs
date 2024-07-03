using System;

namespace Billbee.Net.Models;

/// <summary>
///     Contains information of a delivery note.
/// </summary>
public class DeliveryNote
{
    /// <summary>
    ///     Gets or sets the user-specific number of the order associated with this delivery note.
    /// </summary>
    public string OrderNumber { get; set; }

    /// <summary>
    ///     Gets or sets the number of this delivery note.
    /// </summary>
    public string DeliveryNoteNumber { get; set; }

    /// <summary>
    ///     Gets or sets the delivery note as a PDF file, if requested.
    /// </summary>
    public byte[] PDFData { get; set; }

    /// <summary>
    ///     Gets or sets the date on which the delivery note was issued.
    /// </summary>
    public DateTime? DeliveryNoteDate { get; set; }

    /// <summary>
    ///     Gets or sets the URL to download the delivery note if it is not contained within <see cref="PDFData" />.
    /// </summary>
    public string PdfDownloadUrl { get; set; }
}