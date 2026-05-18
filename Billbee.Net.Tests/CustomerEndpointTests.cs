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

public class CustomerEndpointTests : TestBase
{
    private ICustomerEndpoint Endpoint => GetService<ICustomerEndpoint>();

    [Fact]
    public async Task GetAllAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<Customer>
        {
            ErrorCode = 0,
            Data = [new Customer { Id = 1, Name = "Test Customer" }]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customers").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAllAsync(0, 50);

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAllAsync_Should_ThrowApiException_WhenApiReturnsError()
    {
        var response = new PagedResponse<Customer> { ErrorCode = 500, ErrorMessage = "Server error" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customers").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.GetAllAsync(0, 50));
    }

    [Fact]
    public async Task GetAsync_Should_UseCorrectPath()
    {
        var response = new Response<Customer>
        {
            ErrorCode = 0,
            Data = new Customer { Id = 10, Name = "Customer 10" }
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customers/10").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAsync(10);

        result.Should().NotBeNull();
        result.Id.Should().Be(10);
    }

    [Fact]
    public async Task GetOrdersForCustomerAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<Order>
        {
            ErrorCode = 0,
            Data = [new Order()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customers/5/orders").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetOrdersForCustomerAsync(5, 0, 50);

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAddressesForCustomerAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<Address>
        {
            ErrorCode = 0,
            Data = [new Address()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/customers/5/addresses").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAddressesForCustomerAsync(5, 0, 50);

        result.Should().HaveCount(1);
    }
}
