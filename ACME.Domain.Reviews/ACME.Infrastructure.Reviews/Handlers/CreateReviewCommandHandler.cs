using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.Repositories;
using ACME.Infrastructure.Reviews.Commands;
using MediatR;

namespace ACME.Infrastructure.Reviews.Handlers;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Review>
{
    private readonly IReviewWriteRepository _repository;

    public CreateReviewCommandHandler(IReviewWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
       return  await _repository.CreateAsync(request.Review);
    }
}
