using System.Collections.Generic;

namespace Billbee.Net.Models;

/// <summary>
///     Represents an item within an order.
/// </summary>
public class OrderItem
{
    /// <summary>
    ///     Gets or sets the ID of the individual transaction.
    ///     Only required by eBay to detect aggregated orders.
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    ///     Gets or sets the product associated with this order item.
    /// </summary>
    public OrderItemProduct Product { get; set; }

    /// <summary>
    ///     Gets or sets the quantity of the product ordered.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    ///     Gets or sets the total price of the order item.
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <summary>
    ///     Gets or sets the tax amount for the order item.
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    ///     Gets or sets the tax index for the order item.
    /// </summary>
    public byte? TaxIndex { get; set; }

    /// <summary>
    ///     Gets or sets the discount in percent.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    ///     Gets or sets the list of attributes associated with the order item.
    /// </summary>
    public List<OrderItemAttribute> Attributes { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to get the price from the article if available.
    /// </summary>
    public bool GetPriceFromArticleIfAny { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this position is a coupon, interpreted as a tax-free payment.
    /// </summary>
    public bool IsCoupon { get; set; }

    /// <summary>
    ///     Gets or sets the shipping profile ID.
    /// </summary>
    public string ShippingProfileId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the import of this order won't adjust the stock level at Billbee.
    /// </summary>
    /// <remarks>This is used for Amazon refunds.</remarks>
    public bool DontAdjustStock { get; set; }

    /// <summary>
    ///     Gets or sets the internal Billbee ID of the order item.
    /// </summary>
    public long? BillbeeId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the item is a discount.
    /// </summary>
    public bool IsDiscount { get; set; }

    /// <summary>
    ///     Gets or sets the unrebated total price of the order item.
    /// </summary>
    /// <remarks>Is just used for the Billbee API.</remarks>
    public decimal UnrebatedTotalPrice { get; set; }

    /// <summary>
    ///     Gets or sets the serial number used for the order item.
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    ///     Returns a string that represents the current order item.
    /// </summary>
    /// <returns>A string that represents the current order item.</returns>
    public override string ToString()
    {
        return $"Q:{Quantity} TP:{TotalPrice} Tax:{TaxIndex} Discount:{Discount}";
    }
}