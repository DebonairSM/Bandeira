using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.Domain.Cards
{
    public class CardIssuingService
    {
        public CardIssuingService() { }

        internal bool IsAuthorisedByVerficationService(Card newCard)
        {
            if (int.TryParse(newCard.CardNumber, out int number))
            {
                return number % 2 == 0;
            }
            else
            {
                throw new ArgumentException("The input is not a valid integer.");
            }
        }
    }
}
