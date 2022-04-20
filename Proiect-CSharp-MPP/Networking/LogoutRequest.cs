using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    [Serializable]
    public class LogoutRequest : Request
    {
        private Employee employee;

        public LogoutRequest(Employee employee)
        {
            this.employee = employee;
        }

        public virtual Employee Employee
        {
            get { return employee; }
        }
    }
}
