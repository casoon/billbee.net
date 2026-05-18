using Billbee.Net;
using Example.WorkerService;
using Quartz;
using Quartz.AspNetCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterBillbee(builder.Configuration);

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
        .WithSimpleSchedule(s =>
            s.WithInterval(TimeSpan.FromMinutes(5))
             .RepeatForever()
        ));
});

builder.Services.AddQuartzServer(options =>
{
    options.WaitForJobsToComplete = true;
});

await builder.Build().RunAsync();
