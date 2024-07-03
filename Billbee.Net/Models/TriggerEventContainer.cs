namespace Billbee.Net.Models;

/// <summary>
///     Represents a container for trigger events, including the event name and a delay for execution.
/// </summary>
public class TriggerEventContainer
{
    /// <summary>
    ///     Gets or sets the name of the event.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the delay in minutes until the rule is executed.
    ///     Default value is 0, meaning the rule is executed immediately.
    /// </summary>
    public uint DelayInMinutes { get; set; } = 0;
}