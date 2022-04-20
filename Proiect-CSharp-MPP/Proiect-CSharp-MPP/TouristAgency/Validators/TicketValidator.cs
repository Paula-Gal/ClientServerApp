using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Proiect_CSharp_MPP.TouristAgency.Validators
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
