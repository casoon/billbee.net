using Billbee.Net.Exceptions;
using Billbee.Net.Endpoints;
using Quartz;

namespace Example.WorkerService;

[DisallowConcurrentExecution]
public class ProcessNewOrders(
    ILogger<ProcessNewOrders> logger,
    IOrderEndpoint orders) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var orderList = await orders.GetAllAsync(minOrderDate: DateTime.Today.AddDays(-10));
            foreach (var order in orderList)
                logger.LogInformation("Order {OrderId}", order.BillBeeOrderId);

            logger.LogInformation("Scheduled task {JobName} completed", GetType().Name);
        }
        catch (RateLimitException ex)
        {
            logger.LogWarning(ex, "Rate limit hit, job will retry on next trigger");
        }
        catch (ApiException ex)
        {
            logger.LogError(ex, "Billbee API error in {JobName}", GetType().Name);
            throw new JobExecutionException(ex, refireImmediately: false);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error in {JobName}", GetType().Name);
            throw new JobExecutionException(ex, refireImmediately: false);
        }
    }
}
