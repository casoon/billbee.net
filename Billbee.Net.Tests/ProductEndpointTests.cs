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

public class ProductEndpointTests : TestBase
{
    private ProductEndpoint Endpoint => (ProductEndpoint)GetService<IProductEndpoint>();

    [Fact]
    public async Task GetAllAsync_Should_UseGet()
    {
        var response = new PagedResponse<Product>
        {
            ErrorCode = 0,
            Data = [new Product()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/products").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAllAsync();

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAsync_Should_UseCorrectPath()
    {
        var response = new Response<Product> { ErrorCode = 0, Data = new Product() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/products/10").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.GetAsync(10);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateStockAsync_Should_UsePost()
    {
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/products/updatestock").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.UpdateStockAsync(0, new UpdateStock());

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/products/updatestock" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task UpdateStockMultipleAsync_Should_UsePost()
    {
        var response = new Response<object> { ErrorCode = 0, Data = new object() };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/products/updatestockmultiple").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Endpoint.UpdateStockMultipleAsync(0, []);

        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage.Path == "/api/v1/products/updatestockmultiple" &&
            e.RequestMessage.Method == "POST");
    }

    [Fact]
    public async Task AddProductImageAsync_Should_RejectNonZeroId()
    {
        var image = new ArticleImage { Id = 99 };

        var act = () => Endpoint.AddProductImageAsync(image);

        await Assert.ThrowsAsync<Exception>(act);
    }

    [Fact]
    public async Task UpdateProductImageAsync_Should_RejectZeroId()
    {
        var image = new ArticleImage { Id = 0 };

        var act = () => Endpoint.UpdateProductImageAsync(image);

        await Assert.ThrowsAsync<Exception>(act);
    }

    [Fact]
    public async Task GetAllAsync_Should_ThrowApiException_WhenApiReturnsError()
    {
        var response = new PagedResponse<Product> { ErrorCode = 404, ErrorMessage = "Not found" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/products").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.GetAllAsync());
    }
}
