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

/// <summary>
///     Extension methods for configuring the Billbee API client services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the Billbee ApiClient and its endpoints to the service collection with the specified settings.
    ///     Configures resilience policies including rate limiting, retries, and circuit breaking.
    /// </summary>
    /// <param name="services">The service collection to add the API client to.</param>
    /// <param name="settings">The Billbee settings containing the base address, API key, username, and password.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddBillbeeClient(this IServiceCollection services, BillbeeSettings settings)
    {
        var endpointsNamespace = "Billbee.Net.Endpoints";
        var userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

        // Register the ApiClient as a singleton service
        services.AddSingleton<BillbeeClient>();

        // Dynamically register all endpoint classes in the specified namespace
        var endpointTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && t.Namespace == endpointsNamespace && t.Name.EndsWith("Endpoint"));

        foreach (var endpointType in endpointTypes) services.AddTransient(endpointType);

        // Define the rate limiter policy
        var rateLimiterPolicy = Policy.RateLimitAsync<HttpResponseMessage>(2, TimeSpan.FromSeconds(1));

        // Define the retry policy with exponential backoff
        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.RequestTimeout || msg.StatusCode == (HttpStatusCode) 429)
            .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (outcome, timespan, retryAttempt, context) =>
                {
                    Console.WriteLine(
                        $"Retry {retryAttempt} after {timespan.TotalSeconds} seconds due to: {outcome.Exception?.Message ?? outcome.Result?.StatusCode.ToString()}");
                });

        // Define the circuit breaker policy
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

        // Configure the HttpClient with the base address, headers, and resilience policies
        services.AddHttpClient<BillbeeClient>(client =>
            {
                client.BaseAddress = new Uri(settings.BaseAddress);
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
                client.DefaultRequestHeaders.Add("X-Billbee-Api-Key", settings.ApiKey);

                var basicAuthToken =
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{settings.Username}:{settings.Password}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthToken);
            })
            .AddPolicyHandler(rateLimiterPolicy)
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(circuitBreakerPolicy);

        // Configure logging and OpenTelemetry
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Debug);
            loggingBuilder.AddConsole();
            loggingBuilder.AddOpenTelemetry(options =>
                options.AddConsoleExporter().SetResourceBuilder(
                    ResourceBuilder.CreateDefault().AddService("ResilientHttpClientApp")));
        });


        return services;
    }
}