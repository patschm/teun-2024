using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.ValueObjects;

namespace ACME.Domain.Reviews.Repositories;

public interface IReviewReadRepository
{
    Task<IEnumerable<Review>> GetAllAsync(ReviewParameters paramaters);
    Task<IEnumerable<Review>> GetByProductAsync(Product product, ReviewParameters parameters);
    Task<Review> GetByIdAsync(long id);
}
