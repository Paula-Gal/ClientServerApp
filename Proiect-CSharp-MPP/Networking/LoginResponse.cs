using Model.Domain;
using System;

namespace Networking
{
    [Serializable]
    public class LoginResponse : Response
    {
        private Employee employee;

        public LoginResponse(Employee employee)
        {
            this.employee = employee;
        }

        public virtual Employee Employee
        {
            get { return employee; }
        }
    }
}
