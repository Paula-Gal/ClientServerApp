using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain;
using Model.Validators;

namespace Model.Validators
{
    public class FlightValidator : IValidator<Flight>
    {
        public void Validate(Flight entity)
        {
            IList<string> errors = new List<string>();

        }
    }
}
