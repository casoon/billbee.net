using System.Collections.Generic;

namespace Billbee.Net.Models
{
    public enum ConfirmationMessageSendMode
    {
        None = 0,
        Email = 1,
        Api = 2,
        EmailThenApi = 3,
        ExternalEmail = 4
    }

    /// <summary>
    ///     Container to store information for a message, that can be send via an order.
    /// </summary>
    public class SendMessage
    {
        /// <summary>
        ///     An alternative recipient email address
        /// </summary>
        public string AlternativeMail = null;

        /// <summary>
        ///     The body of the message
        /// </summary>
        public List<MultiLanguageString> Body = new List<MultiLanguageString>();

        /// <summary>
        ///     Defines, how the message is send
        /// </summary>
        public ConfirmationMessageSendMode SendMode = ConfirmationMessageSendMode.EmailThenApi;

        /// <summary>
        ///     The Subject of the message
        /// </summary>
        public List<MultiLanguageString> Subject = new List<MultiLanguageString>();
    }
}