namespace ACME.Api.Reviews.DTO;

public class ReviewDTO
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public long ReviewerId { get; set; }
    public string? ReviewerName { get; set; }
    public byte Score { get; set; }
    public string? Text { get; set; }
    public DateTime PurchaseDate { get; set; }
}
