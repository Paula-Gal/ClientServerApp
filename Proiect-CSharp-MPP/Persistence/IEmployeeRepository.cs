using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IEmployeeRepository : ICRUDRepository<int, Employee>
    {
        Employee FindByUsername(string username);
    }
}
