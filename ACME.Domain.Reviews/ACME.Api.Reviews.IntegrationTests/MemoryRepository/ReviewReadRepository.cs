using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.Exceptions;
using ACME.Domain.Reviews.Repositories;
using ACME.Domain.Reviews.ValueObjects;

namespace ACME.Api.Reviews.IntegrationTests.MemoryRepository;

public class ReviewReadRepository : IReviewReadRepository
{
    private readonly List<Review> _reviewList = new List<Review>();

    public ReviewReadRepository()
    {
        _reviewList.Add(Review.Create(1, new Product(1), new Reviewer(1, "henk"), 3, "Text", new Date(2002, 1, 1)));
    }

    public Task<IEnumerable<Review>> GetAllAsync(ReviewParameters paramaters)
    {
        return Task.FromResult(_reviewList.AsEnumerable());
    }

    public Task<Review> GetByIdAsync(long id)
    {
        var review = _reviewList.FirstOrDefault(r => r.Id == id);
        if (review == null)
        {
            throw new ReviewNotFoundException(id);
        }
        return Task.FromResult(_reviewList.First(r=>r.Id == id));
    }

    public Task<IEnumerable<Review>> GetByProductAsync(Product product, ReviewParameters parameters)
    {
        return Task.FromResult(_reviewList.AsEnumerable());
    }
}
