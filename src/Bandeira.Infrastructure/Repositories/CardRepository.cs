using Bandeira.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Bandeira.Domain.Cards;
using Bandeira.Domain.Shared;

namespace Bandeira.Infrastructure.Repositories;

internal sealed class CardRepository : Repository<Card, CardId>, ICardRepository
{
    public CardRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
