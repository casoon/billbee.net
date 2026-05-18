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

public class AutomaticProvisionEndpointTests : TestBase
{
    private IAutomaticProvisionEndpoint Endpoint => GetService<IAutomaticProvisionEndpoint>();

    [Fact]
    public async Task TermsInfoAsync_Should_UseCorrectPath()
    {
        var response = new Response<TermsResult>
        {
            ErrorCode = 0,
            Data = new TermsResult { LinkToTermsWebPage = "https://example.com/terms" }
        };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/automaticprovision/termsinfo").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.TermsInfoAsync();

        result.Should().NotBeNull();
        result.LinkToTermsWebPage.Should().Be("https://example.com/terms");
    }

    [Fact]
    public async Task TermsInfoAsync_Should_ThrowApiException_WhenApiReturnsError()
    {
        var response = new Response<TermsResult> { ErrorCode = 500, ErrorMessage = "Server error" };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/automaticprovision/termsinfo").UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        await Assert.ThrowsAsync<ApiException>(() => Endpoint.TermsInfoAsync());
    }

    [Fact]
    public async Task CreateAccountAsync_Should_UsePost()
    {
        var account = new Account { EMail = "test@example.com" };
        var response = new Response<Account> { ErrorCode = 0, Data = account };

        MockServer
            .Given(Request.Create().WithPath("/api/v1/automaticprovision/createaccount/").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBodyAsJson(response));

        var result = await Endpoint.CreateAccountAsync(account);

        result.Should().NotBeNull();
        MockServer.LogEntries.Should().Contain(e =>
            e.RequestMessage!.Path == "/api/v1/automaticprovision/createaccount/" &&
            e.RequestMessage.Method == "POST");
    }
}
