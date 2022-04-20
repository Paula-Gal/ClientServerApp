using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Proiect_CSharp_MPP.TouristAgency.Validators
{
    public class CustomerValidator : IValidator<Customer>
    {
        public void Validate(Customer tourist)
        {
            IList<string> errors = new List<string>();

            if(tourist.Name.Trim().Equals(""))
            {
                errors.Add("The name cannot be empty!\n");
            }

            if(tourist.Address.Trim().Equals(""))
            {
                errors.Add("Invalid address!\n");
            }

            Regex regex = new Regex("[0-9]{13}", RegexOptions.Compiled);

            if(!regex.IsMatch(tourist.CNP))
            {
                errors.Add("Invalid CNP! The CNP must have exactly 13 digits!");
            }

            string errorMessaage = errors
                .ToList()
                .Aggregate("", string.Concat);
            if(errorMessaage.Length > 0)
            {
                throw new ValidationException(errorMessaage);
            }

        }
    }
}
