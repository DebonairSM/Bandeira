using Bandeira.Application.Abstractions.Messaging;
using Bandeira.Application.Cards;

namespace Bandeira.Api.Application.Cards
{
    public sealed record GetBalanceQuery(string cardNumber) 
        : IQuery<CardBalanceResponse>;
}