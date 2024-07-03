namespace Billbee.Net.Models;

/// <summary>
///     Represents a custom field value for an article.
/// </summary>
public class ArticleCustomFieldValue
{
    /// <summary>
    ///     Gets or sets the ID of the article.
    /// </summary>
    public long? ArticleId { get; set; }

    /// <summary>
    ///     Gets or sets the definition of the custom field.
    /// </summary>
    public ArticleCustomFieldDefinition Definition { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the custom field definition.
    /// </summary>
    public long? DefinitionId { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the custom field value.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    ///     Gets or sets the value of the custom field.
    /// </summary>
    public object Value { get; set; }
}