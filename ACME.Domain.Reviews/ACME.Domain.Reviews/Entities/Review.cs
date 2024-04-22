using ACME.Domain.Reviews.ValueObjects;

namespace ACME.Domain.Reviews.Entities;

public sealed class Review
{
    private Review(long id, Product product, Reviewer reviewer, Score score, string text, Date purchaseDate)
    {
        Id = id;
        Product = product;
        Reviewer = reviewer;
        Score = score;
        Text = text;
        PurchaseDate = purchaseDate;
    }

    public long Id { get; private set; }
    public Product Product { get; private set; }
    public Reviewer Reviewer { get; set; }
    public Score Score { get; private set; }
    public string Text { get; private set; }
    public Date PurchaseDate { get; private set; }

    public static Review Create(long id, Product product, Reviewer reviewer, Score score, string text, Date purchaseDate)
    {
        return new Review(id, product, reviewer,score, text, purchaseDate);
    }
}
