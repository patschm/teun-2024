using ACME.Domain.Reviews.Entities;
using MediatR;

namespace ACME.Infrastructure.Reviews.Commands;

public record ReadReviewCommand(long Id) : IRequest<Review>;
