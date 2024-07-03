namespace Billbee.Net.Models;

/// <summary>
///     Represents the result containing links to terms and privacy web pages and HTML content.
/// </summary>
public class TermsResult
{
    /// <summary>
    ///     Gets or sets the link to the terms and conditions web page.
    /// </summary>
    public string LinkToTermsWebPage { get; set; }

    /// <summary>
    ///     Gets or sets the link to the privacy policy web page.
    /// </summary>
    public string LinkToPrivacyWebPage { get; set; }

    /// <summary>
    ///     Gets or sets the link to the HTML content of the terms and conditions.
    /// </summary>
    public string LinkToTermsHtmlContent { get; set; }

    /// <summary>
    ///     Gets or sets the link to the HTML content of the privacy policy.
    /// </summary>
    public string LinkToPrivacyHtmlContent { get; set; }
}