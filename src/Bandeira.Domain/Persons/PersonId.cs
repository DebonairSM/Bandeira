namespace Bandeira.Domain.Persons;

public record PersonId(Guid Value)
{
    public static PersonId New() => new(Guid.NewGuid());
}
