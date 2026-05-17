using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WireMock.Server;

namespace Billbee.Net.Tests;

public abstract class TestBase : IDisposable
{
    protected IServiceProvider ServiceProvider { get; private set; }
    protected WireMockServer MockServer { get; private set; }

    protected TestBase()
    {
        MockServer = WireMockServer.Start(); // random free port

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Billbee:Url"] = $"http://localhost:{MockServer.Port}/api/v1"
            })
            .Build();

        var services = new ServiceCollection();
        services.AddLogging(b => b.AddConfiguration(configuration.GetSection("Logging")));
        services.RegisterBillbee(configuration);

        ServiceProvider = services.BuildServiceProvider();
    }

    protected T GetService<T>() where T : notnull =>
        ServiceProvider.GetRequiredService<T>();

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            MockServer?.Stop();
            MockServer?.Dispose();
            if (ServiceProvider is IDisposable d) d.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
