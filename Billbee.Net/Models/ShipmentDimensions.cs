namespace Billbee.Net.Models;

/// <summary>
///     Represents the dimensions of a package to be used for shipping an order.
/// </summary>
public class ShipmentDimensions
{
    /// <summary>
    ///     Gets or sets the length of the package in centimeters.
    /// </summary>
    public decimal Length { get; set; }

    /// <summary>
    ///     Gets or sets the width of the package in centimeters.
    /// </summary>
    public decimal Width { get; set; }

    /// <summary>
    ///     Gets or sets the height of the package in centimeters.
    /// </summary>
    public decimal Height { get; set; }
}