namespace Billbee.Net.Models;

/// <summary>
///     Defines the types of custom fields available for an article.
/// </summary>
public enum ApiArticleCustomFieldType
{
    /// <summary>
    ///     A text field.
    /// </summary>
    TextField,

    /// <summary>
    ///     A textarea.
    /// </summary>
    Textarea,

    /// <summary>
    ///     A number input field.
    /// </summary>
    NumberInput,

    /// <summary>
    ///     A select input field.
    /// </summary>
    SelectInput
}

/// <summary>
///     Represents the definition of a custom field for an article.
/// </summary>
public class ArticleCustomFieldDefinition
{
    /// <summary>
    ///     Gets or sets the configuration for the custom field.
    /// </summary>
    public object Configuration { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of the custom field definition.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the custom field is nullable.
    /// </summary>
    public bool IsNullable { get; set; }

    /// <summary>
    ///     Gets or sets the name of the custom field.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the type of the custom field.
    /// </summary>
    public ApiArticleCustomFieldType? Type { get; set; }
}