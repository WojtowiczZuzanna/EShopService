using System.Diagnostics;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using EShop.Domain.Models;
using EShopService;
using Xunit.Abstractions;

namespace EShopService.IntegrationTests;

public class RecordTimeOf10000Items : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public RecordTimeOf10000Items(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    [Fact]
    public async Task Post_AddThousandsProducts_ExceptedThousandsProducts()
    {
        // Arrange
        var products = new List<Product>();
        for (int i = 0; i < 10_000; i++)
        {
            products.Add(new Product { Name = $"Product_{i}" });
        }

        var stopwatch = Stopwatch.StartNew();

        // Act
        foreach (var product in products)
        {
            var response = await _client.PostAsJsonAsync("/api/product", product);
            response.EnsureSuccessStatusCode();
        }

        stopwatch.Stop();

        // Assert
        var responseAll = await _client.GetAsync("/api/product");
        responseAll.EnsureSuccessStatusCode();
        var allProducts = await responseAll.Content.ReadFromJsonAsync<List<Product>>();

        allProducts.Should().HaveCountGreaterThanOrEqualTo(10_000);

        var seconds = stopwatch.Elapsed.TotalSeconds;
        _output.WriteLine($"Inserted 10,000 products in {seconds:F2} seconds.");
    }

    [Fact]
    public async Task Post_AddThousandsProductsAsync_ExceptedThousandsProducts()
    {
        // Arrange
        var stopwatch = Stopwatch.StartNew();

        var tasks = new List<Task<HttpResponseMessage>>();
        for (int i = 1; i <= 10_000; i++)
        {
            var product = new Product { Name = $"Product {i}" };
            tasks.Add(_client.PostAsJsonAsync("/api/product", product));
        }

        // Act
        await Task.WhenAll(tasks);
        stopwatch.Stop();

        // Assert
        var products = await _client.GetFromJsonAsync<List<Product>>("/api/product");
        products.Should().NotBeNull();
        products.Count.Should().BeGreaterThanOrEqualTo(10_000);

        _output.WriteLine($"Inserted 10,000 products asynchronously in {stopwatch.ElapsedMilliseconds} ms");
    }
}
