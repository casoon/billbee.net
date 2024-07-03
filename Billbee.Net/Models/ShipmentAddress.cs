namespace Billbee.Net.Models;

/// <summary>
///     Represents the address information for a shipment.
/// </summary>
public class ShipmentAddress
{
    /// <summary>
    ///     Gets or sets the company name.
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    ///     Gets or sets the first name of the recipient.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name of the recipient.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///     Gets or sets an additional name or department.
    /// </summary>
    public string Name2 { get; set; }

    /// <summary>
    ///     Gets or sets the street name.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    ///     Gets or sets the house number.
    /// </summary>
    public string HouseNumber { get; set; }

    /// <summary>
    ///     Gets or sets the postal code.
    /// </summary>
    public string Zip { get; set; }

    /// <summary>
    ///     Gets or sets the city name.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///     Gets or sets the ISO 2 code of the country.
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    ///     Gets or sets the ISO 3 code of the country.
    /// </summary>
    public string CountryCodeISO3 { get; set; }

    /// <summary>
    ///     Gets or sets the email address of the recipient.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets the telephone number of the recipient.
    /// </summary>
    public string Telephone { get; set; }

    /// <summary>
    ///     Gets or sets any additional address information.
    /// </summary>
    public string AddressAddition { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the address is in an export country.
    /// </summary>
    public bool IsExportCountry { get; set; }

    /// <summary>
    ///     Gets or sets the state or province.
    /// </summary>
    public string State { get; set; }
}