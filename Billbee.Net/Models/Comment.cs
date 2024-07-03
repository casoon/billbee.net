using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents a comment associated with an order.
/// </summary>
public class Comment
{
    /// <summary>
    ///     Gets or sets a value indicating whether the comment was sent by the customer.
    ///     If true, this comment was sent from the customer; otherwise, it was sent by the shop owner.
    /// </summary>
    public bool FromCustomer { get; set; }

    /// <summary>
    ///     Gets or sets the content of the comment.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///     Gets or sets the name of the sender.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the date and time when this comment was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of this comment.
    /// </summary>
    public long Id { get; set; }
}