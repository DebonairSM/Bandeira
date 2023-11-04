using Bandeira.Application.Abstractions.Messaging;
using Bandeira.Domain.Persons;

namespace Bandeira.Application.Cards;

public record IssueNewCardCommand(Guid PersonId) : ICommand<Guid>;