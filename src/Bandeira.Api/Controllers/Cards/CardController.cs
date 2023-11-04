using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Cryptography;
using System.Text;
using Bandeira.Application.Persons.SearchPersons;
using System.Threading;
using Bandeira.Api.Application.Cards;

namespace Bandeira.Api.Controllers.Cards
{
    [Authorize]
    [ApiController]
        [Route("api/cards")]
        public class CardController : ControllerBase
        {
            // This would normally be stored in a database
            private static readonly List<Card> Cards = new List<Card>();

        private readonly ISender _sender;

        public CardController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("create")]
            public ActionResult<Card> CreateCard()
            {
                var cardNumber = GenerateCardNumber();
                var card = new Card { CardNumber = cardNumber, Balance = 0 };
                Cards.Add(card);
                return Ok(card);
            }

            [HttpPost("pay")]
            public ActionResult Pay(string cardNumber, double amount)
            {
                var card = Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
                if (card == null)
                {
                    return NotFound("Card not found");
                }

                card.Balance += amount;
                return Ok(new { Balance = card.Balance });
            }

        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance(string cardNumber, CancellationToken cancellationToken)
            {
                var query = new GetBalanceQuery(cardNumber);
                var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);

            }

    }
    

}
