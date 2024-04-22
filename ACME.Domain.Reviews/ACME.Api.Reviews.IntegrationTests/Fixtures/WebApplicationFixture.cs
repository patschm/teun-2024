using ACME.Api.Reviews.IntegrationTests.MemoryRepository;
using ACME.Domain.Reviews.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ACME.Api.Reviews.IntegrationTests.Fixtures;

public class WebApplicationFixture: WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
        });
        base.ConfigureWebHost(builder);
    }
}
