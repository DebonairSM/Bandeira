using Bandeira.Domain.Abstractions;

namespace Bandeira.Domain.Cards
{
    public static class CardErrors
    {
        public static readonly Error NotEligible = new(
    "Card.NotEligible", "The issuing service has determined that this person is not currently eligble to receive this card.");

        public static readonly Error CardIsNotANumber = new(
    "Card.NotANumber", "Card generated is not a number.");

    }
}