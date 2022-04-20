using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validators
{
    public interface IValidator<E>
    {
        void Validate(E entity);
    }
}
