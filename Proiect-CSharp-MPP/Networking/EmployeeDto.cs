using System;

namespace Networking
{
    [Serializable]
    public class EmployeeDto
    {
        private string username;
        private string password;

        public EmployeeDto(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return username; }
        }

        public string Password
        {
            get { return password; }
        }

    }
}
