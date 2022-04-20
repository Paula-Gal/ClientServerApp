using System;

namespace Networking
{
    [Serializable]
    public class LoginRequest : Request
    {
        private EmployeeDto employeeDto;

        public LoginRequest(EmployeeDto employeeDto)
        {
            this.employeeDto = employeeDto;
        }

        public virtual EmployeeDto Employee
        {
            get { return employeeDto; }
        }
    }
}
