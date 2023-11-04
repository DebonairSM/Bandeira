using Bandeira.Domain.Persons;
using Bandeira.Domain.Bookings;
using Bandeira.Domain.Shared;
using Bandeira.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bandeira.Domain.Cards;

namespace Bandeira.Infrastructure.Configurations;

internal sealed class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("cards");

        builder.HasKey(card => card.Id);

        builder.Property(card => card.Id)
            .HasConversion(card => card.Value, value => new CardId(value));

        builder.Property(card => card.CardNumber);

        builder.OwnsOne(card => card.CardBalance, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(card => card.CardIssuedTo);
    }
}
