using Bandeira.Domain.Abstractions;
using Bandeira.Domain.Shared;

namespace Bandeira.Domain.Persons;

public sealed class Person : Entity<PersonId>
{
    public Person(
        PersonId id,
        Name name,
        Description description,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities)
        : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        ServiceFee = cleaningFee;
        Amenities = amenities;
    }

    private Person()
    {
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money Price { get; private set; }

    public Money ServiceFee { get; private set; }

    public DateTime? LastBookedOnUtc { get; internal set; }

    public List<Amenity> Amenities { get; private set; } = new();
}
