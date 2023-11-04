using Bandeira.Domain.Persons;

namespace Bandeira.Domain.Persons;

public interface IPersonRepository
{
    Task<Person?> GetByIdAsync(PersonId id, CancellationToken cancellationToken = default);

    void Add(Person person);
}