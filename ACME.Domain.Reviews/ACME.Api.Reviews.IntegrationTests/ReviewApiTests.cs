using ACME.Api.Reviews.IntegrationTests.Fixtures;
using ACME.Api.Reviews.IntegrationTests.MemoryRepository;
using ACME.Domain.Reviews.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ACME.Api.Reviews.IntegrationTests;

public class ReviewApiTests
{
    [Fact]
    public async Task GetResults_Should_Return_Ok()
    {
        var web = new WebApplicationFixture();
  
        var client = web.CreateClient();
        var result = await client.GetAsync("reviews");

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
    [Fact]
    public async Task GetResult_Should_Return_Ok()
    {
        var web = new WebApplicationFixture();

        var client = web.CreateClient();
        var result = await client.GetAsync("reviews/1");

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.NotNull(result.Content);
    }
    [Fact]
    public async Task GetResult_Should_Return_NotFound()
    {
        var web = new WebApplicationFixture();

        var client = web.CreateClient();
        var result = await client.GetAsync("reviews/111");

        Assert.NotNull(result);
        Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
    }
}