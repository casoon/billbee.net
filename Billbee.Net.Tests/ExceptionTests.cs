using System.Net;
using Billbee.Net.Exceptions;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace Billbee.Net.Tests;

public class ExceptionTests : TestBase
{
    [Fact]
    public void ServerErrorException_Should_StoreStatusCode()
    {
        var ex = new ServerErrorException(503);

        ex.StatusCode.Should().Be(503);
        ex.Message.Should().Contain("503");
    }

    [Fact]
    public void ServerErrorException_Should_FormatMessageWithStatusCode()
    {
        var ex = new ServerErrorException(500);

        ex.Message.Should().Be("Server error (HTTP 500)");
    }

    [Fact]
    public async Task GetAsync_Should_ThrowServerErrorException_On500()
    {
        MockServer
            .Given(Request.Create().WithPath("/api/v1/orders/1").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.InternalServerError));

        var client = GetService<IBillbeeClient>();

        await Assert.ThrowsAsync<ServerErrorException>(() => client.GetAsync<object>("orders/1"));
    }

    [Fact]
    public void ApiException_Should_AcceptMessageOnly()
    {
        var ex = new ApiException("Something went wrong");

        ex.Message.Should().Be("Something went wrong");
    }

    [Fact]
    public void ApiException_Should_AcceptMessageAndInnerException()
    {
        var inner = new InvalidOperationException("inner");
        var ex = new ApiException("outer", inner);

        ex.Message.Should().Be("outer");
        ex.InnerException.Should().BeSameAs(inner);
    }
}
