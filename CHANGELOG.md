# Changelog

All notable changes to this project will be documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [Unreleased]

## [1.0.0] - 2026-05-17

### Changed
- Upgraded target framework to .NET 10, dropped netstandard2.1
- Updated all NuGet packages to current versions (Polly 8.6.6, Newtonsoft.Json 13.0.4, Microsoft.Extensions 10.x)
- Flurl HTTP configuration (timeout, headers, AllowAnyHttpStatus) now applies regardless of logging setting
- All `throw ex` replaced with `throw` to preserve original stack traces
- Removed redundant Newtonsoft.Json serialize/deserialize round-trip in extension methods
- Nullable interface parameters corrected (`List<T>` → `List<T>?`)
- `CultureInfo.InvariantCulture` added to all `DateTime.ToString` calls
- Test infrastructure upgraded: WireMock.Net 2.x, FluentAssertions 8.x, dynamic ports to avoid conflicts

### Added
- Polly circuit breaker implemented using `CircuitBreakerExceptionCount` and `CircuitBreakerDurationSeconds` options
- WireMock integration tests for `OrderEndpoint` and `ProductEndpoint`

### Fixed
- `return default` silently swallowed API errors in `Put`, `Patch`, and `GetAll` — now throws `ApiException`
- Delivery note endpoint path was `/orders/CreateDeliveryNote/{id}/shipment` — corrected to `/orders/CreateDeliveryNote/{id}`
- `UpdateProductImageAsync` validation was inverted (required zero Id instead of non-zero)
- `GetPatchableProductFieldsAsync` had an unused `id` parameter
- `updatestock` and `updatestockmultiple` used `PUT` — corrected to `POST` per API spec
- `Console.WriteLine` removed from `AddTagsAsync`

## [0.4.4] - 2024-01-01

### Added
- Initial release with Billbee API client for Orders, Products, Customers, Invoices, Shipments
- Polly retry and throttle policies
- Dependency injection registration via `RegisterBillbee`
