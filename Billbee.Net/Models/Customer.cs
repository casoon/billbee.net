namespace Billbee.Net.Models;

/// <summary>
///     Represents a customer with various details.
/// </summary>
public class Customer
{
    /// <summary>
    ///     Gets or sets the unique identifier for the customer.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the customer.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the email address of the customer.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets the primary telephone number of the customer.
    /// </summary>
    public string Tel1 { get; set; }

    /// <summary>
    ///     Gets or sets the secondary telephone number of the customer.
    /// </summary>
    public string Tel2 { get; set; }

    /// <summary>
    ///     Gets or sets the customer number.
    /// </summary>
    public int? Number { get; set; }

    /// <summary>
    ///     Gets or sets the price group identifier for the customer.
    /// </summary>
    public long? PriceGroupId { get; set; }

    /// <summary>
    ///     Gets or sets the language identifier for the customer.
    /// </summary>
    public int? LanguageId { get; set; }

    /// <summary>
    ///     Gets or sets the VAT identifier for the customer.
    /// </summary>
    public string VatId { get; set; }

    /// <summary>
    ///     Gets or sets the type of the customer.
    ///     0 = Endcustomer, 1 = Businesscustomer.
    /// </summary>
    public byte? Type { get; set; }
}