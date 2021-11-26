// See https://aka.ms/new-console-template for more information
using Billbee.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            BillbeeStarter(host.Services);

            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            IConfiguration Configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.RegisterBillbee(Configuration));
        }

        public static void BillbeeStarter(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var orders = provider.GetRequiredService<IOrderEndpoint>();
            var customers = provider.GetRequiredService<ICustomerEndpoint>();

            //var test = orders.GetSingleAsync("").GetAwaiter().GetResult();

            //var test = customers.GetAllAsync(0,20).GetAwaiter().GetResult();

            var test = customers.GetOrdersForCustomer(134620045, 0, 10).GetAwaiter().GetResult();

            int i = 0;
        }
    }
}




