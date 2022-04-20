using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Proiect_CSharp_MPP.TouristAgency.Validators
{
    public class FlightValidator : IValidator<Flight>
    {
        public void Validate(Flight entity)
        {
            IList<string> errors = new List<string>();

        }
    }
}
