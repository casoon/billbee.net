using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WireMock.Server;
using WireMock.Settings;

namespace Billbee.Net.Tests;

/// <summary>
/// Base class for all tests providing common setup and utilities
/// </summary>
public abstract class TestBase : IDisposable
{
    protected IServiceProvider ServiceProvider { get; private set; }
    protected WireMockServer MockServer { get; private set; }
    protected IConfiguration Configuration { get; private set; }

    protected TestBase()
    {
        SetupMockServer();
        SetupServices();
    }

    private void SetupMockServer()
    {
        MockServer = WireMockServer.Start(new WireMockServerSettings
        {
            Port = 8080,
            StartAdminInterface = true
        });
    }

    private void SetupServices()
    {
        var services = new ServiceCollection();
        
        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .Build();

        services.AddSingleton(Configuration);
        services.AddLogging(builder => 
        {
            builder.AddConfiguration(Configuration.GetSection("Logging"));
            builder.AddConsole();
        });

        // Register Billbee services
        services.RegisterBillbee(Configuration);

        ServiceProvider = services.BuildServiceProvider();
    }

    protected T GetService<T>() where T : notnull
    {
        return ServiceProvider.GetRequiredService<T>();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            MockServer?.Stop();
            MockServer?.Dispose();
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}