using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_CSharp_MPP.TouristAgency.Validators
{
    public interface IValidator<E>
    {
        void Validate(E entity);
    }
}
