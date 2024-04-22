using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.Repositories;

namespace ACME.Api.Reviews.IntegrationTests.MemoryRepository;

public class ReviewWriteRepository : IReviewWriteRepository
{
    public Task CreateAsync(Review review)
    {
        return Task.CompletedTask;
    }
}
