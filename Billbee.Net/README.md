# Billbee.Net

Billbee.Net is a modern and asynchronous .NET client library designed to interact with the Billbee API efficiently.

## GOAL

Provide .NET client support for the Billbee API.

## Installation

Get it on NuGet:

```shell
PM> Install-Package Billbee.Net
```

## Configuration

To use Billbee.Net in your .NET projects, add the necessary configuration to your `appsettings.json` file:

```json
{
  "Billbee": {
    "BaseAddress": "https://app.billbee.io/api/v1",
    "ApiKey": "YOUR_API_KEY",
    "Username": "YOUR_USERNAME",
    "Password": "YOUR_PASSWORD"
  }
}
```

## How to Use

### Register the Service

In your `Startup.cs` or `Program.cs` file, register the Billbee service:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Billbee.Net;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        var billbeeSettings = new BillbeeSettings();
        Configuration.GetSection("Billbee").Bind(billbeeSettings);
        
        var serviceProvider = new ServiceCollection()
            .AddApiClient(billbeeSettings)
            .BuildServiceProvider();
    }
}
```

### Example Usage

Here is an example of how to use the Billbee API client in your application:

```csharp
using System;
using System.Threading.Tasks;
using Billbee.Net.Endpoints;
using Billbee.Net.Models;
using Microsoft.Extensions.Logging;

public class ExampleService
{
    private readonly ILogger<ExampleService> _logger;
    private readonly OrderEndpoint _orderEndpoint;

    public ExampleService(ILogger<ExampleService> logger, OrderEndpoint orderEndpoint)
    {
        _logger = logger;
        _orderEndpoint = orderEndpoint;
    }

    public async Task ProcessNewOrders()
    {
        try
        {
            var orders = await _orderEndpoint.GetAllAsync(minOrderDate: DateTime.Today.AddDays(-10));
            foreach (var order in orders.Data)
            {
                Console.WriteLine(order.BillBeeOrderId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing new orders.");
        }
    }
}
```

## Available Endpoints

The following endpoints are available in the `Billbee.Net` library:

- `AutomaticProvisionEndpoint`
- `CloudStorageEndpoint`
- `CustomerAddressEndpoint`
- `CustomerEndpoint`
- `DeliveryNoteEndpoint`
- `EnumApiEndpoint`
- `EventEndpoint`
- `InvoiceEndpoint`
- `OrderEndpoint`
- `ProductEndpoint`
- `ShipmentEndpoint`
- `WebhookEndpoint`

## Important Notice

The library implements the key functionalities of the Billbee API but is not complete. If you have any questions or
encounter any issues, please contact the developer.

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.

---

This `README` provides a comprehensive overview and guide for developers on how to set up and use the `Billbee.Net`
library, including installation, configuration, and usage examples, along with a list of available endpoints.