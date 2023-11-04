using Bandeira.Domain.Persons;
using Bandeira.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using Bandeira.Domain.Cards;
using Bandeira.Domain.Shared;

namespace Bandeira.Infrastructure.Repositories;

internal sealed class CardRepository : Repository<Card, CardId>, ICardRepository
{
    private static readonly CardStatus[] CardStatuses =
    {
        CardStatus.Active,
        CardStatus.LostOrStolen,
        CardStatus.NotActivated
    };

    public CardRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<bool> IsOverlappingAsync(
        Person person,
        DateRange duration,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Booking>()
            .AnyAsync(
                booking =>
                    booking.PersonId == person.Id &&
                    booking.Duration.Start <= duration.End &&
                    booking.Duration.End >= duration.Start &&
                    ActiveCardStatuses.Contains(booking.Status),
                cancellationToken);
    }
}
