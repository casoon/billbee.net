namespace Billbee.Net.Models
{
    /// <summary>
    /// Represents image information for an article image.
    /// </summary>
    public class ArticleImage
    {
        /// <summary>
        /// Gets or sets the URL where this image is located.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the ID of this image.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the path of the external thumbnail, which will be ignored if posting to Billbee.
        /// </summary>
        public string ThumbPathExt { get; set; }

        /// <summary>
        /// Gets or sets the URL of the thumbnail, which will be ignored if posting to Billbee.
        /// </summary>
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Gets or sets the position of the image when more than one image is given, defining the order.
        /// </summary>
        public byte? Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is the default image.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the ID of the article to which this image belongs.
        /// </summary>
        public long ArticleId { get; set; }
    }
}