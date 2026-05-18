using System.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;
using Billbee.Net.Responses;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace Billbee.Net.Tests;

public class CustomerAddressEndpointTests : TestBase
{
    private ICustomerAddressEndpoint Endpoint => GetService<ICustomerAddressEndpoint>();

    [Fact]
    public async Task GetAllAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<CustomerAddress>
        {
            ErrorCode = 0,
            Data = [new CustomerAddress { Id = 1 }]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customer-addresses").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAllAsync();

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAllAsync_Should_ThrowApiException_WhenApiReturnsError()
    {
        var response = new PagedResponse<CustomerAddress> { ErrorCode = 404, ErrorMessage = "Not found" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customer-addresses").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.GetAllAsync());
    }

    [Fact]
    public async Task GetAsync_Should_UseCorrectPath()
    {
        var response = new Response<CustomerAddress>
        {
            ErrorCode = 0,
            Data = new CustomerAddress { Id = 42 }
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customer-addresses/42").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAsync(42);

        result.Should().NotBeNull();
        result.Id.Should().Be(42);
    }

    [Fact]
    public async Task AddAsync_Should_UsePost()
    {
        var address = new CustomerAddress { FirstName = "John" };
        var response = new Response<CustomerAddress> { ErrorCode = 0, Data = address };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customer-addresses").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.AddAsync(address);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/customer-addresses" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task UpdateAsync_Should_UsePut()
    {
        var address = new CustomerAddress { Id = 5, FirstName = "Jane" };
        var response = new Response<CustomerAddress> { ErrorCode = 0, Data = address };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customer-addresses/5").UsingPut())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.UpdateAsync(address);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/customer-addresses/5" &&
            e.RequestMessage.Method == "PUT");
    }
}
