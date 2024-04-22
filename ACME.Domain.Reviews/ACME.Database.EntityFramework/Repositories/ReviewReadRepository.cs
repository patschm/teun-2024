using ACME.Database.EntityFramework.Mapping;
using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.Exceptions;
using ACME.Domain.Reviews.Repositories;
using ACME.Domain.Reviews.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ACME.Database.EntityFramework.Repositories;

public class ReviewReadRepository : IReviewReadRepository
{
    private readonly ShopContext _shopContext;

    public ReviewReadRepository(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    public async Task<IEnumerable<Review>> GetAllAsync(ReviewParameters par)
    {
        var query = _shopContext.Reviews
            .Skip((par.Page - 1) * par.Amount)
            .Take(par.Amount)
            .Where(r=>r.Reviewer != null)
            .Select(r => r.ToDomainReview());

        return await query.ToListAsync();
    }

    public async Task<Review> GetByIdAsync(long id)
    {
        var review = await _shopContext.Reviews.FindAsync(id);
        if (review == null)
        {
            throw new ReviewNotFoundException(id);
        }
        return review.ToDomainReview();
    }

    public async Task<IEnumerable<Review>> GetByProductAsync(Product product, ReviewParameters par)
    {
        var query = _shopContext.Reviews
            .Skip((par.Page - 1) * par.Amount)
            .Take(par.Amount)
            .Where(r => r.ProductId == product.Id && r.Reviewer != null)
            .Select(r => r.ToDomainReview());

        return await query.ToListAsync();
    }
}
