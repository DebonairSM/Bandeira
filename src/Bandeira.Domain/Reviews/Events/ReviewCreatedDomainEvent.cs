using Bandeira.Domain.Abstractions;

namespace Bandeira.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(ReviewId ReviewId) : IDomainEvent;
