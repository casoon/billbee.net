using Billbee.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Enums;
using Billbee.Net.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.RegisterBillbee(builder.Configuration);

using var host = builder.Build();
using var scope = host.Services.CreateScope();

try
{
    var orders = scope.ServiceProvider.GetRequiredService<IOrderEndpoint>();
    var orderStates = new List<OrderStateEnum> { OrderStateEnum.Im_Fulfillment };
    var result = await orders.GetAllAsync(orderStateId: orderStates);
    foreach (var order in result)
        Console.WriteLine($"{order.BillBeeOrderId} {order.OrderNumber} {order.Customer?.Name} {order.CreatedAt}");
}
catch (RateLimitException ex)
{
    Console.WriteLine($"Rate limit exceeded: {ex.Message}");
}
catch (ApiException ex)
{
    Console.WriteLine($"Billbee API error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
