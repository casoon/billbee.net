# Billbee.Net

[![License: MIT](https://img.shields.io/badge/license-MIT-blue?style=flat-square)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple?style=flat-square)](https://dotnet.microsoft.com/)
[![GitHub Release Date](https://img.shields.io/github/release-date/casoon/billbee.net?style=flat-square&logo=github)](https://github.com/casoon/billbee.net/releases)

A modern, asynchronous .NET 10 client library for the [Billbee API](https://www.billbee.io/). Built with Flurl.Http and Polly for robust, resilient HTTP communication.

## Features

- **Async/Await** — fully asynchronous API
- **Resilient** — automatic retry and circuit breaker via Polly
- **Rate limiting** — exponential backoff on HTTP 429
- **Dependency Injection** — native `Microsoft.Extensions.DependencyInjection` support
- **Structured logging** — configurable via `Microsoft.Extensions.Logging`
- **Strongly typed** — full IntelliSense and XML documentation

## Installation

```bash
dotnet add package Billbee.Net
```

## Configuration

```json
{
  "Billbee": {
    "Url": "https://app.billbee.io/api/v1",
    "ApiKey": "your-api-key",
    "Username": "your-username",
    "Password": "your-password",
    "Logging": false
  }
}
```

## Registration

```csharp
builder.Services.RegisterBillbee(builder.Configuration);
```

## Usage

```csharp
public class OrderService(IOrderEndpoint orders)
{
    public Task<List<Order>> GetRecentAsync() =>
        orders.GetAllAsync(orderStateId: [OrderStateEnum.Im_Fulfillment]);

    public async Task<Order> GetAsync(long id)
    {
        try
        {
            return await orders.GetAsync(id);
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, "Failed to get order {Id}", id);
            throw;
        }
    }
}
```

## Available Endpoints

- **Orders** — retrieve, create, update, manage orders
- **Products** — product catalog and stock management
- **Customers** — customer data and addresses
- **Invoices** — invoice generation
- **Shipments** — shipping and tracking
- **Events** — custom event handling
- **Delivery Notes** — delivery documentation

## Requirements

- .NET 10.0
- Billbee API credentials (API Key, Username, Password)

## Building & Testing

```bash
dotnet restore
dotnet build
dotnet test
```

## API Documentation

[Billbee API Documentation](https://www.billbee.io/hilfe/api/)

## License

MIT — see [LICENSE](LICENSE) for details.

## Author

**Jörn Seidel** · [casoon.de](https://casoon.de) · info@casoon.de
