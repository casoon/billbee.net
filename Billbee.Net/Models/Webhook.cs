using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Represents a webhook configuration with various properties.
/// </summary>
public class Webhook
{
    /// <summary>
    ///     Gets or sets the unique identifier of the webhook.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     Gets or sets the URI to which the webhook sends requests.
    /// </summary>
    public string WebHookUri { get; set; }

    /// <summary>
    ///     Gets or sets the secret used to secure the webhook.
    /// </summary>
    public string Secret { get; set; }

    /// <summary>
    ///     Gets or sets the description of the webhook.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the webhook is paused.
    /// </summary>
    public bool IsPaused { get; set; }

    /// <summary>
    ///     Gets or sets the list of filters applied to the webhook.
    /// </summary>
    public List<string> Filters { get; set; }

    /// <summary>
    ///     Gets or sets the headers included in the webhook requests.
    /// </summary>
    public Dictionary<string, string> Headers { get; set; }

    /// <summary>
    ///     Gets or sets additional properties of the webhook.
    /// </summary>
    public Dictionary<string, object> Properties { get; set; }
}