# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Modern .NET 8 target framework support
- Comprehensive unit test suite with WireMock.NET
- Code coverage reporting in CI/CD pipeline
- Modern C# nullable reference types support
- SourceLink support for better debugging experience
- Extensive XML documentation for all public APIs
- GitHub issue and PR templates
- Modern GitHub Actions workflow with automated NuGet publishing

### Changed
- **BREAKING**: Updated minimum .NET Standard version to 2.1
- **BREAKING**: Replaced Newtonsoft.Json with System.Text.Json
- **BREAKING**: Updated Polly to version 8.x (breaking API changes)
- **BREAKING**: Improved error handling with more specific exception types
- Updated all NuGet package dependencies to latest stable versions
- Improved logging with structured logging patterns
- Enhanced retry policies with better backoff strategies
- Modernized code style with latest C# language features
- Improved async/await patterns throughout the codebase
- Enhanced configuration validation with better error messages

### Deprecated
- Legacy .NET Framework specific workarounds (will be removed in v2.0)

### Removed
- Dependency on Newtonsoft.Json (replaced with System.Text.Json)
- Unused package references and code
- Legacy .NET Framework 4.6.1 support

### Fixed
- Memory leaks in HTTP client usage
- Race conditions in concurrent API calls
- Improper disposal of resources
- Thread safety issues in configuration access

### Security
- Updated all dependencies to address known security vulnerabilities
- Improved API key handling and storage patterns
- Enhanced input validation for all endpoints

## [0.4.4] - 2023-XX-XX

### Added
- Basic Billbee API client functionality
- Support for major API endpoints (Orders, Products, Customers, etc.)
- Polly integration for retry policies
- Basic logging support
- Simple dependency injection registration

### Changed
- Initial release with basic functionality

[Unreleased]: https://github.com/casoon/billbee.net/compare/v0.4.4...HEAD
[0.4.4]: https://github.com/casoon/billbee.net/releases/tag/v0.4.4