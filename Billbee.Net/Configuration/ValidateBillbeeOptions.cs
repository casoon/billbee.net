using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Billbee.Net.Configuration;

/// <summary>
/// Validates BillbeeOptions configuration
/// </summary>
public class ValidateBillbeeOptions : IValidateOptions<BillbeeOptions>
{
    /// <summary>
    /// Validates the options
    /// </summary>
    /// <param name="name">The name of the options instance</param>
    /// <param name="options">The options instance to validate</param>
    /// <returns>Validation result</returns>
    public ValidateOptionsResult Validate(string? name, BillbeeOptions options)
    {
        if (options == null)
        {
            return ValidateOptionsResult.Fail("BillbeeOptions cannot be null");
        }

        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.Url))
        {
            failures.Add("Url is required");
        }
        else if (!Uri.TryCreate(options.Url, UriKind.Absolute, out var uri) || 
                 (uri.Scheme != "http" && uri.Scheme != "https"))
        {
            failures.Add("Url must be a valid HTTP or HTTPS URL");
        }

        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            failures.Add("ApiKey is required");
        }

        if (string.IsNullOrWhiteSpace(options.Username))
        {
            failures.Add("Username is required");
        }

        if (string.IsNullOrWhiteSpace(options.Password))
        {
            failures.Add("Password is required");
        }

        if (options.TimeoutSeconds < 1 || options.TimeoutSeconds > 300)
        {
            failures.Add("TimeoutSeconds must be between 1 and 300");
        }

        if (options.MaxRetryAttempts < 0 || options.MaxRetryAttempts > 10)
        {
            failures.Add("MaxRetryAttempts must be between 0 and 10");
        }

        if (options.CircuitBreakerExceptionCount < 1 || options.CircuitBreakerExceptionCount > 100)
        {
            failures.Add("CircuitBreakerExceptionCount must be between 1 and 100");
        }

        if (options.CircuitBreakerDurationSeconds < 1 || options.CircuitBreakerDurationSeconds > 600)
        {
            failures.Add("CircuitBreakerDurationSeconds must be between 1 and 600");
        }

        return failures.Count > 0 
            ? ValidateOptionsResult.Fail(failures) 
            : ValidateOptionsResult.Success;
    }
}