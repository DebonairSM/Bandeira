namespace Bandeira.Domain.Cards
{
    public record CardId(Guid Value)
    {
        public static CardId New() => new(Guid.NewGuid());
    }
}