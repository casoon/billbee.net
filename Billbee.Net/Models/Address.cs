#nullable enable
namespace Billbee.Net.Models;

/// <summary>
///     Basic address for usage in orders.
/// </summary>
public class Address
{
    /// <summary>
    ///     Gets or sets the internal id of this address.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the customer id associated with this address.
    /// </summary>
    public long CustomerId { get; set; }

    /// <summary>
    ///     Gets or sets the city of the address.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    ///     Gets or sets the street of the address.
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    ///     Gets or sets the company name associated with the address.
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    ///     Gets or sets the second line of the address.
    /// </summary>
    public string? Line2 { get; set; }

    /// <summary>
    ///     Gets or sets the third line of the address.
    /// </summary>
    public string? Line3 { get; set; }

    /// <summary>
    ///     Gets or sets the ZIP code of the address.
    /// </summary>
    public string? Zip { get; set; }

    /// <summary>
    ///     Gets or sets the state of the address.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    ///     Gets or sets the name of the country.
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    ///     Gets or sets the country code.
    /// </summary>
    public string? CountryCode { get; set; }

    /// <summary>
    ///     Gets or sets the ISO 2 code of the country.
    /// </summary>
    public string? CountryISO2 { get; set; }

    /// <summary>
    ///     Gets or sets the first name of the addressee.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name of the addressee.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    ///     Gets or sets the phone number of the addressee, used for notification purposes.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    ///     Gets or sets the email address of the addressee, used for notification purposes.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     Gets or sets the house number of the address.
    /// </summary>
    public string? HouseNumber { get; set; }

    /// <summary>
    ///     Gets or sets a comment about the address for better differentiation.
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    ///     Gets or sets the name addition.
    /// </summary>
    public string? NameAddition { get; set; }

    /// <summary>
    ///     Gets or sets the first telephone number.
    /// </summary>
    public string? Tel1 { get; set; }

    /// <summary>
    ///     Gets or sets the second telephone number.
    /// </summary>
    public string? Tel2 { get; set; }

    /// <summary>
    ///     Gets or sets the fax number.
    /// </summary>
    public string? Fax { get; set; }

    /// <summary>
    ///     Gets or sets the address addition.
    /// </summary>
    public string? AddressAddition { get; set; }
}