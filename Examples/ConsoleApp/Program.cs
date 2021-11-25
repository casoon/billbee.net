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

            var orders = provider.GetRequiredService<IOrdersEndpoint>();

            //var test = orders.GetAsync("").GetAwaiter().GetResult();

        }
    }
}




