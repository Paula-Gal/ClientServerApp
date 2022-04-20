using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Domain;

namespace Persistence
{
    public interface ICustomerRepository : ICRUDRepository<int, Customer>
    {
        Customer FindByCnp(string cnp);
    }
}
