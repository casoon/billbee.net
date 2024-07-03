using Billbee.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Models;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Setup Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddApiClient("https://api.yourservice.com/", "your-api-key", "your-password")
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