using Billbee.Net;
using Quartz;
using Quartz.AspNetCore;


namespace Example.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
        var builder = Host.CreateApplicationBuilder(args);
        
        builder.Services.RegisterBillbee(configuration);
        
        builder.Services.AddQuartz(quartz =>
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
                .WithSimpleSchedule
                (s =>
                    s.WithInterval(TimeSpan.FromMinutes(5))
                        .RepeatForever()
                ));
        
        });
        
        builder.Services.AddQuartzServer(options =>
        {
            // when shutting down we want jobs to complete gracefully
            options.WaitForJobsToComplete = true;
        });
        
        var host = builder.Build();
        host.Run();
    }
}