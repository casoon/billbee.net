using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Extensions;
using Billbee.Net.Logging;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Wrap;

namespace Billbee.Net
{
    public class BillbeeClient : IBillbeeClient
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly ILogger<BillbeeClient> _logger;
        private readonly string _password;
        private readonly double _pollyCircuitBreakDurationInSecondsValue = 100;
        private readonly int _pollyCircuitBreakExceptionCountValue = 10;
        private readonly string _username;
        private IConfiguration _config;
        private readonly AsyncPolicyWrap _policyWrap;

        public BillbeeClient(ILogger<BillbeeClient> logger, IFlurlTelemetryLogger flurlTelemetryLogger)
        {
            _config = ServiceRegistration.Configuration;

            _baseUrl = _config["BillbeeUrl"];
            _username = _config["Username"];
            _password = _config["Password"];
            _apiKey = _config["ApiKey"];
            _logger = logger;

            if (string.IsNullOrWhiteSpace(_baseUrl))
                throw new Exception("Base Url not configured. Please add BillbeeUrl to configuration");

            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new Exception("ApiKey not configured. Please add ApiKey to configuration");

            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
                throw new Exception(
                    "Username and or Password are not configured. Please add Username and Password to configuration file");

            if (string.IsNullOrWhiteSpace(_baseUrl)) throw new Exception("billbee url not provided");


            var retryPolicy = Policy
                .Handle<FlurlHttpException>()
                .WaitAndRetryAsync(
                    10,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        // logging
                    }
                );

            var circuitBreaker = Policy
                .Handle<FlurlHttpException>()
                .Or<FlurlHttpTimeoutException>()
                .CircuitBreakerAsync(
                    _pollyCircuitBreakExceptionCountValue,
                    TimeSpan.FromSeconds(_pollyCircuitBreakDurationInSecondsValue)
                );


            var throttlePolicy = Policy
                .Handle<FlurlParsingException>(a =>
                    a.StatusCode != null && a.StatusCode == (int) HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(
                    10,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        // logging
                    }
                );


            var timeoutPolicy = Policy.TimeoutAsync(TimeSpan.FromMilliseconds(2500));

            var bulkheadPolicy = Policy.BulkheadAsync(10, 2);


            _policyWrap = Policy.WrapAsync(retryPolicy, throttlePolicy, circuitBreaker, timeoutPolicy, bulkheadPolicy);


            FlurlHttp.ConfigureClientForUrl(_baseUrl)
                .AfterCall(call => flurlTelemetryLogger.Log(call))
                .AllowAnyHttpStatus()
                .WithHeaders(new
                {
                    Accept = "application/json"
                });
            
        }

        public async Task<T> GetAsync<T>(string endPoint, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            try
            {
                return await _policyWrap.ExecuteAsync(() => _baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .Get<T>(_apiKey, _username, _password));
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAllAsync<T>(string endPoint, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            try
            {
                return await _policyWrap.ExecuteAsync(() => _baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .GetAll<T>(_apiKey, _username, _password));
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        public async Task<T> AddAsync<T>(string endPoint, T t, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            try
            {
                return await _policyWrap.ExecuteAsync(() => _baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .Post(_apiKey, _username, _password, t));
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync<T>(string endPoint, T t, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            try
            {
                return await _policyWrap.ExecuteAsync(() => _baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .Put(_apiKey, _username, _password, t));
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        public async Task<T> PatchAsync<T>(string endPoint, Dictionary<string, object> param)
        {
            try
            {
                return await _policyWrap.ExecuteAsync(() => _baseUrl
                    .AppendPathSegments(endPoint)
                    .Patch<T>(_apiKey, _username, _password, param));
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync<T>(string endPoint)
        {
            try
            {
                await _policyWrap.ExecuteAsync(async () =>
                {
                    await _baseUrl
                        .AppendPathSegments(endPoint)
                        .Delete<T>(_apiKey, _username, _password);
                });
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync<T>(string endPoint, T t)
        {
            try
            {
                await _policyWrap.ExecuteAsync(async () =>
                {
                    await _baseUrl
                        .AppendPathSegments(endPoint)
                        .Post(_apiKey, _username, _password, t);
                });
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }
    }
}