using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.ValueObjects;
using MediatR;

namespace ACME.Infrastructure.Reviews.Commands;

public record ReadReviewsCommand(ReviewParameters Parameters) : IRequest<IEnumerable<Review>>;

