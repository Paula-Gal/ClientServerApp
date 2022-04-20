using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Domain;

namespace Persistence
{
    public interface IEmployeeRepository : ICRUDRepository<int, Employee>
    {
        Employee FindByUsername(string username);
    }
}
