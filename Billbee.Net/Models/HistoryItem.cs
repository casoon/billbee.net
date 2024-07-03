using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents an item in the history log, capturing events and actions taken.
/// </summary>
public class HistoryItem
{
    /// <summary>
    ///     Gets or sets the date and time when the history item was created.
    /// </summary>
    /// <value>The creation timestamp of the history item.</value>
    public DateTime Created { get; set; }

    /// <summary>
    ///     Gets or sets the name of the event type associated with this history item.
    /// </summary>
    /// <value>The name describing the type of event.</value>
    public string EventTypeName { get; set; }

    /// <summary>
    ///     Gets or sets the descriptive text of the history item.
    /// </summary>
    /// <value>The detailed text describing the event.</value>
    public string Text { get; set; }

    /// <summary>
    ///     Gets or sets the name of the employee who performed the action recorded in this history item.
    /// </summary>
    /// <value>The name of the employee associated with the event.</value>
    public string EmployeeName { get; set; }

    /// <summary>
    ///     Gets or sets the type identifier of the event.
    /// </summary>
    /// <value>The numerical ID representing the type of event.</value>
    public int TypeId { get; set; }
}