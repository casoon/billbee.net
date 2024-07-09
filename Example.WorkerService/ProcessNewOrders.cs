using Billbee.Net.Endpoints;
using Billbee.Net.Models;
using Billbee.Net.Responses;
using Quartz;

namespace Example.WorkerService;

/// <summary>
///     Job for processing new orders.
/// </summary>
[DisallowConcurrentExecution]
public class ProcessNewOrders : IJob
{
    private readonly ILogger<ProcessNewOrders> _logger;
    private readonly OrderEndpoint _orders;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ProcessNewOrders" /> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="orders">The order endpoint instance.</param>
    public ProcessNewOrders(ILogger<ProcessNewOrders> logger, OrderEndpoint orders)
    {
        _logger = logger;
        _orders = orders;
    }

    /// <summary>
    ///     Executes the job to process new orders.
    /// </summary>
    /// <param name="context">The job execution context.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            // Fetch orders from the last 10 days
            PagedResponse<Order> orderList = await _orders.GetAllAsync(minOrderDate: DateTime.Today.AddDays(-10));
            foreach (var order in orderList.Items) Console.WriteLine(order.BillBeeOrderId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            _logger.LogError(ex, "An error occurred while processing new orders.");
        }

        _logger.LogInformation($"Scheduled task {GetType().Name} completed successfully.");
    }
}