using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Proiect_CSharp_MPP.TouristAgency.Validators
{
    public class EmployeeValidator : IValidator<Employee>
    {
        public void Validate(Employee employee)
        {
            IList<string> errors = new List<string>();
            
            if(employee.Username.Trim().Equals(""))
            {
                errors.Add("Invalid username!\n");
            }

            if(employee.Username.Trim().Length < 6)
            {
                errors.Add("The password must have at least 6 characters! Whitespaces are not allowed!");
            }

            string errorMessage = errors
                .ToList()
                .Aggregate("", string.Concat);
            if(errorMessage.Length > 0)
            {
                throw new ValidationException(errorMessage);
            }

        }
    }
}
