using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using EShopService;

namespace EShopService.IntegrationTests;

public class CreditCardControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CreditCardControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Post_ValidCard_ShouldReturnOk()
    {
        var validCard = "4111111111111111"; 

        var response = await _client.PostAsJsonAsync("/api/creditcard", validCard);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task Post_TooLongCard_ShouldReturn414()
    {
        var longCard = new string('4', 30); 

        var response = await _client.PostAsJsonAsync("/api/creditcard", longCard);
        response.StatusCode.Should().Be((System.Net.HttpStatusCode)414);
    }

    [Fact]
    public async Task Post_TooShortCard_ShouldReturn400()
    {
        var shortCard = "123"; 

        var response = await _client.PostAsJsonAsync("/api/creditcard", shortCard);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Post_InvalidCard_ShouldReturn400()
    {
        var invalidCard = "abcdefghijk";

        var response = await _client.PostAsJsonAsync("/api/creditcard", invalidCard);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Post_UnsupportedProvider_ShouldReturn406()
    {
        var unsupportedCard = "7777777777777777"; 

        var response = await _client.PostAsJsonAsync("/api/creditcard", unsupportedCard);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotAcceptable);
    }
}
