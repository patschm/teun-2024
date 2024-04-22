using ACME.Database.EntityFramework.Mapping;
using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.Repositories;

namespace ACME.Database.EntityFramework.Repositories;

public class ReviewWriteRepository : IReviewWriteRepository
{
    private readonly ShopContext _shopContext;

    public ReviewWriteRepository(ShopContext shopContext)
    {
        _shopContext = shopContext;
    }

    public async Task CreateAsync(Review review)
    {
        var dbReview = review.ToEntityReview();
        //dbReview.Id = 0;
        _shopContext.Reviews.Add(dbReview);
        await _shopContext.SaveChangesAsync();
    }
}
