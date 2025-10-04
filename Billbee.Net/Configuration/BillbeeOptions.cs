using System.ComponentModel.DataAnnotations;

namespace Billbee.Net.Configuration;

/// <summary>
/// Configuration options for the Billbee API client
/// </summary>
public class BillbeeOptions
{
    /// <summary>
    /// Configuration section name
    /// </summary>
    public const string SectionName = "Billbee";

    /// <summary>
    /// The base URL for the Billbee API
    /// </summary>
    [Required]
    [Url]
    public string Url { get; set; } = "https://app.billbee.io/api/v1";

    /// <summary>
    /// The API key for authentication
    /// </summary>
    [Required]
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// The username for authentication
    /// </summary>
    [Required]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The password for authentication
    /// </summary>
    [Required]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Whether to enable HTTP request/response logging
    /// </summary>
    public bool Logging { get; set; } = false;

    /// <summary>
    /// HTTP request timeout in seconds
    /// </summary>
    [Range(1, 300)]
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Maximum number of retry attempts
    /// </summary>
    [Range(0, 10)]
    public int MaxRetryAttempts { get; set; } = 3;

    /// <summary>
    /// Circuit breaker exception count threshold
    /// </summary>
    [Range(1, 100)]
    public int CircuitBreakerExceptionCount { get; set; } = 10;

    /// <summary>
    /// Circuit breaker duration in seconds
    /// </summary>
    [Range(1, 600)]
    public double CircuitBreakerDurationSeconds { get; set; } = 100;

    /// <summary>
    /// Validates the configuration
    /// </summary>
    /// <returns>True if valid, false otherwise</returns>
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Url) &&
               !string.IsNullOrWhiteSpace(ApiKey) &&
               !string.IsNullOrWhiteSpace(Username) &&
               !string.IsNullOrWhiteSpace(Password);
    }
}