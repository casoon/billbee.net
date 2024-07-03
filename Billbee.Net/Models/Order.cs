using System;
using System.Collections.Generic;
using Billbee.Net.Enums;

namespace Billbee.Net.Models;

/// <summary>
///     Represents an order in Billbee.
/// </summary>
public class Order
{
    /// <summary>
    ///     Gets or sets the list of shipping IDs that reference the shippings made for this order.
    /// </summary>
    public List<OrderShippingId> ShippingIds { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the customer has accepted the loss of the right to return.
    /// </summary>
    public bool AcceptLossOfReturnRight { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the order in the external system (marketplace).
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     Gets or sets the order number of the order in the external system (marketplace).
    ///     This is often the same as the ID.
    /// </summary>
    public string OrderNumber { get; set; }

    /// <summary>
    ///     Gets or sets the state the order is currently in.
    /// </summary>
    public OrderStateEnum State { get; set; }

    /// <summary>
    ///     Gets or sets the VAT mode this order was created with.
    /// </summary>
    public VatModeEnum? VatMode { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp when this order was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp when this order was shipped.
    /// </summary>
    public DateTime? ShippedAt { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp when this order was confirmed and accepted.
    /// </summary>
    public DateTime? ConfirmedAt { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp when this order was paid.
    /// </summary>
    public DateTime? PaidAt { get; set; }

    /// <summary>
    ///     Gets or sets the internal comment to this order.
    /// </summary>
    public string SellerComment { get; set; }

    /// <summary>
    ///     Gets or sets the comments and messages between customer and shop owner.
    /// </summary>
    public List<Comment> Comments { get; set; }

    /// <summary>
    ///     Gets or sets the prefix used to create the invoice number.
    /// </summary>
    public string InvoiceNumberPrefix { get; set; }

    /// <summary>
    ///     Gets or sets the postfix used to create the invoice number.
    /// </summary>
    public string InvoiceNumberPostfix { get; set; }

    /// <summary>
    ///     Gets or sets the auto-generated number to build the invoice number.
    /// </summary>
    public int? InvoiceNumber { get; set; }

    /// <summary>
    ///     Gets or sets the date of the invoice.
    /// </summary>
    public DateTime? InvoiceDate { get; set; }

    /// <summary>
    ///     Gets or sets the addressee of the invoice.
    /// </summary>
    public Address InvoiceAddress { get; set; }

    /// <summary>
    ///     Gets or sets the addressee where the order was/is shipped to.
    /// </summary>
    public Address ShippingAddress { get; set; }

    /// <summary>
    ///     Gets or sets the payment method used to pay for this order.
    /// </summary>
    public PaymentTypeEnum PaymentMethod { get; set; }

    /// <summary>
    ///     Gets or sets the cost defined for shipping in this order.
    /// </summary>
    public decimal ShippingCost { get; set; }

    /// <summary>
    ///     Gets or sets the total gross value of the order.
    /// </summary>
    public decimal TotalCost { get; set; }

    /// <summary>
    ///     Gets or sets the list of items purchased in the order.
    /// </summary>
    public List<OrderItem> OrderItems { get; set; }

    /// <summary>
    ///     Gets or sets the currency of the order.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the order is canceled.
    /// </summary>
    public bool IsCanceled { get; set; }

    /// <summary>
    ///     Gets or sets the RESTful path for the order.
    /// </summary>
    public string RestfulPath { get; set; }

    /// <summary>
    ///     Gets or sets the seller information.
    /// </summary>
    public OrderUser Seller { get; set; }

    /// <summary>
    ///     Gets or sets the buyer information.
    /// </summary>
    public OrderUser Buyer { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp when this order was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    ///     Gets or sets the first tax rate.
    /// </summary>
    public decimal? TaxRate1 { get; set; }

    /// <summary>
    ///     Gets or sets the second tax rate.
    /// </summary>
    public decimal? TaxRate2 { get; set; }

    /// <summary>
    ///     Gets or sets the Order ID from the Billbee database, if available in the external system.
    /// </summary>
    public long BillBeeOrderId { get; set; }

    /// <summary>
    ///     Gets or sets the parent order ID from the Billbee database.
    /// </summary>
    public long? BillBeeParentOrderId { get; set; }

    /// <summary>
    ///     Gets or sets the VAT ID.
    /// </summary>
    public string VatId { get; set; }

    /// <summary>
    ///     Gets or sets the list of individual tags appended to this order.
    /// </summary>
    public List<string> Tags { get; set; }

    /// <summary>
    ///     Gets or sets the shipping weight in kilograms.
    /// </summary>
    public decimal? ShipWeightKg { get; set; }

    /// <summary>
    ///     Gets or sets the code of the language this order was created in.
    /// </summary>
    public string LanguageCode { get; set; }

    /// <summary>
    ///     Gets or sets the total amount paid by the customer for this order.
    /// </summary>
    public decimal? PaidAmount { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID for the shipping profile for this order.
    /// </summary>
    public string ShippingProfileId { get; set; }

    /// <summary>
    ///     Gets or sets the display name of the shipping profile, if available.
    /// </summary>
    public string ShippingProfileName { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID for the used shipping provider.
    /// </summary>
    public long? ShippingProviderId { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID for the used shipping product.
    /// </summary>
    public long? ShippingProviderProductId { get; set; }

    /// <summary>
    ///     Gets or sets the name of the used shipping provider.
    /// </summary>
    public string ShippingProviderName { get; set; }

    /// <summary>
    ///     Gets or sets the name of the used shipping product.
    /// </summary>
    public string ShippingProviderProductName { get; set; }

    /// <summary>
    ///     Gets or sets the payment instruction text for printout on the invoice, if available.
    /// </summary>
    public string PaymentInstruction { get; set; }

    /// <summary>
    ///     Gets or sets an optional order ID for an order if this is a cancel order (Shopify only at the moment).
    /// </summary>
    public string IsCancelationFor { get; set; }

    /// <summary>
    ///     Gets or sets the payment transaction ID.
    /// </summary>
    public string PaymentTransactionId { get; set; }

    /// <summary>
    ///     Gets or sets the optional country ISO2 code of the country where the order is shipped from (FBA).
    /// </summary>
    public string DeliverySourceCountryCode { get; set; }

    /// <summary>
    ///     Gets or sets the optional multiline text printed on the invoice.
    /// </summary>
    public string CustomInvoiceNote { get; set; }

    /// <summary>
    ///     Gets or sets the customer number.
    /// </summary>
    public string CustomerNumber { get; set; }

    /// <summary>
    ///     Gets or sets the customer information.
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    ///     Gets or sets the timestamp when this order was last modified.
    /// </summary>
    public DateTime LastModifiedAt { get; set; }

    /// <summary>
    ///     Gets or sets the API account name.
    /// </summary>
    public string ApiAccountName { get; set; }

    /// <summary>
    ///     Gets or sets the API account ID.
    /// </summary>
    public long? ApiAccountId { get; set; }

    /// <summary>
    ///     Gets or sets the merchant's VAT ID.
    /// </summary>
    public string MerchantVatId { get; set; }

    /// <summary>
    ///     Gets or sets the customer's VAT ID.
    /// </summary>
    public string CustomerVatId { get; set; }

    /// <summary>
    ///     Gets or sets the payment reference.
    /// </summary>
    public string PaymentReference { get; set; }

    /// <summary>
    ///     Gets or sets the distribution center.
    /// </summary>
    public string DistributionCenter { get; set; }

    /// <summary>
    ///     Gets or sets the adjustment cost.
    /// </summary>
    public decimal AdjustmentCost { get; set; }

    /// <summary>
    ///     Gets or sets the reason for the adjustment.
    /// </summary>
    public string AdjustmentReason { get; set; }

    /// <summary>
    ///     Gets or sets the rebate difference.
    /// </summary>
    public decimal RebateDifference { get; set; }
}