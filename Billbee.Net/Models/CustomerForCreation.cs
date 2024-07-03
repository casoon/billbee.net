namespace Billbee.Net.Models;

/// <summary>
///     Represents a customer for creation, including address details.
/// </summary>
public class CustomerForCreation : Customer
{
    /// <summary>
    ///     Gets or sets the address details for the customer.
    /// </summary>
    public CustomerAddress Address { get; set; }
}