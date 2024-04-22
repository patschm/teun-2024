using ACME.Domain.Reviews.Entities;
using MediatR;

namespace ACME.Infrastructure.Reviews.Commands;

public record CreateReviewCommand(Review review) : IRequest;

