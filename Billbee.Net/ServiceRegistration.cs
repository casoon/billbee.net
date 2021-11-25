using System;
using Billbee.Net.Endpoints;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Billbee.Net
{
    public static class ServiceRegistration
    {

        internal static IConfiguration Configuration;


        public static IServiceCollection RegisterBillbee(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            Configuration = configuration;

            var baseUrl = configuration["BillbeeUrl"];

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new Exception("billbee url not provided");
            }


            FlurlHttp.ConfigureClient(baseUrl, cli => cli
                .Configure(settings =>
                {

                })
                .WithHeaders(new
                {
                    Accept = "application/json",
                }));


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

