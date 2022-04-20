using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain;
using Model.Validators;

namespace Model.Validators
{
    public class TicketValidator : IValidator<Ticket>
    {
        public void Validate(Ticket ticket)
        {
            IList<string> errors = new List<string>();

            if(ticket.NumberOfPlaces <= 0)
            {
                errors.Add("The ticket must contain at least one person!\n");
            }

            string errorMessage = errors
                .ToList()
                .Aggregate("", string.Concat);
            if (errorMessage.Length > 0)
            {
                throw new ValidationException(errorMessage);
            }
        }
    }
}
