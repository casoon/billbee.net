namespace Billbee.Net.Models;

/// <summary>
///     Represents a user associated with an order in Billbee.
/// </summary>
public class OrderUser
{
    /// <summary>
    ///     Gets or sets the platform associated with the user.
    /// </summary>
    public string Platform { get; set; }

    /// <summary>
    ///     Gets or sets the Billbee shop name associated with the user.
    /// </summary>
    public string BillbeeShopName { get; set; }

    /// <summary>
    ///     Gets or sets the Billbee shop ID associated with the user.
    /// </summary>
    public long? BillbeeShopId { get; set; }

    /// <summary>
    ///     Gets or sets the user's ID.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     Gets or sets the user's nickname.
    /// </summary>
    public string Nick { get; set; }

    /// <summary>
    ///     Gets or sets the user's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the user's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///     Gets the user's full name, which is a combination of the first name and last name.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    /// <summary>
    ///     Gets or sets the user's email address.
    /// </summary>
    public string Email { get; set; }
}