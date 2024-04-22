using ACME.Api.Reviews.DTO;
using ACME.Domain.Reviews.Entities;

namespace ACME.Api.Reviews.Mapping;

public static class ReviewMapping
{
    public static ReviewDTO ToDTOReview(this Review review)
    {
        return new ReviewDTO
        {
            Id = review.Id,
            ProductId = review.Product.Id,
            PurchaseDate = new DateTime(review.PurchaseDate.Year, review.PurchaseDate.Month, review.PurchaseDate.Day),
            ReviewerId = review.Reviewer.Id,
            ReviewerName = review.Reviewer.Name,
            Score = review.Score.Value,
            Text = review.Text
        };
    }

    public static Review ToDomainReview(this ReviewDTO review) 
    {
        return Review.Create(
            review.Id,
            new Product(review.ProductId),
            new Reviewer(review.ReviewerId, review.ReviewerName),
            review.Score,
            review.Text ?? "",
            review.PurchaseDate);
    }
}
