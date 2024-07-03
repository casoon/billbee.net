using System;

namespace Billbee.Net.Models;

/// <summary>
///     Represents the result of a create user request.
/// </summary>
public class CreateUserResult
{
    /// <summary>
    ///     Gets or sets the password that was assigned to the user.
    ///     Note: This password cannot be recovered afterwards.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    ///     Gets or sets the internal ID assigned to this user.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets the URL that allows the user a one-time login without a password.
    /// </summary>
    public string OneTimeLoginUrl { get; set; }
}