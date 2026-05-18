using Billbee.Net.Configuration;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Billbee.Net.Tests;

public class ValidateBillbeeOptionsTests
{
    private readonly ValidateBillbeeOptions _validator = new();

    [Fact]
    public void Validate_Should_Succeed_WithValidOptions()
    {
        var options = new BillbeeOptions
        {
            Url = "https://app.billbee.io/api/v1",
            ApiKey = "my-key",
            Username = "user",
            Password = "pass",
            TimeoutSeconds = 30,
            MaxRetryAttempts = 3,
            CircuitBreakerExceptionCount = 10,
            CircuitBreakerDurationSeconds = 100
        };

        var result = _validator.Validate(null, options);

        result.Should().Be(ValidateOptionsResult.Success);
    }

    [Fact]
    public void Validate_Should_Fail_WhenUrlIsEmpty()
    {
        var options = ValidOptions();
        options.Url = "";

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenUrlIsNotHttp()
    {
        var options = ValidOptions();
        options.Url = "ftp://example.com";

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenApiKeyIsEmpty()
    {
        var options = ValidOptions();
        options.ApiKey = "";

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenUsernameIsEmpty()
    {
        var options = ValidOptions();
        options.Username = "";

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenPasswordIsEmpty()
    {
        var options = ValidOptions();
        options.Password = "";

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenTimeoutSecondsTooLow()
    {
        var options = ValidOptions();
        options.TimeoutSeconds = 0;

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenTimeoutSecondsTooHigh()
    {
        var options = ValidOptions();
        options.TimeoutSeconds = 301;

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenMaxRetryAttemptsTooHigh()
    {
        var options = ValidOptions();
        options.MaxRetryAttempts = 11;

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenMaxRetryAttemptsNegative()
    {
        var options = ValidOptions();
        options.MaxRetryAttempts = -1;

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenCircuitBreakerExceptionCountTooLow()
    {
        var options = ValidOptions();
        options.CircuitBreakerExceptionCount = 0;

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenCircuitBreakerDurationSecondsTooLow()
    {
        var options = ValidOptions();
        options.CircuitBreakerDurationSeconds = 0;

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_Fail_WhenCircuitBreakerDurationSecondsTooHigh()
    {
        var options = ValidOptions();
        options.CircuitBreakerDurationSeconds = 601;

        var result = _validator.Validate(null, options);

        result.Failed.Should().BeTrue();
    }

    [Fact]
    public void BillbeeOptions_IsValid_Should_ReturnTrue_WithAllFields()
    {
        var options = ValidOptions();

        options.IsValid().Should().BeTrue();
    }

    [Fact]
    public void BillbeeOptions_IsValid_Should_ReturnFalse_WhenApiKeyMissing()
    {
        var options = ValidOptions();
        options.ApiKey = "";

        options.IsValid().Should().BeFalse();
    }

    private static BillbeeOptions ValidOptions() => new()
    {
        Url = "https://app.billbee.io/api/v1",
        ApiKey = "my-key",
        Username = "user",
        Password = "pass",
        TimeoutSeconds = 30,
        MaxRetryAttempts = 3,
        CircuitBreakerExceptionCount = 10,
        CircuitBreakerDurationSeconds = 100
    };
}
