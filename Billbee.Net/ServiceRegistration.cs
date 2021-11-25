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
            serviceCollection.AddScoped<IOrdersEndpoint, OrdersEndpoint>();


            return serviceCollection;
        }
    }
}

