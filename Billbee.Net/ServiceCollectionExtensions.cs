using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using Polly;
using Polly.Extensions.Http;

namespace Billbee.Net;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the ApiClient and CustomerAddressEndpoint to the service collection with the specified base address, API key,
    ///     password, and username.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="baseAddress">The base address of the API.</param>
    /// <param name="apiKey">The API key.</param>
    /// <param name="password">The password.</param>
    /// <param name="username">The username.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApiClient(
        this IServiceCollection services,
        string baseAddress,
        string apiKey,
        string username,
        string password)
    {
        var endpointsNamespace = "Billbee.Net.Endpoints";
        var userAgent = $"Billbee.Net/{typeof(ApiClient).Assembly.GetName().Version}";

        // Create the ResiliencePipeline with a SlidingWindowRateLimiter
        var rateLimiterPolicy = Policy.RateLimitAsync<HttpResponseMessage>(2, TimeSpan.FromSeconds(1));

        // Define the retry strategy with exponential backoff
        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.RequestTimeout || msg.StatusCode == (HttpStatusCode) 429)
            .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (outcome, timespan, retryAttempt, context) =>
                {
                    Console.WriteLine(
                        $"Retry {retryAttempt} after {timespan.TotalSeconds} seconds due to: {outcome.Exception?.Message ?? outcome.Result?.StatusCode.ToString()}");
                });

        // Define the circuit breaker strategy
        var circuitBreakerPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.RequestTimeout || msg.StatusCode == (HttpStatusCode) 429)
            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(10),
                (outcome, timespan) =>
                {
                    Console.WriteLine(
                        $"Circuit broken for {timespan.TotalSeconds} seconds due to: {outcome.Exception?.Message ?? outcome.Result?.StatusCode.ToString()}");
                },
                () => Console.WriteLine("Circuit reset."));

        services.AddHttpClient<ApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
                client.DefaultRequestHeaders.Add("X-Billbee-Api-Key", apiKey);

                // Encode username and password for Basic Auth
                var basicAuthToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthToken);
            })
            .AddPolicyHandler(rateLimiterPolicy)
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(circuitBreakerPolicy);

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Debug);
            loggingBuilder.AddConsole();

            loggingBuilder.AddOpenTelemetry(options =>
                options.AddConsoleExporter().SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService("ResilientHttpClientApp")));
        });

        services.AddSingleton<ApiClient>();
        // Add all endpoint classes to the service collection
        var endpointTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && t.Namespace == endpointsNamespace && t.Name.EndsWith("Endpoint"));

        foreach (var endpointType in endpointTypes) services.AddTransient(endpointType);

        return services;
    }
}