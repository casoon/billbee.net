using System.Collections.Generic;
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

public class OrderEndpointAdditionalTests : TestBase
{
    private IOrderEndpoint Endpoint => GetService<IOrderEndpoint>();

    [Fact]
    public async Task GetLayoutsAsync_Should_UseCorrectPath()
    {
        var response = new Response<string> { ErrorCode = 0, Data = "[{\"Id\":1}]" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/layouts").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetLayoutsAsync();

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetPatchableFieldsAsync_Should_UseCorrectPath()
    {
        var response = new Response<string> { ErrorCode = 0, Data = "[\"State\",\"Tags\"]" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/patchablefields").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetPatchableFieldsAsync();

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task PatchOrderAsync_Should_UsePatch()
    {
        var response = new Response<string> { ErrorCode = 0, Data = "{}" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/10").UsingPatch())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var fields = new Dictionary<string, object> { ["State"] = 8 };
        var result = await Endpoint.PatchOrderAsync(10, fields);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/10" &&
            e.RequestMessage.Method == "PATCH");
    }

    [Fact]
    public async Task GetInvoicesAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<Invoice>
        {
            ErrorCode = 0,
            Data = [new Invoice()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/invoices").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetInvoicesAsync();

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task AddAsync_WithShopId_Should_UsePost()
    {
        var order = new Order();
        var response = new Response<Order> { ErrorCode = 0, Data = order };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.AddAsync(order, 42);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task AddTagsAsync_Should_UsePost()
    {
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/3/tags").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.AddTagsAsync(3, ["urgent", "vip"]);

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/3/tags" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task UpdateTagsAsync_Should_UsePut()
    {
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/3/tags").UsingPut())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.UpdateTagsAsync(3, ["urgent"]);

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/3/tags" &&
            e.RequestMessage.Method == "PUT");
    }

    [Fact]
    public async Task AddInvoiceAsync_Should_UsePost()
    {
        var response = new Response<Invoice> { ErrorCode = 0, Data = new Invoice() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/CreateInvoice/20").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.AddInvoiceAsync(20);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/CreateInvoice/20" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task SendMailAsync_Should_UsePost()
    {
        var message = new SendMessage();
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/5/send-message").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.SendMailAsync(5, message);

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/5/send-message" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task CreateEventAsync_Should_UsePost()
    {
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/7/trigger-event").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.CreateEventAsync(7, "TestEvent");

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders/7/trigger-event" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task UpdateAsync_Should_UsePut()
    {
        var order = new Order { BillBeeOrderId = 99 };
        var response = new Response<Order> { ErrorCode = 0, Data = order };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders").UsingPut())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.UpdateAsync(order);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/orders" &&
            e.RequestMessage.Method == "PUT");
    }

    [Fact]
    public async Task GetAllAsync_WithDateFilters_Should_UseCorrectPath()
    {
        var response = new PagedResponse<Order>
        {
            ErrorCode = 0,
            Data = [new Order()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var minDate = new System.DateTime(2024, 1, 1);
        var maxDate = new System.DateTime(2024, 12, 31);
        var result = await Endpoint.GetAllAsync(
            minOrderDate: minDate,
            maxOrderDate: maxDate,
            shopId: [1, 2],
            orderStateId: [OrderStateEnum.Versendet],
            tag: ["vip"],
            minimumBillBeeOrderId: 100,
            modifiedAtMin: minDate,
            modifiedAtMax: maxDate,
            excludeTags: true
        );

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetInvoicesAsync_WithFilters_Should_UseCorrectPath()
    {
        var response = new PagedResponse<Invoice>
        {
            ErrorCode = 0,
            Data = [new Invoice()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/invoices").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var minDate = new System.DateTime(2024, 1, 1);
        var result = await Endpoint.GetInvoicesAsync(
            minInvoiceDate: minDate,
            maxInvoiceDate: minDate,
            shopId: [1],
            orderStateId: [1],
            tag: ["paid"],
            minPayDate: minDate,
            maxPayDate: minDate,
            includePositions: true,
            excludeTags: false
        );

        result.Should().HaveCount(1);
    }
}
