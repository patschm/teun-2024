using ACME.Domain.Reviews.Entities;

namespace ACME.Database.EntityFramework.Mapping;

public static class ReviewMapping
{
    public static Review ToDomainReview(this Models.Review r)
    {
        return Review.Create(
                r.Id,
                new Product(r.ProductId),
                new Reviewer(r.ReviewerId ?? 0, r.Reviewer!.Name),
                r.Score,
                r.Text ?? "",
                r.DateBought ?? DateTime.Now);
    }
    public static Models.Review ToEntityReview(this Review r) 
    {
        return new Models.Review
        {
            Id = r.Id,
            DateBought = new DateTime(r.PurchaseDate.Year, r.PurchaseDate.Month, r.PurchaseDate.Day),
            ReviewerId = r.Reviewer.Id,
            ProductId = r.Product.Id,
            Score = r.Score.Value,
            Text = r.Text,
            ReviewType = 1
        };
    }
}
