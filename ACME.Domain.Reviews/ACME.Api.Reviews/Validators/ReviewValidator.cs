using ACME.Api.Reviews.DTO;
using FluentValidation;

namespace ACME.Api.Reviews.Validators;

public class ReviewValidator : AbstractValidator<ReviewDTO>

{
    public ReviewValidator()
    {
        RuleFor(b => b.PurchaseDate).NotEmpty()
            .GreaterThanOrEqualTo(r => new DateTime(2000, 1, 1));
        RuleFor(b => b.ReviewerId).NotEmpty();
        RuleFor(b => b.Text).NotEmpty().MaximumLength(1024);
        RuleFor(b => b.Score).NotEmpty().InclusiveBetween((byte)1, (byte)5);
        RuleFor(b => b.ProductId).NotEmpty();
    }
}
