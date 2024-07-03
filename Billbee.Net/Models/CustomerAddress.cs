namespace Billbee.Net.Models;

/// <summary>
///     Represents a customer address with various details.
/// </summary>
public class CustomerAddress
{
    /// <summary>
    ///     Gets or sets the unique identifier for the customer address.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    ///     Gets or sets the type of address.
    ///     1 = Invoice address, 2 = Shipping address.
    /// </summary>
    public int AddressType { get; set; }

    /// <summary>
    ///     Gets or sets the identifier of the customer associated with this address.
    /// </summary>
    public long? CustomerId { get; set; }

    /// <summary>
    ///     Gets or sets the company name associated with the address.
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    ///     Gets or sets the first name of the person associated with the address.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name of the person associated with the address.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///     Gets or sets the secondary name associated with the address.
    /// </summary>
    public string Name2 { get; set; }

    /// <summary>
    ///     Gets or sets the street name of the address.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    ///     Gets or sets the house number of the address.
    /// </summary>
    public string Housenumber { get; set; }

    /// <summary>
    ///     Gets or sets the ZIP code of the address.
    /// </summary>
    public string Zip { get; set; }

    /// <summary>
    ///     Gets or sets the city of the address.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///     Gets or sets the state of the address.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    ///     Gets or sets the country code of the address.
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    ///     Gets or sets the email address associated with the address.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets the primary telephone number associated with the address.
    /// </summary>
    public string Tel1 { get; set; }

    /// <summary>
    ///     Gets or sets the secondary telephone number associated with the address.
    /// </summary>
    public string Tel2 { get; set; }

    /// <summary>
    ///     Gets or sets the fax number associated with the address.
    /// </summary>
    public string Fax { get; set; }

    /// <summary>
    ///     Gets the full address as a single string.
    /// </summary>
    public string FullAddr => $"{Street} {Housenumber}, {Zip} {City}, {State}, {CountryCode}";

    /// <summary>
    ///     Gets or sets additional information for the address.
    /// </summary>
    public string AddressAddition { get; set; }
}