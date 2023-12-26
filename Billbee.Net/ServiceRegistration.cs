using Billbee.Net.Endpoints;
using Billbee.Net.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Billbee.Net
{
    public static class ServiceRegistration
    {
        internal static IConfiguration Configuration;

        public static IServiceCollection RegisterBillbee(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            Configuration = configuration;

            serviceCollection.AddTransient<ILogger>(s => s.GetService<ILogger<BillbeeClient>>());
            serviceCollection.AddScoped<IFlurlTelemetryLogger, FlurlTelemetryLogger>();
            serviceCollection.AddScoped<IBillbeeClient, BillbeeClient>();
            serviceCollection.AddScoped<IAutomaticProvisionEndpoint, AutomaticProvisionEndpoint>();
            serviceCollection.AddScoped<ICloudStorageEndpoint, CloudStorageEndpoint>();
            serviceCollection.AddScoped<ICustomerAddressEndpoint, CustomerAddressEndpoint>();
            serviceCollection.AddScoped<ICustomerEndpoint, CustomerEndpoint>();
            serviceCollection.AddScoped<IDeliveryNoteEndpoint, DeliveryNoteEndpoint>();
            serviceCollection.AddScoped<IEnumApiEndpoint, EnumApiEndpoint>();
            serviceCollection.AddScoped<IEventEndpoint, EventEndpoint>();
            serviceCollection.AddScoped<IInvoiceEndpoint, InvoiceEndpoint>();
            serviceCollection.AddScoped<IOrderEndpoint, OrderEndpoint>();
            serviceCollection.AddScoped<IProductEndpoint, ProductEndpoint>();
            serviceCollection.AddScoped<IShipmentEndpoint, ShipmentEndpoint>();
            serviceCollection.AddScoped<IWebhookEndpoint, WebhookEndpoint>();

            return serviceCollection;
        }
    }
}