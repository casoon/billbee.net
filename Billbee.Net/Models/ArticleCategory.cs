namespace Billbee.Net.Models;

/// <summary>
///     Represents information about a category of an article.
/// </summary>
public class ArticleCategory
{
    /// <summary>
    ///     Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID of the category.
    /// </summary>
    public long? Id { get; set; }
}