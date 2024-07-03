namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of a customer search, containing basic customer details.
/// </summary>
public class CustomerSearchResult
{
    /// <summary>
    ///     Gets or sets the unique identifier for the customer.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the customer.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets a comma-separated list of addresses associated with the customer.
    /// </summary>
    public string Addresses { get; set; }

    /// <summary>
    ///     Gets or sets the customer number.
    /// </summary>
    public string Number { get; set; }
}