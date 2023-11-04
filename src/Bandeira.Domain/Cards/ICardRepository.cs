using Bandeira.Domain.Persons;

namespace Bandeira.Domain.Cards;

public interface ICardRepository
{
    Task<Card?> GetByIdAsync(CardId id, CancellationToken cancellationToken = default);

    void Add(Card booking);
}
