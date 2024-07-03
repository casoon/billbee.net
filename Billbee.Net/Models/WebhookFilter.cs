namespace Billbee.Net.Models;

/// <summary>
///     Represents a filter for a webhook, containing a name and a description.
/// </summary>
public class WebhookFilter
{
    /// <summary>
    ///     Gets or sets the name of the webhook filter.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the description of the webhook filter.
    /// </summary>
    public string Description { get; set; }
}