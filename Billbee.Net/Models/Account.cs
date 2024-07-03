namespace Billbee.Net.Models;

/// <summary>
///     Account information for creation of a new account.
/// </summary>
public class Account
{
    /// <summary>
    ///     Gets or sets the Email address of the user to create.
    /// </summary>
    public string EMail { get; set; }

    /// <summary>
    ///     Gets or sets the password of the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the user has accepted the Billbee terms & conditions.
    /// </summary>
    public bool AcceptTerms { get; set; }

    /// <summary>
    ///     Gets or sets the invoice address of the Billbee user.
    /// </summary>
    public UserAddress Address { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the user is interested in the Billbee newsletter.
    /// </summary>
    public bool Newsletter { get; set; }

    /// <summary>
    ///     Gets or sets the Billbee affiliate code to attach to the user.
    /// </summary>
    public string AffiliateCouponCode { get; set; }

    /// <summary>
    ///     Gets or sets the normal VAT rate of the user.
    /// </summary>
    public decimal? Vat1Rate { get; set; }

    /// <summary>
    ///     Gets or sets the reduced VAT rate of the user.
    /// </summary>
    public decimal? Vat2Rate { get; set; }

    /// <summary>
    ///     Gets or sets the default VAT mode of the user.
    /// </summary>
    /// <remarks>0: Show VAT, 1: Kleinunternehmer</remarks>
    public VatModeEnum? DefaultVatMode { get; set; }

    /// <summary>
    ///     Gets or sets the default currency of the user.
    /// </summary>
    public string DefaultCurrency { get; set; }

    /// <summary>
    ///     Gets or sets the default VAT index of the user.
    /// </summary>
    /// <remarks>1: normal VAT, 2: reduced VAT</remarks>
    public byte? DefaultVatIndex { get; set; }

    /// <summary>
    ///     Returns a string representation of the account.
    /// </summary>
    /// <returns>A string that represents the current account.</returns>
    public override string ToString()
    {
        return $"EMail: {EMail}, Name: {Address?.Name}, Country: {Address?.Country}, Terms: {AcceptTerms}";
    }

    /// <summary>
    ///     Represents the invoice address of a Billbee user.
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        ///     Gets or sets the company name.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the first line of the address.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        ///     Gets or sets the second line of the address.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        ///     Gets or sets the ZIP code.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the ISO2 country code of the user's country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets the VAT ID.
        /// </summary>
        public string VatId { get; set; }
    }
}

/// <summary>
///     Enumeration for VAT modes.
/// </summary>
public enum VatModeEnum
{
    ShowVat = 0,
    Kleinunternehmer = 1
}