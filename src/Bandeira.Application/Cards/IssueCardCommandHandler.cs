using Bandeira.Application.Abstractions.Clock;
using Bandeira.Application.Abstractions.Messaging;
using Bandeira.Application.Cards;
using Bandeira.Domain.Abstractions;
using Bandeira.Domain.Cards;
using Bandeira.Domain.Persons;
using MediatR;

namespace Bookify.Application.Cards;

internal sealed class IssueNewCardCommandHandler : ICommandHandler<IssueNewCardCommand, Guid>
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public IssueNewCardCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(IssueNewCardCommand request, CancellationToken cancellationToken)
    {
        var personId = new PersonId(request.PersonId);
        var issuedToPerson = _personRepository.GetByIdAsync(personId,cancellationToken).Result;

        var newCard = Card.Create(issuedToPerson, new CardIssuingService()).Value;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newCard.Id.Value;
    }

}