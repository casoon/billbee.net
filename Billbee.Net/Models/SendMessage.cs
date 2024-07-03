using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Specifies the mode of sending a confirmation message.
/// </summary>
public enum ConfirmationMessageSendMode
{
    /// <summary>
    ///     No message is sent.
    /// </summary>
    None = 0,

    /// <summary>
    ///     Send the message via email.
    /// </summary>
    Email = 1,

    /// <summary>
    ///     Send the message via API.
    /// </summary>
    Api = 2,

    /// <summary>
    ///     Send the message via email first, then via API if the email fails.
    /// </summary>
    EmailThenApi = 3,

    /// <summary>
    ///     Send the message via an external email service.
    /// </summary>
    ExternalEmail = 4
}

/// <summary>
///     Container to store information for a message that can be sent via an order.
/// </summary>
public class SendMessage
{
    /// <summary>
    ///     Gets or sets an alternative recipient email address.
    /// </summary>
    public string AlternativeMail { get; set; } = null;

    /// <summary>
    ///     Gets or sets the body of the message.
    /// </summary>
    public List<MultiLanguageString> Body { get; set; } = new();

    /// <summary>
    ///     Gets or sets the mode of sending the message.
    /// </summary>
    public ConfirmationMessageSendMode SendMode { get; set; } = ConfirmationMessageSendMode.EmailThenApi;

    /// <summary>
    ///     Gets or sets the subject of the message.
    /// </summary>
    public List<MultiLanguageString> Subject { get; set; } = new();
}