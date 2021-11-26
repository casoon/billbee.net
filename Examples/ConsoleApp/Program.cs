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
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureServices((_, services) =>
                    services.RegisterBillbee(Configuration));
        }

        public static void BillbeeStarter(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var orders = provider.GetRequiredService<IOrderEndpoint>();
            var customers = provider.GetRequiredService<ICustomerEndpoint>();


        }
    }
}




