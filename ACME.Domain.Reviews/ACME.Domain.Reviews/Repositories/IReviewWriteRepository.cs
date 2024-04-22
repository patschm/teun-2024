using ACME.Domain.Reviews.Entities;

namespace ACME.Domain.Reviews.Repositories;

public interface IReviewWriteRepository
{
    Task CreateAsync(Review review);
}
