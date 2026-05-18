using System.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Exceptions;
using Billbee.Net.Responses;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace Billbee.Net.Tests;

public class EnumApiEndpointTests : TestBase
{
    private IEnumApiEndpoint Endpoint => GetService<IEnumApiEndpoint>();

    [Fact]
    public async Task GetPaymentTypesAsync_Should_UseCorrectPath()
    {
        var response = new Response<string> { ErrorCode = 0, Data = "[\"PayPal\",\"CreditCard\"]" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/enums/paymenttypes").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetPaymentTypesAsync();

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPaymentTypesAsync_Should_ThrowApiException_WhenApiReturnsError()
    {
        var response = new Response<string> { ErrorCode = 500, ErrorMessage = "Error" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/enums/paymenttypes").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.GetPaymentTypesAsync());
    }

    [Fact]
    public async Task GetShippingCarriersAsync_Should_UseCorrectPath()
    {
        var response = new Response<string> { ErrorCode = 0, Data = "[\"DHL\",\"DPD\"]" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/enums/shippingcarriers").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetShippingCarriersAsync();

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetShipmentTypesAsync_Should_UseCorrectPath()
    {
        var response = new Response<string> { ErrorCode = 0, Data = "[\"Parcel\",\"Letter\"]" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/enums/shipmenttypes").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetShipmentTypesAsync();

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetOrderStatesAsync_Should_UseCorrectPath()
    {
        var response = new Response<string> { ErrorCode = 0, Data = "[\"Pending\",\"Shipped\"]" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/enums/orderstates").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetOrderStatesAsync();

        result.Should().NotBeNull();
    }
}
