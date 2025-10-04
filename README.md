# Billbee.Net

![Status: Unmaintained](https://img.shields.io/badge/status-unmaintained-lightgrey?style=flat-square)
![Maintenance: Archived](https://img.shields.io/badge/maintenance-archived-orange?style=flat-square)
[![License](https://img.shields.io/github/license/casoon/billbee.net?style=flat-square)](LICENSE)
[![GitHub Release Date](https://img.shields.io/github/release-date/casoon/billbee.net?style=flat-square&logo=github)](https://github.com/casoon/billbee.net/releases)

A **modern**, **asynchronous** .NET client library for the [Billbee API](https://www.billbee.io/). Built with performance, reliability, and ease of use in mind.

## ⚠️ Projektstatus

**Status: Nicht mehr aktiv gepflegt (Stand: 04.10.2025)**

Dieses Repository enthielt eine von mir entwickelte Anbindung an Billbee.net.

Das Projekt wird nicht mehr aktiv gepflegt, da:

- Billbee im Laufe der Zeit viele der zuvor ergänzten Funktionen selbst integriert hat
- Der Integrations- und Serviceaufwand für einzelne Kund:innen wirtschaftlich nicht mehr sinnvoll war und diese – teils mit meiner Unterstützung:
  - auf alternative Plattformen gewechselt sind oder
  - sich für eine vollständig individuelle Eigenentwicklung entschieden haben, um alle Prozesse zentral zu kontrollieren

Es existiert daher **kein aktiver Kundenbetrieb** dieser Bibliothek.

**Kontakt:**
Sollte es einen konkreten Bedarf geben, Billbee erneut mit dieser Bibliothek zu verbinden, kann man sich gerne unter **info@casoon.de** melden.

**Hinweis:** Dieses Repository bleibt als Referenz öffentlich verfügbar, wird aber nicht weiter gepflegt.

## ✨ Features

- 🚀 **Modern .NET**: Targets .NET 8 and .NET Standard 2.1
- ⚡ **Async/Await**: Fully asynchronous API with proper async patterns
- 🛡️ **Resilient**: Built-in retry policies and circuit breaker patterns using Polly
- 🔄 **Rate Limiting**: Automatic handling of API rate limits with exponential backoff
- 🏗️ **Dependency Injection**: Native support for Microsoft.Extensions.DependencyInjection
- 📝 **Comprehensive Logging**: Structured logging support with configurable levels
- 🧪 **Well Tested**: Extensive unit tests with mocked HTTP responses
- 📚 **Strongly Typed**: Full IntelliSense support with comprehensive XML documentation
- 🔒 **Secure**: Follows security best practices for API communication

## 🚀 Quick Start

### Installation

```bash
# Package Manager
Install-Package Billbee.Net

# .NET CLI
dotnet add package Billbee.Net

# PackageReference
<PackageReference Include="Billbee.Net" Version="1.0.0" />
```

### Configuration

Add your Billbee API credentials to your configuration:

**appsettings.json:**
```json
{
  "Billbee": {
    "Url": "https://app.billbee.io/api/v1",
    "ApiKey": "your-api-key",
    "Username": "your-username",
    "Password": "your-password",
    "Logging": "false"
  }
}
```

### Registration

**Program.cs (.NET 8):**
```csharp
using Billbee.Net;

var builder = WebApplication.CreateBuilder(args);

// Register Billbee services
builder.Services.RegisterBillbee(builder.Configuration);

var app = builder.Build();
```

**Legacy Startup.cs:**
```csharp
using Billbee.Net;

public void ConfigureServices(IServiceCollection services)
{
    services.RegisterBillbee(Configuration);
}
```

### Usage Examples

#### Basic Order Retrieval
```csharp
using Billbee.Net.Endpoints;
using Billbee.Net.Enums;

public class OrderService
{
    private readonly IOrderEndpoint _orderEndpoint;
    
    public OrderService(IOrderEndpoint orderEndpoint)
    {
        _orderEndpoint = orderEndpoint;
    }
    
    public async Task<List<Order>> GetRecentOrdersAsync()
    {
        var orderStates = new List<OrderStateEnum> { OrderStateEnum.Im_Fulfillment };
        return await _orderEndpoint.GetAllAsync(orderStateId: orderStates);
    }
    
    public async Task<Order> GetOrderAsync(long orderId)
    {
        return await _orderEndpoint.GetAsync(orderId);
    }
}
```

#### Advanced Filtering
```csharp
public async Task<List<Order>> GetOrdersWithFiltersAsync()
{
    return await _orderEndpoint.GetAllAsync(
        page: 1,
        pageSize: 50,
        minOrderDate: DateTime.Now.AddDays(-30),
        maxOrderDate: DateTime.Now,
        orderStateId: new List<OrderStateEnum> { OrderStateEnum.Shipped },
        tag: new List<string> { "priority", "express" }
    );
}
```

#### Error Handling
```csharp
using Billbee.Net.Exceptions;

public async Task<Order> SafeGetOrderAsync(long orderId)
{
    try
    {
        return await _orderEndpoint.GetAsync(orderId);
    }
    catch (ApiException ex)
    {
        _logger.LogError(ex, "Failed to retrieve order {OrderId}: {Message}", orderId, ex.Message);
        throw;
    }
}
```

## 📋 Available Endpoints

- **Orders** - Retrieve, create, update, and manage orders
- **Products** - Product catalog management
- **Customers** - Customer data and addresses
- **Invoices** - Invoice generation and management
- **Shipments** - Shipping and tracking information
- **Webhooks** - Event notification management
- **Events** - Custom event handling
- **Delivery Notes** - Delivery documentation
- **Cloud Storage** - File and document management

## 🔧 Advanced Configuration

### Custom HTTP Client Configuration
```csharp
services.AddHttpClient<IBillbeeClient>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
    client.DefaultRequestHeaders.Add("User-Agent", "MyApp/1.0");
});
```

### Logging Configuration
```json
{
  "Logging": {
    "LogLevel": {
      "Billbee.Net": "Information"
    }
  },
  "Billbee": {
    "Logging": "true"
  }
}
```

## 🧪 Testing

Die Bibliothek enthält umfassende Unit-Tests, die die Funktionalität der API-Client-Implementierung validieren:

```bash
# Alle Tests ausführen
dotnet test

# Tests mit minimaler Ausgabe
dotnet test --verbosity minimal

# Spezifisches Test-Projekt ausführen
dotnet test Billbee.Net.Tests

# Tests mit Coverage-Analyse
dotnet test --collect:"XPlat Code Coverage"
```

**Test-Status**: ✅ Alle 3 Tests bestehen erfolgreich
- API-Client Grundfunktionalität
- Fehlerbehandlung und ApiException-Tests
- Verzögerte API-Antworten

## 🔨 Building

```bash
# Pakete wiederherstellen
dotnet restore

# Lösung erstellen
dotnet build

# Clean Build
dotnet clean && dotnet build

# Release-Build erstellen
dotnet build --configuration Release

# NuGet-Paket erstellen
dotnet pack --configuration Release
```

**Build-Status**: ✅ Erfolgreich kompiliert (965 Warnungen zu Nullable-Referenztypen und XML-Dokumentation)

> **Hinweis**: Die Warnungen betreffen hauptsächlich Nullable-Referenztypen und fehlende XML-Kommentare und beeinträchtigen die Funktionalität nicht.

## 📜 Legacy-Status

**Stand der letzten Wartung (04.10.2025):**
- ✅ Grundfunktionalität implementiert und getestet
- ✅ Build erfolgreich
- ⚠️ 965 Compiler-Warnungen (hauptsächlich Nullable-Referenztypen und XML-Dokumentation)
- ⚠️ Keine weitere Entwicklung oder Wartung geplant

**Grund der Archivierung:**
Die ursprünglichen Funktionen dieser Bibliothek wurden entweder von Billbee selbst nachgerüstet oder durch individuelle Lösungen ersetzt.

## 📚 Examples

Schauen Sie sich die Beispielprojekte im Repository an:

- **[Console Application](Example.ConsoleApp)** - Grundlegende Verwendungsbeispiele
- **[Web API](Example.WebApi)** - ASP.NET Core Integration
- **[Worker Service](Example.WorkerService)** - Hintergrunddienst mit Quartz.NET

## 📚 Verwendung als Referenz

**Hinweis:** Dieses Projekt wird nicht mehr aktiv entwickelt.

Das Repository bleibt als **Referenz** verfügbar für:
- Entwickler, die ähnliche API-Clients erstellen möchten
- Beispiele für .NET-Bibliotheksstruktur mit Dependency Injection
- Patterns für HTTP-Client-Implementierungen mit Polly
- Teststrategien für API-Clients

**Fork-Politik:**
Falls jemand das Projekt forken und weiterentwickeln möchte, ist das ausdrücklich erwünscht. Bitte kontaktieren Sie mich unter **info@casoon.de** für eventuelle Unterstützung beim Übergang.

## 📄 API Documentation

For detailed API documentation, visit the [Billbee API Documentation](https://www.billbee.io/hilfe/api/).

## 🆘 Support

- **Documentation**: Check our [Wiki](https://github.com/casoon/billbee.net/wiki)
- **Issues**: [GitHub Issues](https://github.com/casoon/billbee.net/issues)
- **Discussions**: [GitHub Discussions](https://github.com/casoon/billbee.net/discussions)

## 📋 Requirements

- .NET 8.0 or .NET Standard 2.1 compatible runtime
- Billbee API credentials (API Key, Username, Password)
- Internet connection for API communication

## 📊 Compatibility

| Platform | Version | Status |
|----------|---------|--------|
| .NET 8.0 | ✅ | Fully Supported |
| .NET 6.0 | ✅ | Supported via .NET Standard 2.1 |
| .NET Core 3.1 | ✅ | Supported via .NET Standard 2.1 |
| .NET Framework 4.7.2+ | ✅ | Supported via .NET Standard 2.1 |

## 📝 Changelog

See [CHANGELOG.md](CHANGELOG.md) for a detailed list of changes.

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Autor

**Jörn Seidel** - [GitHub](https://github.com/casoon) | [CASOON](https://casoon.de)

**Kontakt:** info@casoon.de • Freelancer für digitale Transformation in Rostock, MV

## 🙏 Acknowledgments

- [Billbee](https://www.billbee.io/) for providing an excellent e-commerce platform
- [Flurl](https://flurl.dev/) for the HTTP client foundation
- [Polly](https://www.thepollyproject.org/) for resilience patterns
- The .NET community for continuous inspiration

---

📚 **Dieses Repository bleibt als Referenz und Lernmaterial verfügbar** 📚

*Archiviert am 04.10.2025 • Letzte aktive Entwicklung: 2024*
