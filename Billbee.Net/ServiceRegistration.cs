using Billbee.Net.Configuration;
using Billbee.Net.Endpoints;
using Billbee.Net.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Billbee.Net
{
    /// <summary>
    /// Extension methods for registering Billbee services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Registers all Billbee services with the dependency injection container
        /// </summary>
        /// <param name="serviceCollection">The service collection</param>
        /// <param name="configuration">Configuration containing Billbee settings</param>
        /// <returns>The service collection for chaining</returns>
        public static IServiceCollection RegisterBillbee(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            // Configure options
            var configSection = configuration.GetSection(BillbeeOptions.SectionName);
            serviceCollection.Configure<BillbeeOptions>(configSection);
            
            // Validate options on startup
            serviceCollection.AddSingleton<IValidateOptions<BillbeeOptions>, ValidateBillbeeOptions>();

            // Register logging services
            serviceCollection.AddSingleton<IFlurlTelemetryLogger, FlurlTelemetryLogger>();
            serviceCollection.AddSingleton<IBillbeeClient, BillbeeClient>();
            serviceCollection.AddSingleton<IAutomaticProvisionEndpoint, AutomaticProvisionEndpoint>();
            serviceCollection.AddSingleton<ICloudStorageEndpoint, CloudStorageEndpoint>();
            serviceCollection.AddSingleton<ICustomerAddressEndpoint, CustomerAddressEndpoint>();
            serviceCollection.AddSingleton<ICustomerEndpoint, CustomerEndpoint>();
            serviceCollection.AddSingleton<IDeliveryNoteEndpoint, DeliveryNoteEndpoint>();
            serviceCollection.AddSingleton<IEnumApiEndpoint, EnumApiEndpoint>();
            serviceCollection.AddSingleton<IEventEndpoint, EventEndpoint>();
            serviceCollection.AddSingleton<IInvoiceEndpoint, InvoiceEndpoint>();
            serviceCollection.AddSingleton<IOrderEndpoint, OrderEndpoint>();
            serviceCollection.AddSingleton<IProductEndpoint, ProductEndpoint>();
            serviceCollection.AddSingleton<IShipmentEndpoint, ShipmentEndpoint>();
            serviceCollection.AddSingleton<IWebhookEndpoint, WebhookEndpoint>();

            return serviceCollection;
        }
    }
}