namespace Billbee.Net.Models;

/// <summary>
///     Represents an attribute of an order item.
/// </summary>
public class OrderItemAttribute
{
    /// <summary>
    ///     Gets or sets the ID of the attribute.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the attribute.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the value of the attribute.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    ///     Gets or sets the price associated with the attribute.
    /// </summary>
    public decimal Price { get; set; }
}