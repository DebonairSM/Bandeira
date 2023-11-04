using Bandeira.Domain.Abstractions;
using Bandeira.Domain.Shared;

namespace Bandeira.Domain.Persons;

public sealed class Person : Entity<PersonId>
{
    public Person(
        PersonId id,
        string name,
        string description,
        string address,
        Money price)
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
    }

    private Person()
    {
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Address { get; private set; }

    public Money Price { get; private set; }


}
