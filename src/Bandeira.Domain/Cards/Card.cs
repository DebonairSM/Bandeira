using Bandeira.Domain.Abstractions;
using Bandeira.Domain.Cards.Events;
using Bandeira.Domain.Persons;
using Bandeira.Domain.Reviews;
using Bandeira.Domain.Shared;
using System.Security.Cryptography;

namespace Bandeira.Domain.Cards
{
    public sealed class Card : Entity<CardId>
    {
        private Card() { }
        private Card(
            CardId id,
            string cardNumber,
            Person cardIssuedTo
            ) : base(id)
        {
            CardNumber = cardNumber;
            CardIssuedTo = cardIssuedTo;
        }

        public CardId CardId {  get; private set; }
        public string CardNumber {  get; private set; }
        public Money CardBalance {  get; private set; }
        public Person CardIssuedTo { get; private set; }

        public static Result<Card> Create(Person cardIssuedTo)
        {
           var newCard = new Card(
                CardId.New(),
                GenerateCardNumber(),
                cardIssuedTo);
            
            if (newCard.Status != CardStatus.Completed)
            {
                return Result.Failure<Card>(CardErrors.NotEligible);
            }

            newCard.RaiseDomainEvent(new CardNumberGeneratedDomainEvent(newCard.Id));
            return newCard;
        }
        private static string GenerateCardNumber()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[8];
                rng.GetBytes(randomNumber);
                return BitConverter.ToUInt64(randomNumber, 0).ToString().PadLeft(15, '0');
            }
        }
    }
}
