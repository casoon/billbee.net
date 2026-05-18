using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Configuration;
using Billbee.Net.Exceptions;
using Billbee.Net.Extensions;
using Billbee.Net.Logging;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Wrap;

namespace Billbee.Net
{
    /// <summary>
    /// Main HTTP client for Billbee API with built-in retry policies and rate limiting
    /// </summary>
    public class BillbeeClient : IBillbeeClient
    {
        private readonly BillbeeOptions _options;
        private readonly AsyncPolicyWrap _policyWrap;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the BillbeeClient
        /// </summary>
        /// <param name="options">Configuration options</param>
        /// <param name="flurlTelemetryLogger">HTTP telemetry logger</param>
        /// <param name="logger">Application logger</param>
        public BillbeeClient(IOptions<BillbeeOptions> options, IFlurlTelemetryLogger flurlTelemetryLogger, ILogger<BillbeeClient> logger)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (!_options.IsValid())
            {
                throw new ArgumentException("Invalid Billbee configuration. Please ensure Url, ApiKey, Username, and Password are provided.", nameof(options));
            }

            var retryPolicy = Policy
                .Handle<FlurlHttpTimeoutException>()
                .WaitAndRetryAsync(
                    _options.MaxRetryAttempts,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        _logger.LogWarning("HTTP timeout on attempt {RetryCount}. Retrying in {Delay}ms. Exception: {Exception}",
                            retryCount, timeSpan.TotalMilliseconds, exception?.Message);
                    }
                );

            var throttlePolicy = Policy
                .Handle<RateLimitException>()
                .WaitAndRetryAsync(
                    _options.MaxRetryAttempts,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        _logger.LogWarning("Rate limit exceeded on attempt {RetryCount}. Retrying in {Delay}ms. Exception: {Exception}",
                            retryCount, timeSpan.TotalMilliseconds, exception?.Message);
                    }
                );

            var circuitBreakerPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(
                    _options.CircuitBreakerExceptionCount,
                    TimeSpan.FromSeconds(_options.CircuitBreakerDurationSeconds),
                    onBreak: (exception, duration) =>
                    {
                        _logger.LogWarning("Circuit breaker opened for {Duration}s. Exception: {Message}",
                            duration.TotalSeconds, exception?.Message);
                    },
                    onReset: () => _logger.LogInformation("Circuit breaker reset.")
                );

            _policyWrap = Policy.WrapAsync(retryPolicy, throttlePolicy, circuitBreakerPolicy);

            // Issue #1: HTTP behavior is configured regardless of logging to avoid environment-dependent differences
            FlurlHttp.Clients.WithDefaults(builder =>
            {
                builder
                    .AllowAnyHttpStatus()
                    .WithTimeout(TimeSpan.FromSeconds(_options.TimeoutSeconds))
                    .WithHeaders(new { Accept = "application/json" });
                if (_options.Logging)
                    builder.AfterCall(call => flurlTelemetryLogger.Log(call));
            });
        }

        public async Task<T> GetAsync<T>(string endPoint, Dictionary<string, string>? param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            return await _policyWrap.ExecuteAsync(() => _options.Url
                .AppendPathSegments(endPoint)
                .SetQueryParams(param)
                .Get<T>(_options.ApiKey, _options.Username, _options.Password));
        }

        public async Task<List<T>> GetAllAsync<T>(string endPoint, Dictionary<string, string>? param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            return await _policyWrap.ExecuteAsync(() => _options.Url
                .AppendPathSegments(endPoint)
                .SetQueryParams(param)
                .GetAll<T>(_options.ApiKey, _options.Username, _options.Password));
        }

        public async Task<T> AddAsync<T>(string endPoint, T t, Dictionary<string, string>? param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            return await _policyWrap.ExecuteAsync(() => _options.Url
                .AppendPathSegments(endPoint)
                .SetQueryParams(param)
                .Post(_options.ApiKey, _options.Username, _options.Password, t));
        }

        public async Task<T> UpdateAsync<T>(string endPoint, T t, Dictionary<string, string>? param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            return await _policyWrap.ExecuteAsync(() => _options.Url
                .AppendPathSegments(endPoint)
                .SetQueryParams(param)
                .Put(_options.ApiKey, _options.Username, _options.Password, t));
        }

        public async Task<T> PatchAsync<T>(string endPoint, Dictionary<string, object> param)
        {
            return await _policyWrap.ExecuteAsync(() => _options.Url
                .AppendPathSegments(endPoint)
                .Patch<T>(_options.ApiKey, _options.Username, _options.Password, param));
        }

        public async Task DeleteAsync<T>(string endPoint)
        {
            await _policyWrap.ExecuteAsync(async () =>
            {
                await _options.Url
                    .AppendPathSegments(endPoint)
                    .Delete<T>(_options.ApiKey, _options.Username, _options.Password);
            });
        }

        public async Task DeleteAsync<T>(string endPoint, T t)
        {
            await _policyWrap.ExecuteAsync(async () =>
            {
                await _options.Url
                    .AppendPathSegments(endPoint)
                    .Post(_options.ApiKey, _options.Username, _options.Password, t);
            });
        }
    }
}
