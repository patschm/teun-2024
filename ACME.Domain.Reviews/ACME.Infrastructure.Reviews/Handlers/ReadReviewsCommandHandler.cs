using ACME.Domain.Reviews.Entities;
using ACME.Domain.Reviews.Repositories;
using ACME.Infrastructure.Reviews.Commands;
using MediatR;

namespace ACME.Infrastructure.Reviews.Handlers;

public class ReadReviewsCommandHandler : IRequestHandler<ReadReviewsCommand, IEnumerable<Review>>
{
    private readonly IReviewReadRepository _repository;

    public ReadReviewsCommandHandler(IReviewReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Review>> Handle(ReadReviewsCommand request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(request.Parameters);
    }
}
