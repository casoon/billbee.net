namespace Billbee.Net.Models;

/// <summary>
///     Represents information about a product image in an order.
/// </summary>
public class OrderProductImage
{
    /// <summary>
    ///     Gets or sets the URL where this image is located.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this image should be used as the default image.
    /// </summary>
    public bool IsDefaultImage { get; set; }

    /// <summary>
    ///     Gets or sets the position of the image if more than one image is supplied, defining the order.
    /// </summary>
    public byte? Position { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the image in the external system from which the corresponding order was received.
    /// </summary>
    public string ExternalId { get; set; }
}