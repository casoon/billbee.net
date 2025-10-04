using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Billbee.Net.Endpoints;
using System.Net;
using Xunit;
using Billbee.Net.Responses;
using Billbee.Net.Exceptions;

namespace Billbee.Net.Tests;

/// <summary>
/// Tests for BillbeeClient functionality
/// </summary>
public class BillbeeClientTests : TestBase
{
    [Fact]
    public async Task GetAsync_Should_ReturnData_When_ApiReturnsSuccess()
    {
        // Arrange
        var expectedData = new { Id = 1, Name = "Test Order" };
        var expectedResponse = new Response<object>
        {
            ErrorCode = 0,
            ErrorMessage = "",
            Data = expectedData
        };
        
        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/1").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(expectedResponse));

        var client = GetService<IBillbeeClient>();

        // Act
        var result = await client.GetAsync<object>("orders/1");

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAsync_Should_ReturnData_When_ApiReturnsDelayedResponse()
    {
        // Arrange
        var expectedData = new { Id = 1, Name = "Test Order" };
        var expectedResponse = new Response<object>
        {
            ErrorCode = 0,
            ErrorMessage = "",
            Data = expectedData
        };
        
        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/1").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(expectedResponse)
                .WithDelay(100)); // Add a small delay to simulate slower response

        var client = GetService<IBillbeeClient>();

        // Act
        var result = await client.GetAsync<object>("orders/1");

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAsync_Should_HandleErrorResponse_Properly()
    {
        // Arrange
        var errorResponse = new Response<object>
        {
            ErrorCode = 404,
            ErrorMessage = "Order not found",
            Data = null!
        };
        
        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/999").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK) // HTTP 200 but API error
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(errorResponse));

        var client = GetService<IBillbeeClient>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ApiException>(() => client.GetAsync<object>("orders/999"));
        exception.Message.Should().Contain("Order not found");
        exception.Message.Should().Contain("404");
    }
}