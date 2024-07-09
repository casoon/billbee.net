using Billbee.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        // Billbee-Einstellungen
        var billbeeSettings = new BillbeeSettings();
        configuration.GetSection("Billbee").Bind(billbeeSettings);

        // Setup Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddApiClient(billbeeSettings)
            .BuildServiceProvider();

        var customerAddressEndpoint = serviceProvider.GetService<CustomerAddressEndpoint>();

        if (customerAddressEndpoint == null)
        {
            Console.WriteLine("Failed to retrieve CustomerAddressEndpoint from service provider.");
            return;
        }

        // Add a new customer address
        var newAddress = new CustomerAddress
        {
            // Set the necessary properties for the new address
            Street = "123 Main St",
            City = "Anytown"
            // Add other necessary fields as per your model
        };

        await customerAddressEndpoint.AddAsync(newAddress);
        Console.WriteLine("New customer address added.");

        // Retrieve a customer address by ID
        Console.Write("Enter the ID of the customer address to retrieve: ");
        if (long.TryParse(Console.ReadLine(), out var addressId))
        {
            var address = await customerAddressEndpoint.GetAsync(addressId);
            if (address != null)
                Console.WriteLine(
                    $"Address retrieved: {address.Street}, {address.City}");
            else
                Console.WriteLine("Address not found.");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}

// Class to bind the API settings
public class ApiSettings
{
    public string BaseAddress { get; set; }
    public string ApiKey { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}