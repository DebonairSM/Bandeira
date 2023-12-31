using Bandeira.Domain.Persons;
using Bandeira.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bandeira.Infrastructure.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons");

        builder.HasKey(person => person.Id);

        builder.Property(person => person.Id)
            .HasConversion(personId => personId.Value, value => new PersonId(value));

        builder.OwnsOne(person => person.Address);

        builder.Property(person => person.Name)
            .HasMaxLength(200);

        builder.Property(person => person.Description)
            .HasMaxLength(2000);

        builder.OwnsOne(person => person.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.Property<uint>("Version").IsRowVersion();
    }
}
