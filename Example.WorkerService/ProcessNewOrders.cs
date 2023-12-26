using Billbee.Net.Endpoints;
using Quartz;

namespace Example.WorkerService;

[DisallowConcurrentExecution]
public class ProcessNewOrders(
    ILogger logger,
    IOrderEndpoint orders) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var orderList = orders.GetAllAsync(minOrderDate: DateTime.Today.AddDays(-10)).GetAwaiter().GetResult();
            foreach (var order in orderList)
                if (order.BillBeeOrderId != null)
                    Console.WriteLine(order.BillBeeOrderId.Value);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        logger.LogInformation($"Scheduled task {GetType().Name}");
        await Task.CompletedTask;
    }
}