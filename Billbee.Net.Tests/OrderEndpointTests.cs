using System.Net;
using Billbee.Net.Endpoints;
using Billbee.Net.Enums;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;
using Billbee.Net.Responses;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace Billbee.Net.Tests;

public class OrderEndpointTests : TestBase
{
    private IOrderEndpoint Endpoint => GetService<IOrderEndpoint>();

    [Fact]
    public async Task GetAllAsync_Should_UseGetAndReturnOrders()
    {
        var response = new PagedResponse<Order>
        {
            ErrorCode = 0,
            Data = [new Order { BillBeeOrderId = 42 }]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAllAsync();

        result.Should().HaveCount(1);
        result[0].BillBeeOrderId.Should().Be(42);
    }

    [Fact]
    public async Task GetAllAsync_Should_ThrowApiException_WhenApiReturnsError()
    {
        var response = new PagedResponse<Order> { ErrorCode = 500, ErrorMessage = "Internal error" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.GetAllAsync());
    }

    [Fact]
    public async Task GetAsync_Should_UseCorrectPath()
    {
        var response = new Response<Order> { ErrorCode = 0, Data = new Order { BillBeeOrderId = 1 } };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/1").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAsync(1);

        result.BillBeeOrderId.Should().Be(1);
    }

    [Fact]
    public async Task AddDeliveryNoteAsync_Should_UseCorrectPath_WithoutShipmentSuffix()
    {
        var response = new Response<DeliveryNote> { ErrorCode = 0, Data = new DeliveryNote() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/CreateDeliveryNote/99").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.AddDeliveryNoteAsync(99);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/CreateDeliveryNote/99" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task AddShipmentAsync_Should_UsePost_WithOrderIdInPath()
    {
        var shipment = new OrderShipment { OrderId = 7 };
        var response = new Response<OrderShipment> { ErrorCode = 0, Data = shipment };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/7/shipment").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.AddShipmentAsync(shipment);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateOrderStateAsync_Should_UsePut()
    {
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/5/orderstate").UsingPut())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.UpdateOrderStateAsync(5, OrderStateEnum.Versendet);

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/5/orderstate" &&
            e.RequestMessage.Method == "PUT");
    }

    [Fact]
    public async Task GetOrderByExternalReferenceAsync_Should_UseCorrectPath()
    {
        var response = new Response<Order> { ErrorCode = 0, Data = new Order() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/findbyextref/EXT-123").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetOrderByExternalReferenceAsync("EXT-123");

        result.Should().NotBeNull();
    }
}
