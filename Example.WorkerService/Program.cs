using Billbee.Net;
using Quartz;
using Quartz.AspNetCore;

namespace Example.WorkerService;

public class Program
{
    /// <summary>
    ///     Main entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = CreateHostBuilder(args).Build();
        builder.Run();
    }

    /// <summary>
    ///     Creates and configures the host builder for the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <returns>An instance of IHostBuilder.</returns>
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                ConfigureQuartz(services);
                ConfigureApiClient(services, hostContext.Configuration);
            });
    }

    /// <summary>
    ///     Configures Quartz services and scheduler.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    private static void ConfigureQuartz(IServiceCollection services)
    {
        services.AddQuartz(quartz =>
        {
            quartz.SchedulerId = "Scheduler-Core";
            quartz.SchedulerName = "Billbee";
            quartz.UseSimpleTypeLoader();
            quartz.UseInMemoryStore();
            quartz.UseDefaultThreadPool(tp => { tp.MaxConcurrency = 3; });

            quartz.AddJob<ProcessNewOrders>(j => j.WithIdentity("ProcessNewOrders"));

            quartz.AddTrigger(t => t
                .ForJob("ProcessNewOrders")
                .StartNow()
                .WithSimpleSchedule(s => s
                    .WithInterval(TimeSpan.FromMinutes(5))
                    .RepeatForever()));
        });

        services.AddQuartzServer(options =>
        {
            options.WaitForJobsToComplete = true; // Graceful shutdown
        });
    }

    /// <summary>
    ///     Configures the API client services.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="configuration">The IConfiguration to retrieve settings from.</param>
    private static void ConfigureApiClient(IServiceCollection services, IConfiguration configuration)
    {
        var billbeeSettings = new BillbeeSettings();
        configuration.GetSection("Billbee").Bind(billbeeSettings);

        services.AddApiClient(billbeeSettings);
    }
}