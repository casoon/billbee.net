using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Extensions;
using Flurl;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Flurl.Http;
using Billbee.Net.Responses;
using Polly.CircuitBreaker;
using Polly;
using System.Net;
using Polly.Retry;
using Polly.Wrap;
using Polly.Timeout;
using Polly.Bulkhead;
using Billbee.Net.Exceptions;
using Billbee.Net.Logging;

namespace Billbee.Net
{

    public class BillbeeClient : IBillbeeClient
    {
        protected IConfiguration _config;
        protected internal readonly string _baseUrl;
        protected internal readonly string _username;
        protected internal readonly string _password;
        protected internal readonly string _apiKey;
        protected internal readonly double _pollyCircuitBreakDurationInSecondsValue = 100;
        protected internal readonly int _pollyCircuitBreakExceptionCountValue = 10;
        private readonly ILogger<BillbeeClient> _logger;
        private AsyncPolicyWrap _policyWrap;

        public BillbeeClient(ILogger<BillbeeClient> logger, IFlurlTelemetryLogger flurlTelemetryLogger)
        {
            this._config = ServiceRegistration.Configuration;

            _baseUrl = this._config["BillbeeUrl"];
            _username = this._config["Username"];
            _password = this._config["Password"];
            _apiKey = this._config["ApiKey"];
            _logger = logger;

            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new Exception("Base Url not configured. Please add BillbeeUrl to configuration");
            }

            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new Exception("ApiKey not configured. Please add ApiKey to configuration");
            }

            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
            {
                throw new Exception("Username and or Password are not configured. Please add Username and Password to configuration file");
            }

            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new Exception("billbee url not provided");
            }


            AsyncRetryPolicy retryPolicy = Policy
                .Handle<FlurlHttpException>()
                .WaitAndRetryAsync(
                    10,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) => {
                        // logging
                    }
                );

            AsyncCircuitBreakerPolicy circuitBreaker = Policy
                .Handle<FlurlHttpException>()
                .Or<FlurlHttpTimeoutException>()
                .CircuitBreakerAsync(
                    exceptionsAllowedBeforeBreaking: _pollyCircuitBreakExceptionCountValue,
                    durationOfBreak: TimeSpan.FromSeconds(_pollyCircuitBreakDurationInSecondsValue)
                );


            AsyncRetryPolicy throttlePolicy = Policy
                .Handle<FlurlParsingException> (a => a.StatusCode != null && a.StatusCode == (int)System.Net.HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(
                    10,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) => {
                        // logging
                    }
                );


            AsyncTimeoutPolicy timeoutPolicy = Policy.TimeoutAsync(TimeSpan.FromMilliseconds(2500));

            AsyncBulkheadPolicy bulkheadPolicy =  Policy.BulkheadAsync(10, 2);


            _policyWrap = Policy.WrapAsync(retryPolicy, throttlePolicy, circuitBreaker, timeoutPolicy, bulkheadPolicy);


            FlurlHttp.ConfigureClient(_baseUrl, cli => cli
            .Configure(settings =>
            {
                //settings.BeforeCall = call => _logger.LogInformation($"Calling {call.Request.Url}");
                //settings.OnError = call => logger.LogError($"Call to Billbee API failed: {call.Exception}");
                settings.AfterCallAsync = flurlCall => flurlTelemetryLogger.Log(flurlCall);

            })
            .AllowAnyHttpStatus()
            .WithHeaders(new
            {
                Accept = "application/json",
            }));

        }

        public async Task<T> GetAsync<T>(string endPoint, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            try {
                return await _policyWrap.ExecuteAsync(() => _baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .Get<T>(_apiKey, _username, _password));

            } catch (ApiException ex)
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
                    .Post<T>(_apiKey, _username, _password, t));

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
                    .Put<T>(_apiKey, _username, _password, t));
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
                         .Post<T>(_apiKey, _username, _password, t);
                });

            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

    }
}

