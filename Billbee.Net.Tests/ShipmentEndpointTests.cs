using System.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;
using Billbee.Net.Models.Rechnungsdruck.WebApp.Model.Api;
using Billbee.Net.Responses;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace Billbee.Net.Tests;

public class ShipmentEndpointTests : TestBase
{
    private IShipmentEndpoint Endpoint => GetService<IShipmentEndpoint>();

    [Fact]
    public async Task GetShippingProviderAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<ShippingProvider>
        {
            ErrorCode = 0,
            Data = [new ShippingProvider()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/shipment/shippingproviders").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetShippingProviderAsync();

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetShippingProviderAsync_Should_ThrowApiException_WhenApiReturnsError()
    {
        var response = new PagedResponse<ShippingProvider> { ErrorCode = 500, ErrorMessage = "Server error" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/shipment/shippingproviders").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.GetShippingProviderAsync());
    }

    [Fact]
    public async Task GetShippingCarriersAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<ShippingCarrier>
        {
            ErrorCode = 0,
            Data = [new ShippingCarrier()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/shipment/shippingcarriers").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetShippingCarriersAsync();

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task AddShipmentAsync_Should_UsePost()
    {
        var shipment = new PostShipment { ProviderName = "DHL" };
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/shipment/shipment").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.AddShipmentAsync(shipment);

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/shipment/shipment" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task ShipOrderWithLabelAsync_Should_UsePost()
    {
        var shipment = new ShipmentWithLabel();
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/shipment/shipwithlabel").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.ShipOrderWithLabelAsync(shipment);

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/shipment/shipwithlabel" &&
            e.RequestMessage.Method == "POST");
    }
}
