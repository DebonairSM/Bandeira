using Bandeira.Domain.Abstractions;

namespace Bandeira.Domain.Cards.Events;

public sealed record CardNumberGeneratedDomainEvent(CardId CardId) : IDomainEvent;
