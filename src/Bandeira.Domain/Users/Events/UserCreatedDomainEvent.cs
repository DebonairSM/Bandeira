using Bandeira.Domain.Abstractions;

namespace Bandeira.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;
