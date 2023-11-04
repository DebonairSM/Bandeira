using Bandeira.Domain.Abstractions;

namespace Bandeira.Domain.Persons;

public static class PersonErrors
{
    public static Error NotFound = new(
        "Property.Found",
        "The property with the specified identifier was not found");
}
