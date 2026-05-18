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

public class EventEndpointTests : TestBase
{
    private IEventEndpoint Endpoint => GetService<IEventEndpoint>();

    [Fact]
    public async Task GetAllAsync_Should_UseCorrectPath()
    {
        var response = new PagedResponse<Event>
        {
            ErrorCode = 0,
            Data = [new Event()]
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/events").UsingGet())
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
        var response = new PagedResponse<Event> { ErrorCode = 404, ErrorMessage = "Not found" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/events").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.GetAllAsync());
    }
}
