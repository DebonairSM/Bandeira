using Bandeira.Domain.Persons;

namespace Bandeira.Infrastructure.Repositories;

internal sealed class PersonRepository : Repository<Person, PersonId>, IPersonRepository
{
    public PersonRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
