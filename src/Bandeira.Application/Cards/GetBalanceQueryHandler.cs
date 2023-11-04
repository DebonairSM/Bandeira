
using Bandeira.Api.Application.Cards;
using Bandeira.Application.Abstractions.Data;
using Bandeira.Application.Abstractions.Messaging;
using Bandeira.Application.Persons.SearchPersons;
using Bandeira.Domain.Abstractions;
using Dapper;

namespace Bandeira.Application.Cards
{
    internal sealed class GetBalanceQueryHandler
        : IQueryHandler<GetBalanceQuery, CardBalanceResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBalanceQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<Result<CardBalanceResponse>> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            if (request.cardNumber == "")
            {
                return new CardBalanceResponse();
            }
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
            SELECT
                cardnumber AS CardNumber,
                cardbalance AS CardBalance
            FROM cards
            WHERE CardNumber = @CardNumber
            """;

            var cardBalance = await connection
                .QuerySingleAsync<CardBalanceResponse>(
                sql,
                new
                {
                    request.cardNumber
                });

            return cardBalance;
        }
    }
}
