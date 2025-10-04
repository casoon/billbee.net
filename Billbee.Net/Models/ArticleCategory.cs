namespace Billbee.Net.Models
{
    /// <summary>
    ///     Information about a category of an article
    /// </summary>
    public class ArticleCategory
    {
        /// <summary>
        ///     The name of the category
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     The internal id of the category
        /// </summary>
        public long? Id { get; set; }
    }
}