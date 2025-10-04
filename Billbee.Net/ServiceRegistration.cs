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