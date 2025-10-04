# Billbee.Net Modernization Guide

This guide outlines what has been completed and what still needs to be done to fully modernize the Billbee.Net library.

## ✅ Completed

### 1. Project Structure Updates
- ✅ Updated to target .NET 8.0 and .NET Standard 2.1
- ✅ Modern project file with comprehensive metadata
- ✅ Updated package references to latest versions
- ✅ Added nullable reference types support
- ✅ Added SourceLink for debugging
- ✅ Added symbol package generation

### 2. Testing Infrastructure
- ✅ Created comprehensive test project using xUnit
- ✅ Added WireMock.NET for HTTP mocking
- ✅ Added FluentAssertions for better test readability
- ✅ Added Moq for mocking dependencies
- ✅ Created TestBase class for common test setup
- ✅ Added sample unit tests

### 3. Documentation
- ✅ Completely rewritten README.md with modern formatting
- ✅ Added comprehensive usage examples
- ✅ Added build and test instructions
- ✅ Created CHANGELOG.md following Keep a Changelog format
- ✅ Updated WARP.md with current information

### 4. GitHub Repository Enhancements
- ✅ Modern GitHub Actions workflow with:
  - Multi-target framework builds
  - Code coverage reporting
  - Automated NuGet publishing
  - Dependency caching
- ✅ GitHub issue templates (Bug Report, Feature Request)
- ✅ Pull request template
- ✅ Repository configuration guide

### 5. CI/CD Pipeline
- ✅ Updated to use latest GitHub Actions
- ✅ Added code coverage collection
- ✅ Added automated NuGet package creation
- ✅ Added release automation

## ⚠️ Remaining Work (Critical)

### 1. Newtonsoft.Json to System.Text.Json Migration
**Priority: Critical**

The following files need to be updated to remove Newtonsoft.Json dependencies:

```bash
# Files requiring updates:
- /Extensions/BillbeeFlurlExtension.cs
- /Logging/FlurlTelemetryLogger.cs  
- /Models/ArticleSource.cs
- All model classes using [JsonProperty] attributes
```

**Migration Steps:**
1. Replace `using Newtonsoft.Json;` with `using System.Text.Json;`
2. Replace `[JsonProperty("name")]` with `[JsonPropertyName("name")]`
3. Replace `JObject` with `JsonElement` or `JsonDocument`
4. Update serialization/deserialization calls
5. Handle DateTime serialization differences
6. Update null handling patterns

### 2. Nullable Reference Types Implementation
**Priority: High**

Current warnings need to be addressed:
- Add proper null checks and null-forgiving operators
- Update method signatures to properly indicate nullable parameters
- Add null validation in constructors and methods
- Update XML documentation for nullable parameters

### 3. Modern C# Features
**Priority: Medium**

- Implement record types for simple data models
- Use pattern matching where appropriate
- Implement async enumerables for paginated results
- Use local functions for helper methods
- Implement proper disposing patterns with using declarations

### 4. Error Handling Improvements
**Priority: High**

```csharp
// Current pattern:
catch (ApiException ex)
{
    throw ex; // Re-throwing loses stack trace
}

// Should be:
catch (ApiException)
{
    throw; // Preserves stack trace
}
```

### 5. Configuration Options Pattern
**Priority: Medium**

Replace direct configuration access with Options pattern:

```csharp
// Create BillbeeOptions class
public class BillbeeOptions
{
    public string Url { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Logging { get; set; }
}

// Update ServiceRegistration to use IOptions<T>
```

## 🔧 Quick Fixes for Immediate Build Success

### 1. Temporary Newtonsoft.Json Fix
Add back Newtonsoft.Json package reference to get builds working:

```xml
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```

### 2. Disable Nullable Warnings Temporarily
Add to project file:

```xml
<PropertyGroup>
    <Nullable>enable</Nullable>
    <WarningsAsErrors />
    <WarningsNotAsErrors>CS8625;CS8600;CS8601;CS8602;CS8603;CS8604</WarningsNotAsErrors>
</PropertyGroup>
```

### 3. Fix XML Documentation Warnings
Search and fix XML comments with invalid characters in:
- `/Models/MultiLanguageString.cs`
- `/Models/DeliveryNote.cs`
- `/Models/Account.cs`
- `/Models/InvoiceDetail.cs`
- `/Models/Shipment.cs`
- `/Models/ApiResult.cs`
- `/Models/Order.cs`

## 📋 Migration Priority Order

1. **Fix XML Documentation** (Quick wins)
2. **Add Newtonsoft.Json temporarily** (Build fix)
3. **Address nullable warnings gradually** (File by file)
4. **Implement Options pattern** (Configuration improvement)
5. **Migrate to System.Text.Json** (Major refactor)
6. **Update examples** (Documentation)
7. **Add integration tests** (Testing)

## 🎯 Next Steps

1. **Immediate**: Run the quick fixes above to get builds working
2. **Week 1**: Fix XML documentation and nullable warnings
3. **Week 2**: Implement Options pattern and improve error handling
4. **Week 3-4**: Migrate from Newtonsoft.Json to System.Text.Json
5. **Week 5**: Update examples and add more comprehensive tests

## 🧪 Testing Strategy

Since you mentioned you can't test against the live API:

1. **Unit Tests**: Test business logic with mocked dependencies
2. **Integration Tests**: Use WireMock.NET to simulate API responses
3. **Contract Tests**: Verify request/response formats match API documentation
4. **Load Tests**: Test resilience policies under simulated load

## 📚 Resources

- [System.Text.Json Migration Guide](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to)
- [.NET Options Pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options)
- [Nullable Reference Types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references)
- [Modern .NET Testing](https://docs.microsoft.com/en-us/dotnet/core/testing/)