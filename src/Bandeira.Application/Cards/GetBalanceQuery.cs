using Bandeira.Application.Abstractions.Messaging;
using Bandeira.Application.Cards;

namespace Bandeira.Application.Cards
{
    public sealed record GetBalanceQuery(string cardNumber) 
        : IQuery<CardBalanceResponse>;
}