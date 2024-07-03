using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents an event with various details such as timestamp, type, and associated entities.
/// </summary>
public class Event
{
    /// <summary>
    ///     Gets or sets the timestamp when the event was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    ///     Gets or sets the identifier of the event type.
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    ///     Gets or sets the readable text representation of the event type.
    /// </summary>
    public string TypeText { get; set; }

    /// <summary>
    ///     Gets or sets the internal identifier of this event.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the internal identifier of the employee who initiated this event, if applicable.
    /// </summary>
    public string EmployeeId { get; set; }

    /// <summary>
    ///     Gets or sets the name of the employee who initiated this event, if applicable.
    /// </summary>
    public string EmployeeName { get; set; }

    /// <summary>
    ///     Gets or sets the internal identifier of the order this event is based on, if applicable.
    /// </summary>
    public long? OrderId { get; set; }
}