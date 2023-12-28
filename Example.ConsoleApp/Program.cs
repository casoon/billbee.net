using Billbee.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

using var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;


try
{
    var orders = services.GetRequiredService<IOrderEndpoint>();
    var orderStates = new List<OrderStateEnum> {OrderStateEnum.Im_Fulfillment};
    var result = orders.GetAllAsync(orderStateId: orderStates).GetAwaiter().GetResult();
    foreach (var order in result)
        Console.WriteLine(order.BillBeeOrderId + " " + order.OrderNumber + " " + order.Customer.Name + " " +
                          order.CreatedAt);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) => { services.RegisterBillbee(configuration); });
}