namespace Billbee.Net.Models;

/// <summary>
///     Represents a container for a language-specific translation.
/// </summary>
public class MultiLanguageString
{
    /// <summary>
    ///     Gets or sets the text representation in the specified language.
    /// </summary>
    /// <value>The translated text in the specified language.</value>
    public string Text { get; set; }

    /// <summary>
    ///     Gets or sets the ISO language code that specifies the language of the text in <see cref="Text" />.
    /// </summary>
    /// <value>The ISO 639-1 language code.</value>
    public string LanguageCode { get; set; }
}