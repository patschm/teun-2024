using ACME.Domain.Reviews.Repositories;
using ACME.Infrastructure.Reviews.Commands;
using MediatR;

namespace ACME.Infrastructure.Reviews.Handlers;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
{
    private readonly IReviewWriteRepository _repository;

    public CreateReviewCommandHandler(IReviewWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(request.Review);
    }
}
